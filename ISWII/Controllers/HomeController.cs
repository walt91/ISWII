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
        public ActionResult Recomend(string nombre = "", string telefono = "", string correoelectronico = "", string comentario = "")
        {
            
            Recomend nueva = new Recomend();
            nueva.nombre = nombre;
            nueva.telefono = telefono;
            nueva.correo = correoelectronico;
            nueva.comentario = comentario;
            if (ModelState.IsValid)
            {
                db.Recomendations.Add(nueva);
                db.SaveChanges();

            }
            return View();
        }

        

        public ActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Contact(string name = "", string email = "", string topic = "", string commentary = "")
        {

            //datos del mensaje y el correo al que le vamos a enviar el mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            mmsg.To.Add("walt.mendezs@gmail.com");
            mmsg.Subject = topic;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            mmsg.Body = "Send by: " + name + "\n" + "E-mail: " + email + "\n" + "Commentary: " + commentary;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; 

            mmsg.From = new System.Net.Mail.MailAddress(email);
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials =
                new System.Net.NetworkCredential("walt.mendez@gmail.com", "huntertoto69");
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";
           

            try
            {

                cliente.Send(mmsg);//Enviamos el mensaje  
            }
            catch (System.Net.Mail.SmtpException ex)
            {

                // aqui todos los erros al no poder enviar el correo
            }
            return View();
        }

        public ActionResult Recomendations()
        {
            return View();
        }

    }
}