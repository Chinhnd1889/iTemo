using iTemo.Core.Enum;

namespace iTemo.Models
{
    public class SearchCriteriaRequest
    {
        public string Keyword { get; set; }

        public string ViewName { get; set; }

        public bool IsExport { get; set; }

        public ExportTypeEnum ExportType { get; set; }
    }
}