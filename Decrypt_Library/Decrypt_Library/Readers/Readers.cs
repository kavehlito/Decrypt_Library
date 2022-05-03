using System;
using System.Globalization;
using System.Linq;

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

            if (digits == false)
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
        }*/


        public static bool IntReaderConvertStringToInt(string userInput, out int num)
        {
            if (!int.TryParse(userInput, out num))
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

        #region default readers

        public static bool LegalIDRangeLanguage(string userInput, out int convertedUserIdInput)
        {
            var languageList = EntityFrameworkCode.EntityframeworkLanguages.ShowAllLanguages();

            if (!IntReaderConvertStringToInt(userInput, out convertedUserIdInput))
                return false;

            if (convertedUserIdInput > languageList.Count || convertedUserIdInput < 1)
                return false;

            return true;
        }

        public static bool LegalIDRangeCategoryId(string userInput, out int convertedUserIdInput)
        {
            var categoryList = EntityFrameworkCode.EntityframeworkCategories.ShowAllCategories();

            if (!IntReaderConvertStringToInt(userInput, out convertedUserIdInput))
                return false;

            if (convertedUserIdInput > categoryList.Count || convertedUserIdInput < 1)
                return false;

            return true;
        }

        public static bool LegalIDRangeShelfId(string userInput, out int convertedUserIdInput)
        {
            var shelfList = EntityFrameworkCode.EntityframeworkShelf.ShowAllShelves();

            if (!IntReaderConvertStringToInt(userInput, out convertedUserIdInput))
                return false;

            if (convertedUserIdInput > shelfList.Count || convertedUserIdInput < 1)
                return false;

            return true;
        }

        public static bool LegalIDRangeAudienceId(string userInput, out int convertedUserIdInput)
        {
            var audienceId = EntityFrameworkCode.EntityframeworkAudience.ShowAllAudiences();

            if (!IntReaderConvertStringToInt(userInput, out convertedUserIdInput))
                return false;

            if (convertedUserIdInput > audienceId.Count || convertedUserIdInput < 1)
                return false;

            return true;
        }

        public static bool LegalIDRangeMediaId(string userInput, out int convertedUserIdInput)
        {
            var MediaId = EntityFrameworkCode.EntityframeworkMediaTypes.ShowAllMediaTypes();

            if (!IntReaderConvertStringToInt(userInput, out convertedUserIdInput))
                return false;

            if (convertedUserIdInput > MediaId.Count || convertedUserIdInput < 1)
                return false;

            return true;
        }

        #endregion

        #region Double readers
        public static bool DoubleReaderOutDouble(string userInput, out double num)
        {
            if (Double.TryParse(userInput, out num))
                return true;

            return false;
        }

        #endregion

        #region Long Readers

        public static bool LongReaderOutLong(string userInput, out long num)
        {
            if(long.TryParse(userInput, out num))
                return true;

            return false;

        }

        public static bool LongReaderLengthEqualsTo(string userInput, int selectedNumber, out long num)
        {
            if (!LongReaderOutLong(userInput, out num))
                return false;

            if (num != selectedNumber)
                return false;

            return true;
        }

        #endregion
        public static bool ReadDateTime(string userInput, out DateTime date)
        {
            if (!DateTime.TryParseExact(userInput, "yyyy/MM/dd", null, DateTimeStyles.None, out date))
                return false;
            
            return true;
        }

    }
}