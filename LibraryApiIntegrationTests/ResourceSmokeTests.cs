using LibraryApi;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApiIntegrationTests
{
    public class ResourceSmokeTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient Client;

        public ResourceSmokeTests(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        [Theory]
        [InlineData("/books")]
        [InlineData("/books/1")]
        public async Task CheckItResourceIsAlive(string resource)
        {
            var response = await Client.GetAsync(resource);

            Assert.True(response.IsSuccessStatusCode);

        }

        [Fact]
        public async Task CanGetBook()
        {
            var response = await Client.GetAsync("/books/1");

            var book = await response.Content.ReadAsAsync<BookDetailsResponse>();

            Assert.Equal(1, book.id);
            Assert.Equal("Walden", book.title);
            Assert.Equal("Philosophy", book.genre);
        }
        [Fact]
        public async Task CanAddBook()
        {
            var bookToAdd = new PostBookRequest
            {
                title = "Composing Electronic Music",
                author = "Smihht",
                genre = "Non-Fiction",
                numberOfPages = 300
            };

            var response = await Client.PostAsJsonAsync("/books", bookToAdd);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var location = response.Headers.Location.LocalPath;
            var getItResponse = await Client.GetAsync(location);
            var responseData = await getItResponse.Content.ReadAsAsync<BookDetailsResponse>();

            Assert.Equal(bookToAdd.title, responseData.title);
            Assert.Equal(bookToAdd.author, responseData.author);

        }
    }
    public class BookDetailsResponse
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public int numberOfPages { get; set; }
    }

    public class PostBookRequest
    {
        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public int numberOfPages { get; set; }
    }

}
