using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public class PermissionManager
    {
        public static bool CanEditData(string role)
        {
            return RoleManager.HasPermission(role, "Edit");
        }

        public static bool CanViewData(string role)
        {
            return RoleManager.HasPermission(role, "View");
        }
    }
}
