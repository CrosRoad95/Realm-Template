using Realm.Resources.AgnosticGuiSystem;
using Realm.Server.Interfaces;
using Serilog;
using System.Diagnostics;

namespace RealmRPG.ConsoleUtilities;

public sealed class HotReloadLogic
{
    public HotReloadLogic(IInternalRPGServer rpgServer, ILogger logger, string path)
    {
        var hotReload = new HotReload(path);
        hotReload.OnReload += async () =>
        {
            var stopwatch = Stopwatch.StartNew();
            await rpgServer.GetRequiredService<AgnosticGuiSystemService>().UpdateGuiFiles();
            logger.Information("Updated guis in: {time}ms", stopwatch.ElapsedMilliseconds);
        };
    }
}