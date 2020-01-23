using System;
using System.Linq;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public const int keyNumber = 3;
        public const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        public const string numeral = "0123456789";

        public string Crypt(string message)
        {
            string cryptedMessage = null;

            if (message != null)
            {
                message = message.ToLower();
            }
            else
                throw new ArgumentNullException();

            foreach (char c in message)
            {
                if (alphabet.Contains(c))
                {
                    int alphabetIndex = alphabet.IndexOf(c);
                    if (alphabetIndex + keyNumber >= alphabet.Length)
                        alphabetIndex = (alphabetIndex + keyNumber) - alphabet.Length;
                    else
                        alphabetIndex += keyNumber;

                    cryptedMessage += alphabet.Substring(alphabetIndex, 1);
                }
                else if (numeral.Contains(c))
                {
                    cryptedMessage += c;
                }
                else if (Char.IsWhiteSpace(c))
                {
                    cryptedMessage += c;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            return cryptedMessage;
        }

        public string Decrypt(string cryptedMessage)
        {
            string decriptedMessage = null;

            if (cryptedMessage != null)
            {
                cryptedMessage = cryptedMessage.ToLower();
            }
            else
                throw new ArgumentNullException();

            foreach (char c in cryptedMessage)
            {
                if (alphabet.Contains(c))
                {
                    int alphabetIndex = alphabet.IndexOf(c);
                    if (alphabetIndex - keyNumber < 0)
                        alphabetIndex = (alphabetIndex - keyNumber) + 26;
                    else
                        alphabetIndex -= keyNumber;

                    decriptedMessage += alphabet.Substring(alphabetIndex, 1);
                }
                else if (numeral.Contains(c))
                {
                    decriptedMessage += c;
                }
                else if (Char.IsWhiteSpace(c))
                {
                    decriptedMessage += c;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            return decriptedMessage;
        }
    }
}
