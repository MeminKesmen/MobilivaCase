using Microsoft.Extensions.Options;
using MobilivaCase.Application.DTOs.RabbitMq;
using MobilivaCase.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Infrastructure.Services
{
    public class MailService : IMailService
    {
        
        public MailService()
        {
            
        }

        public bool SendOrderInfo(OrderMailDto orderMailDto)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(Configuration.MailConfig.MailAdresi);
            message.To.Add(new MailAddress(orderMailDto.CustomerEmail));
            message.Subject = $"Sipariş :: Sipariş";
            message.Body = "<h1>Sipariş bilgileri...</h1><hr/><br/>";
            orderMailDto.OrderDetails.ForEach(od =>
            {
                message.Body += $"<h3>Ürün : {od.Description} </h3><br/>";
            });

            message.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = Configuration.MailConfig.MailSunucuAdresi;
            smtp.Port = Convert.ToInt32(Configuration.MailConfig.MailSunucuPortu);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(Configuration.MailConfig.MailAdresi, Configuration.MailConfig.MailSifresi);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(message);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

      
    }
}
