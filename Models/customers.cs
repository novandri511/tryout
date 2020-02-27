namespace dotnet_ef_web_api_customers.Models
{
    public class CustomersRequest
    {
        public int Id{get; set;}
        public string Full_name{get; set;}
        public string Username{get; set;}
        public string Email { get; set;}
        public string Phone_number{get; set;}
        public string Created_at{get; set;}
        public string Updated_at{get; set;}

    }

    public class CustomersActions : CustomersRequest
    {
        public int Id{get; set;}
        public string Full_name{get; set;}
        public string Username{get; set;}
        public string Email { get; set;}
        public string Phone_number{get; set;}
        public string Created_at{get; set;}
        public string Updated_at{get; set;}

    }



}