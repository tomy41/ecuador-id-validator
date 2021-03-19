namespace ecuador.id.validator.Validators
{
  internal class RucPublicoValidator : DocumentValidator
  {
    private const int VALID_THIRD_DIGIT = 6;

    public RucPublicoValidator(string document) : base(document)
    {
      Type = DocumentType.RUC_Publico;
      ModuleValidator = new Module11Validator(new int[] { 3, 2, 7, 6, 5, 4, 3, 2 });
    }

    internal override string GetOfficeNumber()
    {
      return document.Substring(9, 4);
    }

    internal override int GetVerifyDigit()
    {
      return int.Parse(document.Substring(8, 1));
    }

    internal override void ValidateAdditionalRules()
    {
      ValidateOfficeNumber();
    }

    internal override void ValidateThirdDigit()
    {
      var thirdDigit = int.Parse(document.Substring(2, 1));
      if (thirdDigit != VALID_THIRD_DIGIT)
        throw new EcuadorIdValidationException();
    }
  }
}