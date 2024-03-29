﻿using AspNetCoreMvc2.Introduction.Entities;
using System.Collections.Generic;

namespace AspNetCoreMvc2.Introduction
{
    /*
        Modelin bir diğer kullanım şekli form işlemlerinde kullanılabilir.
     */
    public class EmployeeListViewModel
    {
        public List<Employee> Employees { get; set; }
        public List<string> Cities { get; set; }
    }
}