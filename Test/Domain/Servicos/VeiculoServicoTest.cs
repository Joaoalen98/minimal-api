using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;
using Test.Helpers;

namespace Test.Domain.Servicos;

[TestClass]
public class VeiculoServicoTest
{
    private int TruncarTabela(DbContexto context)
    {
        return context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");
    }

    [TestMethod]
    public void TestandoSalvar_VeiculoServico()
    {
        // Arrange
        var context = ContextoBanco.CriarContextoDeTeste();
        TruncarTabela(context);

        var veiculo = new Veiculo();
        veiculo.Id = 1;
        veiculo.Ano = 1977;
        veiculo.Marca = "Chevrolet";
        veiculo.Nome = "Opala";

        var veiculoServico = new VeiculoServico(context);

        // Act
        veiculoServico.Incluir(veiculo);

        // Assert
        Assert.AreEqual(1, veiculoServico.Todos(1).Count());
    }

    [TestMethod]
    public void TestandoBuscaPorId_VeiculoServico()
    {
        // Arrange
        var context = ContextoBanco.CriarContextoDeTeste();
        TruncarTabela(context);

        var veiculo = new Veiculo();
        veiculo.Id = 1;
        veiculo.Ano = 1977;
        veiculo.Marca = "Chevrolet";
        veiculo.Nome = "Opala";

        var veiculoServico = new VeiculoServico(context);

        // Act
        veiculoServico.Incluir(veiculo);
        var veiculoSalvo = veiculoServico.BuscaPorId(veiculo.Id);

        // Assert
        Assert.AreEqual(1, veiculoSalvo?.Id);
    }

}
