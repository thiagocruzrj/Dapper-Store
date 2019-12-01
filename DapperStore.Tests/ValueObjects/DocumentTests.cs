using DapperStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperStore.Tests
{
    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document invalidDocument;
        public DocumentTests()
        {
            validDocument = new Document("14220929762");
            invalidDocument = new Document("12345678910");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            // invalid cpf
            Assert.AreEqual(false, invalidDocument.IsValid);
        }

        [TestMethod]
        public void ShouldNotReturnNotificationWhenDocumentIsNotValid()
        {
            // valid cpf
            Assert.AreEqual(true, validDocument.IsValid);
        }
    }
}
