namespace dotnet_ef_web_api_drivers.Models
{
    public class DriversRequest
    {
        public int Id{get; set;}
        public string Full_name{get; set;}
        public string Phone_number{get; set;}
        public string Created_at{get; set;}
        public string Updated_at{get; set;}
       

    }
    public class DriversActions : DriversRequest
    {
        public int Id{get; set;}
        public string Full_name{get; set;}
        public string Phone_number{get; set;}
        public string Created_at{get; set;}
        public string Updated_at{get; set;}

    }
}