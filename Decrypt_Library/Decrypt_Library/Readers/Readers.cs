using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decrypt_Library.Readers
{
    internal class Readers
    {

        #region Stringreaders
        public static bool StringReaderSpecifyStringRange(string userInput, int minNum, int maxNum)
        {
            if (!StringReader(userInput))
                return false;

            if (userInput.Length < minNum || userInput.Length > maxNum)
                return false;

            return true;
        }

        public static bool StringReader(string userInput)
        {
            if (!userInput.Any(char.IsLetter) || string.IsNullOrEmpty(userInput))
                return false;

            return true;
        }

        public static bool StringLengthEqualsTo(string userInput, int stringLength)
        {
            if (!StringReader(userInput))
                return false;

            if (userInput.Length != stringLength)
                return false;

            return true;
        } 
        public static bool IsStringAndIsInt(string userInput)
        {
            if (userInput.Any(char.IsDigit) && userInput.Any(char.IsLetter))
                return true;

            return false;
        }
        public static bool StringPasswordCorrect(string passwordInput, int minNum, bool digits)
        {

            if (!IsStringAndIsInt(passwordInput))
                return false;

            if (passwordInput.Length < minNum)
                return false;

            if(digits == false)
                return false;

            return true;
        }
        // Reader för email
        
        #endregion

        #region int reader
        public static bool IntReaderString(string userInput)
        {
            if (userInput.Any(char.IsLetter))
                return false;

            return true;
        }
        
        // reader för personnummer
        /*
        public static bool SSNReader(string SSNInput, int minNum)
        {
            if (!IntReader(SSNInput, out int num))
                return false;

            if(!SSNInput < minNum)
                    return true;

        }
        */
        
        public static bool IntEqualsToSelectedNumber(string userInput, int selectedNumber, out int num)
        {
            num = 0;
            if (Int32.TryParse(userInput, out num))
            {
                if (num == selectedNumber)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IntReaderSpecifyIntRange(string userInput, int minNum, int maxNum, out int num)
        {
            num = 0;

            if (Int32.TryParse(userInput, out num))
            {
                if (num <= maxNum && num >= minNum)
                    return true;
            }
            return true;
        }
        #endregion
    }
}
