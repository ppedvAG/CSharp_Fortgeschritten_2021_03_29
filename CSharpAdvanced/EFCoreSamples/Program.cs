using EFCoreSamples.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using EFCoreSamples.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreSamples
{
    class Program
    {
        static void Main(string[] args)
        {
           try
            {
                using (MyDbContext ctx = new MyDbContext())
                {
                    Order order = new Order();
                    order.CustomerID = 123;
                    order.EmployeeID = 456;
                    order.OrderDate = DateTime.Now;

                    Order order1 = new Order();
                    order1.CustomerID = 123;
                    order1.EmployeeID = 456;
                    order1.OrderDate = DateTime.Now;

                    // ctx.Orders Repository Pattern
                    ctx.Orders.Add(order); // Insert in Order-Tabelle in OrderDB
                    ctx.Orders.Add(order1); // Insert in Order-Tabelle in OrderDB

                    ctx.SaveChanges(); // UnitOfWork Pattern

                    foreach (Order currentOrder in ctx.Orders)
                    {
                        Console.WriteLine($"{currentOrder.CustomerID} - { currentOrder.EmployeeID} - {currentOrder.OrderDate.ToString()}");
                    }

                    IList<Order> mySelectedOrders = ctx.Orders.Where(n => n.OrderDate == DateTime.Now).ToList();
                    Order myOrder = ctx.Orders.Single(s => s.Id == 1);

                    foreach (Order currentOrder in mySelectedOrders)
                        Console.WriteLine($"{currentOrder.CustomerID} - { currentOrder.EmployeeID} - {currentOrder.OrderDate.ToString()}");
                }
            }
            catch (Exception ex)
            {

            }

           

            Console.ReadKey();
        }
    }
}
