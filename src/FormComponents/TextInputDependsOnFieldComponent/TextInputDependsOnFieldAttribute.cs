using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Xperience.DependingFieldComponents.FormComponents.TextInputDependsOnFieldComponent
{
    public class TextInputDependsOnFieldAttribute : FormComponentAttribute, IDependsOnFieldProperties
    {
        public string? FieldName { get; set; }

        public string? ExpectedValue { get; set; }
    }
}
