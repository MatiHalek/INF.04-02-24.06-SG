using System.IO;

namespace desktopowa
{
    public class MusicAlbum(string artist, string album, uint songsNumber, int yearOfEdition, uint downloadNumber)
    {
        public string Artist { get; set; } = artist;
        public string Album { get; set; } = album;
        public uint SongsNumber { get; set; } = songsNumber;
        public int YearOfEdition { get; set; } = yearOfEdition;
        public uint DownloadNumber { get; set; } = downloadNumber;
        public static List<MusicAlbum> ReadAlbums(string filePath)
        {
            List<MusicAlbum> albumList = [];
            using (StreamReader readFile = new(filePath))
            {
                while (!readFile.EndOfStream)
                {
                    string artist = readFile.ReadLine() ?? "";
                    string album = readFile.ReadLine() ?? "";
                    uint songsNumber = uint.Parse(readFile.ReadLine() ?? "");
                    int yearOfEdition = int.Parse(readFile.ReadLine() ?? "");
                    uint downloadNumber = uint.Parse(readFile.ReadLine() ?? "");
                    readFile.ReadLine();
                    MusicAlbum music = new(artist, album, songsNumber, yearOfEdition, downloadNumber);
                    albumList.Add(music);
                }
            }
            return albumList;
        }
    }
}
