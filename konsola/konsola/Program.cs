namespace konsola
{
    internal class Program
    {  
        static void Main(string[] args)
        {
            MusicAlbum.DisplayAlbums(MusicAlbum.ReadAlbums("../../../Data.txt"));
            //Console.WriteLine(sizeof(uint));
        }
    }
}
