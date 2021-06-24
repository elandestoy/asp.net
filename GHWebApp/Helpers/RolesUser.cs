
using System;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

namespace  GHWebApp.Helpers
{
    public static class RolesUser
    {
        public const string Administrator = "Admin";
        public const string Assistant = "Assistant";
        public const string rApplicant = "Applicant";
        public const string rManager = "Manager";
    }
}