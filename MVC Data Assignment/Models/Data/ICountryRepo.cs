﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Data
{
    public interface ICountryRepo
    {
        Country Create(string name);
        Country Read(int id);
        List<Country> Read();
        Country Update(Country country);
        bool Delete(Country country);
    }
}