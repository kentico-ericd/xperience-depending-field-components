using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

namespace Xperience.DependingFieldComponents.FormComponents.NumberInputDependsOnFieldComponent
{
    public class NumberInputDependsOnFieldProperties : FormComponentProperties
    {
        [TextInputComponent(Label = "Depends on", ExplanationText = "The name of the field that determines this field's visibility", Order = 1)]
        public string? DependsOn { get; set; }


        [TextInputComponent(Label = "Expected value", ExplanationText = "The value of the depending field which will reveal this field", Order = 2)]
        public string? ExpectedValue { get; set; }


        [TextInputComponent(Label = "{$base.forms.numberinput.watermark.label$}", Tooltip = "{$base.forms.numberinput.watermark.tooltip$}")]
        public string? WatermarkText { get; set; }
    }
}
