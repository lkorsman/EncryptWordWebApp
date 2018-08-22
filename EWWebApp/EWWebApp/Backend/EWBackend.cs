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

        [Display(Name = "Shift", Description = "Caesar shift value")]
        [Required(ErrorMessage = "Shift value is required")]
        private int Shift { get; set; }

        [Display(Name = "Guesses", Description = "Number of Guesses")]
        [Required(ErrorMessage = "Guesses is required")]
        public int NumberOfGuesses { get; set; }

        [Display(Name = "Player guess", Description = "Guess of Shift")]
        [Required(ErrorMessage = "Guess required")]
        public int Guess { get; set; }

        [Display(Name = "Correct", Description = "Shift guess true")]
        [Required(ErrorMessage = "Guesses is required")]
        public bool Correct { get; set; }

        private static volatile EWBackend instance;
        private static Object syncRoot = new Object();

        public static EWBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new EWBackend();
                            SetDataSource(1);
                        }
                    }
                }

                return instance;
            }
        }

        // Get the Datasource to use
        private static EWMockDataSource DataSource;

        /// <summary>
        /// Sets the Datasource to be Mock or SQL
        /// </summary>
        /// <param name="dataSourceEnum"></param>
        public static void SetDataSource(int dataSourceEnum)
        {
            if (dataSourceEnum == 0)
            {
                // SQL not hooked up yet...
                throw new NotImplementedException();
            }

            // Default is to use the Mock
            DataSource = EWMockDataSource.Instance;
        }

        public EWBackend()
        {
            Shift = 3;
            NumberOfGuesses = 0;
            Word = "";
            Result = "";
            Correct = false;
            Guess = 0;
        }

        public EWBackend(String word)
        {
            Shift = 3;
            NumberOfGuesses = 0;
            Word = word;
            Result = "";
            Correct = false;
            Guess = 0;
        }

        public EWBackend(String word, String result)
        {
            Shift = 3;
            NumberOfGuesses = 0;
            Word = word;
            Result = result;
            Correct = false;
            Guess = 0;
        }

        public bool GuessShift(int guess)
        {
            NumberOfGuesses++;
            if (guess == Shift)
            { 
                Correct = true;
                return true;
            }
            else
                return false;
        }

        public void Encrypt(String word)
        {
            Word = word;
            string output = string.Empty;   // String to hold encryption result

                // Encrypt each letter of string using SHIFT
                foreach (char ch in word)
                    output += Cipher(ch, Shift);

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
