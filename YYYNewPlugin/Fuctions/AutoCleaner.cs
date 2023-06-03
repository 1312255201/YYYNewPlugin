using System.Collections.Generic;
using InventorySystem.Items.Pickups;
using MEC;
using Mirror;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using UnityEngine;
using YYYNewPlugin.API;

namespace YYYNewPlugin.Fuctions
{
    public class AutoCleaner
    {
        [PluginEvent(ServerEventType.RoundStart)]
        void OnRoundStart()
        {
            Timing.RunCoroutine(CleanFloorPlugin());
        }
        private static IEnumerator<float> CleanFloorPlugin()
        {
            yield return Timing.WaitForSeconds(1);
            int time = 0;
            while (Round.IsRoundStarted)
            {
                yield return Timing.WaitForSeconds(1);
                time++;
                switch(time)
                {
                    case 1:
                        Server.SendBroadcast("[服务器清理大师]\n服务器将会在400s后清理地面的",10);
                        break;
                    case 200:
                        Server.SendBroadcast("[服务器清理大师]\n服务器将会在200s后清理地面的掉落物，和布娃娃", 10);
                        break;
                    case 350:
                        Server.SendBroadcast("[服务器清理大师]\n服务器将会在50s后清理地面的掉落物，和布娃娃", 10);
                        break;
                    case 390:
                        Server.ClearBroadcasts();
                        for(int i = 10; i >= 0;i--)
                        {
                            Server.SendBroadcast("[服务器清理大师]\n服务器将会在" +i+ "后清理地面的掉落物，和布娃娃", 1);
                        }
                        break;
                    case 400:
                        Server.ClearBroadcasts();
                        Server.SendBroadcast("[服务器清理大师]\n开始清理", 5);
                        break;
                    case 410:
                        time = 0;
                        int ragdollnum = 0;
                        int itemnum = 0;
                        BasicRagdoll[] ragdolls = Object.FindObjectsOfType<BasicRagdoll>();
                        foreach(BasicRagdoll basicRagdoll in ragdolls)
                        {
                            ragdollnum++;
                            NetworkServer.Destroy(basicRagdoll.gameObject);
                        }
                        ItemPickupBase[] itemPickupBases = Object.FindObjectsOfType<ItemPickupBase>();
                        foreach (ItemPickupBase itemPickupBase in itemPickupBases)
                        {
                            //清理物品我们做点限制,我们来自己搓点方法
                            if(itemPickupBase.Info.ItemId.IsScpItem() || itemPickupBase.Info.ItemId.IsKeycard())
                            {
                                continue;
                            }
                            //如果这个物品是一个卡或者是一个特殊物品我们就不清理
                            NetworkServer.Destroy(itemPickupBase.gameObject);
                            itemnum++;
                        }
                        Server.SendBroadcast("本次一共清理了" + itemnum + "件物品" + ragdollnum + "个尸体",10);
                        break;

                }

            }
        }
    }
}