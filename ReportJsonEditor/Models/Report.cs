using System.Collections.Generic;

namespace ReportJsonEditor.Models
{
    public class UserGroup
    {
        public string GroupCode { get; set; }
        public List<string> ForcedValues { get; set; }
    }

    public class DataSource
    {
        public string DataSourceName { get; set; }
        public string ReportSelectTemplate { get; set; }
    }

    public class ReportInput
    {
        public string InputName { get; set; }
        public string InputType { get; set; }
        public string DefaultValue { get; set; }
        public string UiLabel { get; set; }
        public string UiControlType { get; set; }
        public string LiveSearchQuery { get; set; }
        public string DropdownLookupName { get; set; }
        public bool Required { get; set; }
        public string InputPlaceholder { get; set; }
        public string InputSelectWhereTemplate { get; set; }
    }

    public class Report
    {
        public string ReportName { get; set; }
        public string ReportCode { get; set; }
        public string ReportDescription { get; set; }
        public string ReportAdminNotes { get; set; }
        public int Active { get; set; }
        public List<UserGroup> UserGroups { get; set; }
        public string ExecutionTiming { get; set; }
        public string OutputType { get; set; }
        public DataSource DataSource { get; set; }
        public List<ReportInput> ReportInputs { get; set; }
    }
}