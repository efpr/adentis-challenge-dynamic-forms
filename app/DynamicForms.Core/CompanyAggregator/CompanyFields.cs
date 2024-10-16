
namespace DynamicForms.Core.CompanyAggregator
{
    public class CompanyFields
    {
        public string Label { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public Validation? Validation { get; set; }
        public IEnumerable<string>? Options { get; set; }
    }
}
