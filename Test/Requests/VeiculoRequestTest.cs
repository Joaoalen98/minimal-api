using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.ModelViews;
using MinimalApi.DTOs;
using Test.Helpers;

namespace Test.Requests;

[TestClass]
public class VeiculoRequestTest
{
    [ClassInitialize]
    public static void ClassInit(TestContext testContext)
    {
        Setup.ClassInit(testContext);
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        Setup.ClassCleanup();
    }

    private async Task<string> ObterTokenAutenticacao()
    {
        var loginDTO = new LoginDTO
        {
            Email = "adm@teste.com",
            Senha = "123456"
        };

        var content = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "Application/json");
        var response = await Setup.client.PostAsync("/administradores/login", content);

        var result = await response.Content.ReadAsStringAsync();
        var admLogado = JsonSerializer.Deserialize<AdministradorLogado>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return admLogado?.Token ?? "";
    }


    [TestMethod]
    public async Task TestarGetSetPropriedades_RequestVeiculo()
    {
        // Arrange
        var veiculoDTO = new VeiculoDTO
        {
            Ano = 1983,
            Marca = "Ford",
            Nome = "Landau"
        };

        var content = new StringContent(JsonSerializer.Serialize(veiculoDTO), Encoding.UTF8, "Application/json");

        // Act
        Setup.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await ObterTokenAutenticacao());
        var response = await Setup.client.PostAsync("/veiculos", content);

        // Assert
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

        var result = await response.Content.ReadAsStringAsync();
        var veiculoSalvo = JsonSerializer.Deserialize<Veiculo>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Assert.IsNotNull(veiculoSalvo?.Ano ?? 1983);
        Assert.IsNotNull(veiculoSalvo?.Marca ?? "Ford");
        Assert.IsNotNull(veiculoSalvo?.Nome ?? "Landau");
    }
}
