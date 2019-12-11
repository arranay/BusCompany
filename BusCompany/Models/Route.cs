using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusCompany.Models
{
    public class Route
    {
        private int id;
        private string routeName;
        private int numberOfHult;
        private bool approvedStatus;
        private int hultId;

        List<Hult> hultOnRoute;

        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "Данное поле является обязательным")]
        public string RouteName { get => routeName; set => routeName = value; }

        public int NumberOfHult { get => numberOfHult; set => numberOfHult = value; }
        public bool ApprovedStatus { get => approvedStatus; set => approvedStatus = value; }
        public List<Hult> HultOnRoute { get => hultOnRoute; set => hultOnRoute = value; }
        public int HultId { get => hultId; set => hultId = value; }
    }
}