using System.ComponentModel.DataAnnotations;

namespace MVCCoreProject.Models.Entities
{
    public class UserAddres
    {
      
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string AcikAdres { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
    }
}
