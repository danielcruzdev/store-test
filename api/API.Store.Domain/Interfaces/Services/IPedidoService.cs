using API.Store.Domain.Models;

namespace API.Store.Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> GetAll();
        Task<Pedido?> GetById(int id);
        Task<bool> Insert(Pedido pedido);
        Task<bool> Update(Pedido pedido);
        Task<bool> Delete(int id);
    }
}
