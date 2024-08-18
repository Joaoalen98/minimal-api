using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedades_EntidadeVeiculo()
    {
        // Arrange
        var veiculo = new Veiculo();

        // Act
        veiculo.Id = 1;
        veiculo.Ano = 1977;
        veiculo.Marca = "Chevrolet";
        veiculo.Nome = "Opala";

        // Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual(1977, veiculo.Ano);
        Assert.AreEqual("Chevrolet", veiculo.Marca);
        Assert.AreEqual("Opala", veiculo.Nome);
    }
}
