using CMS.Core;

using Kentico.Xperience.Admin.Base.Forms;

using Xperience.DependingFieldComponents;
using Xperience.DependingFieldComponents.FormComponents.TextInputDependsOnFieldComponent;
using Xperience.DependingFieldComponents.VisibilityConditions;

[assembly: RegisterFormComponent(DependingFieldComponentsConstants.TEXTINPUT_IDENTIFIER, typeof(TextInputDependsOnFieldComponent), DependingFieldComponentsConstants.TEXTINPUT_FIELDDESCRIPTION)]

namespace Xperience.DependingFieldComponents.FormComponents.TextInputDependsOnFieldComponent
{
    /// <summary>
    /// A form component which can be configured to appear based on the value of another field.
    /// </summary>
    [ComponentAttribute(typeof(TextInputDependsOnFieldAttribute))]
    public class TextInputDependsOnFieldComponent : FormComponent<TextInputDependsOnFieldProperties, TextInputClientProperties, string>
    {
        private readonly ILocalizationService localizationService;


        public override string ClientComponentName => "@kentico/xperience-admin-base/TextInput";


        /// <summary>
        /// Initializes a new instance of <see cref="TextInputDependsOnFieldComponent"/>.
        /// </summary>
        public TextInputDependsOnFieldComponent(ILocalizationService localizationService) : base(localizationService)
        {
            this.localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
        }


        protected override void ConfigureComponent()
        {
            DependingFieldVisibilityCondition.Configure(this);

            base.ConfigureComponent();
        }


        protected override Task ConfigureClientProperties(TextInputClientProperties clientProperties)
        {
            clientProperties.WatermarkText = localizationService.LocalizeString(Properties.WatermarkText);

            return base.ConfigureClientProperties(clientProperties);
        }
    }
}
