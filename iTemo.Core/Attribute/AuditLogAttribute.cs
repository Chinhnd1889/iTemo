using System;

namespace iTemo.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AuditLogAttribute : System.Attribute
    {
        public LogType LogType { get; set; }

        public string Name { get; set; }

        public string PrimaryKey { get; set; }

        public Type ForeignRepositoryType { get; set; }

        public string AdditionalQuery { get; set; }

        public string[] CombineFields { get; set; }

        public string SeperatedBy { get; set; }

        public string PropertyName { get; set; }

        public AuditLogAttribute(LogType logType, string name)
        {
            LogType = logType;
            Name = name;
        }

        public AuditLogAttribute(LogType logType, string name, string primaryKey)
        {
            LogType = logType;
            Name = name;
            PrimaryKey = primaryKey;
        }

        public AuditLogAttribute(LogType logType, string name, string[] combineFields, string seperatedBy)
        {
            LogType = logType;
            Name = name;
            CombineFields = combineFields;
            SeperatedBy = seperatedBy;
        }

        public AuditLogAttribute(LogType logType, string name, Type foreignRepositoryType, string propertyName)
        {
            LogType = logType;
            Name = name;
            ForeignRepositoryType = foreignRepositoryType;
            PropertyName = propertyName;
        }

        public AuditLogAttribute(LogType logType, string name, Type foreignRepositoryType, string[] combineFields, string seperatedBy)
        {
            LogType = logType;
            Name = name;
            ForeignRepositoryType = foreignRepositoryType;
            CombineFields = combineFields;
            SeperatedBy = seperatedBy;
        }

        public AuditLogAttribute(LogType logType, string name, Type foreignRepositoryType, string additionalQuery, string propertyName)
        {
            LogType = logType;
            Name = name;
            ForeignRepositoryType = foreignRepositoryType;
            AdditionalQuery = additionalQuery;
            PropertyName = propertyName;
        }
    }

    public enum LogType
    {
        Data = 1,
        Profile = 2, //By UserId
        Combine = 3,
        Remark = 4,
        Attachment = 5,
        PublicTag = 6,
        Keyword = 7,
        Profile2 = 8, //By UserProfileId
        ServiceRequestDetail = 9,
        GetListRemarkChange = 10,
        GetListKeywordChange = 11,
        Profile3 = 12, //By UserProfileId
        Division = 13, //By division
        LinkedCompany = 14,
        LinkedContact = 15,
        LinkedContactLog = 16,
        LinkedCompanyRequest = 17,
        LinkedOpportunity = 18,
        LinkedPFC = 19,
        LinkedServiceRequest = 20,
        LinkedGTP = 21,
        LinkedSurvey = 22,
        LinkedObject = 23,
        IndustryNorm = 24,
        LinkToSurvey = 25
    }
}