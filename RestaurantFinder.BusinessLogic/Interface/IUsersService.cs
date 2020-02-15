﻿using RestaurantFinder.BusinessLogic.Common;
using RestaurantFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFinder.BusinessLogic.Interface
{
   public interface IUsersService : IGenericService<User>
    {
        bool Checklogin(string name, string pass);
        int userid(string name);
         int Insert(User entity);
    }

}
