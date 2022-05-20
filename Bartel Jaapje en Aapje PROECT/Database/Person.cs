using System.ComponentModel.DataAnnotations;

namespace Bartel_Jaapje_en_Aapje_PROECT.Database
{
    public class Person
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }
    }
}
