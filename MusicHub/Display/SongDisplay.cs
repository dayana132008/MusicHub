using MusicHub.Business;
using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Display
{
    internal class SongDisplay
    {
        private int closeOperationId = 6;
        private SongBusiness songBusiness = new SongBusiness();
        public SongDisplay()
        {
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Song" + new string(' ', 18));
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
                        Update(songBusiness);
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
            songBusiness.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Song song = songBusiness.Get(id);
            if (song != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + song.SongId);
                Console.WriteLine("Name: " + song.Title);
                Console.WriteLine("Country: " + song.Duration);
                Console.WriteLine("Genre: " + song.AlbumId);

                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update(SongBusiness songBusiness)
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Song song = songBusiness.Get(id);
            if (song != null)
            {
                Console.WriteLine("Enter title: ");
                song.Title = Console.ReadLine();
                Console.WriteLine("Enter duration: ");
                song.Duration = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter albumId: ");
                song.AlbumId = int.Parse(Console.ReadLine());

                songBusiness.Update(song);
            }
            else
            {
                Console.WriteLine("Song not found!");
            }
        }

        private void Add()
        {
            Song song = new Song();
            Console.WriteLine("Enter ID: ");
            song.SongId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter title: ");
            song.Title = Console.ReadLine();
            Console.WriteLine("Enter duration: ");
            song.Duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter albumId: ");
            song.AlbumId = int.Parse(Console.ReadLine());

            songBusiness.Add(song);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Song" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var SongDisplay = songBusiness.GetAll();
            foreach (var item in SongDisplay)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.SongId, item.Title, item.Duration, item.AlbumId);
            }
        }
    }
}
