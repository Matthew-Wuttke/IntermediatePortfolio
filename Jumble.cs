//Matthew Wuttke
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntermPortfolio
{
    class Jumble
    {
        //data members
        string[] arywords = { "dba", "valve", "nintendo", "mario", "database", "kratos", "xenosaga", "pills", "java", "halo", ".hack", "sega",
                                "snake", "arbiter", "mindsculpt", "aggrocrag"};
        char[] displayWord;
        string hiddenWord;

        //Methods
        public string Hint()                            //Returns the first character for the user's hint
        {
            string first;
            first = hiddenWord.Substring(0, 1);
            return first;           
        }

        public string Hiddenword                        //Returns the hidden word
        {
            get {return hiddenWord;}
        }
        
        public char[] Displayword                       //Returns the scrambled word
        {
            get { return displayWord; }
        }
        
        public Jumble()                                 //Constructor
        {
            GenerateWord();
            ScrambleWord();
        }
        private void GenerateWord()                     //Takes the array of words and picks one
        {
            //data members
            int number;
            Random generator = new Random();

            number = generator.Next(arywords.Length);

            hiddenWord = arywords[number];
        }
        
        public void ScrambleWord()                      //Scrambles the word up
        {
            //Data members
            int random;
            char temp;
            Random randObj = new Random();

            displayWord = new char[hiddenWord.Length];  //Initializes the array

            for (int i = 0; i < hiddenWord.Length; i++) //Scrambles each character in the word so it's not in the same spot.
            {
                do
                    random = randObj.Next(hiddenWord.Length);

                while (displayWord[random] != 0);

                temp = hiddenWord[i];
                displayWord[random] = temp;
            }
        }
        
        public bool GuessMatch(string guess)            //Checks to see if the user's guess matches the hidden word and returns if it's right or wrong.
        {
            bool value;

            if (guess == hiddenWord)
                value = true;
            else
                value = false;

            return value;

        }
    }
}
