namespace API.Helpers
{
    public class Pagination<T> where T : class
    {

        public Pagination(int pageindex, int pageSize, int count, IReadOnlyList<T> data)
        {
            pageIndex = pageindex;
            PageSize = pageSize;
            Count = count;
            Data = data;

        }
        public int pageIndex { get; set; }

        public int PageSize { get; set; }

        public int Count { get; set; }

        public IReadOnlyList<T> Data { get; set; }


    }
}