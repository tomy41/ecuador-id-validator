using System.Text.RegularExpressions;

namespace ecuador.id.validator.Validators
{
    internal abstract class DocumentValidator
    {
        protected string document;
        protected IModuleValidator ModuleValidator;
        protected DocumentType Type;

        public DocumentValidator(string document)
        {
            this.document = document;
        }

        public virtual DocumentType ValidateDocument()
        {
            ValidateDocumentFormat();
            ValidateProvince();
            ValidateThirdDigit();
            ValidateModule(ModuleValidator);
            ValidateAdditionalRules();
            return Type;
        }

        internal abstract string GetOfficeNumber();

        internal abstract int GetVerifyDigit();

        internal abstract void ValidateAdditionalRules();

        internal abstract void ValidateThirdDigit();

        protected void ValidateDocumentFormat()
        {
            document = document.Trim();
            var formatPattern = new Regex(@"[0-9]{10}|[0-9]{13}", RegexOptions.IgnoreCase);

            if (!formatPattern.Match(document).Success)
                throw new EcuadorIdValidationException("Document format is not valid");
        }

        protected void ValidateOfficeNumber()
        {
            var officeNumber = GetOfficeNumber();
            int.TryParse(officeNumber, out int parsedOfficeNumber);

            if (parsedOfficeNumber == 0)
                throw new EcuadorIdValidationException("Office number is not valid.");
        }

        private void ValidateModule(IModuleValidator moduleValidator)
        {
            var moduleResult = moduleValidator.CalculateModule(document);
            var verifyDigit = GetVerifyDigit();

            if (moduleResult != verifyDigit)
                throw new EcuadorIdValidationException();
        }

        private void ValidateProvince()
        {
            const int MIN_PROVINCE_CODE = 1;
            const int MAX_PROVINCE_CODE = 24;
            const int FOREIGNER_PROVINCE_CODE = 30;

            var provinceDigits = int.Parse(document.Substring(0, 2));
            if ((provinceDigits < MIN_PROVINCE_CODE || provinceDigits > MAX_PROVINCE_CODE) && provinceDigits != FOREIGNER_PROVINCE_CODE)
                throw new EcuadorIdValidationException("Document does not belong to any province or foreigner person.");
        }
    }
}