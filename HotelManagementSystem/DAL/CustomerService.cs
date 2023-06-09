﻿using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerService
    {
        private HotelManagementContext db = new HotelManagementContext();

        public IEnumerable<Customer> GetCustomer()
        {
            IEnumerable<Customer> clist;
            try
            {
                clist = db.Customers.ToList();
                return clist;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Customer GetCustomerById(int Id)
        {
            Customer? cust;
            try
            {
                cust = db.Customers.Find(Id);
                if (cust != null)
                {
                    return cust;
                }
                else
                {
                    throw new Exception("Record not found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Customer UpdateCustomer(Customer CustomerRec)
        {
            try
            {
                if (CustomerRec != null)
                {
                    db.Entry(CustomerRec).State = EntityState.Modified;
                    db.SaveChanges();
                    return CustomerRec;
                }
                else
                {
                    throw new Exception("Ui Error");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> AddCustomer(Customer cust)
        {
            var Cust = new Customer()
            {
                CustomerId = cust.CustomerId,
                CustomerName = cust.CustomerName,
                CustomerDob = cust.CustomerDob,
                CustomerAddress = cust.CustomerAddress,
                CustomerContact = cust.CustomerContact,
                CustomerEmail = cust.CustomerEmail,
                Age = cust.Age,
                Custpass=cust.Custpass
            };
            db.Customers.Add(Cust);
            await db.SaveChangesAsync();
            return (int)Cust.CustomerId;
        }
        public async Task RemoveCustomer(int CustomerId)
        {
            Customer cst = db.Customers.Where((x) => x.CustomerId == CustomerId).FirstOrDefault();
            db.Customers.Remove(cst);
            await db.SaveChangesAsync();
        }
    }
}
