namespace QBSync.API;

public class ApiEndpoints
{
    private const string ApiBase = "api";
    
    public static class QbItems
    {
        private const string Base = $"{ApiBase}/qbItems";

        public const string GetAll = Base;

        public static class CustomColumns
        {
            private const string CustomFieldsBase = $"{Base}/customColumns";
            public const string GetAll = CustomFieldsBase;
        }
    }
}