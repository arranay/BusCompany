
using System.ComponentModel.DataAnnotations;

namespace BusCompany.Models
{
    public class Bus
    {
        private string numberPlate;
        private string mark;
        private bool technicalStatus;
        private int speed;
        private int fuelConsumption;
        private int mileage;
        private bool status;

        [Required(ErrorMessage = "Данное поле является обязательным")]
        [RegularExpression(@"^[а-яё]{1}[0-9]{3}[а-яё]{2}$",
            ErrorMessage = "Номерной знак должен соответствовать шаблону: БЦЦЦББ (Где Б - любая буква русского алфавита, Ц-любая цифра)")]
        public string NumberPlate { get => numberPlate; set => numberPlate = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        [StringLength(maximumLength:30, ErrorMessage = "Длина строки должна составлять не более 20 символов")]
        public string Mark { get => mark; set => mark = value; }

        public bool TechnicalStatus { get => technicalStatus; set => technicalStatus = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        [Range(1, 200, ErrorMessage = "Проверьте введённые данные")]
        public int Speed { get => speed; set => speed = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        [Range(1, 200, ErrorMessage = "Проверьте введённые данные")]
        public int FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        [Range(1, 1000, ErrorMessage = "Проверьте введённые данные")]
        public int Mileage { get => mileage; set => mileage = value; }

        public bool Status { get => status; set => status = value; }
    }
}