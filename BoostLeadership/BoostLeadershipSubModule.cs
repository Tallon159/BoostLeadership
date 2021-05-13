using HarmonyLib;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace BoostLeadership
{
    public class BoostLeadershipSubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            try
            {
                base.OnSubModuleLoad();
                Harmony harmony1 = new Harmony("mod.bannerlord.boostleadership");
                harmony1.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                var path = Path.Combine(BasePath.Name, "Modules", "BoostLeadership", "ErrorLog.xml");
                using (StreamWriter writer = File.AppendText(path))
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    for (; ex != null; ex = ex.InnerException)
                    {
                        stringBuilder.AppendLine(ex.Message);
                        stringBuilder.AppendLine(ex.StackTrace);
                    }
                    writer.Write("\r\nNew Log Entry: ");
                    DateTime now = DateTime.Now;
                    string longTimeString = now.ToLongTimeString();
                    now = DateTime.Now;
                    string longDateString = now.ToLongDateString();
                    string str = longTimeString + " " + longDateString;
                    writer.WriteLine(str);
                    writer.WriteLine(" >> " + stringBuilder.ToString());
                    writer.WriteLine("-------------------------------");
                }
                InformationManager.DisplayMessage(new InformationMessage($"Error patching BoostLeadership module. See error in logs.",new Color(255,0,0)));
            }

            //protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
            //{
            //    try
            //    {
            //        if (!(gameStarterObject is CampaignGameStarter))
            //            return;
            //        this.AddBehaviors(game, (CampaignGameStarter)gameStarterObject);
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //}

            //private void AddBehaviors(Game game, CampaignGameStarter gameInitializer)
            //{
            //    try
            //    {
            //        if (!(game.GameType is Campaign))
            //            return;
            //        gameInitializer.AddBehavior((CampaignBehaviorBase)new BoostLeadershipMobilePartyTrainingBehavior());
            //        InformationManager.DisplayMessage(new InformationMessage($"{nameof(BoostLeadershipMobilePartyTrainingBehavior)} added"));
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //}
        }
    }
}
