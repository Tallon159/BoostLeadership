using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BoostLeadership
{
    public class BoostLeadershipSubModule : MBSubModuleBase
    {

        public const float MoraleThreshold = 65f;
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);
            try
            {
                if (!(gameStarterObject is CampaignGameStarter))
                    return;
                this.AddBehaviors(game, (CampaignGameStarter)gameStarterObject);
            }
            catch (Exception ex)
            {
            }
        }



        private void AddBehaviors(Game game, CampaignGameStarter gameInitializer)
        {
            try
            {
                if (!(game.GameType is Campaign))
                    return;
                
                gameInitializer.AddBehavior(new BoostLeadershipMobilePartyTrainingBehavior());
            }
            catch (Exception ex)
            {
            }
        }
    }
}
