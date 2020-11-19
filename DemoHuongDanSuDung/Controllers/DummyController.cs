using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DemoHuongDanSuDung.Models;
using Microsoft.Ajax.Utilities;

namespace DemoHuongDanSuDung.Controllers
{
    public class DummyController : Controller
    {
        private List<Dummy> _dm2;

        private void InitDm()
        {
            _dm2 = new List<Dummy>
            {
                new Dummy {Id = 1, Name = "First Dummy", DummyDate = DateTime.Now},
                new Dummy {Id = 2, Name = "First Dummy2", DummyDate = DateTime.Now},
                new Dummy {Id = 3, Name = "First Dummy3", DummyDate = DateTime.Now},
                new Dummy {Id = 4, Name = "First Dummy4", DummyDate = DateTime.Now}
            };
        }

        public ActionResult Index(int? id, string newName)
        {
            InitDm();
            if (!newName.IsNullOrWhiteSpace() && id.HasValue)
            {
                Dummy first = null;
                foreach (var dm in _dm2)
                {
                    if (dm.Id == id)
                    {
                        first = dm;
                        break;
                    }
                }

                first.Name = newName;
            }
            return View(_dm2);
        }
        
        // GET
        public ActionResult DummyIndex(int? id)
        {
            InitDm();
            if (!id.HasValue)
            {
                return View(_dm2.ElementAt(0));
            }
            return View(_dm2.FirstOrDefault(dm => dm.Id == id));
        }
        [HttpGet]
        public ActionResult Test()
        {
            return Redirect("~/home/index/100");
        }

        [HttpPost]
        public ActionResult Test(int id)
        {
            return Redirect("~/home/index/100");
        }

        public ActionResult Edit(int id)
        {
            InitDm();
            
            return View(_dm2.FirstOrDefault(dm => dm.Id == id));
        }
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "DummyDate")]Dummy dm)
        {
  it           InitDm();
            _dm2.RemoveAll(dm1 => dm1.Id == dm.Id);
            _dm2.Add(dm);
            return RedirectToAction("Index", new {id = dm.Id, newName = dm.Name});
        }

    }
}