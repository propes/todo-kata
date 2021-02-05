using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ApiIntegrationKata.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ApiIntegrationKata.Tests
{
    public class ApiGetShould : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;

        public ApiGetShould(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/v1/todo");
        }

        [Fact]
        public async Task ReturnTodoItems()
        {
            var todoItems = new []
            {
                new { Description = "Walk the dog", Priority = 2 },
                new { Description = "Wash the cat", Priority = 1 }
            };
            
            await _httpClient.PostAsync("", JsonContent.Create(todoItems[0]));
            await _httpClient.PostAsync("", JsonContent.Create(todoItems[1]));
            
            var response = await _httpClient.GetAsync("");

            response.StatusCode.Should().Be(200);

            var items = await response.Content.ReadFromJsonAsync<TodoItemDto[]>();
            
            items.Should().BeEquivalentTo(todoItems);
        }
    }
}