﻿using PJ_Socks_App.main.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Repositories
{
    public class ProductRepository
    {
        private readonly SockSalesDataContext context;

        public ProductRepository()
        {
            context = SockSalesDataContext.GetInstance();
        }

    }
}
