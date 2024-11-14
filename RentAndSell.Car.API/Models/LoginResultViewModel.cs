namespace RentAndSell.Car.API.Models
{
    public class LoginResultViewModel
    {
        public string BasicAuth { get; set; }
        public bool IsLogin { get; set; }
        public string ErrorMessage { get; set; }
    }
}
