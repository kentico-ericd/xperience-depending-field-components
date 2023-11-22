using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

namespace Xperience.DependingFieldComponents.FormComponents.NumberInputDependsOnFieldComponent
{
    /// <summary>
    /// Properties for the <see cref="NumberInputDependsOnFieldComponent"/> component.
    /// </summary>
    public class NumberInputDependsOnFieldProperties : FormComponentProperties, IDependsOnPropertyProperties
    {
        [TextInputComponent(Label = DependingFieldComponentsConstants.PROPERTY_DEPENDSON_LABEL, Tooltip = DependingFieldComponentsConstants.PROPERTY_DEPENDSON_TOOLTIP, Order = 1)]
        public string? DependsOn { get; set; }


        [TextInputComponent(Label = DependingFieldComponentsConstants.PROPERTY_EXPECTEDVALUE_LABEL, Tooltip = DependingFieldComponentsConstants.PROPERTY_EXPECTEDVALUE_TOOLTIP, Order = 2)]
        public string? ExpectedValue { get; set; }


        [TextInputComponent(Label = "{$base.forms.numberinput.watermark.label$}", Tooltip = "{$base.forms.numberinput.watermark.tooltip$}")]
        public string? WatermarkText { get; set; }
    }
}
