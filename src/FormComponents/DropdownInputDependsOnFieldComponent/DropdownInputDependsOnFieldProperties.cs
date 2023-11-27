using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

namespace Xperience.DependingFieldComponents.FormComponents.DropdownInputDependsOnFieldComponent
{
    /// <summary>
    /// Properties for the <see cref="DropdownInputDependsOnFieldComponent"/> component.
    /// </summary>
    public class DropdownInputDependsOnFieldProperties : DropDownProperties, IDependsOnPropertyProperties
    {
        [TextInputComponent(Label = DependingFieldComponentsConstants.PROPERTY_DEPENDSON_LABEL, Tooltip = DependingFieldComponentsConstants.PROPERTY_DEPENDSON_TOOLTIP, Order = 1)]
        public string? DependsOn { get; set; }


        [TextInputComponent(Label = DependingFieldComponentsConstants.PROPERTY_EXPECTEDVALUE_LABEL, Tooltip = DependingFieldComponentsConstants.PROPERTY_EXPECTEDVALUE_TOOLTIP, Order = 2)]
        public string? ExpectedValue { get; set; }


        internal IEnumerable<DropDownOptionItem>? OptionsItems { get; set; }
    }
}
