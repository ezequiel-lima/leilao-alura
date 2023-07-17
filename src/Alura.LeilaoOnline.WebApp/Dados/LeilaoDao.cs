using Alura.LeilaoOnline.WebApp.Dados.Interfaces;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public class LeilaoDao : ILeilaoDao
    {
        AppDbContext _context;

        public LeilaoDao()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Categoria> BuscarCategorias()
        {
            return _context.Categorias.ToList();
        }

        public IEnumerable<Leilao> BuscarLeiloes()
        {
            return _context.Leiloes.Include(x => x.Categoria).ToList();
        }

        public IEnumerable<Leilao> BuscarLeiloesPorTermo(string termo)
        {
            return _context.Leiloes
                .Include(x => x.Categoria)
                .Where(x => string.IsNullOrWhiteSpace(termo) ||
                    x.Titulo.ToUpper().Contains(termo.ToUpper()) ||
                    x.Descricao.ToUpper().Contains(termo.ToUpper()) ||
                    x.Categoria.Descricao.ToUpper().Contains(termo.ToUpper())
                );
        }

        public Leilao BuscarPorId(int id)
        {
            return _context.Leiloes.FirstOrDefault(x => x.Id == id);
        }

        public void Incluir(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }

        public void Alterar(Leilao leilao)
        {
            _context.Leiloes.Update(leilao);
            _context.SaveChanges();
        }

        public void Excluir(Leilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }
    }
}
