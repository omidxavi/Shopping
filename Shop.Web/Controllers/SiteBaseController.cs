using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Web.Controllers;

[Authorize]
[Area("User")]
[Route("user")]
public class SiteBaseController : Controller
{
    protected string ErrorMessage = "ErrorMessage";
    protected string SuccessMessage = "SuccessMessage";
    protected string WarningMessage = "WarningMessage";
    protected string InfoMessage = "InfoMessage";

}