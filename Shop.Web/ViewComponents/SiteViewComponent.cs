﻿using Microsoft.AspNetCore.Mvc;

namespace Shop.Web.ViewComponents;


#region site header

public class SiteHeaderViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("SiteHeader");
    }
}

#endregion

#region site footer

public class SiteFooterViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("SiteFooter");
    }
}

#endregion