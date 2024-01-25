using API.Store.Application;
using API.Store.Domain.Dtos.Request;
using API.Store.Domain.Interfaces.Services;
using API.Store.Domain.Models;
using API.Store.Test.Helpers;
using AutoFixture;
using Moq;
using Shouldly;
using Xunit;

namespace API.Store.Test.Application
{
    public class PedidoApplicationTest
    {
        private readonly IFixture _fixture;

        public PedidoApplicationTest()
            => _fixture = AutoMoqFixtureFactory.CreateFixture();

        [Fact]
        [Trait("PedidoApplication", "GetAll_With_Data")]
        public async Task GetAll_With_Data()
        {
            #region Arrange

            var responseService = _fixture.CreateMany<Pedido>(20);
            var mockService = _fixture.Freeze<Mock<IPedidoService>>();
            mockService.Setup(x => x.GetAll()).ReturnsAsync(responseService);
            var mockApplication = _fixture.Create<PedidoApplication>();

            #endregion

            #region Act

            var result = await mockApplication.GetAll();

            #endregion

            #region Assert 

            result.ShouldNotBeEmpty();

            #endregion 
        }

        [Fact]
        [Trait("PedidoApplication", "GetAll_Without_Data")]
        public async Task GetAll_Without_Data()
        {
            #region Arrange

            var responseService = _fixture.CreateMany<Pedido>(0);
            var mockService = _fixture.Freeze<Mock<IPedidoService>>();
            mockService.Setup(x => x.GetAll()).ReturnsAsync(responseService);
            var mockApplication = _fixture.Create<PedidoApplication>();

            #endregion

            #region Act

            var result = await mockApplication.GetAll();

            #endregion

            #region Assert 

            result.ShouldBeEmpty();

            #endregion 
        }

        [Fact]
        [Trait("PedidoApplication", "GetAll_With_Data")]
        public async Task GetById_With_Data()
        {
            #region Arrange

            var responseService = _fixture.Create<Pedido>();
            var mockService = _fixture.Freeze<Mock<IPedidoService>>();
            mockService.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(responseService);
            var mockApplication = _fixture.Create<PedidoApplication>();

            #endregion

            #region Act

            var result = await mockApplication.GetById(It.IsAny<int>());

            #endregion

            #region Assert 

            result.ShouldNotBeNull();

            #endregion 
        }

        [Fact]
        [Trait("PedidoApplication", "GetById_Without_Data")]
        public async Task GetById_Without_Data()
        {
            #region Arrange
            Pedido responseService = null;
            var mockService = _fixture.Freeze<Mock<IPedidoService>>();
            mockService.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(responseService);
            var mockApplication = _fixture.Create<PedidoApplication>();

            #endregion

            #region Act

            var result = await mockApplication.GetById(It.IsAny<int>());

            #endregion

            #region Assert 

            result.ShouldBeNull();

            #endregion 
        }

        [Fact]
        [Trait("PedidoApplication", "Insert_Sucess")]
        public async Task Insert_Sucess()
        {
            #region Arrange
            var mockRequest = new PedidoInsertRequest 
            {
                EmailCliente = "TESTE@gmail.com",
                NomeCliente = "TESTE SILVA SILVA",
                ItensPedido = new List<ItensPedidoInsertRequest> 
                {
                    new ItensPedidoInsertRequest 
                    {
                        NomeProduto = "Notebook",
                        Quantidade = 2,
                        ValorProduto = 56709.99M
                    }
                }
            };

            var mockService = _fixture.Freeze<Mock<IPedidoService>>();
            mockService.Setup(x => x.Insert(It.IsAny<Pedido>())).ReturnsAsync(true);
            var mockApplication = _fixture.Create<PedidoApplication>();

            #endregion

            #region Act

            var result = await mockApplication.Insert(mockRequest);

            #endregion

            #region Assert 

            result.ShouldBeTrue();

            #endregion 
        }

        [Fact]
        [Trait("PedidoApplication", "Insert_Erro")]
        public async Task Insert_Erro()
        {
            #region Arrange
            var mockRequest = new PedidoInsertRequest
            {
                EmailCliente = "TESTE@gmail.com",
                NomeCliente = "TESTE SILVA SILVA",
                ItensPedido = new List<ItensPedidoInsertRequest>
                {
                    new ItensPedidoInsertRequest
                    {
                        NomeProduto = "Notebook",
                        Quantidade = 2,
                        ValorProduto = 56709.99M
                    }
                }
            };

            var mockEntity = _fixture.Create<Pedido>();
            var mockService = _fixture.Freeze<Mock<IPedidoService>>();
            mockService.Setup(x => x.Insert(mockEntity)).ReturnsAsync(false);
            var mockApplication = _fixture.Create<PedidoApplication>();

            #endregion

            #region Act

            var result = await mockApplication.Insert(mockRequest);

            #endregion

            #region Assert 

            result.ShouldBeFalse();

            #endregion 
        }

        [Fact]
        [Trait("PedidoApplication", "Update_Sucess")]
        public async Task Update_Sucess()
        {
            #region Arrange

            var mockRequest = new PedidoUpdateRequest
            {
                Id = 1,
                Pago = true,
                EmailCliente = "TESTE@gmail.com",
                NomeCliente = "TESTE SILVA SILVA",
                ItensPedido = new List<ItensPedidoUpdateRequest>
                {
                    new ItensPedidoUpdateRequest
                    {
                        Id = 1,
                        IdProduto = 1,
                        NomeProduto = "Notebook",
                        Quantidade = 2,
                        ValorProduto = 56709.99M
                    }
                }
            };

            var mockService = _fixture.Freeze<Mock<IPedidoService>>();
            mockService.Setup(x => x.Update(It.IsAny<Pedido>())).ReturnsAsync(true);
            var mockApplication = _fixture.Create<PedidoApplication>();

            #endregion

            #region Act

            var result = await mockApplication.Update(mockRequest);

            #endregion

            #region Assert 

            result.ShouldBeTrue();

            #endregion 
        }

        [Fact]
        [Trait("PedidoApplication", "Update_Erro")]
        public async Task Update_Erro()
        {
            #region Arrange
            var mockRequest = new PedidoUpdateRequest
            {
                EmailCliente = "TESTE@gmail.com",
                NomeCliente = "TESTE SILVA SILVA",
                ItensPedido = new List<ItensPedidoUpdateRequest>
                {
                    new ItensPedidoUpdateRequest
                    {
                        NomeProduto = "Notebook",
                        Quantidade = 2,
                        ValorProduto = 56709.99M
                    }
                }
            };

            var mockEntity = _fixture.Create<Pedido>();
            var mockService = _fixture.Freeze<Mock<IPedidoService>>();
            mockService.Setup(x => x.Update(mockEntity)).ReturnsAsync(false);
            var mockApplication = _fixture.Create<PedidoApplication>();

            #endregion

            #region Act

            var result = await mockApplication.Update(mockRequest);

            #endregion

            #region Assert 

            result.ShouldBeFalse();

            #endregion 
        }

        [Fact]
        [Trait("PedidoApplication", "Delete_Sucess")]
        public async Task Delete_Sucess()
        {
            #region Arrange

            var mockService = _fixture.Freeze<Mock<IPedidoService>>();
            mockService.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(true);
            var mockApplication = _fixture.Create<PedidoApplication>();

            #endregion

            #region Act

            var result = await mockApplication.Delete(It.IsAny<int>());

            #endregion

            #region Assert 

            result.ShouldBeTrue();

            #endregion 
        }

        [Fact]
        [Trait("PedidoApplication", "Delete_Erro")]
        public async Task Delete_Erro()
        {
            #region Arrange

            var mockService = _fixture.Freeze<Mock<IPedidoService>>();
            mockService.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(false);
            var mockApplication = _fixture.Create<PedidoApplication>();

            #endregion

            #region Act

            var result = await mockApplication.Delete(It.IsAny<int>());

            #endregion

            #region Assert 

            result.ShouldBeFalse();

            #endregion 
        }
    }
}
