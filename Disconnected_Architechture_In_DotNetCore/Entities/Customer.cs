using System.ComponentModel.DataAnnotations;

namespace Disconnected_Architechture_In_DotNetCore.Entities
{
    public class Customer
    {
        [Key]
        public int id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
