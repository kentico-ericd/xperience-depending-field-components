using CMS.Core;

using Kentico.Xperience.Admin.Base.Forms;

using Xperience.DependingFieldComponents;
using Xperience.DependingFieldComponents.FormComponents.NumberInputDependsOnFieldComponent;
using Xperience.DependingFieldComponents.VisibilityConditions;

[assembly: RegisterFormComponent(DependingFieldComponentsConstants.NUMBERINPUT_IDENTIFIER, typeof(NumberInputDependsOnFieldComponent), DependingFieldComponentsConstants.NUMBERINPUT_FIELDDESCRIPTION)]

namespace Xperience.DependingFieldComponents.FormComponents.NumberInputDependsOnFieldComponent
{
    /// <summary>
    /// A form component which can be configured to appear based on the value of another field.
    /// </summary>
    [ComponentAttribute(typeof(NumberInputDependsOnFieldAttribute))]
    public class NumberInputDependsOnFieldComponent : FormComponent<NumberInputDependsOnFieldProperties, NumberInputClientProperties, int?>
    {
        private readonly ILocalizationService localizationService;


        public override string ClientComponentName => "@kentico/xperience-admin-base/NumberInput";


        /// <summary>
        /// Initializes a new instance of <see cref="NumberInputDependsOnFieldComponent"/>.
        /// </summary>
        public NumberInputDependsOnFieldComponent(ILocalizationService localizationService) : base(localizationService)
        {
            this.localizationService = localizationService;
        }


        protected override void ConfigureComponent()
        {
            var maxRule = new MaximumIntegerValueValidationRule(localizationService)
            {
                Properties = { MaxValue = Int32.MaxValue },
            };
            var minRule = new MinimumIntegerValueValidationRule(localizationService)
            {
                Properties = { MinValue = Int32.MinValue },
            };

            AddValidationRule(maxRule);
            AddValidationRule(minRule);
            if (!String.IsNullOrEmpty(Properties.DependsOn) && Properties.ExpectedValue is not null)
            {
                AddVisibilityCondition(new DependingFieldVisibilityCondition(Properties.DependsOn, Properties.ExpectedValue));
            }
        }


        protected override Task ConfigureClientProperties(NumberInputClientProperties clientProperties)
        {
            clientProperties.WatermarkText = localizationService.LocalizeString(Properties.WatermarkText);

            return base.ConfigureClientProperties(clientProperties);
        }
    }
}
