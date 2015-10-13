using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yekzen.Core.Collections;
using Yekzen.Domain.Metadata;

namespace Yekzen.Web.Bootstrap.Controllers
{
    public class ScopeController : Controller
    {
        // GET: Scope
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Data()
        {
            var webScope = new Scope() { Id = "web-scope", Type = "Scope", Name = "Web Scope" };

            var scopeLink = new Link { Id = "web-scope", Type = "Link", LinkType = "Scope" };

            // Create items.
            var itemSchema = new Schema() { Id = "form-item-type", Name = "Form Item Type", Description = "For creating form items.", Type = "Schema", Scope = scopeLink };

            itemSchema.Fields.Add(new Field() { Id = "Title", Name = "Title", Type = "Text" });

            itemSchema.Fields.Add(new Field() { Id = "InputType", Name = "InputType", Type = "Text" });

            var schemaLink = new Link { Id = "form-item-type", Type = "Link", LinkType = "Schema" };

            var nameEntry = new Entry() { Id = "Name", Type = "Entry", ContentType = schemaLink, Scope = scopeLink };
            nameEntry.Fields.Add("Title", "Name");
            nameEntry.Fields.Add("InputType", "name");

            var submitEntry = new Entry() { Id = "Submit", Type = "Entry", ContentType = schemaLink, Scope = scopeLink };
            submitEntry.Fields.Add("Title", "Submit");
            submitEntry.Fields.Add("InputType", "submit");

            // Create Form
            var formSchema = new Schema() { Id = "form-type", Name = "Form Type", Description = "For creating forms.", Type = "Schema", Scope = scopeLink };

            formSchema.Fields.Add(new Field { Id = "form-items", Name = "Items", Items = itemSchema, Type = "Collection" });

            var formEntry = new Entry { Id = "form-entry", Type = "Entry", ContentType = new Link { Id = "form-type", Type = "Link", LinkType = "Schema" }, Scope = scopeLink };

            var items = new Collection() { Id = "Items", Type = "Collection", ContentType = new Link { Id = "form-item-type", Type = "Link", LinkType = "Schema" }, Scope = scopeLink };
            items.Items.AddRange(new[]{
                nameEntry, 
                submitEntry
            });
            formEntry.Fields.Add("Items", items);

            return Json(formEntry, JsonRequestBehavior.AllowGet);
        }
    }
}