using konsola;

namespace konsolaTests
{
    public class ProgramTests
    {
        [Fact]
        public void GivenFilePath_WhenReadAlbums_ThenReturnListOfAlbums()
        {
            //Arrange
            string filePath = "../../../test.txt";
            File.WriteAllLines(filePath, ["artist1", "\"album1\"", "10", "2021", "100", "", "artist2", "\"album2\"", "20", "2022", "200", "" ]);
            //Act
            var albums = Program.ReadAlbums(filePath);
            //Assert
            Assert.Equal(2, albums.Count);

            Assert.Equal("artist1", albums[0].Artist);
            Assert.Equal("\"album1\"", albums[0].Album);
            Assert.Equal(10u, albums[0].SongsNumber);
            Assert.Equal(2021, albums[0].YearOfEdition);
            Assert.Equal(100u, albums[0].DownloadNumber);

            Assert.Equal("artist2", albums[1].Artist);
            Assert.Equal("\"album2\"", albums[1].Album);
            Assert.Equal(20u, albums[1].SongsNumber);
            Assert.Equal(2022, albums[1].YearOfEdition);
            Assert.Equal(200u, albums[1].DownloadNumber);

        }
    }
}