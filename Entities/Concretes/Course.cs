
using _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Core.Entities;

namespace _2024_NET_Kamp_2Gun_Odev3_KodlamaIOAnaSayfa.Entities.Concretes
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int InstructorId { get; set; }
        public int CategoryId { get; set; }
    }
}
