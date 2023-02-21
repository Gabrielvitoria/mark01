using System.Text.RegularExpressions;

namespace Mark01.Core.ValueObjects
{
    public partial class Email : ValueObjects
    {

        private const string EmailRegexParttern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        
        /// <summary>
        /// Create a new Email addres
        /// </summary>
        /// <param name="adress">Adress of email person</param>
        public Email(string adress)
        {
            if (!EmailRegex().IsMatch(adress))
                throw new Exception("Email invalid!");

            Adress = adress;
        }

        /// <summary>
        /// Adress of email person
        /// </summary>

        public string Adress { get; }

        [GeneratedRegex(EmailRegexParttern)]
        private static partial Regex EmailRegex();
    }
}
