using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend.Utilities.Util
{
    public static class PolicyUtil
    {
        public static bool CheckPassword(string password)
        {
            if (password.Length < 6 || password.Length>18)
            {
                return false;
            }
            return password.Select(c => (byte)c).All(code => !((code < 48) | (code > 122)));
        }

        public static bool CheckUserName(string userName)
        {
            // Độ dài từ 4-16
            if (userName.Length < 6 || userName.Length > 19) return false;

            //Kí tự đầu tiên phải là chữ cái
            var fillterChar = "abcdefghijklmnopqrstuvxyzw0123456789._";
            if (fillterChar.IndexOf(userName[0]) < 0) return false;

            //Kí tự '.' không được xuất hiện liền nhau
            if (userName.IndexOf("..") >= 0) return false;

            // Ký tự '.' không được ở sau cùng
            if (userName.EndsWith(".")) return false;

            //Chuỗi hợp lệ   abcdefghijklmnopqrstuvxyzw012345678.
            fillterChar = "abcdefghijklmnopqrstuvxyzw0123456789._";
            return userName.All(t => fillterChar.IndexOf(t) >= 0);
        }
    }
}
