using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzByLeapMotionProject
{
    class Quiz
    {
      // Création des variables
        private int id;
        private String ListQuestion;
        private String[] ListReponse;

        public Quiz(int id, String Question, String[] Reponse)
        {
          // Classe de construction, initialisation
            this.id = id;
            this.ListQuestion = Question;
            this.ListReponse = Reponse;
        }

        public int getId()
        {
          // Permet d'obtenir l'id
            return this.id;
        }
        public void setId(int id)
        {
          // Edite l'id
            this.id = id;
        }

        public String getQuestion()
        {
          // Permet d'obtenir la question
            return this.ListQuestion;
        }

        public void setQuestion(String question)
        {
          // Permet d'éditer la question
            this.ListQuestion = question;
        }

        public String[] getListReponse()
        {
          // Permet d'obtenir la liste des réponses
            return this.ListReponse;
        }

        public void setListReponse(String[] reponse)
        {
          // Permet de modifier la liste des réponses
            this.ListReponse = reponse;
        }
    }
}
