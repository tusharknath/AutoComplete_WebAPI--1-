using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoComplete1.Models
{
    public class Name
    {
        public static List<string> GetWords()
        {
            //string path = HttpContext.Current.Server.MapPath("~/App_Data/words.txt");
            //List<string> objList = File.ReadAllLines(path).ToList();
            //return objList;

            if (HttpContext.Current.Application["lstWords"] != null)
            {
                List<string> wordObj = (List<string>)HttpContext.Current.Application["lstWords"];

                return wordObj;
            }
            else
            {
                return null;
            }
        }
    }
}