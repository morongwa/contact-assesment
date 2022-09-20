using System;
using contact.app.business;
using contact.app.business.context;
using contact.app.business.entity;
using Microsoft.EntityFrameworkCore;

namespace contact.app.mvc.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider service) {

            using (var context = new WebCoreContext(service.GetRequiredService<DbContextOptions<WebCoreContext>>())) {

                context.Database.EnsureCreated();

                if (context.OnlineUsers.Any()) {
                    return;
                }

                context.OnlineUsers.AddRange(
                    new OnlineUser {
                        Username = "user1",
                        Password = "user1-123",
                        DateCreated = DateTime.Now,
                        Active = true
                        
                    },
                    new OnlineUser
                    {
                        Username = "user2",
                        Password = "user2-123",
                        DateCreated = DateTime.Now,
                        Active = true

                    },
                    new OnlineUser
                    {
                        Username = "user3",
                        Password = "user3-123",
                        DateCreated = DateTime.Now,
                        Active = true

                    },
                    new OnlineUser
                    {
                        Username = "user4",
                        Password = "user4-123",
                        DateCreated = DateTime.Now,
                        Active = true

                    }
                );

                context.SaveChanges();
            }
        }
    }
}

