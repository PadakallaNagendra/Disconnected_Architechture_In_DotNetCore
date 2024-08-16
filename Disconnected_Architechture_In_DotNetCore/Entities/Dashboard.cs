using System.ComponentModel.DataAnnotations;

namespace Disconnected_Architechture_In_DotNetCore.Entities
{
    public class Dashboard
    {
      
        public int position { get; set; }
        public string name { get; set; }
        public decimal weight { get; set; }
        public string symbol { get; set; }
        public  string location { get; set; }
    }
}
