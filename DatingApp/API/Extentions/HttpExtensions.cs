using System.Text.Json;
using API.Helpers;

namespace API.Extentions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, PaginationHeader header)
        {
            var jsonOptinos = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
            response.Headers.Add("Pagination", JsonSerializer.Serialize(header, jsonOptinos));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
            
        }
        
    }
}