using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yekzen.Domain.Metadata;
using Yekzen.Core.Collections;

namespace Yekzen.Web.Bootstrap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult Data()
        {
            var webScope = new Scope() { Id = "web-scope", Type = "Scope", Name = "Web Scope" };

            var scopeLink = new Link { Id = "web-scope", Type = "Link", LinkType = "Scope" };

            // Create items.
            var itemSchema = new Schema() { Id = "form-item-type", Name = "Form Item Type", Description = "For creating form items.", Type = "Schema", Scope = scopeLink };

            itemSchema.Fields.Add(new Field() { Id="Title", Name="Title", Type="Text" });

            itemSchema.Fields.Add(new Field() { Id = "InputType", Name = "InputType", Type = "Text" });

            var schemaLink = new Link { Id = "form-item-type", Type = "Link", LinkType = "Schema" };

            var emailEntry = new Entry() { Id="Email",Type="Entry", ContentType = schemaLink, Scope = scopeLink  };
            emailEntry.Fields.Add("Title", "Email address");
            emailEntry.Fields.Add("InputType", "email");

            var passwordEntry = new Entry() { Id = "Password", Type = "Entry", ContentType = schemaLink, Scope = scopeLink };
            passwordEntry.Fields.Add("Title", "Password");
            passwordEntry.Fields.Add("InputType", "password");

            var submitEntry = new Entry() { Id = "Submit", Type = "Entry", ContentType = schemaLink, Scope = scopeLink };
            submitEntry.Fields.Add("Title", "Submit");
            submitEntry.Fields.Add("InputType", "submit");
            
            // Create Form
            var formSchema = new Schema() { Id = "form-type", Name = "Form Type", Description = "For creating forms.", Type = "Schema", Scope = scopeLink };
            
            formSchema.Fields.Add( new Field { Id = "form-items", Name = "Items", Items = itemSchema, Type = "Collection" } );

            var formEntry = new Entry { Id = "form-entry", Type = "Entry", ContentType = new Link { Id = "form-type", Type = "Link", LinkType = "Schema" }, Scope = scopeLink };

            var items = new Collection() { Id = "Items", Type = "Collection", ContentType = new Link { Id = "form-item-type", Type = "Link", LinkType = "Schema" }, Scope = scopeLink };
            items.Items.AddRange(new []{
                emailEntry,
                passwordEntry,
                submitEntry
            });
            formEntry.Fields.Add("Items", items);
            
            return Json(formEntry, JsonRequestBehavior.AllowGet);
        }
    }
}