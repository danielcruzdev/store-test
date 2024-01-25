using API.Store.Domain.Interfaces.Repositories;
using API.Store.Domain.Interfaces.Services;
using API.Store.Domain.Models;
using API.Store.Domain.Services;
using API.Store.Test.Helpers;
using AutoFixture;
using Moq;
using Shouldly;
using Xunit;

namespace API.Store.Test.Application
{
    public class PedidoServiceTest
    {
        private readonly IFixture _fixture;

        public PedidoServiceTest()
            => _fixture = AutoMoqFixtureFactory.CreateFixture();

        [Fact]
        [Trait("PedidoService", "GetAll_With_Data")]
        public async Task GetAll_With_Data()
        {
            #region Arrange

            var responseRepository = _fixture.CreateMany<Pedido>(20);
            var mockRepository = _fixture.Freeze<Mock<IPedidoRepository>>();
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(responseRepository);
            var mockApplication = _fixture.Create<PedidoService>();

            #endregion

            #region Act

            var result = await mockApplication.GetAll();

            #endregion

            #region Assert 

            result.ShouldNotBeEmpty();

            #endregion 
        }

        [Fact]
        [Trait("PedidoService", "GetAll_Without_Data")]
        public async Task GetAll_Without_Data()
        {
            #region Arrange

            var responseRepository = _fixture.CreateMany<Pedido>(0);
            var mockRepository = _fixture.Freeze<Mock<IPedidoService>>();
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(responseRepository);
            var mockApplication = _fixture.Create<PedidoService>();

            #endregion

            #region Act

            var result = await mockApplication.GetAll();

            #endregion

            #region Assert 

            result.ShouldBeEmpty();

            #endregion 
        }

        [Fact]
        [Trait("PedidoService", "GetAll_Without_Data")]
        public async Task GetAll_Exception()
        {
            #region Arrange
            var mockRepository = _fixture.Freeze<Mock<IPedidoService>>();
            mockRepository.Setup(x => x.GetAll()).Throws(new Exception());
            var mockApplication = _fixture.Create<PedidoService>();

            #endregion

            #region Act

            var result = await mockApplication.GetAll();

            #endregion

            #region Assert 

            result.ShouldBeEmpty();

            #endregion 
        }

        [Fact]
        [Trait("PedidoService", "GetById_With_Data")]
        public async Task GetById_With_Data()
        {
            #region Arrange

            var responseRepository = _fixture.Create<Pedido>();
            var mockRepository = _fixture.Freeze<Mock<IPedidoRepository>>();
            mockRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(responseRepository);
            var mockApplication = _fixture.Create<PedidoService>();

            #endregion

            #region Act

            var result = await mockApplication.GetById(It.IsAny<int>());

            #endregion

            #region Assert 

            result.ShouldNotBeNull();

            #endregion 
        }

        [Fact]
        [Trait("PedidoService", "GetById_Without_Data")]
        public async Task GetById_Without_Data()
        {
            #region Arrange

            Pedido responseRepository = null;
            var mockRepository = _fixture.Freeze<Mock<IPedidoService>>();
            mockRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(responseRepository);
            var mockApplication = _fixture.Create<PedidoService>();

            #endregion

            #region Act

            var result = await mockApplication.GetById(It.IsAny<int>());

            #endregion

            #region Assert 

            result.ShouldBeNull();

            #endregion 
        }

        [Fact]
        [Trait("PedidoService", "GetById_Exception")]
        public async Task GetById_Exception()
        {
            #region Arrange
            var mockRepository = _fixture.Freeze<Mock<IPedidoService>>();
            mockRepository.Setup(x => x.GetById(It.IsAny<int>())).Throws(new Exception());
            var mockApplication = _fixture.Create<PedidoService>();

            #endregion

            #region Act

            var result = await mockApplication.GetById(It.IsAny<int>());

            #endregion

            #region Assert 

            result.ShouldBeNull();

            #endregion 
        }

        [Fact]
        [Trait("PedidoService", "Insert_Sucess")]
        public async Task Insert_Sucess()
        {
            #region Arrange
            var mockRepository = _fixture.Freeze<Mock<IPedidoRepository>>();
            mockRepository.Setup(x => x.Insert(It.IsAny<Pedido>())).ReturnsAsync(true);
            var mockApplication = _fixture.Create<PedidoService>();

            #endregion

            #region Act

            var result = await mockApplication.Insert(It.IsAny<Pedido>());

            #endregion

            #region Assert 

            result.ShouldBeTrue();

            #endregion 
        }

        [Fact]
        [Trait("PedidoService", "Insert_Erro")]
        public async Task Insert_Erro()
        {
            #region Arrange
            var mockRepository = _fixture.Freeze<Mock<IPedidoRepository>>();
            mockRepository.Setup(x => x.Insert(It.IsAny<Pedido>())).ReturnsAsync(false);
            var mockApplication = _fixture.Create<PedidoService>();

            #endregion

            #region Act

            var result = await mockApplication.Insert(It.IsAny<Pedido>());

            #endregion

            #region Assert 

            result.ShouldBeFalse();

            #endregion 
        }

        [Fact]
        [Trait("PedidoService", "Insert_Exception")]
        public async Task Insert_Exception()
        {
            #region Arrange
            var mockRepository = _fixture.Freeze<Mock<IPedidoRepository>>();
            mockRepository.Setup(x => x.Insert(It.IsAny<Pedido>())).Throws(new Exception());
            var mockApplication = _fixture.Create<PedidoService>();

            #endregion

            #region Act

            var result = await mockApplication.Insert(It.IsAny<Pedido>());

            #endregion

            #region Assert 

            result.ShouldBeFalse();

            #endregion 
        }

        [Fact]
        [Trait("PedidoService", "Update_Sucess")]
        public async Task Update_Sucess()
        {
            #region Arrange
            var pedido = new Pedido
            {
                Id = 1,
                DataCriacao = DateTime.Now,
                EmailCliente = "d.afc98@yahoo.com",
                NomeCliente = "Daniel Cruz",
                Pago = true,
                ItensPedido = new List<ItemPedido> 
                { 
                    new() {
                        Id = 1,
                        IdPedido = 1,
                        IdProduto= 1,
                        Produto = new Produto { Id = 1, NomeProduto = "Notebook", Valor = 5999.99M },
                        Quantidade = 10
                        }
                }
            };

            var mockPedidoRepository = _fixture.Freeze<Mock<IPedidoRepository>>();
            var mockProdutoRepository = _fixture.Freeze<Mock<IProdutoRepository>>();
            var mockItemPedidoRepository = _fixture.Freeze<Mock<IItemPedidoRepository>>();

            mockPedidoRepository.Setup(x => x.Update(It.IsAny<Pedido>())).ReturnsAsync(true);
            mockProdutoRepository.Setup(x => x.Update(It.IsAny<Produto>())).ReturnsAsync(true);
            mockItemPedidoRepository.Setup(x => x.Update(It.IsAny<ItemPedido>())).ReturnsAsync(true);

            var mockApplication = _fixture.Create<PedidoService>();

            #endregion

            #region Act

            var result = await mockApplication.Update(pedido);

            #endregion

            #region Assert 

            result.ShouldBeTrue();

            #endregion 
        }

        [Fact]
        [Trait("PedidoService", "Update_Erro")]
        public async Task Update_Erro()
        {
            #region Arrange
            var pedido = new Pedido
            {
                Id = 1,
                DataCriacao = DateTime.Now,
                EmailCliente = "d.afc98@yahoo.com",
                NomeCliente = "Daniel Cruz",
                Pago = true,
                ItensPedido = new List<ItemPedido>
                {
                    new() {
                        Id = 1,
                        IdPedido = 1,
                        IdProduto= 1,
                        Produto = new Produto { Id = 1, NomeProduto = "Notebook", Valor = 5999.99M },
                        Quantidade = 10
                        }
                }
            };

            var mockPedidoRepository = _fixture.Freeze<Mock<IPedidoRepository>>();
            var mockProdutoRepository = _fixture.Freeze<Mock<IProdutoRepository>>();
            var mockItemPedidoRepository = _fixture.Freeze<Mock<IItemPedidoRepository>>();

            mockPedidoRepository.Setup(x => x.Update(It.IsAny<Pedido>())).ReturnsAsync(false);
            mockProdutoRepository.Setup(x => x.Update(It.IsAny<Produto>())).ReturnsAsync(false);
            mockItemPedidoRepository.Setup(x => x.Update(It.IsAny<ItemPedido>())).ReturnsAsync(false);

            var mockApplication = _fixture.Create<PedidoService>();

            #endregion
            
            #region Act

            var result = await mockApplication.Update(pedido);

            #endregion

            #region Assert 

            result.ShouldBeFalse();

            #endregion 
        }

        [Fact]
        [Trait("PedidoService", "Update_Exception")]
        public async Task Update_Exception()
        {
            #region Arrange

            var mockPedidoRepository = _fixture.Freeze<Mock<IPedidoRepository>>();

            mockPedidoRepository.Setup(x => x.Update(It.IsAny<Pedido>())).Throws(new Exception());

            var mockApplication = _fixture.Create<PedidoService>();

            #endregion

            #region Act

            var result = await mockApplication.Update(It.IsAny<Pedido>());

            #endregion

            #region Assert 

            result.ShouldBeFalse();

            #endregion 
        }
    }
}
