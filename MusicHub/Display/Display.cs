using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Display
{
    public class Display
    {
        public Display()
        {
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(LogoTitle());
            Console.WriteLine("1. Albums");
            Console.WriteLine("2. Artists");
            Console.WriteLine("3. Playlists");
           // Console.WriteLine("4. PlaylistSongs");
            Console.WriteLine("4. Songs");
           // Console.WriteLine("6. UserPlaylists");
            Console.WriteLine("5. Users");
            Console.WriteLine("6. Exit");
        }

        private string LogoTitle()
        {

            String s =
"\n  __  __           _      _    _       _     " +
"\n |  \\/  |         (_)    | |  | |     | |    " +
"\n | \\  / |_   _ ___ _  ___| |__| |_   _| |__  " +
"\n | |\\/| | | | / __| |/ __|  __  | | | | '_ \\ " +
"\n | |  | | |_| \\__ \\ | (__| |  | | |_| | |_) |" +
"\n |_|  |_|\\__,_|___/_|\\___|_|  |_|\\__,_|_.__/ " +
"\n";


            return s;
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
                        {
                            new AlbumDisplay();
                            break;
                        }
                    case 2:
                        {
                            new ArtistDisplay();
                            break;
                        }
                    case 3:
                        {
                            new PlaylistDisplay();
                            break;
                        }
                    case 4:
                        {
                            new SongDisplay();
                            break;
                        }
                    case 5:
                        {
                            new UserDisplay();
                            break;
                        }
                    default:
                        break;
                }
            } while (operation != 6);
        }
    }
}
