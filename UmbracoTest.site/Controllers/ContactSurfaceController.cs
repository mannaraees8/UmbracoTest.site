using Umbraco;
using System.Web;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Cms.Core.Web;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.BackOffice.ActionResults;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using UmbracoTest.site.umbraco.models;
using System.Net.Mail;

namespace UmbracoTest.site.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        public ContactSurfaceController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
        }

        public ActionResult SubmitForm(ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                SendEmail(contactModel);
                TempData["isEmailSent"] = true;
            }
            return Redirect("/");
        }

        private void SendEmail(ContactModel contactModel)
        {
            MailMessage message = new MailMessage(contactModel.Email, "mannaraees8@gmail.com");
            message.Subject = $"Enquiry from {contactModel.FullName}";
            message.Body = $"<p>Full Name : {contactModel.FullName}<p><p>Email : {contactModel.Email}<p><p>Phone : {contactModel.Phone}<p><p>Message : {contactModel.Message}<p>";
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("127.0.0.1",25);
            client.Send(message);
        }
    }
}
