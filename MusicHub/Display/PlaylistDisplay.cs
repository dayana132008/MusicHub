using MusicHub.Business;
using MusicHub.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Display
{
    internal class PlaylistDisplay
    {
        private int closeOperationId = 6;
        private PlaylistBusiness playlistBusiness = new PlaylistBusiness();
        public PlaylistDisplay()
        {
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Playlist" + new string(' ', 18));
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
                        Update(playlistBusiness);
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
            playlistBusiness.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Playlist playlist = playlistBusiness.Get(id);
            if (playlist != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + playlist.PlaylistId);
                Console.WriteLine("Name: " + playlist.Name);
                Console.WriteLine("CreatedDate: " + playlist.CreatedDate);

                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update(PlaylistBusiness playlistBusiness)
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Playlist playlist = playlistBusiness.Get(id);
            if (playlist != null)
            {
                Console.WriteLine("Enter name: ");
                playlist.Name = Console.ReadLine();
                Console.WriteLine("Enter createdDate: ");
                string input = Console.ReadLine();

                string[] parts = input.Split('.');

                int day = int.Parse(parts[0]);
                int month = int.Parse(parts[1]);
                int year = int.Parse(parts[2]);

                DateOnly createdDate = new DateOnly(year, month, day);

                playlist.CreatedDate = createdDate;


                playlistBusiness.Add(playlist);

                playlistBusiness.Update(playlist);
            }
            else
            {
                Console.WriteLine("Playlist not found!");
            }
        }

        private void Add()
        {
            Playlist playlist = new Playlist();
            Console.WriteLine("Enter ID: ");
            playlist.PlaylistId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter name: ");
            playlist.Name = Console.ReadLine();
            Console.WriteLine("Enter createdDate: ");
            string input = Console.ReadLine();

            string[] parts = input.Split('.');

            int day = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int year = int.Parse(parts[2]);

            DateOnly createdDate = new DateOnly(year, month, day);

            playlist.CreatedDate = createdDate;


            playlistBusiness.Add(playlist);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Playlist" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var ArtistDisplay = playlistBusiness.GetAll();
            foreach (var item in ArtistDisplay)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.PlaylistId, item.Name, item.Name, item.CreatedDate);
            }
        }
    }
}
 