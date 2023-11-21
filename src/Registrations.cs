using CMS;

using Kentico.Xperience.Admin.Base.Forms;

using Xperience.DependingFieldComponents.FormComponents.NumberInputDependsOnFieldComponent;
using Xperience.DependingFieldComponents.FormComponents.RadioGroupInputDependsOnFieldComponent;
using Xperience.DependingFieldComponents.FormComponents.TextInputDependsOnFieldComponent;

[assembly: AssemblyDiscoverable]
[assembly: RegisterFormComponent(TextInputDependsOnFieldComponent.IDENTIFIER, typeof(TextInputDependsOnFieldComponent), "Text input with field dependency")]
[assembly: RegisterFormComponent(NumberInputDependsOnFieldComponent.IDENTIFIER, typeof(NumberInputDependsOnFieldComponent), "Number input with field dependency")]
[assembly: RegisterFormComponent(RadioGroupInputDependsOnFieldComponent.IDENTIFIER, typeof(RadioGroupInputDependsOnFieldComponent), "Radio button group with field dependency")]
namespace Xperience.DependingFieldComponents
{
    internal class Registrations
    {
    }
}
