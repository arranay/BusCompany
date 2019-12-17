namespace BusCompany.Models
{
    public class Conductor : Employees
    {
        private bool onRoute;
        public bool OnRoute { get => onRoute; set => onRoute = value; }
    }
}