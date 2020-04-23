using ModLib;
using ModLib.Attributes;
using System.Xml.Serialization;

namespace BoostLeadership
{
    public class BoostLeadershipSettings : SettingsBase
    {
        [XmlElement]
        public override string ID { get; set; } = InstanceID;

        public const string InstanceID = "BoostLeadershipSettings";

        public override string ModuleFolderName => "BoostLeadership";
        
        public override string ModName => "BoostLeadership";

        [XmlElement]
        [SettingProperty("Morale Threshold",65.0f,75.0f,"Change the morale threshold to gain leadership skill (default 75.0)")]
        public float MoraleThreshold { get; set; } = 75.0f;

        [XmlElement]
        [SettingProperty("Apply to IA","default is true")]
        public bool ApplyToIA { get; set; } = true;
    }
}
