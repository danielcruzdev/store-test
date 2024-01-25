using API.Store.Database.Contexts;
using API.Store.Domain.Interfaces.Repositories;
using API.Store.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Store.Database.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly StoreDbContext _context;

        public PedidoRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pedido>> GetAll()
        {
            return await _context.Pedidos
                                 .AsNoTracking()
                                 .Include(x => x.ItensPedido)
                                 .ThenInclude(x => x.Produto)
                                 .ToListAsync();
        }

        public async Task<Pedido?> GetById(int id)
        {
            return await _context.Pedidos
                                 .AsNoTracking()
                                 .Include(x => x.ItensPedido)
                                 .ThenInclude(x => x.Produto)
                                 .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<bool> Insert(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
