using System.ComponentModel.DataAnnotations;

namespace MVCCoreProject.Models.Entities
{
    public class Shippers
    {
        public int ShippersId { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
    }
}
