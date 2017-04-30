using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoComplete1.Models;

namespace AutoComplete1.Controllers
{
    public class WordController : Controller
    {
        [HttpGet]
        public ActionResult Search()
        {
            string[] s = Name.GetWords().ToArray();

            Search a = new Search(s);
            return View();
        }

    }
}
