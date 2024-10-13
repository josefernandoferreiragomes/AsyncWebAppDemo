using System.Linq;

namespace AsyncWebDemo.Site.Helpers
{
    public static class StringHelper
    {
        /// <summary>
        /// Remove duplicates from string 
        /// </summary>
        /// <param name=""></param>
        public static string? RemoveDuplicateCharactersFromString (string originalString)
        {
            originalString = originalString.Trim ();
            string? result = string.Empty;

            char[] charList = originalString.ToCharArray ();
            char[] charNoDuplicatesList = charList.Distinct().ToArray ();
                       
            result = String.Concat(charNoDuplicatesList);
            return result;

        }
        
        /// <summary>
        /// Remove duplicate words from string 
        /// </summary>
        /// <param name=""></param>
        public static string? RemoveDuplicateWordsFromString (string originalString)
        {
            originalString = originalString.Trim ();
            string? result = string.Empty;

            string[] wordList = originalString.Split (' ');
            string[] stringNoDuplicatesList = wordList.Distinct().ToArray ();
                       
            result = String.Join(' ', stringNoDuplicatesList);
            return result;

        }
    }
}
