using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzByLeapMotionProject
{
    class Quiz
    {
        private int id;
        private String ListQuestion;
        private String[] ListReponse;

        public Quiz(int id, String Question, String[] Reponse)
        {
            this.id = id;
            this.ListQuestion = Question;
            this.ListReponse = Reponse;
        }

        public int getId()
        {
            return this.id;
        }
        public void setId(int id)
        {
            this.id = id;
        }

        public String getQuestion()
        {
            return this.ListQuestion;
        }

        public void setQuestion(String question)
        {
            this.ListQuestion = question;
        }

        public String[] getListReponse()
        {
            return this.ListReponse;
        }

        public void setListReponse(String[] reponse)
        {
            this.ListReponse = reponse;
        }
    }
}