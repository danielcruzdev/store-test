using API.Store.Database.Contexts;
using API.Store.Domain.Interfaces.Repositories;
using API.Store.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Store.Database.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly StoreDbContext _context;

        public ProdutoRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Update(Produto produto)
        {
            try
            {
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
