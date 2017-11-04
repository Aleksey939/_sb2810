using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows;
using SeaBattle.Data.Context;

namespace SeaBattle.Service.Service
{
   public  class EmeilService
    {
            
        public EmeilService(string froms, string to, string subject, string body)
        {
            
                MailMessage mail = new MailMessage(froms, to, subject, body);
                SmtpClient client = new SmtpClient("mail.adm.tools");
                client.Port = 25;
                #region  не будет отправлять,нужен пароль
                client.Credentials = new System.Net.NetworkCredential("a.ivanov@rovas.ua", "An0441nb");
                #endregion
                client.EnableSsl = true;
            try
            {
                client.Send(mail);
            }
            catch
            { MessageBox.Show("Ошибка при отправке письма! "); }
            

        }

 
    }
}
