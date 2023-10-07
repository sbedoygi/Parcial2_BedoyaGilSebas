using Parcial2_PersonaNature.DAL.Entities;

namespace Parcial2_PersonaNature.Models
{
    public class EditViewModel
    {
        public List<NaturalPerson> NaturalPersons { get; set; }
        public Guid Id { get; set; }
        public DateTime? createDate { get; set; }

        public string Age { get; set; }
    }
}
