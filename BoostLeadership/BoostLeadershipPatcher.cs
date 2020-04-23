using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace BoostLeadership
{
    [HarmonyPatch(typeof(MobilePartyTrainingBehavior), "DailyTickParty")]
    public class BoostLeadershipPatcher
    {
        public const float MoraleThreshold = 55f;
        private static bool Prefix(MobileParty mobileParty)
        {
            //exit to default if not leader party
            if (mobileParty.LeaderHero == null) return true;
            if ((double)mobileParty.Morale >= MoraleThreshold)
            {
                mobileParty.LeaderHero?.HeroDeveloper.AddSkillXp(DefaultSkills.Leadership, (float)MathF.Round((float)(0.00999999977648258 * (double)mobileParty.MemberRoster.TotalManCount * ((double)mobileParty.Morale - (MoraleThreshold - 5)))), true, true);
            }
            //skip original method
            return false;
        }
    }
}
