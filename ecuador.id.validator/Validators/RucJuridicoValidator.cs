namespace ecuador.id.validator.Validators
{
  internal class RucJuridicoValidator : DocumentValidator
  {
    private const int VALID_THIRD_DIGIT = 9;

    public RucJuridicoValidator(string document) : base(document)
    {
      Type = DocumentType.RUC_Juridico;
      ModuleValidator = new Module11Validator(new int[] { 4, 3, 2, 7, 6, 5, 4, 3, 2 });
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
      var thirdDigit = int.Parse(document.Substring(2, 1));
      if (thirdDigit != VALID_THIRD_DIGIT)
        throw new EcuadorIdValidationException();
    }
  }
}