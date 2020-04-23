using HarmonyLib;
using ModLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace BoostLeadership
{
    [HarmonyPatch(typeof(MobilePartyTrainingBehavior), "DailyTickParty")]
    public class BoostLeadershipPatcher
    {
        private static bool Prefix(MobileParty mobileParty)
        {
            //exit to default if not leader party
            if (mobileParty.LeaderHero == null) return true;
            var settings = FileDatabase.Get<BoostLeadershipSettings>(BoostLeadershipSettings.InstanceID);
            //if we don't apply to IA, we keep the default behavior
            if (!settings.ApplyToIA && !mobileParty.LeaderHero.IsHumanPlayerCharacter) return true;
            if ((double)mobileParty.Morale >= settings.MoraleThreshold)
            {
                mobileParty.LeaderHero?.HeroDeveloper.AddSkillXp(DefaultSkills.Leadership, (float)MathF.Round((float)(0.00999999977648258 * (double)mobileParty.MemberRoster.TotalManCount * ((double)mobileParty.Morale - (settings.MoraleThreshold - 5)))), true, true);
            }
            //skip original method
            return false;
        }
    }
}
