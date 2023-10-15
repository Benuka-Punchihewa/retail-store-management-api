using Microsoft.AspNetCore.Mvc;

namespace RetailManagment.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("errors")]
    public IActionResult Error()
    {
        return Problem();
    }
}