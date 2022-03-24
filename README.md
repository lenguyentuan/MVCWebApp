## Controller

- Controller is a class which is inherited Controller class: Microsoft.AspNetCore.Mvc.Controller
- Action in Controller is public method (mustn't be static)
- Action method can return any value type, generally, IActionResult
- Services were injected into Controller through constructor

## View

- View has extension .cshtml
- View was return by Action, had address: /View/ControllerName/ActionName.cshtml

## Transmit Data to View

- Model
- ViewData
- ViewBag
- TempData

## Route

- endpoints.MapControllerRoute
- endpoints.MapAreaControllerRoute
- [AcceptVerbs("POST","GET")]
- [Route("Pattern")]
- [HttpGet] [HttpPost]

## Url Generation

### UrlHelper: Action, ActionLink, RouteUrl, Link

```
Url.Action("ActionName","ControllerName" new {area = "areaName", id=.. name=""...})
```

### HtmlTagHelper: ``` <a> <button> <form>

Attributes are used:

```
asp-area="Area"
asp-action="Action"
asp-controller="Product"
asp-route...="123"
asp-route="default" -- default is a route name
```

Person Access Token: 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
