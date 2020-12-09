using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

using System.Threading;
using System.Timers;

namespace QuizApp
{
    public partial class Home : System.Web.UI.Page
    {

        string connectionString = @"Server=localhost; Database=quizdb; Uid=root; pwd=root;";
        MySqlConnection newCon = null;
        private static System.Timers.Timer aTimer;
        public static int points = 0;
        static public string t;
        static public int num = 20;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            part1.Visible = false;
            part2.Visible = false;
            part3.Visible = false;
            part4.Visible = false;
            part5.Visible = false;
            part6.Visible = false;
            part7.Visible = false;
            part8.Visible = false;
            part9.Visible = false;
            part10.Visible = false;
            result.Visible = false;
            someDiv.Visible = false;


            // Check to see if any of your Radio Buttons were selected

            //studentName.InnerHtml = name.Text.ToUpper() + ", Good Luck!" + num;

        }


        protected void btnSubmitName_Click(object sender, EventArgs e)
        {

            ////someDiv.Visible = true;
            //SetTimer();
            studentName.InnerHtml = name.Text.ToUpper() + ", Good Luck!";
            part1.Visible = true;
            welcome.Visible = false;


            RadioButton[] buttons = new RadioButton[] { choice1, choice2, choice3, choice4 };

            if (Page.IsValid)
            {

                try
                {
                    string queryString = "SELECT question FROM questions where questionID = 1";
                    string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 1";
                    newCon = new MySqlConnection(connectionString);

                    newCon.Open();
                    question.Text = readQuestions(queryString);

                    MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

                    MySqlDataReader read = cmd2.ExecuteReader();

                    int count = 0;
                    while (read.Read())
                    {
                        buttons[count].Text = read.GetString(0);
                        count++;
                    }

                    read.Close();


                }
                catch (Exception error)
                {
                    diplay.InnerHtml = error.Message;
                }

            }
            
        }




        protected void answer1_Click(object sender, EventArgs e)
        {
            someDiv.Visible = true;
            //SetTimer();
            //some.InnerHtml = t;
            string correctOne = string.Empty;
            //some.InnerText = t;
            //string answer;

            RadioButton[] buttons = new RadioButton[] { RadioButton1, RadioButton2, RadioButton3, RadioButton4 };
            RadioButton[] options = new RadioButton[] { choice1, choice2, choice3, choice4 };
            part1.Visible = false;

            part2.Visible = true;
            string queryString = "SELECT question FROM questions where questionID = 2";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 2";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 1";

            newCon = new MySqlConnection(connectionString);

            newCon.Open();
            question2.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();

            int count = 0;
            while (read.Read())
            {
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();

            correctOne = readCorrectAnswer(queryCorrect);


            calculatePoints(options, correctOne);

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    //some.InnerHtml = buttons[i].Text;
                    buttons[i].Checked = false;
                }
            }

        }

        public void calculatePoints(RadioButton[] bt, string correctOne)
        {
            for (int i = 0; i < bt.Length; i++)
            {
                if (bt[i].Checked)
                {
                    if (bt[i].Text == correctOne)
                    {
                        points += 10;
                    }
                }
            }

        }

        protected void answer2_Click(object sender, EventArgs e)
        {

            //some.InnerHtml = t;
            //display3.InnerHtml = "timer ";
            part2.Visible = false;
            part3.Visible = true;
            string correctOne = string.Empty;
            RadioButton[] buttons = new RadioButton[] { RadioButton5, RadioButton6, RadioButton7, RadioButton8 };
            RadioButton[] options = new RadioButton[] { RadioButton1, RadioButton2, RadioButton3, RadioButton4 };
            string queryString = "SELECT question FROM questions where questionID = 3";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 3";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 2";
            newCon = new MySqlConnection(connectionString);

            newCon.Open();
            
            question3.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();

            int count = 0;
            while (read.Read())
            {
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();

            correctOne = readCorrectAnswer(queryCorrect);
            calculatePoints(options, correctOne);


            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    buttons[i].Checked = false;
                }
            }

        }

        protected void answer3_Click(object sender, EventArgs e)
        {
            string correctOne = string.Empty;
            part3.Visible = false;
            part4.Visible = true;
            RadioButton[] buttons = new RadioButton[] { RadioButton9, RadioButton10, RadioButton11 };
            RadioButton[] options = new RadioButton[] { RadioButton5, RadioButton6, RadioButton7, RadioButton8 };
            string queryString = "SELECT question FROM questions where questionID = 4";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 4";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 3";
            newCon = new MySqlConnection(connectionString);

            newCon.Open();
            question4.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();

            int count = 0;
            while (read.Read())
            {
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();


            correctOne = readCorrectAnswer(queryCorrect);
            calculatePoints(options, correctOne);

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    buttons[i].Checked = false;
                }
            }

        }

        protected void answer4_Click(object sender, EventArgs e)
        {
            part4.Visible = false;
            part5.Visible = true;
            string correctOne = string.Empty;
            RadioButton[] buttons = new RadioButton[] { RadioButton12, RadioButton13, RadioButton14, RadioButton15 };
            RadioButton[] options = new RadioButton[] { RadioButton9, RadioButton10, RadioButton11 };
            string queryString = "SELECT question FROM questions where questionID = 5";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 5";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 4";
            newCon = new MySqlConnection(connectionString);

            newCon.Open();

            question5.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();

            int count = 0;
            while (read.Read())
            {
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();


            correctOne = readCorrectAnswer(queryCorrect);

            calculatePoints(options, correctOne);

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    buttons[i].Checked = false;
                }
            }
        }

        protected void answer5_Click(object sender, EventArgs e)
        {
            part5.Visible = false;
            part6.Visible = true;
            RadioButton[] buttons = new RadioButton[] { RadioButton16, RadioButton17, RadioButton18, RadioButton19 };
            RadioButton[] options = new RadioButton[] { RadioButton12, RadioButton13, RadioButton14, RadioButton15 };
            string queryString = "SELECT question FROM questions where questionID = 6";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 6";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 5";
            string correctOne = string.Empty;
            newCon = new MySqlConnection(connectionString);

            newCon.Open();

            question6.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();

            int count = 0;
            while (read.Read())
            {
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();

            correctOne = readCorrectAnswer(queryCorrect);
            calculatePoints(options, correctOne);
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    buttons[i].Checked = false;
                }
            }
        }

        protected void answer6_Click(object sender, EventArgs e)
        {
            part6.Visible = false;
            part7.Visible = true;
            RadioButton[] buttons = new RadioButton[] { RadioButton20, RadioButton21, RadioButton22, RadioButton23 };
            RadioButton[] options = new RadioButton[] { RadioButton16, RadioButton17, RadioButton18, RadioButton19 };
            string queryString = "SELECT question FROM questions where questionID = 7";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 7";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 6";
            string correctOne = string.Empty;
            newCon = new MySqlConnection(connectionString);

            newCon.Open();
            question7.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();

            int count = 0;
            while (read.Read())
            {
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();

            correctOne = readCorrectAnswer(queryCorrect);
            calculatePoints(options, correctOne);

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    buttons[i].Checked = false;
                }
            }
        }

        protected void answer7_Click(object sender, EventArgs e)
        {
            part7.Visible = false;
            part8.Visible = true;
            RadioButton[] buttons = new RadioButton[] { RadioButton24, RadioButton25, RadioButton26, RadioButton27 };
            string queryString = "SELECT question FROM questions where questionID = 8";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 8";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 7";
            string correctOne = string.Empty;
            RadioButton[] options = new RadioButton[] { RadioButton20, RadioButton21, RadioButton22, RadioButton23 };
            newCon = new MySqlConnection(connectionString);

            newCon.Open();

            question8.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();

            int count = 0;
            while (read.Read())
            {
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();

            correctOne = readCorrectAnswer(queryCorrect);
            calculatePoints(options, correctOne);

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    buttons[i].Checked = false;
                }
            }
        }

        protected void answer8_Click(object sender, EventArgs e)
        {
            part8.Visible = false;
            part9.Visible = true;
            RadioButton[] buttons = new RadioButton[] { RadioButton28, RadioButton29, RadioButton30 };
            RadioButton[] options = new RadioButton[] { RadioButton24, RadioButton25, RadioButton26, RadioButton27 };
            string queryString = "SELECT question FROM questions where questionID = 9";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 9";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 8";
            string correctOne = string.Empty;
            newCon = new MySqlConnection(connectionString);

            newCon.Open();

            question9.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();

            int count = 0;
            while (read.Read())
            {
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();

            correctOne = readCorrectAnswer(queryCorrect);
            calculatePoints(options, correctOne);

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    buttons[i].Checked = false;
                }
            }
        }

        protected void answer9_Click(object sender, EventArgs e)
        {
            part9.Visible = false;
            part10.Visible = true;
            RadioButton[] buttons = new RadioButton[] { RadioButton31, RadioButton32, RadioButton33, RadioButton34 };
            RadioButton[] options = new RadioButton[] { RadioButton28, RadioButton29, RadioButton30 };
            string queryString = "SELECT question FROM questions where questionID = 10";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 10";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 9";
            string correctOne = string.Empty;
            newCon = new MySqlConnection(connectionString);
            newCon.Open();

            question10.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();

            int count = 0;
            while (read.Read())
            {
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();

            correctOne = readCorrectAnswer(queryCorrect);
            calculatePoints(options, correctOne);

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public string readCorrectAnswer(string query)
        {
            string theAnswer = string.Empty;
            MySqlCommand cmd3 = new MySqlCommand(query, newCon);
            MySqlDataReader reader2 = cmd3.ExecuteReader();
            while (reader2.Read())
            {
                theAnswer = reader2.GetString(0);
            }
            reader2.Close();
            return theAnswer;
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public string readQuestions(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, newCon);
            MySqlDataReader reader = cmd.ExecuteReader();
            string question = string.Empty;
            while (reader.Read())
            {
                question = reader.GetString(0);
            }
            reader.Close();
            return question;
        }

        protected void finish_Click(object sender, EventArgs e)
        {
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 10";
            RadioButton[] options = new RadioButton[] { RadioButton31, RadioButton32, RadioButton33, RadioButton34 };
            string correctOne = string.Empty;
            string insertString = "INSERT INTO leaderboard(POINTS, NAME) VALUES ('" + points + "', '" + name.Text + "') ";
            newCon = new MySqlConnection(connectionString);
            newCon.Open();

            correctOne = readCorrectAnswer(queryCorrect);
            calculatePoints(options, correctOne);
            MySqlCommand cmd2 = new MySqlCommand(insertString, newCon);
            cmd2.ExecuteNonQuery();
            

            part10.Visible = false;
            result.Visible = true;
            studentName.InnerHtml = name.Text.ToUpper();
            announce.InnerHtml = "Result: " + points.ToString() + "%";
            //string leader = "SELECT * from leaderboard";
            //lead.InnerHtml =  readCorrectAnswer(leader);
            loadBoard();
            newCon.Close();
        }

        public void loadBoard()
        {
            List<LeaderInfo> info = new List<LeaderInfo>(); 
            string leader = "SELECT points, name from leaderboard ORDER BY POINTS";
            MySqlCommand cmd = new MySqlCommand(leader, newCon);
            MySqlDataReader reader = cmd.ExecuteReader();
            string question = string.Empty;
            while (reader.Read())
            {
                info.Add(new LeaderInfo
                {
                    leaderName = reader["name"].ToString(),
                    leaderPoints = (int)reader["points"]
                });
            }

            var sb = new System.Text.StringBuilder();

            sb.Append(@"
            <table>
            <tr>
            <th>Name</th>
            <th>Points</th>
            </tr>
            ");

            foreach (var acc in info)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td class='cell'>{0}</td>", acc.leaderName);
                sb.AppendFormat("<td class='cell'>{0}</td>", acc.leaderPoints);
                sb.Append("</tr>");
            }

            sb.Append("</table>");
            string htmlTable = sb.ToString();

            ph1.Controls.Add(new LiteralControl(htmlTable));
            reader.Close();
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            e.SignalTime.ToString();
            

        }


    }   
}


public class LeaderInfo
{
    public string leaderName;
    public int leaderPoints;
}