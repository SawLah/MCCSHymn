using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_MCCSHynm.Models;

namespace WebApp_MCCSHynm.Controllers
{
    [Authorize]
    public class HymnAdminController : Controller
    {
        private MCCFHymnEntities entity = new MCCFHymnEntities();
        // GET: HymnAdmin
        public ActionResult Index()
        {
            return View(entity.Hymns.ToList());
         }

        // GET: HymnAdmin/Details/5
        public ActionResult Details(int id)
        {
            var hymn = (from h in entity.Hymns
                        where h.Id == id
                        select h).FirstOrDefault();
            return View(hymn);
            }

        // GET: HymnAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HymnAdmin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
                {
                //   insert new record to db 
                int hymnNum = 0;
                var numstr = collection[2];
                bool parse = Int32.TryParse(numstr, out hymnNum);
                var hymn = new Hymn();
                hymn.Title = collection[1];
                hymn.HynmNumber = hymnNum;
                hymn.HynmVerse1 = collection[3];
                hymn.HymnChorus = collection[4];
                hymn.HynmClosing = collection[5];
                hymn.HynmVerse2 = collection[6];
                hymn.HymnVerse3 = collection[7];
                hymn.HymnVerse4 = collection[8];
                hymn.HymnVerse5 = collection[9];

                entity.Hymns.Add(hymn);
                entity.SaveChanges();


                return RedirectToAction("Index");
                }
            catch
                {
                return View();

                }
            }

        // GET: HymnAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            try
                {
                var hymn = (from h in entity.Hymns
                            where h.Id == id
                            select h).FirstOrDefault();

                return View(hymn);
                }
            catch
                {
                return View();
                }
            }

        // POST: HymnAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
                {
                var hymn = (from h in entity.Hymns
                            where h.Id == id
                            select h).FirstOrDefault();
                hymn.Title = collection[2];
                hymn.HynmNumber = Convert.ToInt32(collection[3]);
                hymn.HynmVerse1 = collection[4];
                hymn.HymnChorus = collection[5];
                hymn.HynmClosing = collection[6];
                hymn.HynmVerse2 = collection[7];
                hymn.HymnVerse3 = collection[8];
                hymn.HymnVerse4 = collection[9];
                hymn.HymnVerse5 = collection[10];


                entity.SaveChanges();

                return RedirectToAction("Index");
                }
            catch
                {
                return View();
                }
            }

        // GET: HymnAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            var hymn = (from h in entity.Hymns
                        where h.Id == id
                        select h).FirstOrDefault();

            return View(hymn);
            }

        // POST: HymnAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
                {
                var hymnList = entity.Hymns;
                // TODO: Add delete logic here

                var hymn = (from h in hymnList
                            where h.Id == id
                            select h).FirstOrDefault();

                hymnList.Remove(hymn);

                entity.SaveChanges();

                return RedirectToAction("Index");
                }
            catch
                {
                return View();
                }
            }
    }
}
