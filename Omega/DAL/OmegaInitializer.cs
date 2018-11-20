using Omega.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Omega.DAL
{
    public class OmegaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<OmegaContext>
    {
        protected override void Seed(OmegaContext context)
        {
            var users = new List<User>
            {
                new User{FirstName="Kinga", LastName="Gawinowska", Role= new Role{Name="Administrator"}, IsActive=true},
                new User{FirstName="Rafał", LastName="Trojanowski", Role= new Role{Name="User"}, IsActive=true}
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var roles = new List<Role>
            {
                new Role{Name="Administrator"},
                new Role{Name="User"}
            };
            roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            var statuses = new List<Status>
            {
                new Status{Name="Oczekuje"},
                new Status{Name="Przypisany"},
                new Status{Name="Poczekalnia"},
            };
            statuses.ForEach(s => context.Statuses.Add(s));
            context.SaveChanges();

            var clients = new List<Client>
            {
                new Client{ShortName="Amegra",FullName="Amegra sp. z o.o.",NIP="4212121223",City="Warszawa", PostalCode="92-120", StreetName="Kaczorowa", StreetNumber="26", Email="amegra@amegra.pl", PhoneNumber="555555555"},
                new Client{ShortName="Klient",FullName="Klient sp. z o.o.",NIP="4422221223",City="Kraków", PostalCode="52-110", StreetName="Krakowska", StreetNumber="26", Email="klient@klient.pl", PhoneNumber="22 562 23 22"}
            };
            clients.ForEach(c => context.Clients.Add(c));
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order{ClientId=1, StatusId=1, UserAddedId=2, Number="01/01/2018" },
                new Order{ClientId=2, StatusId=2, UserAddedId=1, Number="02/01/2018" },
                new Order{ClientId=2, StatusId=3, UserAddedId=1, Number="03/01/2018" },
            };
            orders.ForEach(o => context.Orders.Add(o));
            context.SaveChanges();
        }
    }
}