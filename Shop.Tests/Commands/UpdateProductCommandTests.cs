using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Domain.Commands.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Tests.Commands
{
    [TestClass]
    public class UpdateProductCommandTests
    {
        private UpdateProductCommand _validCommand;
        private UpdateProductCommand _invalidCommand;

        public UpdateProductCommandTests()
        {
            _validCommand = new UpdateProductCommand();
            _validCommand.Id = Guid.NewGuid();
            _validCommand.Name = "Produto de teste";
            _validCommand.Description = "Descrição produto de teste";
            _validCommand.Price = 100;

            _invalidCommand = new UpdateProductCommand();
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
