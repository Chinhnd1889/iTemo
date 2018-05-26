using iTemo.Core.Enum;

namespace iTemo.Business.Model
{
    public class SearchCriteriaModel
    {
        public string Keyword { get; set; }

        public string ViewName { get; set; }

        public bool IsExport { get; set; }

        public ExportTypeEnum ExportType { get; set; }
    }
}
