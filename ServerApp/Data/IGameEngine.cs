using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Paginations;
using ServerApp.ViewModels.Dragons;
using ServerApp.ViewModels.Heroes;

namespace ServerApp.Data
{
    public interface IGameEngine
    {
        void CreateDragon();
        IView<DragonViewModel> CreateView<TView>(DragonsFilter filter, DragonsOrdering ordering, Order order, int pageSize, int pageNumber) where TView : IView<DragonViewModel>;
        IView<HeroViewModel> CreateView<TView>(HeroesFilter filter, HeroesOrdering ordering, Order order, int pageSize, int pageNumber) where TView : IView<HeroViewModel>;
        void HitDragon();
        bool Signin(string token);
        Task<IActionResult> Signup(SignupHeroViewModel name);
    }
}