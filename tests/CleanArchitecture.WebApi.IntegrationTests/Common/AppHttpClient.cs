using System.Net;
using System.Net.Http.Json;

using CleanArchitecture.Application.Employees.Commands.CreateEmployee;
using CleanArchitecture.Contract.Employees;
using CleanArchitecture.WebApi.IntegrationTests.Common.TestContraints;

using FluentAssertions;

namespace CleanArchitecture.WebApi.IntegrationTests.Common;

public class AppHttpClient(HttpClient _httpClient)
{
    public async Task<CreateEmployeeCommandResponse> CreateEmployeeAndExpectSuccessAsync(
        string? name = null,
        string? email = null)
    {
        name ??= Constants.Employee.Name;
        email ??= Constants.Employee.Email;
        
        var response = await CreateEmployeeAsync(name, email);
        
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var employeeCommandResponse = await response.Content.ReadFromJsonAsync<CreateEmployeeCommandResponse>();
        
        employeeCommandResponse.Should().NotBeNull();

        return employeeCommandResponse!;
    }

    public async Task<HttpResponseMessage> CreateEmployeeAsync(
        string? name = null,
        string? email = null)
    {
        const string url = "/api/employees";
        
        var payload = new CreateEmployeeRequest(name, email);

        return await _httpClient.PostAsJsonAsync(url, payload);
    }
}