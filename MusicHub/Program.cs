using Microsoft.Data.SqlClient;

namespace MusicHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Display.Display d = new Display.Display();
            /*  SqlConnection dbCon = new SqlConnection(
              "Server=(localdb)\\MSSQLLocalDB; " +
              "Database=MusicHub; " +
              "Integrated Security=true");
              dbCon.Open();
              using (dbCon)
              {
                  /* string selectArtists = "select Name from Artists;";
                   SqlCommand command = new SqlCommand(selectArtists, dbCon);
                   using var reader = command.ExecuteReader();
                   while (reader.Read())
                   {
                       Console.WriteLine(reader["Name"]);
                   }



                   int PlaylistId = int.Parse(Console.ReadLine());
                   string Name = Console.ReadLine();
                   string CreatedDate = Console.ReadLine();
                   string insertPlaylists = "insert into Playlists (PlaylistId, Name, CreatedDate) values (@PlaylistId, @Name, @CreatedDate);";

                   var command = new SqlCommand(insertPlaylists, dbCon);

                   command.Parameters.AddWithValue("@PlaylistId", PlaylistId);
                   command.Parameters.AddWithValue("@Name", Name);
                   command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

                   command.ExecuteNonQuery();

                  string deletePlaylists = "delete from Playlists where PlaylistId=11";
                  var command = new SqlCommand(deletePlaylists, dbCon);
                  command.ExecuteNonQuery();

                  string Name = Console.ReadLine();
                  string updatePlaylists = "update Playlists set Name=@Name where PlaylistId=10";
                  var command = new SqlCommand(updatePlaylists, dbCon);
                  command.Parameters.AddWithValue("@Name", Name);
                  command.ExecuteNonQuery();

              }
              dbCon.Close();
            */
        }
    }
}
