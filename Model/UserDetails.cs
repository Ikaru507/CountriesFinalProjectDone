namespace Model
{
    public class UserDetails:BaseEntity
    {
        private string userName;
        private string email;
        private string password;
        private DateTime lastLogin;

        public string UserName { get => userName; set => userName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public DateTime LastLogin { get => lastLogin; set => lastLogin = value; }



    }
}
