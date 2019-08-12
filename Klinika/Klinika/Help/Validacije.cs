using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinika.Help
{
    public  class Validacije
    {
        public Validacije() { }
        public static bool validnostJMBG(String JMBG)
        {
            for(int i = 0; i < JMBG.Length; i++) { if (JMBG[i] < '0' || JMBG[0] > '9') return false; }
            List<int> JMBG_N = JMBG.Select(x => Int32.Parse(x.ToString())).ToList();

            if (JMBG_N.Count != 13)
                return false;

            else
            {
                Double eval = 0;
                for (int i = 0; i < 6; i++)
                {
                    eval += (7 - i) * (JMBG_N[i] + JMBG_N[i + 6]);
                }
                return JMBG_N[12] == 11 - eval % 11;
            }
        }

        public static void check_and_set_message(String value, Func<String, Boolean> validator_func, Control origin, ErrorProvider errProv, String message)
        {
            if (validator_func(value))
                errProv.SetError(origin, "");
            else
                errProv.SetError(origin, message);
        }

        public static Boolean any_has_error(List<Control> controls, ErrorProvider errProv)
        {
            return controls.Any(x => errProv.GetError(x) != "");
        }

        public static Boolean has_error(Control control, ErrorProvider errProv)
        {
            return errProv.GetError(control) != "";
        }

        public static Boolean validateNaziv(String value)
        {

            if (value.Length > 0 && value.Length < 20 && value != null)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if ((value[i] < 65 || value[i] > 90) && (value[i] < 97 || value[i] > 122))
                        return false;
                }
                return true;
            }
            else return false;
        }
        public static Boolean validateUsername(String value)
        {
            if (value.Length > 6 && value.Length < 20 && value != null)
            {
                return true;
            }
            else return false;
        }
        public static string CalculateHash(string input)
        {
            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
