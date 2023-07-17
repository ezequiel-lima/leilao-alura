using Alura.LeilaoOnline.WebApp.Models;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.Interfaces
{
    public interface IHomeDao
    {
        IQueryable<CategoriaComInfoLeilao> BuscarCategoriasComInfoLeiloes();
        Categoria BuscarCategoriaPorId(int categoria);
        IQueryable<Leilao> BuscarLeiloesPorTermo(string termo);
    }
}
