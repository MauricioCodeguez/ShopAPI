using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Domain.Commands.Inputs;

namespace Shop.Tests.Commands
{
    [TestClass]
    public class CreateProductCommandTests
    {
        private CreateProductCommand _validCommand;
        private CreateProductCommand _invalidCommand;

        public CreateProductCommandTests()
        {
            _validCommand = new CreateProductCommand();
            _validCommand.Name = "Produto de teste";
            _validCommand.Description = "Descrição produto de teste";
            _validCommand.Price = 100;

            _invalidCommand = new CreateProductCommand();
            _invalidCommand.Name = "1";
            _invalidCommand.Description = "Descrição";
        }

        [TestMethod]
        public void Should_Validate_When_Command_Is_Valid()
        {
            Assert.AreEqual(true, _validCommand.IsValid());
        }

        [TestMethod]
        public void Should_Not_Validate_When_Command_Is_Valid()
        {
            Assert.AreEqual(false, _invalidCommand.IsValid());
        }
    }
}
