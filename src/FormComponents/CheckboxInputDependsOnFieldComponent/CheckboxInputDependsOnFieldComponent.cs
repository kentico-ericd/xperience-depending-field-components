using Kentico.Xperience.Admin.Base.Forms;

using Xperience.DependingFieldComponents;
using Xperience.DependingFieldComponents.FormComponents.CheckboxInputDependsOnFieldComponent;
using Xperience.DependingFieldComponents.VisibilityConditions;

[assembly: RegisterFormComponent(DependingFieldComponentsConstants.CHECKBOXINPUT_IDENTIFIER, typeof(CheckboxInputDependsOnFieldComponent), DependingFieldComponentsConstants.CHECKBOXINPUT_FIELDDESCRIPTION)]
namespace Xperience.DependingFieldComponents.FormComponents.CheckboxInputDependsOnFieldComponent
{
    /// <summary>
    /// A form component which can be configured to appear based on the value of another field.
    /// </summary>
    [ComponentAttribute(typeof(CheckboxInputDependsOnFieldAttribute))]
    public class CheckboxInputDependsOnFieldComponent : FormComponent<CheckboxInputDependsOnFieldProperties, CheckBoxClientProperties, bool>
    {
        public override string ClientComponentName => "@kentico/xperience-admin-base/Checkbox";


        /// <summary>
        /// Initializes a new instance of <see cref="CheckboxInputDependsOnFieldComponent"/>
        /// </summary>
        public CheckboxInputDependsOnFieldComponent()
        {
        }


        protected override void ConfigureComponent()
        {
            DependingFieldVisibilityCondition.Configure(this);

            base.ConfigureComponent();
        }
    }
}
