using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.Interfaces
{
    public interface ILeilaoDao
    {
        IEnumerable<Categoria> BuscarCategorias();
        IEnumerable<Leilao> BuscarLeiloes();
        IEnumerable<Leilao> BuscarLeiloesPorTermo(string termo);
        Leilao BuscarPorId(int id);
        void Incluir(Leilao leilao);
        void Alterar(Leilao leilao);
        void Excluir(Leilao leilao);
    }
}
