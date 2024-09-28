using System.Windows;
using System.IO;

namespace desktopowa
{
    public partial class MainWindow : Window
    {
        private readonly List<MusicAlbum> albumList = [];
        private int currentAlbumIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
            albumList = ReadAlbums("../../../Data.txt");
            UpdateAlbum(currentAlbumIndex);
        }
        public List<MusicAlbum> ReadAlbums(string filePath)
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
        public void UpdateAlbum(int albumIndex)
        {
            artistLabel.Content = albumList[albumIndex].Artist;
            albumLabel.Content = albumList[albumIndex].Album;
            songsNumberLabel.Content = $"{albumList[albumIndex].SongsNumber} utworów";
            yearOfEditionLabel.Content = albumList[albumIndex].YearOfEdition;
            downloadNumberLabel.Content = albumList[albumIndex].DownloadNumber;
        }
        private void DownloadAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            albumList[currentAlbumIndex].DownloadNumber++;
            UpdateAlbum(currentAlbumIndex);
        }
        private void PreviousAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentAlbumIndex > 0)
            {
                UpdateAlbum(--currentAlbumIndex);
            }
            else
            {
                currentAlbumIndex = albumList.Count - 1;
                UpdateAlbum(currentAlbumIndex);
            }
        }
        private void NextAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            currentAlbumIndex = (currentAlbumIndex + 1) % albumList.Count;
            UpdateAlbum(currentAlbumIndex);
        }
    }
}