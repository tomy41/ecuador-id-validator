namespace ecuador.id.validator.Validators
{
  internal class RucNaturalValidator : DocumentValidator
  {
    //private const int MIN_THIRD_DIGIT = 0;
    //private const int MAX_THIRD_DIGIT = 5;

    public RucNaturalValidator(string document) : base(document)
    {
      Type = DocumentType.RUC_Natural;
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
      ValidateOfficeNumber();
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