using OnePointGlobal.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace OnePointGlobal.API.Controller
{
    public class ServiceController : ApiController
    {
        #region ----------------- Contact Us ------------------

        [HttpPost]
        public IHttpActionResult ContactEmail(string Name, string InquiryMail, string message)
        {
            try
            {
                //string body = "Hello admin. \n";
                //body += "We have contact enquiry from " + Name + ".<br /><br />";
                //body += "<b>Name : </b>" + Name + ".<br /><br />";
                //body += "<b>Email : </b>" + InquiryMail + ".<br /><br />";
                //body += "<b>Message : </b>" + message + ".<br /><br />";
                //body += "Visited from: MCXToolkit.onepointglobal.com";
                //body += "Thank You.<br /><br />";

                //string SenderBody = "Hello " + Name + ". \n";
                //body += "Thank you for your interest in the OnePoint Global Mobile CX Toolkit for Telcos.<br /><br />";
                //body += "<b>Thank You.</b><br /><br />";
                //body += "<b>OnePoint Global Mobile CX Toolkit</b><br /><br />";


                //MailManager mm = new MailManager();
                //string ToMail = ConfigurationManager.AppSettings["AdminMailId"];
                //mm.SendMail(ToMail, MailSubject.Inquiry + " from (" + InquiryMail + " )", body);

                //mm.SendMail(InquiryMail, MailSubject.Inquiry + " from (" + ToMail + " )", SenderBody);
                SmtpClient client = new SmtpClient();
                client.Host = "10.10.1.52";
                client.Port = 25;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                //client.Credentials = new System.Net.NetworkCredential("username", "password");
                client.EnableSsl = true;
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(InquiryMail);
                mailMessage.To.Add("toolkits@onepointglobal.com");
                mailMessage.Subject = "Contact enquiry";
                mailMessage.IsBodyHtml = true;
                string body = "Hello admin. \n";
                body += "We have contact enquiry from " + Name + ".<br /><br />";
                body += "<b>Name : </b>" + Name + ".<br /><br />";
                body += "<b>Email : </b>" + InquiryMail + ".<br /><br />";
                body += "<b>Message : </b>" + message + ".<br /><br />";
                body += "Visited from: MCXToolkit.onepointglobal.com";
                body += "Thank You.<br /><br />";
                mailMessage.Body = body;
                client.Send(mailMessage);

                //ToClient
                SmtpClient client1 = new SmtpClient();
                client1.Host = "10.10.1.52";  //hostName 10.10.1.52
                client1.Port = 25;                // smtp host 25
                client1.UseDefaultCredentials = false;
                client1.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                //client1.Credentials = new System.Net.NetworkCredential("username", "password");
                client1.EnableSsl = true;
                MailMessage mailMessage1 = new MailMessage();
                //mailMessage1.From = new MailAddress("noreply@onepointglobal.com");
                mailMessage1.From = new MailAddress("toolkits@onepointglobal.com");
                mailMessage1.To.Add(InquiryMail);
                mailMessage1.Subject = "Contact Enquiry";
                mailMessage1.IsBodyHtml = true;
                string SenderBody = "Hello " + Name + ". \n";
                SenderBody += "Thank you for your interest in the OnePoint Global Mobile CX Toolkit for Telcos.<br /><br />";
                SenderBody += "<b>Thank You.</b><br /><br />";
                SenderBody += "<b>OnePoint Global Mobile CX Toolkit</b><br /><br />";
                mailMessage1.Body = SenderBody;
                client1.Send(mailMessage1);

                return Success(Messages.SUCCESS);
            }
            catch (Exception ex)
            {
                return Error(ex.Message.ToString());
            }
        }

        #endregion

        #region ----------------- Signup Form ------------------

        [HttpPost]
        public IHttpActionResult SignupEmail(string Name, string InquiryMail, string Mobile, string Company)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = "10.10.1.52";
                client.Port = 25;
                client.UseDefaultCredentials = false;
                //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                //client.Credentials = new System.Net.NetworkCredential("username", "password");
                client.EnableSsl = true;
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(InquiryMail);
                mailMessage.To.Add("toolkits@onepointglobal.com");
                mailMessage.Subject = "Sign-up details";
                mailMessage.IsBodyHtml = true;
                string body = "Hello admin. \n";
                body += "We have Sign-up details.<br /><br />";
                body += "<b>Name : </b>" + Name + ".<br /><br />";
                body += "<b>Email : </b>" + InquiryMail + ".<br /><br />";
                body += "<b>Mobile : </b>" + Mobile + ".<br /><br />";
                body += "<b>Company : </b>" + Company + ".<br /><br />";
                body += "Visited from: MCXToolkit.onepointglobal.com";

                mailMessage.Body = body;
                client.Send(mailMessage);

                //ToClient
                SmtpClient client1 = new SmtpClient();
                client1.Host = "10.10.1.52";  //hostName 10.10.1.52
                client1.Port = 25;                // smtp host 25
                client1.UseDefaultCredentials = false;
                client1.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                //client1.Credentials = new System.Net.NetworkCredential("username", "password");
                client1.EnableSsl = true;
                MailMessage mailMessage1 = new MailMessage();
                //mailMessage1.From = new MailAddress("noreply@onepointglobal.com");
                mailMessage1.From = new MailAddress("toolkits@onepointglobal.com");
                mailMessage1.To.Add(InquiryMail);
                mailMessage1.Subject = "Sign-up details";
                mailMessage1.IsBodyHtml = true;

                string SenderBody = "Hello " + Name + ". \n";
                SenderBody += "Thank you for your interest in the OnePoint Global Mobile CX Toolkit for Telcos.<br /><br />";
                SenderBody += "<b>Thank You.</b><br /><br />";
                SenderBody += "<b>OnePoint Global Mobile CX Toolkit</b><br /><br />";
                mailMessage1.Body = SenderBody;
                client1.Send(mailMessage1);

                return Success(Messages.SUCCESS);
            }
            catch (Exception ex)
            {
                return Error(ex.Message.ToString());
            }
        }

        #endregion


        #region ------------------ Reply Format ----------------------

        public IHttpActionResult Success(string txt, dynamic data = null)
        {
            return PrepareReply(false, txt, data);
        }

        public IHttpActionResult Error(string txt)
        {
            return PrepareReply(true, txt);
        }

        public IHttpActionResult PrepareReply(bool isError, string txt, dynamic data = null)
        {
            var reply = new Reply
            {
                status = isError ? Messages.FAIL : Messages.SUCCESS,
                msg = isError ? "" : txt,
                error = isError ? txt : null,
                data = data,
            };
            return Ok(reply);
        }

        public class Reply
        {
            public string status { get; set; }
            public string msg { get; set; }
            public string error { get; set; }
            public dynamic data { get; set; }
        }

        #endregion

    }
}
