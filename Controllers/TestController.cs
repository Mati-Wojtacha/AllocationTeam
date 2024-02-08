using Microsoft.AspNetCore.Mvc;

public class TestController : ControllerBase
{
    private readonly DatabaseConnectionChecker _checker;

    public TestController(DatabaseConnectionChecker checker)
    {
        _checker = checker;
    }

    [HttpGet]
    [Route("check-connection")]
    public async Task<IActionResult> CheckConnection()
    {
        var isConnected = await _checker.IsConnectionSuccessfulAsync();
        if (isConnected)
        {
            return Ok("Connection to the database is successful.");
        }
        else
        {
            return StatusCode(500, "Failed to connect to the database.");
        }
    }
}
