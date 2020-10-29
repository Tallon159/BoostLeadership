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
        public const float MoraleThreshold = 65f;
        private static bool Prefix(MobileParty mobileParty)
        {
            if(mobileParty.LeaderHero == null || mobileParty.Morale <= MoraleThreshold)
            {
                return false;
            }
            mobileParty.LeaderHero?.HeroDeveloper.AddSkillXp(DefaultSkills.Leadership, (float)MathF.Round((float)(0.00999999977648258 * (double)mobileParty.MemberRoster.TotalManCount * ((double)mobileParty.Morale - (MoraleThreshold - 5)))),true,true);
            return true;
        }
    }
}
 