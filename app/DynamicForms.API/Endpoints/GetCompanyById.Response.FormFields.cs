namespace DynamicForms.Presentation.Endpoints
{
    public class GetCompanyFieldsResponse
    {
        public string Label { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public GetCompanyValidationResponse? Validation { get; set; }
        public IEnumerable<string>? Options { get; set; }
    }
}
