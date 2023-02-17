using System;

namespace Modules.DataBase.Properties
{
    [Serializable]
    public class Property
    {
        public string Type;
        public string SerializedData;
        public PropertyData Data;
    }
}
