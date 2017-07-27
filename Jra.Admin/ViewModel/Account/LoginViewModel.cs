namespace Jra.Admin.ViewModel.Account
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Captcha { get; set; }
        public bool RememberMe { get; set; }
    }
}