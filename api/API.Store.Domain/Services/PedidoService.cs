using API.Store.Domain.Interfaces.Repositories;
using API.Store.Domain.Interfaces.Services;
using API.Store.Domain.Models;

namespace API.Store.Domain.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public PedidoService(IPedidoRepository pedidoRepository,
                             IItemPedidoRepository itemPedidoRepository,
                             IProdutoRepository produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _itemPedidoRepository = itemPedidoRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Pedido>> GetAll()
        {
            try
            {
                return await _pedidoRepository.GetAll();
            }
            catch (Exception)
            {
                //Nessa parte poderia entrar algum log de monitoramento via Kibana/DataDog/Dynatrace 
                return Enumerable.Empty<Pedido>();
            }
        }

        public async Task<Pedido?> GetById(int id)
        {
            try
            {
                return await _pedidoRepository.GetById(id);
            }
            catch (Exception)
            {
                //Nessa parte poderia entrar algum log de monitoramento via Kibana/DataDog/Dynatrace 
                return null;
            }
        }

        public async Task<bool> Insert(Pedido pedido)
        {
            try
            {
                return await _pedidoRepository.Insert(pedido);
            }
            catch (Exception)
            {
                //Nessa parte poderia entrar algum log de monitoramento via Kibana/DataDog/Dynatrace 
                return false;
            }
        }

        public async Task<bool> Update(Pedido pedido)
        {
            try
            {
                bool success = await _pedidoRepository.Update(pedido);

                var updateTasks = pedido.ItensPedido
                    .Select(itemPedido => UpdateItemPedidoAndProduto(itemPedido));

                bool[] results = await Task.WhenAll(updateTasks);
                success &= results.All(result => result);

                return success;
            }
            catch (Exception)
            {
                //Nessa parte poderia entrar algum log de monitoramento via Kibana/DataDog/Dynatrace 
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                if (await _pedidoRepository.GetById(id) is Pedido found)
                    return await _pedidoRepository.Delete(found);

                return false;
            }
            catch (Exception)
            {
                //Nessa parte poderia entrar algum log de monitoramento via Kibana/DataDog/Dynatrace 
                return false;
            }
        }

        private async Task<bool> UpdateItemPedidoAndProduto(ItemPedido itemPedido)
        {
            bool successItemPedido = await _itemPedidoRepository.Update(itemPedido);
            bool successProduto = await _produtoRepository.Update(itemPedido.Produto);

            return successItemPedido && successProduto;
        } 
    }
}
