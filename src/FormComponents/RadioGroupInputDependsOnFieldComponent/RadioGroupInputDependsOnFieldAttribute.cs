using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Xperience.DependingFieldComponents.FormComponents.RadioGroupInputDependsOnFieldComponent
{
    public class RadioGroupInputDependsOnFieldAttribute : RadioGroupComponentAttribute, IDependsOnPropertyProperties
    {
        public string? DependsOn { get; set; }


        public string? ExpectedValue { get; set; }
    }
}
