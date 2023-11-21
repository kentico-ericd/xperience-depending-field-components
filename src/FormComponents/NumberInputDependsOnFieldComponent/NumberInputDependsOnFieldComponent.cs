﻿using CMS.Core;

using Kentico.Xperience.Admin.Base.Forms;

using Xperience.DependingFieldComponents.VisibilityConditions;

namespace Xperience.DependingFieldComponents.FormComponents.NumberInputDependsOnFieldComponent
{
    [ComponentAttribute(typeof(NumberInputDependsOnFieldAttribute))]
    public class NumberInputDependsOnFieldComponent : FormComponent<NumberInputDependsOnFieldProperties, NumberInputClientProperties, int?>
    {
        private readonly ILocalizationService localizationService;


        public const string IDENTIFIER = "NumberInputDependsOnFieldComponent";


        public override string ClientComponentName => "@kentico/xperience-admin-base/NumberInput";


        public NumberInputDependsOnFieldComponent(ILocalizationService localizationService) : base(localizationService)
        {
            this.localizationService = localizationService;
        }


        protected override void ConfigureComponent()
        {
            var maxRule = new MaximumIntegerValueValidationRule(localizationService)
            {
                Properties = { MaxValue = Int32.MaxValue },
            };
            var minRule = new MinimumIntegerValueValidationRule(localizationService)
            {
                Properties = { MinValue = Int32.MinValue },
            };

            AddValidationRule(maxRule);
            AddValidationRule(minRule);
            if (!String.IsNullOrEmpty(Properties.DependsOn) && Properties.ExpectedValue is not null)
            {
                AddVisibilityCondition(new DependingFieldVisibilityCondition(Properties.DependsOn, Properties.ExpectedValue));
            }
        }


        protected override Task ConfigureClientProperties(NumberInputClientProperties clientProperties)
        {
            clientProperties.WatermarkText = localizationService.LocalizeString(Properties.WatermarkText);

            return base.ConfigureClientProperties(clientProperties);
        }
    }
}
