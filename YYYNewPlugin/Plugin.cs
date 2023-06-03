using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;
using YYYNewPlugin.Fuctions;

namespace YYYNewPlugin
{
    public class Plugin
    {
        [PluginConfig]
        public Config config;
        [PluginEntryPoint("YYYNewPlugin","0.0.1","嘤嘤嘤服务器新插件服，基于NWAPI制作","咕咕鱼")]
        void OnEabled()
        {
            Log.Info("插件开始加载了");
            EventManager.RegisterEvents(this);
            Log.Info("垃圾清理插件加载");
            EventManager.RegisterEvents<AutoCleaner>(this);
            Log.Info("等待大厅加载");
            EventManager.RegisterEvents<WaitingLobby>(this);
            Log.Info("系统核弹加载");
            EventManager.RegisterEvents<SystemNuke>(this);
            Log.Info("基础血量设置");
            EventManager.RegisterEvents<NormalHealth>(this);
            Log.Info("MVP系统启动");
            EventManager.RegisterEvents<MVPFuc>(this);
            Log.Info("死亡复活信息显示插件");
            EventManager.RegisterEvents<DeathInFormation>(this);
            Log.Info("队伍信息显示插件");
            EventManager.RegisterEvents<ShowTeamInFormation>(this);
            Log.Info("经验获取系统注册");
            EventManager.RegisterEvents<XpSystem>(this);
            Log.Info("无限子弹注册");
            EventManager.RegisterEvents<UnlimitAmmo>(this);
        }
    }
    
}
