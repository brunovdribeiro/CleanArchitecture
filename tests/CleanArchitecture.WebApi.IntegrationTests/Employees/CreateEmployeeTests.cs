using System.Net;
using System.Net.Http.Json;

using CleanArchitecture.Contract.Employees;

using FluentAssertions;

using Microsoft.AspNetCore.Mvc.Testing;

namespace CleanArchitecture.WebApi.IntegrationTests.Employees;

public class CreateEmployeeTests
{
    [Theory]
    [InlineData(null, "test@test.com")]
    [InlineData("", "test@test.com")]
    [InlineData("a", "test@test.com")]
    [InlineData("ab", "test@test.com")]
    [InlineData("Name", "test@")]
    [InlineData("Name", "test")]
    [InlineData("Name", null)]
    [InlineData("Name", "")]
    public async Task CreateEmployee_WhenPayloadIsInvalid_ShouldReturnBadRequest(string name, string email)
    {
        // Arrange
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var payload = new CreateEmployeeRequest (name, email);

        // Act
        var response = await client.PostAsJsonAsync("/api/employees", payload);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}