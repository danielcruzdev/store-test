using API.Store.Domain.Models;

namespace API.Store.Domain.Interfaces.Repositories
{
    public interface IItemPedidoRepository
    {
        Task<bool> Update(ItemPedido itemPedido);
    }
}
