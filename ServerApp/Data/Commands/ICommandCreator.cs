using ServerApp.Data.Commands.Payloads;
using ServerApp.Data.Handlers;

namespace ServerApp.Data.Commands
{
    public interface ICommandCreator
    {
        ReadCommand<CommandHandler, ReadDragonsPayload>  ReadDragons (ReadDragonsPayload  payload);
        ReadCommand<CommandHandler, ReadHeroesPayload>   ReadHeroes  (ReadHeroesPayload   payload);
        ReadCommand<CommandHandler, ReadHeroHitsPayload> ReadHeroHits(ReadHeroHitsPayload payload);
    }
}