namespace Core.Specifications
{
    public class ProductSpecParams
    {
        public const int MaxPageSize = 50;

        public int pageIndex {get;set;} = 1;

        private int _pagesize = 6;

        public int PageSize {
            get => _pagesize;
            set => _pagesize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? BrandId { get; set; }

        public int? TypeId { get; set; }

        public string Sort { get; set; }

        private string _search;


        public string Search { 

            get  => _search;
            
            set => _search = value.ToLower();
             }

        
    }
}