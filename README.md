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
