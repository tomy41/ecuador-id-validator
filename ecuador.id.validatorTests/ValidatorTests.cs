using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ecuador.id.validator.Tests
{
    [TestClass()]
    public class ValidatorTests
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"|DataDirectory|\TestData\cedula.csv", "cedula#csv", DataAccessMethod.Sequential)]
        [TestMethod()]
        public void ValidateDocumentTest_Cedula()
        {
            var document = TestContext.DataRow[0].ToString();
            var documentType = document.ValidateDocument();
            Assert.IsTrue(documentType == DocumentType.Cedula);
        }

        [TestMethod()]
        public void ValidateDocumentTest_ConsumidorFinal()
        {
            var document = "9999999999999";
            var documentType = document.ValidateDocument();
            Assert.IsTrue(documentType == DocumentType.Consumidor_Final);
        }

        [TestMethod()]
        [ExpectedException(typeof(EcuadorIdValidationException))]
        public void ValidateDocumentTest_InvalidDocument()
        {
            var document = "123456";
            document.ValidateDocument();
        }

        [TestMethod()]
        public void ValidateDocumentTest_IsDocumentValid()
        {
            var document = "1712648870";
            Assert.IsTrue(document.IsDocumentValid());
        }

        [TestMethod()]
        public void ValidateDocumentTest_Not_IsDocumentValid()
        {
            var document = "123456";
            Assert.IsFalse(document.IsDocumentValid());
        }

        [TestMethod()]
        public void ValidateDocumentTest_Not_Valid_ConsumidorFinal()
        {
            var document = "999999999999"; //length 12
            Assert.IsFalse(document.IsDocumentValid());
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"|DataDirectory|\TestData\ruc_juridico.csv", "ruc_juridico#csv", DataAccessMethod.Sequential)]
        [TestMethod()]
        public void ValidateDocumentTest_RucJuridico()
        {
            var document = TestContext.DataRow[0].ToString();
            var documentType = document.ValidateDocument();
            Assert.IsTrue(documentType == DocumentType.RUC_Juridico);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"|DataDirectory|\TestData\ruc_natural.csv", "ruc_natural#csv", DataAccessMethod.Sequential)]
        [TestMethod()]
        public void ValidateDocumentTest_RucNatural()
        {
            var document = TestContext.DataRow[0].ToString();
            var documentType = document.ValidateDocument();
            Assert.IsTrue(documentType == DocumentType.RUC_Natural);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"|DataDirectory|\TestData\ruc_publico.csv", "ruc_publico#csv", DataAccessMethod.Sequential)]
        [TestMethod()]
        public void ValidateDocumentTest_RucPublico()
        {
            var document = TestContext.DataRow[0].ToString();
            var documentType = document.ValidateDocument();
            Assert.IsTrue(documentType == DocumentType.RUC_Publico);
        }
    }
}