using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace BoostLeadership
{

    internal class BoostLeadershipMobilePartyTrainingBehavior : CampaignBehaviorBase
    {
        public const float MoraleThreshold = 70f;
        public override void RegisterEvents()
        {
            CampaignEvents.DailyTickPartyEvent.AddNonSerializedListener((object)this, new Action<MobileParty>(this.DailyTickParty));
        }

        private void DailyTickParty(MobileParty mobileParty)
        {
            if (mobileParty.LeaderHero == null || mobileParty.Morale > 75.0 || mobileParty.Morale <= MoraleThreshold)
                return;
            mobileParty.LeaderHero?.HeroDeveloper.AddSkillXp(DefaultSkills.Leadership, (float)MathF.Round((float)(0.00999999977648258 * (double)mobileParty.MemberRoster.TotalManCount * ((double)mobileParty.Morale - (MoraleThreshold - 5)))), true, true);
        }

        public override void SyncData(IDataStore dataStore)
        {

        }
    }
}