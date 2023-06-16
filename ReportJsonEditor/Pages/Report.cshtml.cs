using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ReportJsonEditor.Models;
using ReportJsonEditor.Services;

namespace ReportJsonEditor.Pages;

public class ReportModel : PageModel
{
    private readonly ILogger<ReportModel> _logger;
    private readonly AppSettingsOptions _options;

    public ReportModel(ILogger<ReportModel> logger, IOptions<AppSettingsOptions> options)
    {
        _logger = logger;
        _options = options.Value;
    }

    public Report Report { get; private set; }
    public string JsonText { get; private set; }

    public void OnGet()
    {
        
        var jsonFilePath = Path.Combine(_options.EditorRootPath, "Data", "rpt_Core_AllContentListing_live.json");

        var reportService = new ReportService(jsonFilePath);
        var json = System.IO.File.ReadAllText(jsonFilePath);

        JsonText = json;
        Report = JsonConvert.DeserializeObject<Report>(json);

        //var json = File(jsonFilePath);
        //return File(json, "application/json", "rpt_Core_AllContentListing_live.json");
    }

    
}
