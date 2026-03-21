using MusicHub.Business;
using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Display
{
    internal class AlbumDisplay
    {
        private int closeOperationId = 6;
        private AlbumBusiness albumBusiness = new AlbumBusiness();
        public AlbumDisplay() 
        {
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Album" + new string(' ', 18));
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
                        Update(albumBusiness);
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
            albumBusiness.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Album album = albumBusiness.Get(id);
            if (album != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + album.AlbumId);
                Console.WriteLine("Title: " + album.Title);
                Console.WriteLine("ReleaseYear: " + album.ReleaseYear);
                Console.WriteLine("ArtistId: " + album.ArtistId);

                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update(AlbumBusiness albumBusiness)
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Album album = albumBusiness.Get(id);
            if (album != null)
            {
                Console.WriteLine("Enter title: ");
                album.Title = Console.ReadLine();
                Console.WriteLine("Enter releaseYear: ");
                album.ReleaseYear = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter artistId: ");
                album.ArtistId = int.Parse(Console.ReadLine());

                albumBusiness.Update(album);
            }
            else
            {
                Console.WriteLine("Album not found!");
            }
        }

        private void Add()
        {
            Album album = new Album();
            Console.WriteLine("Enter ID: ");
            album.AlbumId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter title: ");
            album.Title = Console.ReadLine();
            Console.WriteLine("Enter ReleaseYear: ");
            album.ReleaseYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter ArtistId: ");
            album.ArtistId = int.Parse(Console.ReadLine());

            albumBusiness.Add(album);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Album" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var AlbumDisplay = albumBusiness.GetAll();
            foreach (var item in AlbumDisplay)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.AlbumId, item.Title, item.ReleaseYear, item.ArtistId);
            }
        }
    }
}

    

