﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;

namespace ModernStore.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public readonly ModernStoreDataContext _context;

        public OrderRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public void Save(Order order)
        {
            _context.Orders.Add(order);
        }
    }
}
