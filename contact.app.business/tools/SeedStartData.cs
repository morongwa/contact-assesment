using System;
using contact.app.business.context;
using contact.app.business.entity;
using contact.app.business.repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace contact.app.business.tools
{
    public static class SeedStartData
    {
        public static WebCoreContext GetContext(IServiceProvider service) {
            var context = new WebCoreContext(service.GetRequiredService<DbContextOptions<WebCoreContext>>());
            return context;
        }

        public static void SeedAll(WebCoreContext _context)
        {
            using (var context = _context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                AddressCountryData(context);
                AddressProvinceData(context);
                StatusContactData(context);
                NamedGroupData(context);
            }
        }

        public static void SeedAll(IServiceProvider service) {
            using (var context = GetContext(service))
            {
                SeedAll(context);
            }
        }

        public static void AddressProvinceData(WebCoreContext _context) {
            using (var context = _context) {
                //context.Database.EnsureCreated();

                if (context.AddressProvinces.Any())
                {
                    return;
                }

                
                context.AddressProvinces.AddRange(
                    new AddressProvince {
                        //AddressProvinceId = 1,
                        Name = "Eastern Cape",
                        ProvinceCode = "EC"
                    },
                    new AddressProvince
                    {
                        //AddressProvinceId = 2,
                        Name = "Free State",
                        ProvinceCode = "FS"
                    },
                    new AddressProvince
                    {
                        //AddressProvinceId = 3,
                        Name = "Gauteng",
                        ProvinceCode = "GP"
                    },
                    new AddressProvince
                    {
                        //AddressProvinceId = 4,
                        Name = "KwaZulu Natal",
                        ProvinceCode = "KZN"
                    },
                    new AddressProvince
                    {
                        //AddressProvinceId = 5,
                        Name = "Limpopo",
                        ProvinceCode = "LP"
                    },
                    new AddressProvince
                    {
                        //AddressProvinceId = 6,
                        Name = "Mpumalanga",
                        ProvinceCode = "MP"
                    },
                    new AddressProvince
                    {
                        //AddressProvinceId = 7,
                        Name = "North West",
                        ProvinceCode = "NW"
                    },
                    new AddressProvince
                    {
                        //AddressProvinceId = 8,
                        Name = "Northern Cape",
                        ProvinceCode = "NC"
                    },
                    new AddressProvince
                    {
                        //AddressProvinceId = 9,
                        Name = "Western Cape",
                        ProvinceCode = "WC"
                    }

                );
                context.SaveChanges();
            }
        }

        public static void AddressCountryData(WebCoreContext _context)
        {
            using (var context = _context)
            {
                //context.Database.EnsureCreated();

                if (context.AddressCountries.Any())
                {
                    return;
                }

                context.AddressCountries.AddRange(
                    new AddressCountry {
                        //AddressCountryId = 1,
                        Name = "South Africa",
                        CodeCountry = "ZA",
                        CodePhone = "+27"
                    },
                    new AddressCountry
                    {
                        //AddressCountryId = 2,
                        Name = "Botswana",
                        CodeCountry = "BW",
                        CodePhone = "+25"
                    },
                    new AddressCountry
                    {
                        //AddressCountryId = 3,
                        Name = "Lesotho",
                        CodeCountry = "LS",
                        CodePhone = "+24"
                    },
                    new AddressCountry
                    {
                        //AddressCountryId = 4,
                        Name = "Swaziland",
                        CodeCountry = "SZ",
                        CodePhone = "+23"
                    }
                );

                context.SaveChanges();
            }
        }

        public static void StatusContactData(WebCoreContext _context)
        {
            using (var context = _context)
            {
                //context.Database.EnsureCreated();

                if (context.StatusContacts.Any())
                {
                    return;
                }

                context.StatusContacts.AddRange(
                    new StatusContact
                    {
                        //StatusContactId = 1,
                        Name = "Active",
                        Description = "Contact is active"
                    },
                    new StatusContact
                    {
                        //StatusContactId = 2,
                        Name = "Merged",
                        Description = "Contact is merged with another contact"
                    },
                    new StatusContact
                    {
                        //StatusContactId = 3,
                        Name = "Deleted",
                        Description = "Contact is deleted"
                    }
                );

                context.SaveChanges();
            }
        }

        public static void OnlineUserData(WebCoreContext _context) {
            using (var context = _context) {
                if (context.OnlineUsers.Any()) {
                    return;
                }

                context.OnlineUsers.Add(new OnlineUser()
                {
                    Username = "demo",
                    Password = RepositoryCypher.Encrypt("demo123"),
                    Email = "jramputa@gmail.com",
                    DateCreated = DateTime.Now
                });

                context.SaveChanges();
            }
        }

        public static void NamedGroupData(WebCoreContext _context)
        {
            using (var context = _context)
            {
                //context.Database.EnsureCreated();

                if (context.NamedGroups.Any())
                {
                    return;
                }

                context.NamedGroups.AddRange(
                    new NamedGroup {
                        //NamedGroupId = 1,
                        Name="Default",
                        Description = "Default contact list grouping accross the system",
                        DateCreated = DateTime.Now,
                        CreatedByOnlineUserId = 1
                    },
                    new NamedGroup
                    {
                        //NamedGroupId = 2,
                        Name = "Favourites",
                        Description = "Favourites contact list grouping accross the system",
                        DateCreated = DateTime.Now,
                        CreatedByOnlineUserId = 1
                    }

                );

                context.SaveChanges();
            }
        }
    }
}

