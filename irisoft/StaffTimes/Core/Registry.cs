using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Core
{
    public static class Registry
    {
        private const string Login = "Login";
        private const string Password = "Passwd";
        private const string ProgramName = "StaffTime";

        public static Tuple<string, string> ReadFromFile()
        {
            string login = "";
            string password = "";
            RegistryKey hkcu = Microsoft.Win32.Registry.CurrentUser;
            RegistryKey hkSoftware = hkcu.OpenSubKey("Software");
            //string[] hkSoftwareIrisoft = hkcu.GetSubKeyNames("Irisoft");
            try
            {
                if (hkSoftware != null)
                {
                    RegistryKey hkIrisoft = hkSoftware.OpenSubKey("Irisoft");
                    if (hkIrisoft != null)
                    {
                        var rkProgramm = hkIrisoft.OpenSubKey(ProgramName);
                        if (rkProgramm != null)
                        {
                            login = rkProgramm.GetValue(Login) as string;
                            var passwordRaw = rkProgramm.GetValue(Password) as string;
                            if (!string.IsNullOrEmpty(login))
                                password = Crypto.Decript(passwordRaw, login);
                        }
                    }
                }
            }
            catch (SystemException e)
            {
                MessageBox.Show(e.Message, "Приложение будет завершено.");
            }
            return new Tuple<string, string>(login, password);
        }


        public static Tuple<string, string> ReadLoginPassword()
        {
            string login = "";
            string password = "";
            RegistryKey hkcu = Microsoft.Win32.Registry.CurrentUser;
            RegistryKey hkSoftware = hkcu.OpenSubKey("Software");
            //string[] hkSoftwareIrisoft = hkcu.GetSubKeyNames("Irisoft");
            try
            {
                if (hkSoftware != null)
                {
                    RegistryKey hkIrisoft = hkSoftware.OpenSubKey("Irisoft");
                    if (hkIrisoft != null)
                    {
                        var rkProgramm = hkIrisoft.OpenSubKey(ProgramName);
                        if (rkProgramm != null)
                        {
                            login = rkProgramm.GetValue(Login) as string;
                            var passwordRaw = rkProgramm.GetValue(Password) as string;
                            if(!string.IsNullOrEmpty(login))
                                password = Crypto.Decript(passwordRaw, login);
                        }
                    }
                }
            }
            catch (SystemException e)
            {
                MessageBox.Show(e.Message, "Приложение будет завершено.");
            }
            return new Tuple<string, string>(login, password);
        }

        public static void WriteLoginPassword(string login, string password)
        {
            RegistryKey hkcu = Microsoft.Win32.Registry.CurrentUser;
            RegistryKey hkSoftware = hkcu.OpenSubKey("Software");
            //string[] hkSoftwareIrisoft = hkcu.GetSubKeyNames("Irisoft");
            try
            {
                if (hkSoftware != null)
                {
                    RegistryKey hkIrisoft = hkSoftware.OpenSubKey("Irisoft") ?? hkSoftware.CreateSubKey("Irisoft");
                    if (hkIrisoft != null)
                    {
                        var rkProgramm = hkIrisoft.OpenSubKey(ProgramName);
                        if (rkProgramm == null)
                        {
                            rkProgramm = hkIrisoft.CreateSubKey(ProgramName);
                        }
                        if (rkProgramm != null)
                        {
                            rkProgramm.SetValue(Login, login);
                            password = Crypto.Encript(password, login);
                            rkProgramm.SetValue(password, login);
                        }
                    }
                }
            }
            catch (SystemException e)
            {
                MessageBox.Show(e.Message, "Приложение рекомендуется запустить в режиме администратора.");
            }
        }
    }
}
