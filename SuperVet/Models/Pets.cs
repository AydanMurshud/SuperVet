using System.ComponentModel.DataAnnotations;

namespace SuperVet.Models
{
    public class Pets
    {
        [Key] public int Id { get; set; }
        public string Type { get; set; }

        public string Species { get; set; }

        public string Breed { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
 

    }
}
