using Realm.Server.Services;
using Serilog;

namespace RealmRPG.Logic;

internal sealed class CommandsLogic
{
    private readonly RPGCommandService _commandService;
    private readonly ILogger _logger;

    public CommandsLogic(RPGCommandService commandService, ILogger logger)
    {
        _commandService = commandService;
        _logger = logger;
        _commandService.AddCommandHandler("gp", (entity, args) =>
        {
            logger.Information("{position}, {rotation}", entity.Transform.Position, entity.Transform.Rotation);
            return Task.CompletedTask;
        });
    }
}
