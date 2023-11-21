using Kentico.Xperience.Admin.Base.Forms;

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
        /// Initializes a new instance of <see cref="BooleanFieldVisibilityCondition"/>.
        /// </summary>
        /// <param name="dependsOn">The name of the field that determines whether the component is visible.</param>
        /// <param name="expectedValue">The value of the field specified by <paramref name="fieldName"/> which will reveal the depending field.</param>
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
    }
}
