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
        #endregion

        #region int reader
        public static bool IntReaderString(string userInput)
        {
            if (userInput.Any(char.IsLetter))
                return false;

            return true;
        }

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
