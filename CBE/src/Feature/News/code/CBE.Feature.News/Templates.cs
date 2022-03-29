namespace CBE.Feature.News
{
    using Sitecore.Data;

    public struct Templates
    {
        public struct NewsArticle
        {
            public static readonly ID ID = new ID("{2F75C8AF-35FC-4A88-B585-7595203F442C}");

            public struct Fields
            {
                public static readonly ID Title = new ID("{BD9ECD4A-C0B0-4233-A3CD-D995519AC87B}");
                public const string Title_FieldName = "NewsTitle";

                public static readonly ID Image = new ID("{3437EAAC-6EE8-460B-A33D-DA1F714B5A93}");

                public static readonly ID Date = new ID("{C464D2D7-3382-428A-BCDF-0963C60BA0E3}");

                public static readonly ID Summary = new ID("{9D08271A-1672-44DD-B7EF-0A6EC34FCBA7}");
                public const string Summary_FieldName = "NewsSummary";

                public static readonly ID Body = new ID("{801612C7-5E98-4E3C-80D2-A34D0EEBCBDA}");
                public const string Body_FieldName = "NewsBody";
            }
        }

        public struct NewsFolder
        {
            public static readonly ID ID = new ID("{74889B26-061C-4D6A-8CDB-422665FC34EC}");
        }

        public struct Article
        {
            public static readonly ID ID = new ID("{94A8C8E9-690B-4E65-98E7-F95800222767}");
            public struct Fields
            {
                public static readonly ID Title = new ID("{C30A013F-3CC8-4961-9837-1C483277084A}");
                public static readonly ID Body = new ID("{D74F396D-5C5E-4916-BD0A-BFD58B6B1967}");
                public static readonly ID Summary = new ID("{AC3FD4DB-8266-476D-9635-67814D91E901}");
                public static readonly ID Image = new ID("{9492E0BB-9DF9-46E7-8188-EC795C4ADE44}");

            }
        }
    }
}