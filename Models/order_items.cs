namespace dotnet_ef_web_api_Order_items.Models
{
    public class Order_itemsRequest
    {
        public int Order_id{get; set;}
        public string Product_id{get; set;}
        public string Quantity{get; set;}
      
       

    }
        public class Order_itemsActions : Order_itemsRequest
            {
                public int Order_id{get; set;}
                public string Product_id{get; set;}
                public string Quantity{get; set;}
                
            

            }
}