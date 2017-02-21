using Newtonsoft.Json;
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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Validate_Click(object sender, EventArgs e)
        {
            var quiz = new Dictionary<string, object>();

            String quizTitle = Quiz_Title.Text;
            quiz.Add("title", quizTitle);
            String quizSummary = Quiz_Summary.Text;
            quiz.Add("summary", quizSummary);
            String quizDescription = Quiz_Description.Text;
            quiz.Add("description", quizDescription);

            List<Object> questions = new List<Object>();
            quiz.Add("questions", questions);

            String json = JsonConvert.SerializeObject(quiz);
            var obj = JsonConvert.DeserializeObject(json);
            Console.WriteLine(obj.ToString());

            Quiz_Id.Value = PostJson("http://corejpg.cloudapp.net/quiz", json);
        }

        private static String PostJson(string uri, String json)
        {
            String quizId = "";
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
            Stream receiveStream = httpWebResponse.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, encode);
            Console.WriteLine("\r\nResponse stream received.");
            Char[] read = new Char[256];
            // Reads 256 characters at a time.    
            int count = readStream.Read(read, 0, 256);
            Console.WriteLine("HTML...\r\n");
            while (count > 0)
            {
                // Dumps the 256 characters on a string and displays the string to the console.
                quizId = new String(read, 0, count);
                Console.Write(quizId);
                count = readStream.Read(read, 0, 256);
            }
            Console.WriteLine("");
            // Releases the resources of the response.
            httpWebResponse.Close();
            // Releases the resources of the Stream.
            readStream.Close();
            return quizId;
        }
    }
}