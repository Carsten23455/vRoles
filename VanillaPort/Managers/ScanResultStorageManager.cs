using vRoles.VanillaPort.Buttons;

namespace vRoles.VanillaPort.Managers
{
    public static class ScanResultStorageManager
    {
        public static readonly Dictionary<byte, ScanResult> Results = new();

        public static void Store(byte playerId, ScanResult result)
        {
            Results[playerId] = result;
        }

        public static ScanResult? Get(byte playerId)
        {
            return Results.TryGetValue(playerId, out var result) ? result : null;
        }

        public static void Clear()
        {
            Results.Clear();
        }
    }
}
