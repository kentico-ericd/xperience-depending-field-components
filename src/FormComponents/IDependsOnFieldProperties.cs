using Kentico.Xperience.Admin.Base.FormAnnotations;

using Xperience.DependingFieldComponents.VisibilityConditions;

namespace Xperience.DependingFieldComponents.FormComponents
{
    /// <summary>
    /// Contains common form component properties used within the <see cref="DependingFieldVisibilityCondition"/>
    /// </summary>
    internal interface IDependsOnFieldProperties
    {
        /// <summary>
        /// The name of the field that determines whether the component is visible.
        /// </summary>
        [TextInputComponent(Label = "Depends on field name")]
        public string? FieldName { get; set; }


        /// <summary>
        /// The value of the field specified by <see cref="FieldName"/> which will reveal the depending field.
        /// </summary>
        [CheckBoxComponent(Label = "Expected value")]
        public string? ExpectedValue { get; set; }
    }
}
