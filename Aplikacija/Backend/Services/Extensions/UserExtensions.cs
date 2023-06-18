using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;

namespace Services.Extensions
{
    public static class UserExtensions
    {
        public static void CreateUpdateAddress(this User user, ShippingAddress address)
        {
            if (user.Address == null)
            {
                user.Address = new UserAddress
                {
                    FullName = address.FullName,
                    Address1 = address.Address1,
                    Address2 = address.Address2,
                    City = address.City,
                    Zip = address.Zip,
                    Country=address.Country
                };
            }
            else
            {
                user.Address.FullName = address.FullName;
                user.Address.Address1 = address.Address1;
                user.Address.Address2 = address.Address2;
                user.Address.City = address.City;
                user.Address.Zip = address.Zip;
                user.Address.Country=address.Country;
            }
        }
    }
}