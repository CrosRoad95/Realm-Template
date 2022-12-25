using Realm.Configuration;
using Realm.Logging;
using Realm.Module.Discord;
using Realm.Module.Grpc;
using Realm.Server;
using Realm.Server.Modules;
using Serilog.Events;

namespace RealmRPG.ConsoleUtilities;

public static class RPGServerBuilderExtensions
{
    public static RPGServerBuilder AddDefaultConsole(this RPGServerBuilder serverBuilder)
    {
        serverBuilder.AddConsole(new DefaultServerConsole());
        return serverBuilder;
    }

    public static RPGServerBuilder AddDefaultLogger(this RPGServerBuilder serverBuilder)
    {
        var logger = new RealmLogger(LogEventLevel.Verbose)
            .AddSeq()
            .GetLogger();
        serverBuilder.AddLogger(logger);
        return serverBuilder;
    }

    public static RPGServerBuilder AddDefaultModules(this RPGServerBuilder serverBuilder)
    {
        serverBuilder.AddModule<DiscordModule>();
        serverBuilder.AddModule<IdentityModule>();
        serverBuilder.AddModule<GrpcModule>();
        return serverBuilder;
    }

    public static RPGServerBuilder AddDefaultConfiguration(this RPGServerBuilder serverBuilder)
    {
        var configurationProvider = new RealmConfigurationProvider();
        serverBuilder.AddConfiguration(configurationProvider);
        return serverBuilder;
    }
}
