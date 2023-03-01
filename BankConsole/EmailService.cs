using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace BankConsole
{
    public static class EmailService
    {
        public static void SenMail()
        {
            var message =new MimeMessage();
            message.From.Add(new MailboxAddress ("Daniel Arana", "ing.daniel.arana@gmail.com"));
            message.To.Add(new MailboxAddress("Admin","ing.daniel.arana@gmail.com"));
            message.Subject = "BankConsole: Usuarios nuevos";

            message.Body = new TextPart("plain")
            {
                Text = GetEmailText()
            };

            using (var client = new SmtpClient()){
                client.Connect("smtp.gmail.com",587,false);
                client.Authenticate("ing.daniel.arana@gmail.com", "dsuiceqcdvpxlzvi"); //https://support.google.com/accounts/answer/3466521?hl=es
                client.Send(message);
                client.Disconnect(true);
            }
        }

        private static string GetEmailText()
        {
            List<User> newUsers = Storage.GetNewUsers();

            if(newUsers.Count == 0 )
                return "No hay usuario nuevos.";

            string emailText = "Usuarios agregados hoy:\n";

            foreach(User user in newUsers)
                emailText += "\t +" + user.ShowData() + "\n";

            return emailText;


        }
    }
}