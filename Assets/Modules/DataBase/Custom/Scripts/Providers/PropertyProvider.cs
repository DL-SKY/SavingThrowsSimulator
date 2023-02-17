using Modules.DataBase.Properties;
using System;

namespace Modules.DataBase.Custom.Providers
{
    public class PropertyProvider : Modules.DataBase.Providers.PropertyProvider
    {
        public override PropertyData GetPropertyData(string type, string text)
        {
            switch (type)
            {
                //case EnumProperties.FeatureProperty:
                //    return DeserializePropertyByText<FeaturePropertyData>(text);
                //case EnumProperties.ProficiencyProperty:
                //    return DeserializePropertyByText<ProficiencyPropertyData>(text);

                default:
                    throw new Exception($"Unexpected property type {type}!");
            }
        }
    }
}
