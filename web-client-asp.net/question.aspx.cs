using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quiz
{
    public partial class question : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){
            
        }

        protected void Validate_Click(object sender, EventArgs e)
        {
            String quizId = "";
            var question = new Dictionary<string, object>();

            String questionTitle = Question_Title.Text;
            question.Add("title", questionTitle);
            
            if (Question_Picture.HasFile != false) {
                String questionPictureName = Path.GetFileName(Question_Picture.PostedFile.FileName);
                Question_Picture.SaveAs(Server.MapPath("~/pictures/" + questionPictureName));
                question.Add("picture", questionPictureName);
            }

            List<Object> answers = new List<Object>();

            var answer1 = new Dictionary<string, object>();

            String answerTitle1 = Answer_Title_1.Text;
            answer1.Add("title", answerTitle1);
            Boolean answerCorrect1 = false;
            if (Answer_True_1.Checked) {
                answerCorrect1 = true;
            } else if (Answer_False_1.Checked) {
                answerCorrect1 = false;
            }
            answer1.Add("correct", answerCorrect1);
            
            if (Answer_Picture_1.HasFile != false) {
                String answer1PictureName = Path.GetFileName(Answer_Picture_1.PostedFile.FileName);
                Answer_Picture_1.SaveAs(Server.MapPath("~/pictures/" + answer1PictureName));
                answer1.Add("picture", answer1PictureName);
            }
            
            answers.Add(answer1);

            var answer2 = new Dictionary<string, object>();

            String answerTitle2 = Answer_Title_2.Text;
            answer2.Add("title", answerTitle2);
            Boolean answerCorrect2 = false;
            if (Answer_True_2.Checked) {
                answerCorrect2 = true;
            }
            else if (Answer_False_2.Checked)  {
                answerCorrect2 = false;
            }
            answer2.Add("correct", answerCorrect2);
            
            if (Answer_Picture_2.HasFile != false) {
                String answer2PictureName = Path.GetFileName(Answer_Picture_2.PostedFile.FileName);
                Answer_Picture_2.SaveAs(Server.MapPath("~/pictures/" + answer2PictureName));
                answer2.Add("picture", answer2PictureName);
            }
            

            answers.Add(answer2);

            var answer3 = new Dictionary<string, object>();

            String answerTitle3 = Answer_Title_3.Text;
            answer3.Add("title", answerTitle3);
            Boolean answerCorrect3 = false;
            if (Answer_True_3.Checked) {
                answerCorrect3 = true;
            }
            else if (Answer_False_3.Checked) {
                answerCorrect3 = false;
            }
            answer3.Add("correct", answerCorrect3);
            
            if (Answer_Picture_3.HasFile != false) {
                String answer3PictureName = Path.GetFileName(Answer_Picture_3.PostedFile.FileName);
                Answer_Picture_3.SaveAs(Server.MapPath("~/pictures/" + answer3PictureName));
                answer3.Add("picture", answer3PictureName);
            }

            answers.Add(answer3);

            var answer4 = new Dictionary<string, object>();

            String answerTitle4 = Answer_Title_4.Text;
            answer4.Add("title", answerTitle4);
            Boolean answerCorrect4 = false;
            if (Answer_True_4.Checked) {
                answerCorrect4 = true;
            }
            else if (Answer_False_4.Checked) {
                answerCorrect4 = false;
            }
            answer4.Add("correct", answerCorrect4);
            
            if (Answer_Picture_4.HasFile != false) {
                String answer4PictureName = Path.GetFileName(Answer_Picture_4.PostedFile.FileName);
                Answer_Picture_4.SaveAs(Server.MapPath("~/pictures/" + answer4PictureName));
                answer4.Add("picture", answer4PictureName);
            }

            answers.Add(answer4);

            question.Add("answers", answers);

            var json = JsonConvert.SerializeObject(question);
            var obj2 = JsonConvert.DeserializeObject(json);
            Console.WriteLine(obj2.ToString());

            PostJson("http://corejpg.cloudapp.net/quiz/" + quizId, json);
        }

        private static void PostJson(string uri, String json)
        {
            String str;
            string postData = JsonConvert.SerializeObject(json);
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = bytes.Length;
            httpWebRequest.ContentType = "text/xml";
            using (Stream requestStream = httpWebRequest.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Count());
            }
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            // Releases the resources of the response.
            httpWebResponse.Close();
        }
    }
}