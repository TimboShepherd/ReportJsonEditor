using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReportJsonEditor.Pages;

public class ReportModel : PageModel
{
    private readonly ILogger<ReportModel> _logger;

    public ReportModel(ILogger<ReportModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        
        var jsonFilePath = Path.Combine(HttpContext.Request.PathBase, "ReportJsonEditor", "Data", "rpt_Core_AllContentListing_live.json");

        var reportService = new ReportService(jsonFilePath);
        var json = File.ReadAllText(jsonFilePath);
        return Results.Ok(json);
    }

    public async Task OnPost()
    {
        using var reader = new StreamReader(request.Body);
        var json = await reader.ReadToEndAsync();
        File.WriteAllText(jsonFilePath, json);
        return Results.Ok();
    }
}
