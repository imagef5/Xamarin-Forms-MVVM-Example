using System.Collections.Generic;
using System.Threading.Tasks;
using CommonRepository.Models;

namespace CommonRepository.Services
{
    public class UserService : IUserService
    {

        public async Task<List<User>> GetUsersAsync()
        {

            var users = new List<User>
            {
                new User{
                    FirstName = "paula",
                    LasttName = "vargas",
                    Email = "paula.vargas@example.com",
                    Gender = Gender.Female,
                    Address = new Address{
                        Street = "8911 calle de la luna",
                        City = "vigo",
                        State = "cantabria",
                        PostCode = "42254",
                    },
                    Picture = "https://randomuser.me/api/portraits/med/women/44.jpg"
                },
                new User{
                    FirstName = "romain",
                    LasttName = "hoogmoed",
                    Email = "romain.hoogmoed@example.com",
                    Gender = Gender.Male,
                    Address = new Address{
                        Street = "1861 jan pieterszoon coenstraat",
                        City = "maasdriel",
                        State = "zeeland",
                        PostCode = "69217",
                    },
                    Picture = "https://randomuser.me/api/portraits/med/men/83.jpg"
                }
            };

            return users;
        }
    }
}
