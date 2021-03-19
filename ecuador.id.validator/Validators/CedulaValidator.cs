namespace ecuador.id.validator.Validators
{
  internal class CedulaValidator : DocumentValidator
  {
    //private const int MIN_THIRD_DIGIT = 0;
    //private const int MAX_THIRD_DIGIT = 5;

    public CedulaValidator(string document) : base(document)
    {
      Type = DocumentType.Cedula;
      ModuleValidator = new Module10Validator();
    }

    internal override string GetOfficeNumber()
    {
      return document.Substring(10, 3);
    }

    internal override int GetVerifyDigit()
    {
      return int.Parse(document.Substring(9, 1));
    }

    internal override void ValidateAdditionalRules()
    {
    }

    internal override void ValidateThirdDigit()
    {
      //New third digits are been added so this validation has no longer effect.
      //var thirdDigit = int.Parse(document.Substring(2, 1));
      //if (thirdDigit < MIN_THIRD_DIGIT || thirdDigit > MAX_THIRD_DIGIT)
      //    throw new EcuadorIdValidationException();
    }
  }
}