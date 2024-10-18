
namespace DynamicForms.Core.ValueObj
{
    public class InputTypes
    {
        public static readonly Dictionary<string, byte?> AllowedTypes = new()
        {
            { "text", null },
            { "number", null },
            { "date", null },
            { "email", null },
            { "password", null },
            { "checkbox", null },
            { "radio", null },
            { "select", null },
            { "multiselect", null },
            { "textarea", null }
        };
    }
}
