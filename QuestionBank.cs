//Matthew Wuttke
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace IntermPortfolio

{
    class QuestionBank
    {
        const int NUM_ANSWERS = 4;
        const int NUM_QUESTIONS = 10;

        QuestionUnit[] m_Questions = new QuestionUnit[NUM_QUESTIONS];

        public int GetNumberofQuestions
        {
            get { return NUM_QUESTIONS; }
        }
        public int GetNumberofAnswers
        {
            get { return NUM_ANSWERS; }
        }
        public string GetQuestion(int index)
        {
            return m_Questions[index].Question;
        }
        public string GetAnswer(int index) //string answers (4)
        {
            return m_Questions[index].Answer;
        }
        public string GetCorrectAnswer(int index) //get letter hold correct answer
        {
            return m_Questions[index].CorrectAnswer;
        }
        public string GetExplanation(int index) //get letter hold correct answer
        {
            return m_Questions[index].Explanation;
        }

        //Read File.
        public void ReadQuestionFile(string path)
        {
            int questionCounter = 0;
            string text = null;
            FileInfo theSourceFile = new FileInfo(@path);

            try
            {
                StreamReader reader = theSourceFile.OpenText();

                text = reader.ReadLine();
                while (text != null)
                {
                    //create instance.
                    m_Questions[questionCounter] = new QuestionUnit();

                    //Fill it
                    m_Questions[questionCounter].Question = text;
                    m_Questions[questionCounter].Answer = reader.ReadLine();
                    //read Correct Answer
                    m_Questions[questionCounter].CorrectAnswer = reader.ReadLine();
                    //read Explanation
                    m_Questions[questionCounter].Explanation = reader.ReadLine();
                    text = reader.ReadLine();  //next question..
                    questionCounter = questionCounter + 1;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught and handled" + ex.Message);
            }

        }
        
    }
}
