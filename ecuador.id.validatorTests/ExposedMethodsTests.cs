using ecuador.id.validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ecuador.id.validatorTests
{
    [TestClass()]
    public class ExposedMethodsTests
    {
        [TestMethod()]
        public void IsDocumentValidTest_False()
        {
            var document = "1234567890";
            Assert.IsFalse(document.IsDocumentValid());
        }

        [TestMethod()]
        public void IsDocumentValidTest_True()
        {
            var document = "1712648870";
            Assert.IsTrue(document.IsDocumentValid());
        }

        [TestMethod()]
        public void TryGetDocumentType_False()
        {
            var document = "1234567890";
            Assert.IsFalse(EcuadorIdValidator.TryGetDocumentType(document, out DocumentType? resultType));
            Assert.IsNull(resultType);
        }

        [TestMethod()]
        public void TryGetDocumentType_True()
        {
            var document = "1712648870";
            Assert.IsTrue(EcuadorIdValidator.TryGetDocumentType(document, out DocumentType? resultType));
            Assert.IsNotNull(resultType);
        }

        [TestMethod()]
        public void ValidateDocumentTest()
        {
            var document = "1712648870";
            var documentType = document.ValidateDocument();
            Assert.IsTrue(documentType == DocumentType.Cedula);
        }

        [TestMethod()]
        public void ValidateDocumentTest_Exception()
        {
            var document = "1234567890";
            Assert.ThrowsException<EcuadorIdValidationException>(() => document.ValidateDocument());
        }
    }
}