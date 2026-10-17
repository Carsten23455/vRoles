using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using vRoles.VanillaPort.Roles.Crewmate;

namespace vRoles.VanillaPort.Options.RoleOptions
{
    public class VigilanteSettings : AbstractOptionGroup<Vigilante>
    {
        public override string GroupName => "Vigilante Options";

        [ModdedNumberOption("Vigi Kill CoolDown", 10, 60, 5, MiraAPI.Utilities.MiraNumberSuffixes.Seconds)]
        public float KillCoolDown { get; set; } = 45f;

        [ModdedNumberOption("Kill Amount", 0, 3, 1,  MiraAPI.Utilities.MiraNumberSuffixes.Seconds, null, true)]
        public float InfiniteKills { get; set; } = 1;
    }
}
