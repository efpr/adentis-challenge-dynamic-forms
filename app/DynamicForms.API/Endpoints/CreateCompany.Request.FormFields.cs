namespace DynamicForms.Presentation.Endpoints
{
    public class CreateCompanyFieldsRequest
    {
        public string Label { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public CreateCompanyValidationRequest? Validation { get; set; }
        public IEnumerable<string>? Options { get; set; }
    }
}
