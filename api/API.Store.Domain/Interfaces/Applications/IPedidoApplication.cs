using API.Store.Domain.Dtos.Request;
using API.Store.Domain.Dtos.Responses;

namespace API.Store.Domain.Interfaces.Services
{
    public interface IPedidoApplication
    {
        Task<IEnumerable<PedidoDto>> GetAll();
        Task<PedidoDto?> GetById(int id);
        Task<bool> Insert(PedidoInsertRequest request);
        Task<bool> Update(PedidoUpdateRequest request);
        Task<bool> Delete(int id);
    }
}
