using System;

namespace ecuador.id.validator
{
    public static class EcuadorIdValidator
    {
        public static bool IsDocumentValid(this string document)
        {
            try
            {
                DocumentTypeValidator.GetDocumentValidator(document).ValidateDocument();
                return true;
            }
            catch (EcuadorIdValidationException)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw new EcuadorIdValidationException(ex.Message);
            }
        }

        public static bool TryGetDocumentType(string document, out DocumentType? type)
        {
            try
            {
                type = DocumentTypeValidator.GetDocumentValidator(document).ValidateDocument();
                return true;
            }
            catch
            {
            }
            type = null;
            return false;
        }

        public static DocumentType ValidateDocument(this string document)
        {
            document = document.Trim();
            return DocumentTypeValidator.GetDocumentValidator(document).ValidateDocument();
        }
    }
}