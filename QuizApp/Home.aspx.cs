/*
 * Author: ASAD AHMED
 * DATE: Dec 07, 2020
 * Description: this application is simulates an online quiz with all the bells and whistles.
 * the program stores all the data required for the application in SQL database.
 * the applicaiton first takes the user's name and then presents the user the quesions one at a time
 * each question is timed to 20 seconds. if the timer runs out, the user will not be awarded with any points.
 * after the user finishes the quiz, the results are presented and also the leader board showing all the users that have taken the quiz
 * sorted in ascending order.
 */

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

using Timer = System.Timers.Timer;
using System.Web.Services;
using System.Timers;

namespace QuizApp
{
    public partial class Home : System.Web.UI.Page
    {
        //global variables
        string connectionString = @"Server=localhost; Database=quizdb; Uid=root; pwd=root;";
        MySqlConnection newCon = null;
        //private static System.Timers.Timer aTimer;
        public static int points = 0;
        private static Timer atimer;
        public static int count;
        /*
         * Method header comment
         * Name: Page_Load()
         * Description: This method runs when the page is first loads
         * Params: object sender, EventArgs e
         * Return: Void
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            //hide all the questions when the page loads
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

        }
        /*
             * Method header comment
             * Name: setTimer()
             * Description: This method sets the timer
             * Params: object sender, EventArgs e
             * Return: Void
             */
        static void setTimer()
        {
            atimer = new Timer(1000);
            atimer.Elapsed += TimerOnElapsed;
            atimer.AutoReset = true;
            atimer.Enabled = true;
        }
        /*
             * Method header comment
             * Name: TimerOnElapsed()
             * Description: This handles the elapsed time
             * Params: object sender, EventArgs e
             * Return: Void
             */
        public static void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            DateTime d = e.SignalTime;
            count += d.Second;
            
        }
            /*
             * Method header comment
             * Name: btnSubmitName_Click()
             * Description: This event handler is fired when the user submits the name. it hides the name input and displays the first question
             * Params: object sender, EventArgs e
             * Return: Void
             */
            protected void btnSubmitName_Click(object sender, EventArgs e)
        {
            setTimer();
            

            //show timer
            someDiv.Visible = true;
            //display the student name
            studentName.InnerHtml = name.Text.ToUpper() + ", Good Luck!";
            part1.Visible = true;
            welcome.Visible = false;

            //an array of all the question buttons
            RadioButton[] buttons = new RadioButton[] { choice1, choice2, choice3, choice4 };

            if (Page.IsValid)
            {

                try
                {
                    //start reading the question and the choices from the database tables
                    string queryString = "SELECT question FROM questions where questionID = 1";
                    string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 1";
                    //create new Connectons
                    newCon = new MySqlConnection(connectionString);
                    newCon.Open();
                    //display the question
                    question.Text = readQuestions(queryString);

                    MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

                    MySqlDataReader read = cmd2.ExecuteReader();
                    //read the questions
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
            atimer.Stop();
            atimer.Dispose();
            
        }



        /*
         * Method header comment
         * Name: answer1_Click()
         * Description: This method hides the first queston and displays the second question
         * Params: object sender, EventArgs e
         * Return: Void
         */
        protected void answer1_Click(object sender, EventArgs e)
        {
            someDiv.Visible = true;
            
            string correctOne = string.Empty;
           //an array of the multiple choices

            RadioButton[] buttons = new RadioButton[] { RadioButton1, RadioButton2, RadioButton3, RadioButton4 };
            RadioButton[] options = new RadioButton[] { choice1, choice2, choice3, choice4 };
            part1.Visible = false;
            part2.Visible = true;
            //the query strings for reading the questions from the data base
            string queryString = "SELECT question FROM questions where questionID = 2";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 2";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 1";
            //create new connections
            newCon = new MySqlConnection(connectionString);

            newCon.Open();
            question2.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();
            //start reading the question
            int count = 0;
            while (read.Read())
            {
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();
            //get the correct answer and compare it to the user choice
            correctOne = readCorrectAnswer(queryCorrect);

            //calculate the points being awarded
            calculatePoints(options, correctOne);
            //uncheck the radiobuttons
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    buttons[i].Checked = false;
                }
            }

        }


        /*
         * Method header comment
         * Name: calculatePoints()
         * Description: This method calculates the points based on the correctness of the answer
         * Params: object sender, EventArgs e
         * Return: Void
         */
        public void calculatePoints(RadioButton[] bt, string correctOne)
        {
            //check for the all the choices and compre it to the right one
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


        /*
         * Method header comment
         * Name: answer2_Click()
         * Description: This method hides the second queston and displays the third question
         * Params: object sender, EventArgs e
         * Return: Void
         */
        protected void answer2_Click(object sender, EventArgs e)
        {
            //show timer
            someDiv.Visible = true;
            part2.Visible = false;
            part3.Visible = true;
            string correctOne = string.Empty;
            //start reading the questions and the choices from the database
            RadioButton[] buttons = new RadioButton[] { RadioButton5, RadioButton6, RadioButton7, RadioButton8 };
            RadioButton[] options = new RadioButton[] { RadioButton1, RadioButton2, RadioButton3, RadioButton4 };
            //query strings for the queries
            string queryString = "SELECT question FROM questions where questionID = 3";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 3";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 2";
            //start new connection
            newCon = new MySqlConnection(connectionString);
            newCon.Open();
            //display the question
            question3.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();
            //read from the database
            int count = 0;
            while (read.Read())
            {
                //populate the radio buttons
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();
            //get the correct one and compare
            correctOne = readCorrectAnswer(queryCorrect);
            //calculate the points
            calculatePoints(options, correctOne);

            //uncheck all the radio buttons
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    buttons[i].Checked = false;
                }
            }

        }

        /*
         * Method header comment
         * Name: answer3_Click()
         * Description: This method hides the third queston and displays the fourth question
         * Params: object sender, EventArgs e
         * Return: Void
         */
        protected void answer3_Click(object sender, EventArgs e)
        {
            //show the timer
            someDiv.Visible = true;
            string correctOne = string.Empty;
            part3.Visible = false;
            part4.Visible = true;
            //start reading from the database
            RadioButton[] buttons = new RadioButton[] { RadioButton9, RadioButton10, RadioButton11, RadioButton35 };
            RadioButton[] options = new RadioButton[] { RadioButton5, RadioButton6, RadioButton7, RadioButton8 };
            //query strings for the reading database
            string queryString = "SELECT question FROM questions where questionID = 4";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 4";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 3";
            //create connection
            newCon = new MySqlConnection(connectionString);
            newCon.Open();
            //display the question
            question4.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();
            //read the choices fromt the database
            int count = 0;
            while (read.Read())
            {
                //populate the radiobuttons
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();

            //get the correct answer
            correctOne = readCorrectAnswer(queryCorrect);
            //calculat the points
            calculatePoints(options, correctOne);
            //uncheck the radiobuttons
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    buttons[i].Checked = false;
                }
            }

        }

        /*
         * Method header comment
         * Name: answer4_Click()
         * Description: This method hides the fourth queston and displays the fifth question
         * Params: object sender, EventArgs e
         * Return: Void
         */
        protected void answer4_Click(object sender, EventArgs e)
        {
            //show timer
            someDiv.Visible = true;
            part4.Visible = false;
            part5.Visible = true;
            string correctOne = string.Empty;
            //radio buttons array for answers and mu;ltiple choices
            RadioButton[] buttons = new RadioButton[] { RadioButton12, RadioButton13, RadioButton14, RadioButton15 };
            RadioButton[] options = new RadioButton[] { RadioButton9, RadioButton10, RadioButton11 };
            //query strings for reading database
            string queryString = "SELECT question FROM questions where questionID = 5";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 5";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 4";
            //create connection
            newCon = new MySqlConnection(connectionString);
            newCon.Open();
            //display the question
            question5.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();
            //show the multople choices
            int count = 0;
            while (read.Read())
            {
               
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();

            //get the correct answer
            correctOne = readCorrectAnswer(queryCorrect);
            //calculate the points
            calculatePoints(options, correctOne);
            //uncheck the radio buttons
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    buttons[i].Checked = false;
                }
            }
        }

        /*
         * Method header comment
         * Name: answer5_Click()
         * Description: This method hides the fifth  queston and displays the sixth question
         * Params: object sender, EventArgs e
         * Return: Void
         */
        protected void answer5_Click(object sender, EventArgs e)
        {
            //show timer
            someDiv.Visible = true;
            part5.Visible = false;
            part6.Visible = true;
            //radio buttons for the question and answers
            RadioButton[] buttons = new RadioButton[] { RadioButton16, RadioButton17, RadioButton18, RadioButton19 };
            RadioButton[] options = new RadioButton[] { RadioButton12, RadioButton13, RadioButton14, RadioButton15 };
            // strings for the queries
            string queryString = "SELECT question FROM questions where questionID = 6";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 6";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 5";
            string correctOne = string.Empty;
            newCon = new MySqlConnection(connectionString);
            newCon.Open();
            //display the question
            question6.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();
            // read the multiple choices onto teh radiobuttons
            int count = 0;
            while (read.Read())
            {
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();
            //get the correct answer
            correctOne = readCorrectAnswer(queryCorrect);
            //calculate the points
            calculatePoints(options, correctOne);
            //uncheck all the radio buttons
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    buttons[i].Checked = false;
                }
            }
        }

        /*
         * Method header comment
         * Name: answer7_Click()
         * Description: This method hides the first queston and displays the second question
         * Params: object sender, EventArgs e
         * Return: Void
         */
        protected void answer6_Click(object sender, EventArgs e)
        {
            //show timer
            someDiv.Visible = true;
            part6.Visible = false;
            part7.Visible = true;
            //radiobuttons for the multiple choices
            RadioButton[] buttons = new RadioButton[] { RadioButton20, RadioButton21, RadioButton22, RadioButton23 };
            RadioButton[] options = new RadioButton[] { RadioButton16, RadioButton17, RadioButton18, RadioButton19 };
            //query strings for the database
            string queryString = "SELECT question FROM questions where questionID = 7";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 7";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 6";
            string correctOne = string.Empty;
            //create connectiond SQL
            newCon = new MySqlConnection(connectionString);
            newCon.Open();
            //display the questoin
            question7.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();
            //read the multiple choices
            int count = 0;
            while (read.Read())
            {
                //populate the radio buttons
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();
            //get the correct answer 
            correctOne = readCorrectAnswer(queryCorrect);
            //calculate the points
            calculatePoints(options, correctOne);
            //uncheck the radio buttons
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    buttons[i].Checked = false;
                }
            }
        }

        /*
         * Method header comment
         * Name: answer8_Click()
         * Description: This method hides the seventh queston and displays the eight question
         * Params: object sender, EventArgs e
         * Return: Void
         */
        protected void answer7_Click(object sender, EventArgs e)
        {
            //show timer
            someDiv.Visible = true;
            part7.Visible = false;
            part8.Visible = true;
            //radiobuttons
            RadioButton[] buttons = new RadioButton[] { RadioButton24, RadioButton25, RadioButton26, RadioButton27 };
            //queery string for the database
            string queryString = "SELECT question FROM questions where questionID = 8";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 8";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 7";
            string correctOne = string.Empty;
            //an array of radiobuttons 
            RadioButton[] options = new RadioButton[] { RadioButton20, RadioButton21, RadioButton22, RadioButton23 };
            //create connection
            newCon = new MySqlConnection(connectionString);
            newCon.Open();
            //display the question
            question8.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();
            //read the choices from the datab
            int count = 0;
            while (read.Read())
            {
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();
            //get tht correct question
            correctOne = readCorrectAnswer(queryCorrect);
            //calculate points
            calculatePoints(options, correctOne);
            //uncheck all the radio buttons
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    buttons[i].Checked = false;
                }
            }
        }

        /*
         * Method header comment
         * Name: answer9_Click()
         * Description: This method hides the 8th queston and displays the 9th question
         * Params: object sender, EventArgs e
         * Return: Void
         */
        protected void answer8_Click(object sender, EventArgs e)
        {
            //show timer
            someDiv.Visible = true;
            part8.Visible = false;
            part9.Visible = true;
            //array containing the radio buttons
            RadioButton[] buttons = new RadioButton[] { RadioButton28, RadioButton29, RadioButton30, RadioButton36 };
            RadioButton[] options = new RadioButton[] { RadioButton24, RadioButton25, RadioButton26, RadioButton27 };
            //string queries for the database
            string queryString = "SELECT question FROM questions where questionID = 9";
            string queryAnswer = "SELECT potentialAnwers FROM potentialAnswers where ID = 9";
            string queryCorrect = "SELECT answer FROM correctanswers where ID = 8";
            string correctOne = string.Empty;
            //create connection
            newCon = new MySqlConnection(connectionString);

            newCon.Open();
            //display the question
            question9.Text = readQuestions(queryString);

            MySqlCommand cmd2 = new MySqlCommand(queryAnswer, newCon);

            MySqlDataReader read = cmd2.ExecuteReader();
            //display the multiple choices
            int count = 0;
            while (read.Read())
            {
                buttons[count].Text = read.GetString(0);
                count++;
            }
            read.Close();
            //ge the correct question
            correctOne = readCorrectAnswer(queryCorrect);
            //calculate the points
            calculatePoints(options, correctOne);
            //uncheck the radiobuttons
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    buttons[i].Checked = false;
                }
            }
        }

        /*
         * Method header comment
         * Name: answer10_Click()
         * Description: This method hides the 9th queston and displays the last question
         * Params: object sender, EventArgs e
         * Return: Void
         */
        protected void answer9_Click(object sender, EventArgs e)
        {
            //show timer
            someDiv.Visible = true;
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
            string leader = "SELECT points, name from leaderboard ORDER BY POINTS DESC";
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

        

    }   
}


public class LeaderInfo
{
    public string leaderName;
    public int leaderPoints;
}