using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalculateSalesPrice_MVC.Models;
using System.Data.Entity;


namespace CalculateSalesPrice_MVC.Controllers
{
    public class QuotationsController : Controller
    {
        private QuotationsDbContext context = new QuotationsDbContext();

        // GET: Quotations
        public ActionResult Index()
        {
            List<Quotation> quotations = context.Quotations.ToList();
            return View(quotations);
        }

        [HttpGet]
        public ActionResult CreateQuotation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateQuotation(Quotation quote) 
        { 
            if (ModelState.IsValid)
            {
                quote.CalculateDiscountAmount();
                quote.CalculateTotalPrice();

                quote.CreateAt = DateTime.Now;
                context.Quotations.Add(quote);
                context.SaveChanges();

                return View("Details", quote);
            }

            return View(quote);
        }
        [HttpGet]
        public ActionResult Edit(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Quotation quotation = context.Quotations.Find(id);

            if (quotation == null)
            {
                return HttpNotFound();
            }

            return View(quotation);
        }
        [HttpPost]
        public ActionResult Edit(Quotation quotation)
        {
            if(ModelState.IsValid)
            {
                context.Entry(quotation).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(quotation);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Quotation quotation = context.Quotations.Find(id);

            if (quotation == null)
            { 
                return HttpNotFound();
            }
            return View(quotation);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Quotation quotation = context.Quotations.Find(id);

            if (quotation == null)
            {
                return HttpNotFound();
            }

            context.Quotations.Remove(quotation);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}