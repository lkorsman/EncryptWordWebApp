using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace EWWebApp.Backend
{
    public class EWBackend
    {
        [Display(Name = "Word", Description = "Word to encrypt")]
        [Required(ErrorMessage = "Word is required")]
        public string Word { get; set; }

        [Display(Name = "Result", Description = "Encrypt result")]
        [Required(ErrorMessage = "Word is required")]
        public string Result { get; set; }

        public EWBackend()
        {
            Word = "";
            Result = "";
        }

        public EWBackend(String word)
        {
            Word = word;
            Result = "";
        }

        public EWBackend(String word, String result)
        {
            Word = word;
            Result = result;
        }

        public void Encrypt(String word)
        {
            int SHIFT = 3;
            string output = string.Empty;   // String to hold encryption result

                // Encrypt each letter of string using SHIFT
                foreach (char ch in word)
                    output += Cipher(ch, SHIFT);

            Result = output;
        }

        private char Cipher(char letter, int key)
        {
            char upperOrLower;     // Either 'A' or 'a', keeps uppercase letters
                                   // uppercase and lowercase letters lowercase

            // If letter isn't alphabetical then return the character unmodified
            if (!char.IsLetter(letter))
            {

                return letter;
            }

            // Determine if uppercase or lowercase letter
            upperOrLower = char.IsUpper(letter) ? 'A' : 'a';

            // Cast the letter plus the key to a new character
            return (char)((((letter + key) - upperOrLower) % 26) + upperOrLower);
        }
    }
}
