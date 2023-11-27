using CMS.Core;

using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

using Xperience.DependingFieldComponents;
using Xperience.DependingFieldComponents.FormComponents.DropdownInputDependsOnFieldComponent;
using Xperience.DependingFieldComponents.VisibilityConditions;

[assembly: RegisterFormComponent(DependingFieldComponentsConstants.DROPDOWNINPUT_IDENTIFIER, typeof(DropdownInputDependsOnFieldComponent), DependingFieldComponentsConstants.DROPDOWNINPUT_FIELDDESCRIPTION)]

namespace Xperience.DependingFieldComponents.FormComponents.DropdownInputDependsOnFieldComponent
{
    /// <summary>
    /// A form component which can be configured to appear based on the value of another field.
    /// </summary>
    [ComponentAttribute(typeof(DropdownInputDependsOnFieldAttribute))]
    public class DropdownInputDependsOnFieldComponent : FormComponent<DropdownInputDependsOnFieldProperties, DropDownClientProperties, string>
    {
        private readonly ILocalizationService localizationService;


        public override string ClientComponentName => "@kentico/xperience-admin-base/DropDownSelector";


        /// <summary>
        /// Initializes a new instance of <see cref="DropdownInputDependsOnFieldComponent"/>.
        /// </summary>
        public DropdownInputDependsOnFieldComponent(ILocalizationService localizationService)
        {
            this.localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
        }


        public override string GetValue()
        {
            var value = base.GetValue();
            var options = GetOptions();

            return options?.FirstOrDefault(o => o.Value == value)?.Value ?? String.Empty;
        }


        protected override void ConfigureComponent()
        {
            DependingFieldVisibilityCondition.Configure(this);

            base.ConfigureComponent();
        }


        protected override async Task ConfigureClientProperties(DropDownClientProperties clientProperties)
        {
            clientProperties.Placeholder = !String.IsNullOrEmpty(Properties.Placeholder) ? localizationService.LocalizeString(Properties.Placeholder) : localizationService.GetString("base.forms.dropdown.placeholder");
            clientProperties.Options = GetOptions();

            await base.ConfigureClientProperties(clientProperties);
        }


        private IEnumerable<DropDownOptionItem> GetOptions()
        {
            if (Properties.OptionsItems != null)
            {
                return Properties.OptionsItems;
            }

            return KeyValueOptionsParser.ParseDataSource(
                Properties.Options,
                (value, text) => new DropDownOptionItem { Value = value, Text = localizationService.LocalizeString(text) }
            );
        }


        internal string GetSelectedValue()
        {
            return base.GetValue();
        }
    }
}
