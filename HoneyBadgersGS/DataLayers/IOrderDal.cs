﻿using System.Collections.Generic;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.DataLayers
{
    public interface IOrderDal
    {
        IEnumerable<Order> GetAll();
        int Add(Order order);
        int Update(Order order);
        Order GetData(int id);
        int Delete(int id);
    }
}