using BeatPass.Data.Cart;
using BeatPass.Data.Services;
using BeatPass.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeatPass.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IFestivalsService _festivalsService;
        private readonly ShoppingCart _shoppingCart;
        public OrdersController(IFestivalsService festivalsService, ShoppingCart shoppingCart)
        {
            _festivalsService = festivalsService;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View();
        }
    }
}
