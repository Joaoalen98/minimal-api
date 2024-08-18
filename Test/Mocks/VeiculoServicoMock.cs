using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;

namespace Test.Mocks;

public class VeiculoServicoMock : IVeiculoServico
{
    private readonly List<Veiculo> veiculos = new List<Veiculo>();

    public void Apagar(Veiculo veiculo)
    {
        veiculos.Remove(veiculo);
    }

    public void Atualizar(Veiculo veiculo)
    {
        throw new NotImplementedException();
    }

    public Veiculo? BuscaPorId(int id)
    {
        return veiculos.Find(x => x.Id == id);
    }

    public void Incluir(Veiculo veiculo)
    {
        veiculos.Add(veiculo);
    }

    public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
    {        
        IEnumerable<Veiculo> veiculos = new List<Veiculo>();

        if(!string.IsNullOrEmpty(nome))
        {
            veiculos = veiculos.Where(v => v.Nome.Contains(nome));
        }

        int itensPorPagina = 10;

        if(pagina != null)
            veiculos = veiculos.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);

        return veiculos.ToList();
    }
}
