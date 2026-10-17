using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using vRoles.VanillaPort.Roles.Crewmate;

namespace vRoles.VanillaPort.Options.RoleOptions
{
    public class CriticalCrewmateOption : AbstractOptionGroup<CriticalCrewmate>
    {
        public override string GroupName => "Crit Crew Options";
        
        [ModdedNumberOption("Scan Fail Chance", 0, 50, 10)]
        public float ScanFailChance { get; set; } = 30f;
    }
}