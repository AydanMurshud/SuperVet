using SuperVet.Models;

namespace SuperVet.ViewModels
{
    public class SpeciesViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }
        public List<Breeds>? Breeds { get; set; }
        public int PetsId { get; set; }
        public List<Pets>? Pets { get; set; }
    }
}
