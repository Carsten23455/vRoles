using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using vRoles.VanillaPort.Roles.Crewmate;

namespace vRoles.VanillaPort.Options.RoleOptions
{
    public class DoubleAgentSettings : AbstractOptionGroup<DoubleAgent>
    {
        public override string GroupName => "Double Agent Options";
        [ModdedToggleOption("Can Vent")]
        public bool CanVent { get; set; }
    }
}
