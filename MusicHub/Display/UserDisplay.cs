using MusicHub.Business;
using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Display
{
    internal class UserDisplay
    {
        private int closeOperationId = 6;
        private UserBusiness userBusiness = new UserBusiness();
        public UserDisplay()
        {
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "User" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update(userBusiness);
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            userBusiness.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            User user = userBusiness.Get(id);
            if (user != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + user.UserId);
                Console.WriteLine("Username: " + user.Username);
                Console.WriteLine("Email: " + user.Email);

                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update(UserBusiness userBusiness)
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            User user = userBusiness.Get(id);
            if (user != null)
            {
                Console.WriteLine("Enter username: ");
                user.Username = Console.ReadLine();
                Console.WriteLine("Enter email: ");
                user.Email = Console.ReadLine();
          

                userBusiness.Update(user);
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }

        private void Add()
        {
            User user = new User();
            Console.WriteLine("Enter ID: ");
            user.UserId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter username: ");
            user.Username = Console.ReadLine();
            Console.WriteLine("Enter email: ");
            user.Email = Console.ReadLine();

            userBusiness.Add(user);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "User" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var SongDisplay = userBusiness.GetAll();
            foreach (var item in SongDisplay)
            {
                Console.WriteLine("{0} {1} {2} ", item.UserId, item.Username, item.Email);
            }
        }
    }
}
