using ecuador.id.validator.Validators;

namespace ecuador.id.validator
{
    public enum DocumentType
    {
        Cedula,
        RUC_Natural,
        RUC_Publico,
        RUC_Juridico,
        Consumidor_Final
    }

    internal static class DocumentTypeValidator
    {
        private const int RUC_JURIDICO_THIRD_DIGIT = 9;
        private const int RUC_PUBLICO_THIRD_DIGIT = 6;

        internal static DocumentValidator GetDocumentValidator(string document)
        {
            switch (document.Length)
            {
                case 10:
                    return new CedulaValidator(document);

                case 13:
                    return Get13LengthValidator(document);
            }

            throw new EcuadorIdValidationException("Not a valid document type");
        }

        private static DocumentValidator Get13LengthValidator(string document)
        {
            if (document.Equals(ConsumidorFinalValidator.FIXED_DOCUMENT_NUMBER))
                return new ConsumidorFinalValidator(document);

            var thirdDigit = int.Parse(document.Substring(2, 1));
            switch (thirdDigit)
            {
                case RUC_JURIDICO_THIRD_DIGIT:
                    return new RucJuridicoValidator(document);

                case RUC_PUBLICO_THIRD_DIGIT:
                    return new RucPublicoValidator(document);

                default:
                    if (thirdDigit < 6)
                        return new RucNaturalValidator(document);
                    break;
            }

            throw new EcuadorIdValidationException("Not a valid RUC type");
        }
    }
}