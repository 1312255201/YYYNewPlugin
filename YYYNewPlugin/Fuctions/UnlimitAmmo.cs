using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace YYYNewPlugin.Fuctions;

public class UnlimitAmmo
{
    [PluginEvent(ServerEventType.PlayerReloadWeapon)]
    void PlayerChangeRole(Player player, InventorySystem.Items.Firearms.Firearm firearm)
    {
        try
        {
            player.SetAmmo(firearm.AmmoType, firearm.AmmoManagerModule.MaxAmmo);
        }
        catch
        {
                
        }
    }
}