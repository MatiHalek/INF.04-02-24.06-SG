using System.Windows;

namespace desktopowa
{
    public partial class MainWindow : Window
    {
        private readonly List<MusicAlbum> albumList = [];
        private int currentAlbumIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
            albumList = MusicAlbum.ReadAlbums("../../../Data.txt");
            UpdateAlbum(currentAlbumIndex);
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