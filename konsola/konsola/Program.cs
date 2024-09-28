namespace konsola
{
    internal class Program
    {
        /***********************************************
        nazwa metody: ReadAlbums
        opis metody: Metoda odczytuje dane z pliku tekstowego wyznaczonego przez ścieżkę podaną jako parametr i zapisuje je do kolekcji jako lista obiektów klasy MusicAlbum
        parametry: filePath (string - typ danych tekstowy) - ścieżka do pliku z danymi
        zwracany typ i opis: List<MusicAlbum> - kolekcja, lista obiektów klasy MusicAlbum
        autor: 12345678910
        ************************************************/
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
            /*string[] fileLines = File.ReadAllLines(filePath);
            for (int i = 0; i < fileLines.Length; i += 6)
            {
                string artist = fileLines[i];
                string album = fileLines[i + 1];
                uint songsNumber = uint.Parse(fileLines[i + 2]);
                int yearOfEdition = int.Parse(fileLines[i + 3]);
                uint downloadNumber = uint.Parse(fileLines[i + 4]);
                MusicAlbum music = new(artist, album, songsNumber, yearOfEdition, downloadNumber);
                albumList.Add(music);
            }*/
            return albumList;
        }
        public static void DisplayAlbums(List<MusicAlbum> albumList)
        {
            foreach (MusicAlbum music in albumList)
            {
                Console.WriteLine($"{music.Artist}\n{music.Album}\n{music.SongsNumber}\n{music.YearOfEdition}\n{music.DownloadNumber}\n");
            }
        }
        static void Main(string[] args)
        {
            DisplayAlbums(ReadAlbums("../../../Data.txt"));
            //Console.WriteLine(sizeof(uint));
        }
    }
}
