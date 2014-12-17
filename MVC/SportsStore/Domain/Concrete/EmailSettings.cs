using System;

namespace Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "to@to.com";

        public string MailFromAddress = "test@test.com";

        public bool UseSsl = true;

        public string UserName = "MyUserName";

        public string Password = "MyPassword";

        public string ServerName = "smtp.com";

        public int ServerPort = 25;

        public bool WriteAsFile = false;

        public String FileLocation = @"C:\MyFiles\";
    }
}
