using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperVet.Models
{
    public class Pets
    {
        [Key]
        public int Id { get; set; }

        public string AnimalType { get; set; }
        [ForeignKey("SpeciesId")]

        public int SpeciesId { get; set; }
        public List<Species> Species { get; set; }
    }
}
