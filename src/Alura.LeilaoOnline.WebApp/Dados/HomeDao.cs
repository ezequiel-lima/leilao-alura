using Alura.LeilaoOnline.WebApp.Dados.Interfaces;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public class HomeDao : IHomeDao
    {
        AppDbContext _context;

        public HomeDao()
        {
            _context = new AppDbContext();
        }

        public IQueryable<CategoriaComInfoLeilao> BuscarCategoriasComInfoLeiloes()
        {
            return _context.Categorias
                .Include(c => c.Leiloes)
                .Select(c => new CategoriaComInfoLeilao
                {
                    Id = c.Id,
                    Descricao = c.Descricao,
                    Imagem = c.Imagem,
                    EmRascunho = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Rascunho).Count(),
                    EmPregao = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Pregao).Count(),
                    Finalizados = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Finalizado).Count(),
                });
        }

        public Categoria BuscarCategoriaPorId(int categoria)
        {
            return _context.Categorias
                .Include(c => c.Leiloes)
                .First(c => c.Id == categoria);
        }

        public IQueryable<Leilao> BuscarLeiloesPorTermo(string termo)
        {
            var termoNormalized = termo.ToUpper();

            return _context.Leiloes
                .Where(c =>
                    c.Titulo.ToUpper().Contains(termoNormalized) ||
                    c.Descricao.ToUpper().Contains(termoNormalized) ||
                    c.Categoria.Descricao.ToUpper().Contains(termoNormalized));
        }
    }
}
