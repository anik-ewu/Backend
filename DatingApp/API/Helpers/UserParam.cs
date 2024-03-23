namespace API.Helpers
{
    public class UserParam
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int Pagesize
        {
            get => _pageSize;
            set => _pageSize = (value  > MaxPageSize) ? MaxPageSize : value;
        }

    }
}