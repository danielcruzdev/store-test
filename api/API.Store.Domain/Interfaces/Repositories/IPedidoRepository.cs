using API.Store.Domain.Models;

namespace API.Store.Domain.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetAll();
        Task<Pedido?> GetById(int id);
        Task<bool> Insert(Pedido pedido);
        Task<bool> Update(Pedido pedido);
        Task<bool> Delete(Pedido pedido);
    }
}
