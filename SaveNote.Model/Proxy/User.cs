using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace SaveNote.Model
{
    public partial class User
    {
        public static string GetActivateUrl()
        {
            return Guid.NewGuid().ToString("N");
        }

        public string ConfirmPassword { get; set; }

        public string Captcha { get; set; }

        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var role in rolesArray)
            {
                var hasRole = UserRole.Any(p => string.Compare(p.Role.Code, role, true) == 0);
                if (hasRole)
                {
                    return true;
                }
            }
            return false;
        }

        public static string CreatePassHash(string pass)
        {
            string passHash = pass;

            MD5 hashMaker = MD5.Create();
            byte[] hash = hashMaker.ComputeHash(Encoding.Default.GetBytes(pass));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; ++i)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            passHash = sb.ToString();

            return passHash;
        }
    }
}
