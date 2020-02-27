namespace dotnet_ef_web_api_order.Models
{
    public class OrdersActions : OrdersApicontroller
    {
        public int Id{get; set;}
        public string user_id{get; set;}
        public string status{get; set;}
        public string driver_id { get; set;}
        public string created_at{get; set;}
        public string updated_at{get; set;}
       

    }

}