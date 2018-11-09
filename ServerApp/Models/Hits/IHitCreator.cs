using ServerApp.Models.Characters;
using ServerApp.Models.Weapons;

namespace ServerApp.Models.Hits
{
    public interface IHitCreator
    {
        Hit Hit(ICharacter source, ICharacter target, IWeapon weapon);
    }
}
