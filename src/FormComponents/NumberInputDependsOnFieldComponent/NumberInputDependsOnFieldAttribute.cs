using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Xperience.DependingFieldComponents.FormComponents.NumberInputDependsOnFieldComponent
{
    public class NumberInputDependsOnFieldAttribute : NumberInputComponentAttribute, IDependsOnPropertyProperties
    {
        public string? DependsOn { get; set; }


        public string? ExpectedValue { get; set; }
    }
}
