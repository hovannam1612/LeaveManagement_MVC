namespace LeaveManagement.WebApp.Utils.Constants
{
    public static class UserRole
    {
        public const string Employee = "Employee";

        public const string Admin = "Admin";

        public const string UserOrAdmin = Employee + ", " + Admin;
    }
}