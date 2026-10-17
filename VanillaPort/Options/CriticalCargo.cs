using MiraAPI.GameOptions;

namespace vRoles.VanillaPort.Options
{
    public class CriticalCargo : AbstractOptionGroup
    {
        public override string GroupName => "Critical Cargo";
        public override uint GroupPriority => 0;

        //[ModdedToggleOption("Enabled")]
        public bool Enabled { get; set; }
        //[ModdedNumberOption("Crit Crew Amount", 1, 3, 1)]
        //public float CriticalCrewmateAmount { get; set; }
    }
}
