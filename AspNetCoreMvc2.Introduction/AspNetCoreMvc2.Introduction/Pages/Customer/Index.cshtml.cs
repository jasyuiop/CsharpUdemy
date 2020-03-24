using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreMvc2.Introduction
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet()  // sayfaya url üzerinden istekte bulunduğumuzda get default olarak çalışır (GET) 
        {
            Message += "Date is " + DateTime.Now.ToString();
        }
    }
}