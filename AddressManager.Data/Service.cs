using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AddressManager.Data
{
    public class Service
    {
        public Customer GetCustomerWithAddressesByKey(int custKey)
        {
            using(var context = new CustomerDbContext())
            {
                return context.Customers
                    .Include(g => g.Orders)
                    .Include(i => i.CustomerAddresses)
                    .ThenInclude(c => c.Address)
                    .FirstOrDefault(p => p.Key == custKey);
            }
        }


        public Address GetAddressByKey(int addrKey)
        {
            using(var context = new CustomerDbContext())
            {
                return context.Addresses.FirstOrDefault(c => c.Key == addrKey);
            }
        }


        public Customer GetCustomerWithAddressesByID(string custID)
        {
            using (var context = new CustomerDbContext())
            {
                return context.Customers
                    .Include(cust => cust.CustomerAddresses)
                    .FirstOrDefault(c => c.Id == custID);
            }
        }

        public void AddAddress(Address data, int custKey = 0)
        {
            using (var context = new CustomerDbContext())
            {
                if (custKey == 0)
                {

                }
                else
                {
                    
                }
            }
        }

        public void UpdateAddress(Address address)
        {
            using (var context = new CustomerDbContext())
            {
                var addressToUpdate = context.Addresses.FirstOrDefault(c => c.Key == address.Key);
                if(addressToUpdate != null)
                {
                    addressToUpdate.Line1 = address.Line1;
                    addressToUpdate.Line2 = address.Line2;
                    addressToUpdate.City = address.City;
                    addressToUpdate.State = address.State;
                    addressToUpdate.Zip = address.Zip;

                    context.Addresses.Update(addressToUpdate);
                    context.SaveChanges();
                }
            }
        }
    }
}
