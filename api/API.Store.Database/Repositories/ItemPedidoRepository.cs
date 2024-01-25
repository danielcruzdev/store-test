using API.Store.Database.Contexts;
using API.Store.Domain.Interfaces.Repositories;
using API.Store.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Store.Database.Repositories
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly StoreDbContext _context;

        public ItemPedidoRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Update(ItemPedido itemPedido)
        {
            try
            {
                _context.ItensPedidos.Update(itemPedido);
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
