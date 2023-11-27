using CMS.Core;

using Kentico.Xperience.Admin.Base.Forms;

using Xperience.DependingFieldComponents;
using Xperience.DependingFieldComponents.FormComponents.RadioGroupInputDependsOnFieldComponent;
using Xperience.DependingFieldComponents.VisibilityConditions;

[assembly: RegisterFormComponent(DependingFieldComponentsConstants.RADIOGROUP_IDENTIFIER, typeof(RadioGroupInputDependsOnFieldComponent), DependingFieldComponentsConstants.RADIOGROUP_FIELDDESCRIPTION)]

namespace Xperience.DependingFieldComponents.FormComponents.RadioGroupInputDependsOnFieldComponent
{
    /// <summary>
    /// A form component which can be configured to appear based on the value of another field.
    /// </summary>
    [ComponentAttribute(typeof(RadioGroupInputDependsOnFieldAttribute))]
    public class RadioGroupInputDependsOnFieldComponent : FormComponent<RadioGroupInputDependsOnFieldProperties, RadioGroupClientProperties, string>
    {
        private readonly ILocalizationService localizationService;


        public override string ClientComponentName => "@kentico/xperience-admin-base/RadioGroup";


        /// <summary>
        /// Initializes a new instance of <see cref="RadioGroupInputDependsOnFieldComponent"/>.
        /// </summary>
        public RadioGroupInputDependsOnFieldComponent(ILocalizationService localizationService)
        {
            this.localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
        }


        protected override void ConfigureComponent()
        {
            DependingFieldVisibilityCondition.Configure(this);

            base.ConfigureComponent();
        }


        protected override Task ConfigureClientProperties(RadioGroupClientProperties clientProperties)
        {
            clientProperties.Options = GetOptions();
            clientProperties.Value = GetClientValue();
            clientProperties.Inline = Properties.Inline;
            clientProperties.AriaLabel = localizationService.LocalizeString(Properties.AriaLabel);

            return base.ConfigureClientProperties(clientProperties);
        }


        public override string GetValue()
        {
            var value = base.GetValue();

            return GetOptions()?.FirstOrDefault(o => o.Value == value)?.Value ?? String.Empty;
        }


        private IEnumerable<RadioButton> GetOptions()
        {
            return KeyValueOptionsParser.ParseDataSource(
                Properties.Options,
                (value, text) => new RadioButton { Value = value, Label = localizationService.LocalizeString(text) }
            );
        }


        private string GetClientValue()
        {
            var value = GetValue();
            if (string.IsNullOrEmpty(value))
            {
                var options = GetOptions();
                if (!options.Any())
                {
                    return string.Empty;
                }

                return options.First().Value;
            }

            return value;
        }
    }
}
