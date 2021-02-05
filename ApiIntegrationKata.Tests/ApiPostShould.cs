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
    public class ApiPostShould : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;

        public ApiPostShould(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/v1/todo");
        }

        [Fact]
        public async Task ReturnAcceptedAndCreatedItem()
        {
            var todoItem = new TodoItemDto
            {
                Description = "Walk the dog",
                Priority = 1,
                IsCompleted = false
            };

            var content = JsonContent.Create(todoItem);

            var response = await _httpClient.PostAsync("", content);

            response.StatusCode.Should().Be(201);

            var item = await response.Content.ReadFromJsonAsync<TodoItemDto>();

            item.Should().BeEquivalentTo(todoItem);
        }
    }
}