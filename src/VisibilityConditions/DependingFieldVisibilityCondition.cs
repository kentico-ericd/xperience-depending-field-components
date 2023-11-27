using Kentico.Xperience.Admin.Base.Forms;

using Xperience.DependingFieldComponents.FormComponents;

namespace Xperience.DependingFieldComponents.VisibilityConditions
{
    /// <summary>
    /// A visibility condition that toggles the visibility of a field depending on the value of another field.
    /// </summary>
    public class DependingFieldVisibilityCondition : VisibilityConditionWithDependency
    {
        private readonly string dependsOn;
        private readonly string expectedValue;


        public override IEnumerable<string> DependsOnFields => new string[] { dependsOn };


        /// <summary>
        /// Initializes a new instance of <see cref="DependingFieldVisibilityCondition"/>.
        /// </summary>
        /// <param name="dependsOn">The name of the field that determines whether the component is visible.</param>
        /// <param name="expectedValue">The value of the field specified by <paramref name="dependsOn"/> which will reveal the depending field.</param>
        public DependingFieldVisibilityCondition(string dependsOn, string expectedValue)
        {
            this.dependsOn = dependsOn;
            this.expectedValue = expectedValue;
        }


        public override bool Evaluate(IFormFieldValueProvider formFieldValueProvider)
        {
            if (formFieldValueProvider.TryGet<object>(dependsOn, out var fieldValue))
            {
                if (fieldValue is null)
                {
                    return false;
                }

                var stringRepresentation = fieldValue.ToString();
                if (stringRepresentation is not null)
                {
                    return stringRepresentation.Equals(expectedValue);
                }
            }

            return true;
        }


        /// <summary>
        /// Applies a visibility condition if the required conditions are met.
        /// </summary>
        /// <param name="component">The form component to apply the visibility condition to.</param>
        public static void Configure<TProps, TClientProps, TValue>(FormComponent<TProps, TClientProps, TValue> component)
            where TProps : DependsOnPropertyProperties, new()
            where TClientProps : FormComponentClientProperties<TValue>, new()
        {
            if (!String.IsNullOrEmpty(component.Properties.DependsOn) && component.Properties.ExpectedValue is not null)
            {
                component.AddVisibilityCondition(new DependingFieldVisibilityCondition(component.Properties.DependsOn, component.Properties.ExpectedValue));
            }
        }
    }
}
