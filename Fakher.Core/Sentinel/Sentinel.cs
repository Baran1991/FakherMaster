using System;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.Core.Sentinel
{
    public static class Sentinel
    {
        public static event EventHandler<PasswordUINeededArgs> PasswordUINeeded;

        private static PasswordUINeededArgs OnPasswordUINeeded()
        {
            PasswordUINeededArgs args = null;
            if (PasswordUINeeded != null)
            {
                args = new PasswordUINeededArgs();
                PasswordUINeeded(null, args);
            }
            return args;
        }

        public static void Check(UserInfo userInfo, AccessTagType tagType)
        {
            AccessTag accessTag = userInfo.GetAccessTag(tagType);
            if (accessTag == null)
                throw new Exception(string.Format("شما مجوز [{0}] را ندارید. انجام این عمل برای شما امکان پذیر نیست.",
                                                  tagType.ToDescription()));
            if (accessTag.HasPassword)
            {
                PasswordUINeededArgs args = OnPasswordUINeeded();
                if(string.IsNullOrEmpty(args.Password))
                {
                    throw new Exception(string.Format("انجام این عمل بدون وارد کردن رمز امکان پذیر نیست."));
                }
                if(args.Password != accessTag.Password)
                {
                    throw new Exception(string.Format("رمز اشتباه است."));
                }
            }
        }
    }

    public class PasswordUINeededArgs : EventArgs
    {
        public string Password { get; set; }
    }
}