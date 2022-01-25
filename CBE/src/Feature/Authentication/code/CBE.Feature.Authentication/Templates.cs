using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.Authentication
{
    public struct Templates
    {
        public struct AccountsSettings
        {
            public static readonly ID ID = new ID("{59D216D1-035C-4497-97B4-E3C5E9F1C06B}");

            public struct Fields
            {
                public static readonly ID AccountsDetailsPage = new ID("{ED71D374-8C33-4561-991D-77482AE01330}");
                public static readonly ID RegisterPage = new ID("{71962360-10D8-4B98-BB8D-57660CE11127}");
                public static readonly ID LoginPage = new ID("{60745023-FFD5-400E-8F80-4BCA9F2ABB29}");
                public static readonly ID ForgotPasswordPage = new ID("{F3CD2BB8-472B-4DF0-87C0-A13098E391CA}");
                public static readonly ID AfterLoginPage = new ID("{B128E2B3-3865-4F1C-A147-5F248676D3F5}");
                public static readonly ID ForgotPasswordMailTemplate = new ID("{365254C4-1C1C-493A-9710-671574717898}");
                public static readonly ID SendOTPTemplate = new ID("{BC741ACD-AF9E-485D-A6BC-445F3C490542}");
                public static readonly ID SendSMSOTPTemplate = new ID("{613194C0-9179-46FE-8041-7232C8EF4F08}");
                public static readonly ID RegisterOutcome = new ID("{835FA523-D28A-46A2-A589-6AA4A5BF0846}");
                public static readonly ID ActiveAccountTemplate = new ID("{9B116484-E4D9-475F-B270-83D5BA44721F}");
                public static readonly ID ChangeEmailMailTemplate = new ID("{175505AA-3931-4771-A58B-A27585B61D34}");
                public static readonly ID ChangePassword = new ID("{0C9B1A0F-2706-48C5-9F01-29B1BF4F04DF}");
                public static readonly ID spinitiatedsso = new ID("{1E9FA00C-DE4E-44D3-9CFA-4B7E21A38993}");
                public static readonly ID ActiveOrganizationAccountTemplate = new ID("{8B4DFD6A-DAB4-4915-8307-2762639B1115}");
                public static readonly ID DeactivateRepresentativeTemplate = new ID("{721D9605-D549-49DC-9EE5-3D676CE5A251}");
            }
        }

        public struct MailTemplate
        {
            public static readonly ID ID = new ID("{26DF8F38-7E1B-43D2-85DD-68DF05FA276B}");

            public struct Fields
            {
                public static readonly ID From = new ID("{8605948C-60FB-46B8-8AAA-4C52561B53BC}");
                public static readonly ID Subject = new ID("{0F45DF05-546F-462D-97C0-BA4FB2B02564}");
                public static readonly ID Body = new ID("{1519CCAD-ED26-4F60-82CA-22079AF44D16}");
            }
        }

        public struct Interest
        {
            public static readonly ID ID = new ID("{C9B1855E-CA80-4414-B5BA-956CB67DC5A9}");

            public struct Fields
            {
                public static readonly ID Title = new ID("{1FBE5200-2C62-4A32-BA84-CFFE3CF665D3}");
            }
        }

        public struct ProfileSettigs
        {
            public static readonly ID ID = new ID("{DF3E031E-4D08-44AD-A3CF-80A1321900C3}");

            public struct Fields
            {
                public static readonly ID UserProfile = new ID("{998EDEC8-27F7-4590-A337-B2DF6ED5ACD0}");
                public static readonly ID InterestsFolder = new ID("{021AA3F7-206F-4ACC-9538-F6D7FE86B168}");
                public static readonly ID CompanyProfile = new ID("{74B724A0-9878-445C-959A-92FBA24587E2}");
                public static readonly ID OrganizationProfile = new ID("{322718C1-CCB8-48BD-AE34-02EBF20D8110}");
                public static readonly ID RepresentativeProfile = new ID("{BF8D90CF-414E-41A2-9212-B3AFDAF0BDC0}");

            }
        }


        public struct UserProfile
        {
            public static readonly ID ID = new ID("{696D276B-786A-4D1E-B8BB-8E139DB7BE7C}");

            public struct Fields
            {
                public static readonly ID FirstName = new ID("{E7BC8A3E-3201-4556-B2FF-FF4DB04DB081}");
                public static readonly ID LastName = new ID("{EE21278F-4F83-4A10-8890-66B957F3D312}");
                public static readonly ID PhoneNumber = new ID("{F7A1605F-7BBB-4BC7-BBB4-9E0546648E1D}");
                public static readonly ID Interest = new ID("{A5D0B0AD-CE4E-4E06-B821-F30416B7DEC9}");
            }
        }
        public struct CompanyProfile
        {
            public static readonly ID ID = new ID("{D9AAB41C-BC3D-4DE9-9387-0CFCE4847B12}");

            public struct Fields
            {
                public static readonly ID FullName = new ID("{E7BC8A3E-3201-4556-B2FF-FF4DB04DB081}");
                public static readonly ID Origin = new ID("{EE21278F-4F83-4A10-8890-66B957F3D312}");
                public static readonly ID Mobile = new ID("{F7A1605F-7BBB-4BC7-BBB4-9E0546648E1D}");
                public static readonly ID ProCompany = new ID("{A5D0B0AD-CE4E-4E06-B821-F30416B7DEC9}");
                public static readonly ID NotificationEmail = new ID("{A5D0B0AD-CE4E-4E06-B821-F30416B7DEC9}");
                public static readonly ID Photo = new ID("{72112BC3-66F4-4263-B4AD-6153C918AF7B}");
            }
        }

        public struct OrganizationProfile
        {
            public static readonly ID ID = new ID("{87DD65B9-7D33-4A86-BA54-1CA48158D84D}");

            public struct Fields
            {
                public static readonly ID NameEnglish = new ID("{BF64D58A-9569-48EA-B92E-D4D016D2FEED}");
                public static readonly ID NameArabic = new ID("{0C428FB0-B056-4B8B-BAC1-BE2E5159EADA}");
                public static readonly ID PhoneNumber = new ID("{B563EE8E-C983-4FE8-A8A0-E6149B0EEB24}");
                public static readonly ID NotificationEmail = new ID("{A5D0B0AD-CE4E-4E06-B821-F30416B7DEC9}");
                public static readonly ID SecurityQuestion = new ID("{704E074B-CC46-4FC2-AD99-119421444F4F}");
                public static readonly ID Answer = new ID("{C1A340BB-6661-48C3-9F6F-FAD36D64B5D8}");
            }
        }
        public struct RepresentativeProfile
        {
            public static readonly ID ID = new ID("{7AFAAE39-661D-418E-BDC5-FE30DF0B7CD7}");

            public struct Fields
            {
                public static readonly ID RepresentativeFullName = new ID("{8E151451-1806-4E44-89E3-28DCFB0BA1E2}");
                public static readonly ID RepresentativeJobTitle = new ID("{CC73540A-E300-4E9D-AD3C-4F6FA70EBF51}");
                public static readonly ID RepresentativePhoneNumber = new ID("{62C10D68-EE05-4976-B508-EE730C059A21}");
                public static readonly ID NotificationEmail = new ID("{ADC4BD92-B1ED-4847-B3F7-BB4E803A241F}");
                public static readonly ID SecurityQuestion = new ID("{8C50955D-55A3-4B2B-A2C2-C204813EE3B1}");
                public static readonly ID Answer = new ID("{332E601F-240A-4758-9E8B-4E37C4D56B28}");
            }
        }
    }
}