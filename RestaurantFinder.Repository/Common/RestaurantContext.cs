﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.Repository
{
    public class RestaurantContext:DbContext
    {
        public RestaurantContext(): base("RestaurantConnectionString")
        {

        }
    }
}