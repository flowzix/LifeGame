using LifeGameProject.Models.EnumHelpers;
using LifeGameProject.Static;
using System.Collections.Generic;

namespace LifeGameProject.Models
{
    public class Settings
    {
        public Dictionary<SettingType, int> settings { get; set; }
        private Settings()
        {
            settings = new Dictionary<SettingType, int>();
        }

        public static Settings InitialSettings
        {
            get
            {
                Settings newSettings = CreateNew();
                var enumType = typeof(SettingType);
                var enumVal = enumType.GetEnumValues();
                foreach (var value in enumVal)
                {
                    var member = enumType.GetMember(value.ToString());
                    var attrVal = member[0].GetCustomAttributes(typeof(InitialValueAttribute), false);
                    var initVal = ((InitialValueAttribute)attrVal[0]).value;
                    newSettings.SetSetting((SettingType)value, initVal);
                }
                return newSettings;
            }
        }

        public static Settings FileSettings { get; }

        private static Settings CreateNew()
        {
            return new Settings();
        }
        public void SetSetting(SettingType type, int value)
        {
            settings[type] = value;
        }

        public int GetSetting(SettingType settingType)
        {
            int val;
            bool success = settings.TryGetValue(settingType, out val);
            if (success)
            {
                return val;
            }
            return -1;
        }
    }
}
