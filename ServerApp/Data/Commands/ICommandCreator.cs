using ServerApp.Data.Commands.Payloads;
using ServerApp.Data.Receivers;

namespace ServerApp.Data.Commands
{
    public interface ICommandCreator
    {
        CreateCommand<CommandHandler>                          CreateDragon();
        CreateCommand<CommandHandler, CreateHeroPayload>       CreateHero(CreateHeroPayload payload);
        CreateCommand<CommandHandler, CreateHitPayload>        CreateHit(CreateHitPayload payload);
        ReadCommand  <CommandHandler, ReadDragonByIdPayload>   ReadDragonById(ReadDragonByIdPayload payload);
        ReadCommand  <CommandHandler, ReadDragonsPayload>      ReadDragons(ReadDragonsPayload payload);
        ReadCommand  <CommandHandler, ReadHeroByNamePayload>   ReadHeroByName(ReadHeroByNamePayload payload);
        ReadCommand  <CommandHandler, ReadHeroesPayload>       ReadHeroes(ReadHeroesPayload payload);
        ReadCommand  <CommandHandler, ReadHeroesByNamePayload> ReadHeroesByName(ReadHeroesByNamePayload payload);
        ReadCommand  <CommandHandler, ReadHeroHitsPayload>     ReadHeroHits(ReadHeroHitsPayload payload);
    }                
}