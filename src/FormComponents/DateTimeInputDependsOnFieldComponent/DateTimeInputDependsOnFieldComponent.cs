using CMS.Core;
using CMS.Core.Internal;

using Kentico.Xperience.Admin.Base;
using Kentico.Xperience.Admin.Base.Forms;
using Kentico.Xperience.Admin.Base.Forms.Internal;

using System.Globalization;

using Xperience.DependingFieldComponents;
using Xperience.DependingFieldComponents.FormComponents.DateTimeInputDependsOnFieldComponent;
using Xperience.DependingFieldComponents.VisibilityConditions;

[assembly: RegisterFormComponent(DependingFieldComponentsConstants.DATETIMEINPUT_IDENTIFIER, typeof(DateTimeInputDependsOnFieldComponent), DependingFieldComponentsConstants.DATETIMEINPUT_FIELDDESCRIPTION)]

namespace Xperience.DependingFieldComponents.FormComponents.DateTimeInputDependsOnFieldComponent
{
    /// <summary>
    /// A form component which can be configured to appear based on the value of another field.
    /// </summary>
    [ComponentAttribute(typeof(DateTimeInputDependsOnFieldAttribute))]
    public class DateTimeInputDependsOnFieldComponent : DateInputComponentBase<DependsOnPropertyProperties, DateTimeInputClientProperties, DateTime?>
    {
        private const int YEARS_OFFSET = 2000;
        private const string DATE_TIME_FORMAT = "MM/DD/YYYY hh:mm AM/PM";


        public override string ClientComponentName => "@kentico/xperience-admin-base/DateTimeInput";


        /// <summary>
        /// Initializes a new instance of <see cref="DateTimeInputDependsOnFieldComponent"/>.
        /// </summary>
        public DateTimeInputDependsOnFieldComponent(ILocalizationService localizationService, IDateTimeNowService dateTimeService)
            : base(localizationService, dateTimeService)
        {
            Properties.ExplanationText = string.Format(localizationService.GetString("base.forms.datetimeinput.explanation"), DATE_TIME_FORMAT);

            AddValidationRule(new DateFormatValidationRule(localizationService, DATE_TIME_FORMAT));
        }


        protected override void ConfigureComponent()
        {
            DependingFieldVisibilityCondition.Configure(this);

            base.ConfigureComponent();
        }


        public override void AddValidationRule(IValidationRule validationRule)
        {
            if (validationRule is DateFormatValidationRule)
            {
                ValidationRules.Insert(0, validationRule);
            }
            else
            {
                base.AddValidationRule(validationRule);
            }
        }


        public override void SetValue(DateTime? value)
        {
            if (value.HasValue && value.Value == default)
            {
                value = value.Value.AddYears(YEARS_OFFSET);
            }

            base.SetValue(value);
        }


        protected override Task<ICommandResponse<ValidateDateTimeValueCommandResult>> ValidateDateValueInternal(ValidateDateTimeValueCommandArguments arguments)
        {
            var result = DateTime.TryParseExact(arguments.Value, dateTimeFormatString.Value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out _);

            return Task.FromResult(ResponseFrom(new ValidateDateTimeValueCommandResult { IsValid = result }));
        }
    }
}
