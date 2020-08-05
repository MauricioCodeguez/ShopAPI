using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Domain.Commands.Inputs;
using Shop.Domain.Handlers;
using Shop.Tests.Fakes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Tests.Handlers
{
    [TestClass]
    public class ProductHandlersTests
    {
        private FakeProductRepository _fakeProductRepository;
        private ProductHandler _handler;

        public ProductHandlersTests()
        {
            _fakeProductRepository = new FakeProductRepository();
            _handler = new ProductHandler(_fakeProductRepository);
        }

        [TestMethod]
        public void Should_Create_Product_When_Command_Is_Valid()
        {
            var command = new CreateProductCommand
            {
                Name = "Produto teste",
                Description = "Descrição produto teste",
                Price = 100
            };

            var result = _handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, _handler.Valid);
        }

        [TestMethod]
        public async Task Should_Not_Create_Product_When_Command_Is_InValid()
        {
            var command = new CreateProductCommand
            {
                Name = "Produto teste",
                Description = "Descrição produto teste"
            };

            await  _handler.Handle(command);

            Assert.AreEqual(true, command.Notifications.Count > 0);
            Assert.AreEqual(false, _handler.Valid);
        }

        [TestMethod]
        public void Should_Update_Product_When_Command_Is_Valid()
        {
            var products = _fakeProductRepository.GetAllAsync();
            var product = products.Result.FirstOrDefault();

            var command = new UpdateProductCommand
            {
                Id = product.Id,
                Name = "Produto teste",
                Description = "Descrição produto teste",
                Price = 100
            };

            var result = _handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, _handler.Valid);
        }

        [TestMethod]
        public async Task Should_Not_Update_Product_When_Command_Is_InValid()
        {
            var command = new UpdateProductCommand
            {
                Name = "Produto teste",
                Description = "Descrição produto teste",
                Price = 100
            };

            await _handler.Handle(command);

            Assert.AreEqual(true, command.Notifications.Count > 0);
            Assert.AreEqual(false, _handler.Valid);
        }

        [TestMethod]
        public async Task Should_Not_Create_Product_When_Product_Exists()
        {
            var products = _fakeProductRepository.GetAllAsync();
            var product = products.Result.FirstOrDefault();

            var command = new CreateProductCommand
            {
                Name = product.Name,
                Description = "Descrição produto teste",
                Price = 100
            };

            await _handler.Handle(command);

            Assert.AreEqual(true, _handler.Notifications.Count > 0);
            Assert.AreEqual(false, _handler.Valid);
        }

        [TestMethod]
        public void Should_Delete_Product_When_Product_Exists()
        {
            var products = _fakeProductRepository.GetAllAsync();
            var product = products.Result.FirstOrDefault();

            var result = _handler.DeleteProductHandler(product.Id);
            Assert.AreEqual(true, result.Result.Success);
        }

        [TestMethod]
        public void Should_Not_Delete_Product_When_Product_Not_Exists()
        {
            var result = _handler.DeleteProductHandler(Guid.NewGuid());
            Assert.AreEqual(false, result.Result.Success);
        }
    }
}
