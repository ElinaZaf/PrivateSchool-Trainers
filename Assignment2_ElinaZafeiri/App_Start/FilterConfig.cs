﻿using System.Web;
using System.Web.Mvc;

namespace Assignment2_ElinaZafeiri
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
