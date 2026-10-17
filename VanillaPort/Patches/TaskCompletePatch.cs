using vRoles.VanillaPort.Options;
using vRoles.VanillaPort.Roles.Crewmate;
using vRoles.VanillaPort.Roles.Infection.Crewmate;
using HarmonyLib;
using MiraAPI.GameOptions;
using MiraAPI.Hud;
using UnityEngine;
using vRoles.VanillaPort.Buttons;
using vRoles.VanillaPort.Buttons.InfectionPowers.OriginalPowers;
using vRoles.VanillaPort.Buttons.InfectionPowers.UnUsedPowers;

namespace vRoles.VanillaPort.Patches
{
    [HarmonyPatch(typeof(PlayerControl),nameof(PlayerControl.RpcCompleteTask))]
    public class TaskCompletePatch
    {
        public static void Postfix(PlayerControl __instance, uint idx)
        {
            switch (__instance.Data.Role)
            {
                case CriticalCrewmate:
                {
                    var scan = CustomButtonSingleton<Scan>.Instance;
                    scan.IncreaseUses(1);
                    break;
                }
                case CrewmateTag:
                {
                    var enabledPowerups = new List<int>();
                    
                        enabledPowerups.Add(0);
                        enabledPowerups.Add(1);
                        enabledPowerups.Add(2);
                        
                    if (OptionGroupSingleton<InfectionUnusedOrRemovePowers>.Instance.DisinfectEnabled)
                        enabledPowerups.Add(3);
                    if (OptionGroupSingleton<InfectionUnusedOrRemovePowers>.Instance.SabotageEnabled)
                        enabledPowerups.Add(4);

                    int GetUsesLeft(int id) => id switch
                    {
                        0 => CustomButtonSingleton<Guard>.Instance.UsesLeft,
                        1 => CustomButtonSingleton<Zap>.Instance.UsesLeft,
                        2 => CustomButtonSingleton<VentAbility>.Instance.UsesLeft,
                        3 => CustomButtonSingleton<DisInfect>.Instance.UsesLeft,
                        4 => CustomButtonSingleton<Sabotage>.Instance.UsesLeft,
                        _ => 0
                    };
                    
                    var eligible = enabledPowerups.Where(id => GetUsesLeft(id) <= 0).ToList();

                    if (eligible.Count > 0)
                    {
                        var chosen = eligible[UnityEngine.Random.Range(0, eligible.Count)];

                        switch (chosen)
                        {
                            case 0:
                                CustomButtonSingleton<Guard>.Instance.IncreaseUses(1);
                                Debug.Log($"Gave {__instance.Data.PlayerName} Guard");
                                break;
                            case 1:
                                CustomButtonSingleton<Zap>.Instance.IncreaseUses(1);
                                Debug.Log($"Gave {__instance.Data.PlayerName} Zap");
                                break;
                            case 2:
                                CustomButtonSingleton<VentAbility>.Instance.IncreaseUses(1);
                                Debug.Log($"Gave {__instance.Data.PlayerName} Vent");
                                break;
                            case 3:
                                CustomButtonSingleton<DisInfect>.Instance.IncreaseUses(1);
                                Debug.Log($"Gave {__instance.Data.PlayerName} Disinfect");
                                break;
                            case 4:
                                CustomButtonSingleton<Sabotage>.Instance.IncreaseUses(1);
                                Debug.Log($"Gave {__instance.Data.PlayerName} Sabotage");
                                break;
                        }
                    }

                    break;
                }
            }
        }
    }
}
