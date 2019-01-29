using System.ComponentModel.DataAnnotations;

namespace EstateAgency.Models
{
    public class Person : Client
    {
        [StringLength(50, ErrorMessage = "Имя не должно превышать 50 символов.")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Фамилия не должна превышать 50 символов.")]
        public string Surname { get; set; }

        public override string FullName { get => base.FullName = FirstName + " " + Surname; /*set => base.FullName = value;*/ }
    }
}
