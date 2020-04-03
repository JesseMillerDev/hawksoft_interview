using BlazorBoilerplate.Server.Managers;
using BlazorBoilerplate.Shared.DataInterfaces;
using Moq;
using NUnit.Framework;

namespace BlazorBoilerplate.Server.Tests.Managers
{
    [TestFixture]
    class ToDoManagerTests
    {
        private ContactManager _toDoManager;

        private Mock<IContactStore> _toDoStore;

        [SetUp]
        public void SetUp()
        {
            _toDoStore = new Mock<IContactStore>();

            _toDoManager = new ContactManager(_toDoStore.Object);
        }

        [Test]
        public void SetupWorked()
        {
            Assert.Pass();
        }
    }
}
