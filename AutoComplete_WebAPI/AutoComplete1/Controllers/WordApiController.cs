using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoComplete1.Models;

namespace AutoComplete1.Controllers
{
    public class WordApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> GetWords(string query = "")
        {
            return Search.GetWordsForPrefix(query);
        }
    }
}
