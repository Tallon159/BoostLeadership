using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment.Managers;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace BoostLeadership
{
    public class BoostLeadershipMobilePartyTrainingBehavior : CampaignBehaviorBase
    {
        public double MoraleThreshold = 65.0;

        public override void RegisterEvents()
        {
            CampaignEvents.DailyTickPartyEvent.AddNonSerializedListener((object)this, new Action<MobileParty>(this.DailyTickParty));
        }

        public override void SyncData(IDataStore dataStore)
        {
        }

        private void DailyTickParty(MobileParty mobileParty)
        {
            if (mobileParty.LeaderHero == null || (double)mobileParty.Morale > 75.0 || (double) mobileParty.Morale <= MoraleThreshold)
                return;
            mobileParty.LeaderHero?.HeroDeveloper.AddSkillXp(DefaultSkills.Leadership, (float)MathF.Round((float)(0.00999999977648258 * (double)mobileParty.MemberRoster.TotalManCount * ((double)mobileParty.Morale - (MoraleThreshold - 5)))), true, true);
        }
    }
}