using API.Store.Domain.Dtos.Request;
using API.Store.Domain.Dtos.Responses;
using API.Store.Domain.Interfaces.Services;
using API.Store.Domain.Models;

namespace API.Store.Application
{
    public class PedidoApplication : IPedidoApplication
    {
        private readonly IPedidoService _pedidoService;

        public PedidoApplication(IPedidoService pedidoService)
            => _pedidoService = pedidoService;

        public async Task<IEnumerable<PedidoDto>> GetAll()
        {
            var pedidos = await _pedidoService.GetAll();

            var pedidosDto = pedidos.Select(pedido => new PedidoDto
            {
                Id = pedido.Id,
                Pago = pedido.Pago,
                EmailCliente = pedido.EmailCliente,
                NomeCliente = pedido.NomeCliente,
                ValorTotal = pedido.ItensPedido.Sum(x => x.Quantidade * x.Produto.Valor),
                ItensPedido = pedido.ItensPedido.Select(itemPedido => new ItensPedidoDto
                {
                    Id = itemPedido.Id,
                    IdProduto = itemPedido.Produto.Id,
                    NomeProduto = itemPedido.Produto.NomeProduto,
                    ValorUnitario = itemPedido.Produto.Valor,
                    Quantidade = itemPedido.Quantidade,
                }).ToList()
            }).ToList();

            return pedidosDto;
        }

        public async Task<PedidoDto?> GetById(int id)
        {
            var pedido = await _pedidoService.GetById(id);

            if (pedido is null)
                return null;

            return new PedidoDto
            {
                Id = pedido.Id,
                Pago = pedido.Pago,
                EmailCliente = pedido.EmailCliente,
                NomeCliente = pedido.NomeCliente,
                ValorTotal = pedido.ItensPedido.Sum(x => x.Quantidade * x.Produto.Valor),
                ItensPedido = pedido.ItensPedido.Select(itemPedido => new ItensPedidoDto
                {
                    Id = itemPedido.Id,
                    IdProduto = itemPedido.Produto.Id,
                    NomeProduto = itemPedido.Produto.NomeProduto,
                    ValorUnitario = itemPedido.Produto.Valor,
                    Quantidade = itemPedido.Quantidade,
                }).ToList()
            };
        }

        public async Task<bool> Insert(PedidoInsertRequest request)
        {
            var pedido = new Pedido
            {
                NomeCliente = request.NomeCliente,
                EmailCliente = request.EmailCliente,
                DataCriacao = DateTime.UtcNow,
                Pago = false
            };

            var itensPedido = request.ItensPedido.Select(itemDto => new ItemPedido
            {
                Quantidade = itemDto.Quantidade,
                Produto = new Produto
                {
                    NomeProduto = itemDto.NomeProduto,
                    Valor = itemDto.ValorProduto
                }
            }).ToList();

            pedido.ItensPedido = itensPedido;

            var result = await _pedidoService.Insert(pedido);
            return result;
        }

        public async Task<bool> Update(PedidoUpdateRequest request)
        {
            var pedido = new Pedido
            {
                Id = request.Id,
                NomeCliente = request.NomeCliente,
                EmailCliente = request.EmailCliente,
                DataCriacao = DateTime.Now,
                Pago = request.Pago
            };

            var itensPedido = request.ItensPedido
                .Select(itemDto => new ItemPedido
                {
                    Id = itemDto.Id,
                    Quantidade = itemDto.Quantidade,
                    Produto = new Produto
                    {
                        Id = itemDto.IdProduto,
                        NomeProduto = itemDto.NomeProduto,
                        Valor = itemDto.ValorProduto
                    },
                })
                .ToList();

            pedido.ItensPedido = itensPedido;

            return await _pedidoService.Update(pedido);
        }

        public async Task<bool> Delete(int id)
            => await _pedidoService.Delete(id);
    }
}