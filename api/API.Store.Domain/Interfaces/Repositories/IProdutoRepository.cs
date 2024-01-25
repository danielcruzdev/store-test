using API.Store.Domain.Models;

namespace API.Store.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        Task<bool> Update(Produto produto);
    }
}
