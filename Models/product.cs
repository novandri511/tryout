namespace dotnet_ef_web_api_product.Models
{
    public class ProductRequest
    {
        public int Id{get; set;}
        public string Names{get; set;}
        public string Price{get; set;}
        public string Created_at{get; set;}
        public string Updated_at{get; set;}
       

    }
        public class ProductActions : ProductRequest
            {
                public int Id{get; set;}
                public string Names{get; set;}
                public string Price{get; set;}
                public string Created_at{get; set;}
                public string Updated_at{get; set;}
            

            }
}