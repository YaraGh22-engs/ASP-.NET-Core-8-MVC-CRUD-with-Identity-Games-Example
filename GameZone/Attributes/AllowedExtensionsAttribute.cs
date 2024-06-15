namespace GameZone.Attributes
{
    public class AllowedExtensionsAttribute :ValidationAttribute
    {
        private readonly string _allowedExtensions;

        public AllowedExtensionsAttribute(string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);

                var IsAllowed = _allowedExtensions.Split(',').Contains(extention , StringComparer.OrdinalIgnoreCase);
                if (!IsAllowed)
                {
                    return new ValidationResult($"Only {_allowedExtensions} are allowed!");
                }
            }

            return ValidationResult.Success;
        }
    }
}
