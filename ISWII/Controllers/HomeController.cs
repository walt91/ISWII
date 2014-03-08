using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISWII.Models;

namespace ISWII.Controllers
{
    public class HomeController : Controller
    {
        private WebDb db = new WebDb();
        //
        // GET: /Home/

        public ActionResult Home()
        {
            return View();
        }


        public ActionResult Recomend()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Recomend(string name = "", string telephone = "", string email = "", string commentary = "")
        {
            
            Recomend newRecomend = new Recomend();
            newRecomend.name = name;
            newRecomend.telephone = telephone;
            newRecomend.email = email;
            newRecomend.commentary = commentary;
            if (ModelState.IsValid)
            {
                db.Recomendations.Add(newRecomend);
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string name = "", string email = "", string commentary = "")
        {
            //Data from the message and the email to which you are going to send the message
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            mmsg.To.Add("walt.mendezs@gmail.com");

            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            mmsg.Body = "Send by: " + name + "\n" + "E-mail: " + email + "\n" + "Commentary: " + commentary;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; 

            mmsg.From = new System.Net.Mail.MailAddress(email);
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials = new System.Net.NetworkCredential("walt.mendezs@gmail.com", "piadmin12");
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";
           
            try
            {
                cliente.Send(mmsg);//Send the message 
            }
            catch (System.Net.Mail.SmtpException ex)
            {

                // Here all the errors to the not being able to send the mail
            }
            return View();
        }

        public ActionResult Recommendations()
        {
            List<Recomend> recommendations = db.Recomendations.ToList();
            ViewBag.recommendations = recommendations;
            return View();
        }

    }
}