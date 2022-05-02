using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Decrypt_Library.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        public static Models.User CreateUser()
        {
            string userNameInput = "";
            string ssn = "";
            string passwordInput = "";
            string phoneNrInput = "";
            string emailAddressInput = "";

            bool inputWasWrong = true;
            do
            {
                userNameInput = Console.ReadLine();
                if (userNameInput.Any(char.IsDigit) || userNameInput.Any(char.IsPunctuation) || String.IsNullOrEmpty(userNameInput))
                {
                    inputWasWrong = true;
                    Console.WriteLine("Vänligen försök igen - Siffror, skiljetecken eller tom rad är ej tillåtet");
                    continue;
                }

                Console.WriteLine();
                Console.Write("Ange personnummer: ");

                ssn = Console.ReadLine();
                if (ssn.Any(char.IsPunctuation) || String.IsNullOrEmpty(ssn) || ssn.Length != 10 || ssn.Any(char.IsLetter))
                {
                    inputWasWrong = true;
                    Console.WriteLine("Vänligen använd format: YYMMDDNNNN och försök igen");
                    continue;
                }

                Console.WriteLine();
                Console.Write("Ange ditt lösenord: ");


                passwordInput = Console.ReadLine();
                if (!passwordInput.Any(char.IsDigit) || passwordInput.Any(char.IsPunctuation) || String.IsNullOrEmpty(passwordInput) || passwordInput.Length < 8)
                {
                    inputWasWrong = true;
                    Console.WriteLine("Ditt lösenord ska innehålla minst 1 siffra, vara 8 karaktärer långt och utan skiljetecken");
                    continue;
                }

                Console.WriteLine();
                Console.Write("Ange ditt telefonnr: ");

                phoneNrInput = Console.ReadLine();
                if (!phoneNrInput.Any(char.IsDigit) || phoneNrInput.Any(char.IsPunctuation) || String.IsNullOrEmpty(phoneNrInput) || phoneNrInput.Length != 10)
                {
                    inputWasWrong = true;
                    Console.WriteLine("Ange ditt telefonnummer i 10 siffror");
                    continue;
                }

                Console.WriteLine();
                Console.WriteLine("Ange din e-mail (Ex: abc123@hotmail.com): ");

                emailAddressInput = Console.ReadLine();
                if (!emailAddressInput.Any(char.IsPunctuation) || String.IsNullOrEmpty(emailAddressInput))
                {
                    inputWasWrong = true;
                    Console.WriteLine("Försök igen, använd giltigt format enligt ovan");
                    continue;
                }

            } while (!inputWasWrong);

            Console.WriteLine();

            var newCustomer = new Models.User()
            {
                UserName = userNameInput,
                Ssn = Convert.ToInt64(ssn),
                Password = passwordInput,
                Phonenumber = Convert.ToInt64(phoneNrInput),
                Email = emailAddressInput,
                UserTypeId = 3
            };

            EntityFrameworkCode.EntityframeworkUsers.CreateUser(newCustomer);

            return newCustomer;
        }
    }
}