using MusicHub.Business;
using MusicHub.Data.Models;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Display
{
    internal class ArtistDisplay
    {
        private int closeOperationId = 6;
        private ArtistBusiness artistBusiness = new ArtistBusiness();
        public ArtistDisplay()
        {
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Artist" + new string(' ', 18));
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
                        Update(artistBusiness);
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
            artistBusiness.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Artist artist = artistBusiness.Get(id);
            if (artist != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + artist.ArtistId);
                Console.WriteLine("Name: " + artist.Name);
                Console.WriteLine("Country: " + artist.Country);
                Console.WriteLine("Genre: " + artist.Genre);

                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update(ArtistBusiness artistBusiness)
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Artist artist = artistBusiness.Get(id);
            if (artist != null)
            {
                Console.WriteLine("Enter name: ");
                artist.Name = Console.ReadLine();
                Console.WriteLine("Enter country: ");
                artist.Country = Console.ReadLine();
                Console.WriteLine("Enter genre: ");
                artist.Genre = Console.ReadLine();

                artistBusiness.Update(artist);
            }
            else
            {
                Console.WriteLine("Artist not found!");
            }
        }

        private void Add()
        {
            Artist artist = new Artist();
            Console.WriteLine("Enter ID: ");
            artist.ArtistId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter name: ");
            artist.Name = Console.ReadLine();
            Console.WriteLine("Enter country: ");
            artist.Country = Console.ReadLine();
            Console.WriteLine("Enter genre: ");
            artist.Genre = Console.ReadLine();

            artistBusiness.Add(artist);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Artist" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var ArtistDisplay = artistBusiness.GetAll();
            foreach (var item in ArtistDisplay)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.ArtistId, item.Name, item.Country, item.Genre);
            }
        }
    }
}

