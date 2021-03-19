using System;

namespace ecuador.id.validator.Validators
{
    internal class ConsumidorFinalValidator : DocumentValidator
    {
        public const string FIXED_DOCUMENT_NUMBER = "9999999999999";

        public ConsumidorFinalValidator(string document) : base(document)
        {
            Type = DocumentType.Consumidor_Final;
        }

        public override DocumentType ValidateDocument()
        {
            //Although reaching this point means the document is already a 'consumidor final'
            //we validate again, and implement this class to keep the dev pattern.
            if (document.Equals(FIXED_DOCUMENT_NUMBER))
                return Type;

            throw new EcuadorIdValidationException("Not a valid document type");
        }

        internal override string GetOfficeNumber()
        {
            throw new NotImplementedException();
        }

        internal override int GetVerifyDigit()
        {
            throw new NotImplementedException();
        }

        internal override void ValidateAdditionalRules()
        {
            throw new NotImplementedException();
        }

        internal override void ValidateThirdDigit()
        {
            throw new NotImplementedException();
        }
    }
}