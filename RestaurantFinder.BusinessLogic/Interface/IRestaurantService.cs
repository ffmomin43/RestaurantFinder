﻿using RestaurantFinder.BusinessLogic.Common;
using RestaurantFinder.Models;
using RestaurantFinder.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.BusinessLogic.Interface
{
    public interface IRestaurantService : IGenericService<Restaurant>
    {
        bool IsExist(string name);
    }
}
