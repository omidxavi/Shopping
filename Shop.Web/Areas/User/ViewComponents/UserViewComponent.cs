using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces;
using Shop.Web.Extensions;

namespace Shop.Web.Areas.User.ViewComponents;

public class UserViewComponent : ViewComponent
{
     #region constractor

     private readonly IUserService _userService;
     public UserViewComponent(IUserService userService)
     {
          _userService = userService;
     }

     public async Task<IViewComponentResult> InvokeAsync()
     {
          if (User.Identity.IsAuthenticated)
          {
               var user = await _userService.GetUserById(User.GetUserId());
               return View("UserSideBar",user);


          }
     }
     #endregion
}