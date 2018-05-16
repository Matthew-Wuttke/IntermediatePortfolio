//Matthew Wuttke
using System;
using System.Collections.Generic;
using System.Text;

namespace IntermPortfolio
{
    class QuestionUnit
    {
       // const int NUM_ANSWERS = 4;

        string m_Question;
        string m_Answers;
        string m_CorrectAnswer;
        string m_Explanation;

        public string Question
        {
            get
            {
                return m_Question;
            }

            set
            {
                m_Question = value;
            }
        }

        public string Answer
        {
            get
            {
                return m_Answers;
            }

            set
            {
                m_Answers = value;
            }
        }

        public string CorrectAnswer
        {
            get
            {
                return m_CorrectAnswer;
            }

            set
            {
                m_CorrectAnswer = value;
            }
        }

        public string Explanation
        {
            get
            {
                return m_Explanation;
            }

            set
            {
                m_Explanation = value;
            }
        }
    }
}
