using System.Net;

using CleanArchitecture.Application.Employees.Commands.CreateEmployee;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.WebApi.IntegrationTests.Common;
using CleanArchitecture.WebApi.IntegrationTests.Common.TestContraints;
using CleanArchitecture.WebApi.IntegrationTests.Common.WebAppFactories;

using FluentAssertions;

namespace CleanArchitecture.WebApi.IntegrationTests.Employees;

[Collection(WebAppFactoryCollection.CollectionName)]
public class CreateEmployeeTests
{
    private readonly AppHttpClient _client;
    private readonly AppDbContext _dbContext;

    public CreateEmployeeTests(WebAppFactory webAppFactory)
    {
        _client = webAppFactory.CreateAppHttpClient();
        webAppFactory.ResetDatabase();
        _dbContext = webAppFactory.Context;
    }

    [Theory]
    [InlineData(null, "test@test.com")]
    [InlineData("", "test@test.com")]
    [InlineData("a", "test@test.com")]
    [InlineData("ab", "test@test.com")]
    [InlineData("Name", "test@")]
    [InlineData("Name", "test")]
    [InlineData("Name", null)]
    [InlineData("Name", "")]
    public async Task CreateEmployee_WhenPayloadIsInvalid_ShouldReturnBadRequest(string? name, string? email)
    {
        // Act
        HttpResponseMessage response = await _client.CreateEmployeeAsync(name, email);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task CreateEmployee_WhenPayloadIsValid_ShouldReturnCreated()
    {
        // Act
        CreateEmployeeCommandResponse employeeResponse = await _client.CreateEmployeeAndExpectSuccessAsync();

        Employee? employee = await _dbContext.Employees.FindAsync(employeeResponse.Id);

        // Assert
        employee.Should().NotBeNull();
        employee!.Id.Should().NotBeEmpty();
        employee!.Email.Should().Be(Constants.Employee.Email);
        employee!.Name.Should().Be(Constants.Employee.Name);
    }
}