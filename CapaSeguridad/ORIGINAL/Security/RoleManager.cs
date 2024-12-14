using System.Collections.Generic;


namespace Security
{
    public static class RoleManager
    {
        private static readonly Dictionary<string, List<string>> RolesPermissions = new Dictionary<string, List<string>>
            {
                { "Admin", new List<string> { "Edit", "View", "Delete" } },
                { "User", new List<string> { "View" } }
            };

        public static bool HasPermission(string role, string permission)
        {
            return RolesPermissions.ContainsKey(role) && RolesPermissions[role].Contains(permission);
        }
    }
}
