using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MessageRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            
        }
        public void AddMessage(Message message)
        {
            _context.Messages.Add(message);
        }

        public void DeleteMessage(Message message)
        {
            _context.Messages.Remove(message);
        }

        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams)
        {
            var query = _context.Messages.
            OrderByDescending(x => x.MessageSend)
            .AsQueryable();

            query = messageParams.Container switch 
            {
                "Inbox" => query.Where(u => u.RecipientUsername == messageParams.Username),
                "Outbox" => query.Where(u => u.SenderUsername == messageParams.Username),
                _=> query.Where(u => u.RecipientUsername == messageParams.Username && u.DateRead == null)
            };

            var message = query.ProjectTo<MessageDto>(_mapper.ConfigurationProvider);

            var res =  await PagedList<MessageDto>.CreateAsync(message, messageParams.PageNumber, messageParams.Pagesize);
            return res;    
        }

        public async Task<IEnumerable<MessageDto>> GetMessagesThread(string currentUserName, string recipientUserName)
        {
            var messages = await _context.Messages
                .Include(u => u.Sender).ThenInclude(p => p.Photos)
                .Include(u => u.Recipient).ThenInclude(p => p.Photos)
                .Where(
                    m => m.RecipientUsername == currentUserName && 
                    m.SenderUsername == recipientUserName ||
                    m.RecipientUsername == recipientUserName &&
                    m.SenderUsername == currentUserName
                )
                .OrderBy(m => m.MessageSend)
                .ToListAsync();
            
            var unreadMessages = messages.Where(m => m.DateRead == null 
                && m.RecipientUsername == currentUserName).ToList();
            
            if (unreadMessages.Any())
            {
                foreach(var message in unreadMessages)
                {
                    message.DateRead  = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();
            }

            return _mapper.Map<IEnumerable<MessageDto>>(messages);

        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}