using System.ComponentModel.DataAnnotations;

namespace BusCompany.Models
{
    public class Hult
    {
        private int id;
        private string hultName;
        private int routNumber;

        public int Id { get { return id; } set { id = value; } }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        [RegularExpression(@"^[A-ЯЁ][а-яё]+\s*([A-ЯЁ]*[а-яё]+\s*)*",
            ErrorMessage = "Название остановки должно начинатся с заглавной буквы")]
        public string HultName { get { return hultName; } set { hultName = value; } }
        public int RoutNumber { get => routNumber; set => routNumber = value; }
    }
}