namespace konsola
{
    public class MusicAlbum(string artist, string album, uint songsNumber, int yearOfEdition, uint downloadNumber)
    {
        public string Artist { get; set; } = artist;
        public string Album { get; set; } = album;
        public uint SongsNumber { get; set; } = songsNumber;
        public int YearOfEdition { get; set; } = yearOfEdition;
        public uint DownloadNumber { get; set; } = downloadNumber;
    }
}
