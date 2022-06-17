using System.ComponentModel.DataAnnotations;

namespace Bartel_Jaapje_en_Aapje_PROECT.Database
{
    public class Person
    {
        [Required(ErrorMessage = "Vul dan die kaolo Voornaam in chappie")]
        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        [Required(ErrorMessage = "Vul dan die kaolo Email in chappie")]
        public string Email { get; set; }

        public string Telefoonnummer { get; set; }

        public string Adres { get; set; }

        public string Beschrijving { get; set; }
    }
}
