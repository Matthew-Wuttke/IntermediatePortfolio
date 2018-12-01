//Matthew Wuttke
using System;
using System.Collections.Generic;
using System.Text;

namespace IntermPortfolio
{
    class TriviaUI
    {
        QuestionBank Questions = new QuestionBank();
        int curQuestion;

        public void MainMethod()
        {
            do
            {
                DisplayWelcome();
                Play(); //call play                
            } while (PlayAgain() == true); //keep running as long as the user says yes
        }

        void DisplayWelcome()
        {
            System.Console.WriteLine("Cortana needs you to establish a connection to the Infinity however\n" +
                "the Cartographer is having major interference.  Hurry before Infinity is pulled in.\n");
        }



        void Play()
        {
            string guess;
            int correct = 0;
            int incorrect = 0;
            string line;           
            string[] fields = new string[4];
            char[] delimiter = { Convert.ToChar(",") };
            curQuestion = 0; //hold current question

            Questions.ReadQuestionFile("Halo.txt");
            
            do
            {
                //Output the question
                System.Console.WriteLine(Questions.GetQuestion(curQuestion) + '\n');

                line = Questions.GetAnswer(curQuestion);                
                fields = line.Split(delimiter);
                //Output the answer
                System.Console.WriteLine("A.) " + fields[0]);
                System.Console.WriteLine("B.) " + fields[1]);
                System.Console.WriteLine("C.) " + fields[2]);
                System.Console.WriteLine("D.) " + fields[3]);

                guess = PromptforGuess();

                //Verify Answers...
                if (guess.ToUpper() == Questions.GetCorrectAnswer(curQuestion))
                {
                    correct += 1;
                    System.Console.WriteLine("\nCorrect:    " + Questions.GetExplanation(curQuestion));                    
                }
                else
                {
                    incorrect += 1;
                    System.Console.WriteLine("\nIncorrect:   " + Questions.GetExplanation(curQuestion));
                }
                System.Console.WriteLine("\nPress Enter to continue");
                curQuestion++;
                System.Console.ReadLine();
                System.Console.Clear();
                
            } while (curQuestion < Questions.GetNumberofQuestions);
            //output how many questions the player got write or wrong
            System.Console.WriteLine("\nYou got " + correct + " questions correct");
            System.Console.WriteLine("You got " + incorrect + " questions wrong\n");

        }

        //Ask user for their guess
        string PromptforGuess()
        {
            string guess;

            System.Console.Write("\nSelect A - D:  ");
            guess = System.Console.ReadLine();
            if (guess != null)
                guess = guess.Substring(0).ToUpper();

            return guess;
        }
        private bool PlayAgain()  //Ask the user to see if they want to play again
        {
            string replay;
            //Ask the user to see if they want to play again
            System.Console.Write("Would you like to play again? (y or n) ");
            replay = System.Console.ReadLine();

            if (replay.Equals("y"))
            {
                System.Console.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
