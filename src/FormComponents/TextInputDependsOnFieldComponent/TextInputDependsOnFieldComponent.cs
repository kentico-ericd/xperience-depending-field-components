using CMS.Core;

using Kentico.Xperience.Admin.Base.Forms;

using Xperience.DependingFieldComponents.VisibilityConditions;

namespace Xperience.DependingFieldComponents.FormComponents.TextInputDependsOnFieldComponent
{
    /// <summary>
    /// A form component which can be configured to appear based on the value of another field.
    /// </summary>
    [ComponentAttribute(typeof(TextInputDependsOnFieldAttribute))]
    public class TextInputDependsOnFieldComponent : FormComponent<TextInputDependsOnFieldProperties, TextInputClientProperties, string>
    {
        private readonly ILocalizationService localizationService;


        /// <summary>
        /// The identifier for the <see cref="TextInputDependsOnFieldComponent"/>.
        /// </summary>
        public const string IDENTIFIER = "TextInputDependsOnFieldComponent";


        public override string ClientComponentName => "@kentico/xperience-admin-base/TextInput";


        /// <summary>
        /// Initializes a new instance of <see cref="TextInputDependsOnFieldComponent"/>.
        /// </summary>
        public TextInputDependsOnFieldComponent(ILocalizationService localizationService) : base(localizationService)
        {
            this.localizationService = localizationService;
        }


        protected override void ConfigureComponent()
        {
            if (!String.IsNullOrEmpty(Properties.DependsOn) && Properties.ExpectedValue is not null)
            {
                AddVisibilityCondition(new DependingFieldVisibilityCondition(Properties.DependsOn, Properties.ExpectedValue));
            }

            base.ConfigureComponent();
        }


        protected override Task ConfigureClientProperties(TextInputClientProperties clientProperties)
        {
            clientProperties.WatermarkText = localizationService.LocalizeString(Properties.WatermarkText);

            return base.ConfigureClientProperties(clientProperties);
        }
    }
}
