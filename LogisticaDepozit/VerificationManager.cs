using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticaDepozit
{
    public class VerificationManager
    {
        private Dictionary<string, (string Code, DateTime Expiration)> verificationCodes = new Dictionary<string, (string, DateTime)>();
        private readonly int codeExpirationMinutes = 5;

        public string GenerateVerificationCode(string email)
        {
            string code = new Random().Next(100000, 999999).ToString();
            DateTime expiration = DateTime.Now.AddMinutes(codeExpirationMinutes);

            verificationCodes[email] = (code, expiration);

            Console.WriteLine($"Cod generat pentru {email}: {code} (expiră la {expiration})");
            return code;
        }

        public bool ValidateCode(string email, string code)
        {
            if (verificationCodes.ContainsKey(email))
            {
                var (storedCode, expiration) = verificationCodes[email];

                if (DateTime.Now > expiration)
                {
                    verificationCodes.Remove(email);
                    Console.WriteLine("Codul a expirat.");
                    return false;
                }

                if (storedCode == code)
                {
                    verificationCodes.Remove(email);
                    Console.WriteLine("Cod validat cu succes.");
                 
                    return true;
                }
            }

            Console.WriteLine("Cod invalid sau expirat.");
            return false;
        }
    }
}
