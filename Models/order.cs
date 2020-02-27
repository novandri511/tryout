namespace dotnet_ef_web_api_order.Models
{
    public class OrdersRequest
    {
        public int Id{get; set;}
        public string User_id{get; set;}
        public string Status{get; set;}
        public string Driver_id { get; set;}
        public string Created_at{get; set;}
        public string Updated_at{get; set;}
       

    }
    public class OrdersActions : OrdersRequest
    {
        public int Id{get; set;}
        public string User_id{get; set;}
        public string Status{get; set;}
        public string Driver_id { get; set;}
        public string Created_at{get; set;}
        public string Updated_at{get; set;}
       

    }
}