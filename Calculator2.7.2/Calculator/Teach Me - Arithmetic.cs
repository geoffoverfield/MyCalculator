using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Calculator
{
    public partial class Teach_Me___Arithmetic : Form 
    {

        string location, myImage, rightAns, wrongAns;           //strings to locate image files
        string[] frameImage = new string[10];
        Image myBack;                                           //Tutorial Background Image
        int numOfQuestions = 7;
        int numOfCorrectAnswers = 0;
        double currentScore;
        double highScore;
        double answer1, answer2, answer3, answer4, answer5, answer6, answer7;
        int wildCard;
        Random rand;
        bool ans1, ans2, ans3, ans4, ans5, ans6, ans7;
        int ticker = 1;

        public Teach_Me___Arithmetic()
        {
            InitializeComponent();
            FormInit();
        }
        //Quit Buttons
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
            FormDestroy();
        }
        private void btnQuit1_Click(object sender, EventArgs e)
        {
            this.Close();
            FormDestroy();
        }
        //Destroy Window
        private void FormDestroy()
        {
            timer1.Stop();
            timer1.Dispose();
            timer2.Stop();
            timer2.Dispose();
            timer3.Stop();
            timer3.Dispose();
            if (pbQ1.Image != null)
                pbQ1.Image.Dispose();
            if (pbQ2.Image != null)
                pbQ2.Image.Dispose();
            if (pbQ3.Image != null)
                pbQ3.Image.Dispose();
            if (pbQ4.Image != null)
                pbQ4.Image.Dispose();
            if (pbQ5.Image != null)
                pbQ5.Image.Dispose();
            if (pbQ6.Image != null)
                pbQ6.Image.Dispose();
            if (pbQ7.Image != null)
                pbQ7.Image.Dispose();
            myBack.Dispose();
            location = null;
            myImage = null;
            rightAns = null;
            wrongAns = null;
            this.Dispose();

        }
        //Next Buttons
        private void btnNext_Click(object sender, EventArgs e)
        {
            tabPage1.Hide();
            tabPage2.Show();
        }
        private void btnNext1_Click(object sender, EventArgs e)
        {
            tabPage2.Hide();
            tabPage3.Show();
        }
        private void btnNext2_Click(object sender, EventArgs e)
        {
            tabPage3.Hide();
            tabPage4.Show();
        }
        private void btnNext3_Click(object sender, EventArgs e)
        {
            tabPage4.Hide();
            tabPage5.Show();
        }
        private void btnNext4_Click(object sender, EventArgs e)
        {
            tabPage5.Hide();
            tabPage6.Show();
        }
        private void btnQuiz_Click_1(object sender, EventArgs e)
        {
            tabPage7.Show();
            tabPage6.Hide();
        }
        //Previous Buttons
        private void btnPrev_Click(object sender, EventArgs e)
        {
            tabPage1.Show();
            tabPage2.Hide();
        }
        private void btnPrev1_Click(object sender, EventArgs e)
        {
            tabPage2.Show();
            tabPage3.Hide();
        }
        private void btnPrev2_Click(object sender, EventArgs e)
        {
            tabPage3.Show();
            tabPage4.Hide();
        }
        private void btnPrev3_Click(object sender, EventArgs e)
        {
            tabPage4.Show();
            tabPage5.Hide();
        }
        private void btnPrev4_Click(object sender, EventArgs e)
        {
            tabPage5.Show();
            tabPage6.Hide();
        }
        //Fill Windows
        public void Content()
        {
            //TAB PAGE 1 - WHAT IS...
            tabPage1.Text = "What is Arithmetic?";
            lblHeader.Text = "What is Arithmetic?";
            lblDefinition.Text = "Arithmetic is defined as the branch of mathematics " +
                "dealing with the properties and manipulation of numbers.\n\n" + 
                "This can be broken down to four (4) main mathematical functions:\n" +
                "\t\t1.\tAddition\n\t\t2.\tSubtraction\n\t\t3.\tMultiplication\n\t\t4.\tDivision\n\n" +
                "Click the 'Next' Button to take a look at Additon, or click the 'Addition' Tab\n\n" +
                "Click any other tab to skip ahead, or 'Quit' to exit this tutoring session...";
            myBack = Image.FromFile(myImage + "0.jpg");
            tabPage1.BackgroundImage = myBack;

            //TAB PAGE 2 - ADDITION
            tabPage2.Text = "Addition";
            lblAddDef.Text = "Have you ever heard the saying, 'You can't compare Apples to Oranges'?  Well, what if I told you that YOU CAN!\n\n" +
                "If we look at both items as pieces of fruit, rather than the types of fruit they are, we can compare them quite easily!  " +
                "If I have 5 apples and 4 oranges, how many pieces of fruit do I have?  This is what ADDITION is: Combining like terms - integers in this (and almost every) case." +
                "Just so we know - an integer is any REAL NUMBER...  We'll get to other kinds of numbers later!\n\n" +
                "So, back to this whole fruit thing: If we combine, or ADD, these pieces of fruit together, the EQUATION would look something like this:\n\t\t" +
                "5 + 4 = ?\n\nAnd I bet we know how many pieces of fruit we have, too!!  That's right!  It's nine (9)!\n\n" +
                "Think about this next problem before we move on:  If I have 2 pineapples, 3 cantelopes, 10 tangerines, and 5 strawberries, HOW MANY PIECES OF FRUIT DO I HAVE?" +
                "\n\nLet's write that problem outn\t\t2 + 3 + 10 + 5 = ?\n\nWhen you get the answer, click 'NEXT' to move on to SUBTRACTION...";
            tabPage2.BackgroundImage = myBack;

            //TAB PAGE 3 - SUBTRACTION
            tabPage3.Text = "Subtraction";
            tabPage3.BackgroundImage = myBack;
            
            //TAB PAGE 4 - MULTIPLICATION
            tabPage4.Text = "Multiplication";
            tabPage4.BackgroundImage = myBack;
            
            //TAB PAGE 5 - DIVISION
            tabPage5.Text = "Division";
            tabPage5.BackgroundImage = myBack;
            
            //TAB PAGE 6 - FRACTIONS 
            tabPage6.Text = "Fractions";
            tabPage6.BackgroundImage = myBack;

            //TAB PAGE 7 - QUIZ
            tabPage7.Text = "Quiz";
        }
        //Initialize Form Content
        private void FormInit()
        {
            location = Directory.GetCurrentDirectory();
            myImage = location + "/TutorialImages/Arithmetic";
            rightAns = location + "/TutorialImages/check.png";
            wrongAns = location + "/TutorialImages/ex.png";
            pbFrame.Image = Image.FromFile(location + "/TutorialImages/FRAME.png");
            pbFrame2.Image = Image.FromFile(location + "/TutorialImages/FRAME.png");
            pbFrame3.Image = Image.FromFile(location + "/TutorialImages/FRAME.png");
            pbFrame4.Image = Image.FromFile(location + "/TutorialImages/FRAME.png");
            pbFrame5.Image = Image.FromFile(location + "/TutorialImages/FRAME.png");
            for (int i = 0; i < 10; i++)
            {
                frameImage[i] = location + "/TutorialImages/frameImage" + i + ".bmp";
            }
            timer1.Start();
            timer2.Start();
            timer3.Start();
            Content();
            Reset();
        }
        private void Reset()
        {
            //Reset Wildcard Value 
            //wildCard = rand.Next(1, 11);
            wildCard = 1;
            //Reset booleans
            ans1 = false;
            ans2 = false;
            ans3 = false;
            ans4 = false;
            ans5 = false;
            ans6 = false;
            ans7 = false;
            //Reset buttons, check boxes and picture boxes
            btnSubmit.Enabled = true;
            btnSubmit.Visible = true;
            btnRetry.Enabled = false;
            btnRetry.Visible = false;
            pbQ1.Image = null;
            pbQ2.Image = null;
            pbQ3.Image = null;
            pbQ4.Image = null;
            pbQ5.Image = null;
            pbQ6.Image = null;
            pbQ7.Image = null;
            cbQ1A1.Checked = false;
            cbQ1A2.Checked = false;
            cbQ1A3.Checked = false;
            cbQ1A4.Checked = false;
            cbQ1A5.Checked = false;
            cbQ2A1.Checked = false;
            cbQ2A2.Checked = false;
            cbQ2A3.Checked = false;
            cbQ2A4.Checked = false;
            cbQ2A5.Checked = false;
            cbQ3A1.Checked = false;
            cbQ3A2.Checked = false;
            cbQ3A3.Checked = false;
            cbQ3A4.Checked = false;
            cbQ3A5.Checked = false;
            cbQ4A1.Checked = false;
            cbQ4A2.Checked = false;
            cbQ4A3.Checked = false;
            cbQ4A4.Checked = false;
            cbQ4A5.Checked = false;
            cbQ5A1.Checked = false;
            cbQ5A2.Checked = false;
            cbQ5A3.Checked = false;
            cbQ5A4.Checked = false;
            cbQ5A5.Checked = false;
            cbQ6A1.Checked = false;
            cbQ6A2.Checked = false;
            cbQ6A3.Checked = false;
            cbQ6A4.Checked = false;
            cbQ6A5.Checked = false;
            cbQ7A1.Checked = false;
            cbQ7A2.Checked = false;
            cbQ7A3.Checked = false;
            cbQ7A4.Checked = false;
            cbQ7A5.Checked = false;
            //Generate new questions
            GenerateQuestions();

        }
        
        //Calculate Score
        private int CorrectAnswer()
        {
            int x = 0;
            switch (wildCard)
            {
                case 1:
                    //QUESTION 1
                    if (cbQ1A3.Checked == true)
                    {
                        if (cbQ1A1.Checked == false && cbQ1A2.Checked == false &&
                            cbQ1A4.Checked == false && cbQ1A5.Checked == false)
                            ans1 = true;
                    }
                    //QUESTION 2
                    if (cbQ2A1.Checked == true)
                    {
                        if (cbQ2A2.Checked == false && cbQ2A3.Checked == false &&
                            cbQ2A4.Checked == false && cbQ2A5.Checked == false)
                            ans2 = true;
                    }
                    //QUESTION 3
                    if (cbQ3A2.Checked == true)
                    {
                        if (cbQ3A1.Checked == false && cbQ3A3.Checked == false &&
                            cbQ3A4.Checked == false && cbQ3A5.Checked == false)
                            ans3 = true;
                    }
                    //QUESTION 4
                    if (cbQ4A4.Checked == true)
                    {
                        if (cbQ4A1.Checked == false && cbQ4A2.Checked == false &&
                            cbQ4A3.Checked == false && cbQ4A5.Checked == false)
                            ans4 = true;
                    }
                    //QUESTION 5
                    if (cbQ5A5.Checked == true)
                    {
                        if (cbQ5A1.Checked == false && cbQ5A2.Checked == false &&
                            cbQ5A3.Checked == false && cbQ5A4.Checked == false)
                            ans5 = true;
                    }
                    //QUESTION 6
                    if (cbQ6A2.Checked == true)
                    {
                        if (cbQ6A1.Checked == false && cbQ6A3.Checked == false &&
                            cbQ6A4.Checked == false && cbQ6A5.Checked == false)
                            ans6 = true;
                    }
                    //QUESTION 7
                    if (cbQ7A4.Checked == true)
                    {
                        if (cbQ7A1.Checked == false && cbQ7A2.Checked == false &&
                            cbQ7A3.Checked == false && cbQ7A5.Checked == false)
                            ans7 = true;
                    }
                    break;
            //================================================================================
                case 2:
                    //QUESTION 1
                    if (cbQ1A4.Checked == true)
                    {
                        if (cbQ1A1.Checked == false && cbQ1A2.Checked == false &&
                            cbQ1A3.Checked == false && cbQ1A5.Checked == false)
                            ans1 = true;
                    }
                    //QUESTION 2
                    if (cbQ2A1.Checked == true)
                    {
                        if (cbQ2A2.Checked == false && cbQ2A3.Checked == false &&
                            cbQ2A4.Checked == false && cbQ2A5.Checked == false)
                            ans2 = true;
                    }
                    //QUESTION 3
                    if (cbQ3A3.Checked == true)
                    {
                        if (cbQ3A1.Checked == false && cbQ3A2.Checked == false &&
                            cbQ3A4.Checked == false && cbQ3A5.Checked == false)
                            ans3 = true;
                    }
                    //QUESTION 4
                    if (cbQ4A5.Checked == true)
                    {
                        if (cbQ4A1.Checked == false && cbQ4A2.Checked == false &&
                            cbQ4A3.Checked == false && cbQ4A4.Checked == false)
                            ans4 = true;
                    }
                    //QUESTION 5
                    if (cbQ5A2.Checked == true)
                    {
                        if (cbQ5A1.Checked == false && cbQ5A3.Checked == false &&
                            cbQ5A4.Checked == false && cbQ5A5.Checked == false)
                            ans5 = true;
                    }
                    //QUESTION 6
                    if (cbQ6A5.Checked == true)
                    {
                        if (cbQ6A1.Checked == false && cbQ6A2.Checked == false &&
                            cbQ6A3.Checked == false && cbQ6A4.Checked == false)
                            ans6 = true;
                    }
                    //QUESTION 7
                    if (cbQ7A3.Checked == true)
                    {
                        if (cbQ7A1.Checked == false && cbQ7A2.Checked == false &&
                            cbQ7A4.Checked == false && cbQ7A5.Checked == false)
                            ans7 = true;
                    }
                    break;
            //================================================================================
                case 3:
                    //QUESTION 1
                    if (cbQ1A2.Checked == true)
                    {
                        if (cbQ1A1.Checked == false && cbQ1A4.Checked == false &&
                            cbQ1A3.Checked == false && cbQ1A5.Checked == false)
                            ans1 = true;
                    }
                    //QUESTION 2
                    if (cbQ2A3.Checked == true)
                    {
                        if (cbQ2A2.Checked == false && cbQ2A1.Checked == false &&
                            cbQ2A4.Checked == false && cbQ2A5.Checked == false)
                            ans2 = true;
                    }
                    //QUESTION 3
                    if (cbQ3A1.Checked == true)
                    {
                        if (cbQ3A3.Checked == false && cbQ3A2.Checked == false &&
                            cbQ3A4.Checked == false && cbQ3A5.Checked == false)
                            ans3 = true;
                    }
                    //QUESTION 4
                    if (cbQ4A4.Checked == true)
                    {
                        if (cbQ4A1.Checked == false && cbQ4A2.Checked == false &&
                            cbQ4A3.Checked == false && cbQ4A5.Checked == false)
                            ans4 = true;
                    }
                    //QUESTION 5
                    if (cbQ5A5.Checked == true)
                    {
                        if (cbQ5A1.Checked == false && cbQ5A3.Checked == false &&
                            cbQ5A4.Checked == false && cbQ5A2.Checked == false)
                            ans5 = true;
                    }
                    //QUESTION 6
                    if (cbQ6A1.Checked == true)
                    {
                        if (cbQ6A5.Checked == false && cbQ6A2.Checked == false &&
                            cbQ6A3.Checked == false && cbQ6A4.Checked == false)
                            ans6 = true;
                    }
                    //QUESTION 7
                    if (cbQ7A3.Checked == true)
                    {
                        if (cbQ7A1.Checked == false && cbQ7A2.Checked == false &&
                            cbQ7A4.Checked == false && cbQ7A5.Checked == false)
                            ans7 = true;
                    }
                    break;
            //================================================================================
                case 4:
                    //QUESTION 1
                    if (cbQ1A4.Checked == true)
                    {
                        if (cbQ1A1.Checked == false && cbQ1A2.Checked == false &&
                            cbQ1A3.Checked == false && cbQ1A5.Checked == false)
                            ans1 = true;
                    }
                    //QUESTION 2
                    if (cbQ2A3.Checked == true)
                    {
                        if (cbQ2A2.Checked == false && cbQ2A1.Checked == false &&
                            cbQ2A4.Checked == false && cbQ2A5.Checked == false)
                            ans2 = true;
                    }
                    //QUESTION 3
                    if (cbQ3A1.Checked == true)
                    {
                        if (cbQ3A3.Checked == false && cbQ3A2.Checked == false &&
                            cbQ3A4.Checked == false && cbQ3A5.Checked == false)
                            ans3 = true;
                    }
                    //QUESTION 4
                    if (cbQ4A3.Checked == true)
                    {
                        if (cbQ4A1.Checked == false && cbQ4A2.Checked == false &&
                            cbQ4A5.Checked == false && cbQ4A4.Checked == false)
                            ans4 = true;
                    }
                    //QUESTION 5
                    if (cbQ5A1.Checked == true)
                    {
                        if (cbQ5A2.Checked == false && cbQ5A3.Checked == false &&
                            cbQ5A4.Checked == false && cbQ5A5.Checked == false)
                            ans5 = true;
                    }
                    //QUESTION 6
                    if (cbQ6A2.Checked == true)
                    {
                        if (cbQ6A1.Checked == false && cbQ6A5.Checked == false &&
                            cbQ6A3.Checked == false && cbQ6A4.Checked == false)
                            ans6 = true;
                    }
                    //QUESTION 7
                    if (cbQ7A4.Checked == true)
                    {
                        if (cbQ7A1.Checked == false && cbQ7A2.Checked == false &&
                            cbQ7A3.Checked == false && cbQ7A5.Checked == false)
                            ans7 = true;
                    }
                    break;
            //================================================================================
                case 5:
                    //QUESTION 1
                    if (cbQ1A3.Checked == true)
                    {
                        if (cbQ1A1.Checked == false && cbQ1A2.Checked == false &&
                            cbQ1A4.Checked == false && cbQ1A5.Checked == false)
                            ans1 = true;
                    }
                    //QUESTION 2
                    if (cbQ2A1.Checked == true)
                    {
                        if (cbQ2A2.Checked == false && cbQ2A3.Checked == false &&
                            cbQ2A4.Checked == false && cbQ2A5.Checked == false)
                            ans2 = true;
                    }
                    //QUESTION 3
                    if (cbQ3A4.Checked == true)
                    {
                        if (cbQ3A1.Checked == false && cbQ3A2.Checked == false &&
                            cbQ3A3.Checked == false && cbQ3A5.Checked == false)
                            ans3 = true;
                    }
                    //QUESTION 4
                    if (cbQ4A2.Checked == true)
                    {
                        if (cbQ4A1.Checked == false && cbQ4A5.Checked == false &&
                            cbQ4A3.Checked == false && cbQ4A4.Checked == false)
                            ans4 = true;
                    }
                    //QUESTION 5
                    if (cbQ5A1.Checked == true)
                    {
                        if (cbQ5A2.Checked == false && cbQ5A3.Checked == false &&
                            cbQ5A4.Checked == false && cbQ5A5.Checked == false)
                            ans5 = true;
                    }
                    //QUESTION 6
                    if (cbQ6A5.Checked == true)
                    {
                        if (cbQ6A1.Checked == false && cbQ6A2.Checked == false &&
                            cbQ6A3.Checked == false && cbQ6A4.Checked == false)
                            ans6 = true;
                    }
                    //QUESTION 7
                    if (cbQ7A3.Checked == true)
                    {
                        if (cbQ7A1.Checked == false && cbQ7A2.Checked == false &&
                            cbQ7A4.Checked == false && cbQ7A5.Checked == false)
                            ans7 = true;
                    }
                    break;
            //================================================================================
                case 6:
                    //QUESTION 1
                    if (cbQ1A5.Checked == true)
                    {
                        if (cbQ1A1.Checked == false && cbQ1A2.Checked == false &&
                            cbQ1A4.Checked == false && cbQ1A3.Checked == false)
                            ans1 = true;
                    }
                    //QUESTION 2
                    if (cbQ2A2.Checked == true)
                    {
                        if (cbQ2A1.Checked == false && cbQ2A3.Checked == false &&
                            cbQ2A4.Checked == false && cbQ2A5.Checked == false)
                            ans2 = true;
                    }
                    //QUESTION 3
                    if (cbQ3A1.Checked == true)
                    {
                        if (cbQ3A4.Checked == false && cbQ3A2.Checked == false &&
                            cbQ3A3.Checked == false && cbQ3A5.Checked == false)
                            ans3 = true;
                    }
                    //QUESTION 4
                    if (cbQ4A4.Checked == true)
                    {
                        if (cbQ4A1.Checked == false && cbQ4A5.Checked == false &&
                            cbQ4A3.Checked == false && cbQ4A2.Checked == false)
                            ans4 = true;
                    }
                    //QUESTION 5
                    if (cbQ5A3.Checked == true)
                    {
                        if (cbQ5A2.Checked == false && cbQ5A1.Checked == false &&
                            cbQ5A4.Checked == false && cbQ5A5.Checked == false)
                            ans5 = true;
                    }
                    //QUESTION 6
                    if (cbQ6A5.Checked == true)
                    {
                        if (cbQ6A1.Checked == false && cbQ6A2.Checked == false &&
                            cbQ6A3.Checked == false && cbQ6A4.Checked == false)
                            ans6 = true;
                    }
                    //QUESTION 7
                    if (cbQ7A2.Checked == true)
                    {
                        if (cbQ7A1.Checked == false && cbQ7A3.Checked == false &&
                            cbQ7A4.Checked == false && cbQ7A5.Checked == false)
                            ans7 = true;
                    }
                    break;
            //================================================================================
                case 7:
                    //QUESTION 1
                    if (cbQ1A4.Checked == true)
                    {
                        if (cbQ1A1.Checked == false && cbQ1A2.Checked == false &&
                            cbQ1A3.Checked == false && cbQ1A5.Checked == false)
                            ans1 = true;
                    }
                    //QUESTION 2
                    if (cbQ2A5.Checked == true)
                    {
                        if (cbQ2A2.Checked == false && cbQ2A3.Checked == false &&
                            cbQ2A4.Checked == false && cbQ2A1.Checked == false)
                            ans2 = true;
                    }
                    //QUESTION 3
                    if (cbQ3A3.Checked == true)
                    {
                        if (cbQ3A1.Checked == false && cbQ3A2.Checked == false &&
                            cbQ3A4.Checked == false && cbQ3A5.Checked == false)
                            ans3 = true;
                    }
                    //QUESTION 4
                    if (cbQ4A1.Checked == true)
                    {
                        if (cbQ4A2.Checked == false && cbQ4A5.Checked == false &&
                            cbQ4A3.Checked == false && cbQ4A4.Checked == false)
                            ans4 = true;
                    }
                    //QUESTION 5
                    if (cbQ5A2.Checked == true)
                    {
                        if (cbQ5A1.Checked == false && cbQ5A3.Checked == false &&
                            cbQ5A4.Checked == false && cbQ5A5.Checked == false)
                            ans5 = true;
                    }
                    //QUESTION 6
                    if (cbQ6A4.Checked == true)
                    {
                        if (cbQ6A1.Checked == false && cbQ6A2.Checked == false &&
                            cbQ6A3.Checked == false && cbQ6A5.Checked == false)
                            ans6 = true;
                    }
                    //QUESTION 7
                    if (cbQ7A5.Checked == true)
                    {
                        if (cbQ7A1.Checked == false && cbQ7A2.Checked == false &&
                            cbQ7A4.Checked == false && cbQ7A3.Checked == false)
                            ans7 = true;
                    }
                    break;
            //================================================================================
                case 8:
                    //QUESTION 1
                    if (cbQ1A5.Checked == true)
                    {
                        if (cbQ1A1.Checked == false && cbQ1A2.Checked == false &&
                            cbQ1A4.Checked == false && cbQ1A3.Checked == false)
                            pbQ1.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ1.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 2
                    if (cbQ2A3.Checked == true)
                    {
                        if (cbQ2A2.Checked == false && cbQ2A1.Checked == false &&
                            cbQ2A4.Checked == false && cbQ2A5.Checked == false)
                            pbQ2.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ2.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 3
                    if (cbQ3A1.Checked == true)
                    {
                        if (cbQ3A4.Checked == false && cbQ3A2.Checked == false &&
                            cbQ3A3.Checked == false && cbQ3A5.Checked == false)
                            pbQ3.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ3.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 4
                    if (cbQ4A3.Checked == true)
                    {
                        if (cbQ4A1.Checked == false && cbQ4A5.Checked == false &&
                            cbQ4A2.Checked == false && cbQ4A4.Checked == false)
                            pbQ4.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ4.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 5
                    if (cbQ5A2.Checked == true)
                    {
                        if (cbQ5A1.Checked == false && cbQ5A3.Checked == false &&
                            cbQ5A4.Checked == false && cbQ5A5.Checked == false)
                            pbQ5.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ5.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 6
                    if (cbQ6A4.Checked == true)
                    {
                        if (cbQ6A1.Checked == false && cbQ6A2.Checked == false &&
                            cbQ6A3.Checked == false && cbQ6A5.Checked == false)
                            pbQ6.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ6.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 7
                    if (cbQ7A1.Checked == true)
                    {
                        if (cbQ7A3.Checked == false && cbQ7A2.Checked == false &&
                            cbQ7A4.Checked == false && cbQ7A5.Checked == false)
                            pbQ7.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ7.Image = Image.FromFile(rightAns + "x.png");
                    }
                    return x;
                    break;
            //================================================================================
                case 9:
                    //QUESTION 1
                    if (cbQ1A3.Checked == true)
                    {
                        if (cbQ1A1.Checked == false && cbQ1A2.Checked == false &&
                            cbQ1A4.Checked == false && cbQ1A5.Checked == false)
                            pbQ1.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ1.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 2
                    if (cbQ2A4.Checked == true)
                    {
                        if (cbQ2A2.Checked == false && cbQ2A3.Checked == false &&
                            cbQ2A1.Checked == false && cbQ2A5.Checked == false)
                            pbQ2.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ2.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 3
                    if (cbQ3A5.Checked == true)
                    {
                        if (cbQ3A1.Checked == false && cbQ3A2.Checked == false &&
                            cbQ3A3.Checked == false && cbQ3A4.Checked == false)
                            pbQ3.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ3.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 4
                    if (cbQ4A2.Checked == true)
                    {
                        if (cbQ4A1.Checked == false && cbQ4A5.Checked == false &&
                            cbQ4A3.Checked == false && cbQ4A4.Checked == false)
                            pbQ4.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ4.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 5
                    if (cbQ5A3.Checked == true)
                    {
                        if (cbQ5A2.Checked == false && cbQ5A1.Checked == false &&
                            cbQ5A4.Checked == false && cbQ5A5.Checked == false)
                            pbQ5.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ5.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 6
                    if (cbQ6A1.Checked == true)
                    {
                        if (cbQ6A5.Checked == false && cbQ6A2.Checked == false &&
                            cbQ6A3.Checked == false && cbQ6A4.Checked == false)
                            pbQ6.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ6.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 7
                    if (cbQ7A2.Checked == true)
                    {
                        if (cbQ7A1.Checked == false && cbQ7A3.Checked == false &&
                            cbQ7A4.Checked == false && cbQ7A5.Checked == false)
                            pbQ7.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ7.Image = Image.FromFile(rightAns + "x.png");
                    }
                    return x;
                    break;
            //================================================================================
                case 10:
                    //QUESTION 1
                    if (cbQ1A2.Checked == true)
                    {
                        if (cbQ1A1.Checked == false && cbQ1A4.Checked == false &&
                            cbQ1A3.Checked == false && cbQ1A5.Checked == false)
                            pbQ1.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ1.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 2
                    if (cbQ2A3.Checked == true)
                    {
                        if (cbQ2A2.Checked == false && cbQ2A1.Checked == false &&
                            cbQ2A4.Checked == false && cbQ2A5.Checked == false)
                            pbQ2.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ2.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 3
                    if (cbQ3A1.Checked == true)
                    {
                        if (cbQ3A3.Checked == false && cbQ3A2.Checked == false &&
                            cbQ3A4.Checked == false && cbQ3A5.Checked == false)
                            pbQ3.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ3.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 4
                    if (cbQ4A4.Checked == true)
                    {
                        if (cbQ4A1.Checked == false && cbQ4A2.Checked == false &&
                            cbQ4A3.Checked == false && cbQ4A5.Checked == false)
                            pbQ4.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ4.Image = Image.FromFile(rightAns + "x.png");
                    } //QUESTION 5
                    if (cbQ5A2.Checked == true)
                    {
                        if (cbQ5A1.Checked == false && cbQ5A3.Checked == false &&
                            cbQ5A4.Checked == false && cbQ5A5.Checked == false)
                            pbQ5.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ5.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 6
                    if (cbQ6A5.Checked == true)
                    {
                        if (cbQ6A1.Checked == false && cbQ6A2.Checked == false &&
                            cbQ6A3.Checked == false && cbQ6A4.Checked == false)
                            pbQ6.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ6.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 7
                    if (cbQ7A3.Checked == true)
                    {
                        if (cbQ7A1.Checked == false && cbQ7A2.Checked == false &&
                            cbQ7A4.Checked == false && cbQ7A5.Checked == false)
                            pbQ7.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ7.Image = Image.FromFile(rightAns + "x.png");
                    }
                    return x;
                    break;
            //================================================================================
                case 11:
                    if (cbQ1A1.Checked == true)
                    {
                        if (cbQ1A2.Checked == false && cbQ1A3.Checked == false &&
                            cbQ1A4.Checked == false && cbQ1A5.Checked == false)
                            pbQ1.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ1.Image = Image.FromFile(rightAns + "x.png");
                    }
                    if (cbQ2A3.Checked == true)
                    {
                        if (cbQ2A1.Checked == false && cbQ2A2.Checked == false &&
                            cbQ2A4.Checked == false && cbQ2A5.Checked == false)
                            pbQ2.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ2.Image = Image.FromFile(rightAns + "x.png");
                    }
                    if (cbQ3A4.Checked == true)
                    {
                        if (cbQ3A1.Checked == false && cbQ3A2.Checked == false &&
                            cbQ3A3.Checked == false && cbQ3A5.Checked == false)
                            pbQ3.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ3.Image = Image.FromFile(rightAns + "x.png");
                    }
                    if (cbQ4A2.Checked == true)
                    {
                        if (cbQ4A1.Checked == false && cbQ4A3.Checked == false &&
                            cbQ4A4.Checked == false && cbQ4A5.Checked == false)
                            pbQ4.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ4.Image = Image.FromFile(rightAns + "x.png");
                    }
                    if (cbQ5A4.Checked == true)
                    {
                        if (cbQ5A1.Checked == false && cbQ5A2.Checked == false && 
                            cbQ5A3.Checked == false && cbQ5A5.Checked == false)
                            pbQ5.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ5.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 6
                    if (cbQ6A5.Checked == true)
                    {
                        if (cbQ6A1.Checked == false && cbQ6A2.Checked == false &&
                            cbQ6A3.Checked == false && cbQ6A4.Checked == false)
                            pbQ6.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ6.Image = Image.FromFile(rightAns + "x.png");
                    }
                    //QUESTION 7
                    if (cbQ7A2.Checked == true)
                    {
                        if (cbQ7A1.Checked == false && cbQ7A3.Checked == false &&
                            cbQ7A4.Checked == false && cbQ7A5.Checked == false)
                            pbQ7.Image = Image.FromFile(rightAns + "check.png");
                        else pbQ7.Image = Image.FromFile(rightAns + "x.png");
                    }
                    return x;
                    break;

            }
            //===============END OF SWITCH LOOKING FOR CORRECT ANSWERS BASED ON WILDACRD======
            //==================INPUT IMAGES AND CALCULATE NUMBER OF CORRECT ANSWERS==========
            if (ans1 == true)
            {
                pbQ1.Image = Image.FromFile(rightAns);
                x += 1;
            }
            else if (ans1 == false) pbQ1.Image = Image.FromFile(wrongAns);
            if (ans2 == true)
            {
                pbQ2.Image = Image.FromFile(rightAns);
                x += 1;
            }
            else if (ans2 == false) pbQ2.Image = Image.FromFile(wrongAns);
            if (ans3 == true)
            {
                pbQ3.Image = Image.FromFile(rightAns);
                x += 1;
            }
            else if (ans3 == false) pbQ3.Image = Image.FromFile(wrongAns);
            if (ans4 == true)
            {
                pbQ4.Image = Image.FromFile(rightAns);
                x += 1;
            }
            else if (ans4 == false) pbQ4.Image = Image.FromFile(wrongAns);
            if (ans5 == true)
            {
                pbQ5.Image = Image.FromFile(rightAns);
                x += 1;
            }
            else if (ans5 == false) pbQ5.Image = Image.FromFile(wrongAns);
            if (ans6 == true)
            {
                pbQ6.Image = Image.FromFile(rightAns);
                x += 1;
            }
            else if (ans6 == false) pbQ6.Image = Image.FromFile(wrongAns);
            if (ans7 == true)
            {
                pbQ7.Image = Image.FromFile(rightAns);
                x += 1;
            }
            else if (ans7 == false) pbQ7.Image = Image.FromFile(wrongAns);

            numOfCorrectAnswers = x;
            x = 0;
            return numOfCorrectAnswers;
        }
        private void Score()
        {
            CorrectAnswer();
            currentScore = (Convert.ToDouble(numOfCorrectAnswers) / Convert.ToDouble(numOfQuestions)) *100;
            if (currentScore > highScore)
                highScore = currentScore;
            else highScore = highScore;

           
            lblCurrentScore.Text = Convert.ToInt32(currentScore).ToString();
            lblHighScore.Text = Convert.ToInt32(highScore).ToString();
        }
        //Generate Questions and Answers
        private void GenerateQuestions()
        {
            int x, y;
            int randAns1, randAns2, randAns3, randAns4;
            Random rand = new Random();

            switch (wildCard)
            {
                case 1:
                    //QUESTION 1
                    x = rand.Next(1, 50);
                    y = rand.Next(1, 50);
                    answer1 = x + y;
                    randAns1 = x + ((y * 2) - x);
                    randAns2 = rand.Next(1, 100);
                    randAns3 = x - y;
                    randAns4 = x * 2;
                    lblQuestion1.Text = x + " + " + y + " = ?";
                    cbQ1A1.Text = randAns1.ToString();
                    cbQ1A3.Text = answer1.ToString();
                    cbQ1A2.Text = randAns2.ToString();
                    cbQ1A4.Text = randAns3.ToString();
                    cbQ1A5.Text = randAns4.ToString();
                    //QUESTION 2
                    x = rand.Next(1, 20);
                    y = rand.Next(1, 15);
                    answer2 = x * y;
                    randAns1 = x + ((y * 2) - x);
                    randAns2 = rand.Next(1, 100);
                    randAns3 = x - y;
                    randAns4 = x * 2;
                    lblQuestion2.Text = x + " x " + y + " = ?";
                    cbQ2A3.Text = randAns1.ToString();
                    cbQ2A1.Text = answer2.ToString();
                    cbQ2A2.Text = randAns2.ToString();
                    cbQ2A4.Text = randAns3.ToString();
                    cbQ2A5.Text = randAns4.ToString();
                    //QUESTION 3
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 10);
                    answer3 = x / y;
                    randAns1 = x + ((y * 2) - x);
                    randAns2 = rand.Next(1, 100);
                    randAns3 = x - y;
                    randAns4 = x * 2;
                    lblQuestion3.Text = x + " ÷ " + y + " = ?";
                    cbQ3A1.Text = randAns1.ToString();
                    cbQ3A2.Text = answer3.ToString();
                    cbQ3A3.Text = randAns2.ToString();
                    cbQ3A4.Text = randAns3.ToString();
                    cbQ3A5.Text = randAns4.ToString();
                    //QUESTION 4
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 100);
                    answer4 = x + y;
                    randAns1 = x + ((y * 2) - x);
                    randAns2 = rand.Next(1, 100);
                    randAns3 = x - y;
                    randAns4 = x * 2;
                    lblQuestion4.Text = x + " + " + y + " = ?";
                    cbQ4A5.Text = randAns1.ToString();
                    cbQ4A4.Text = answer4.ToString();
                    cbQ4A1.Text = randAns2.ToString();
                    cbQ4A2.Text = randAns3.ToString();
                    cbQ4A3.Text = randAns4.ToString();
                    //QUESTION 5
                    x = rand.Next(1, 80);
                    y = rand.Next(1, 50);
                    answer5 = x - y;
                    randAns1 = x + ((y * 2) - x);
                    randAns2 = rand.Next(1, 100);
                    randAns3 = (2 * x) - y;
                    randAns4 = x * 2;
                    lblQuestion5.Text = x + " - " + y + " = ?";
                    cbQ5A1.Text = randAns1.ToString();
                    cbQ5A5.Text = answer5.ToString();
                    cbQ5A3.Text = randAns2.ToString();
                    cbQ5A4.Text = randAns3.ToString();
                    cbQ5A2.Text = randAns4.ToString();
                    //QUESTION 6
                    x = rand.Next(1, 10);
                    y = rand.Next(1, 19);
                    answer6 = x * y;
                    randAns1 = x + ((y * 2) - x);
                    randAns2 = rand.Next(1, 100);
                    randAns3 = x - y;
                    randAns4 = x * 2;
                    lblQuestion6.Text = x + " x " + y + " = ?";
                    cbQ6A1.Text = randAns1.ToString();
                    cbQ6A2.Text = answer6.ToString();
                    cbQ6A3.Text = randAns2.ToString();
                    cbQ6A4.Text = randAns3.ToString();
                    cbQ6A5.Text = randAns4.ToString();
                    //QUESTION 7
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 30);
                    answer7 = x / y;
                    randAns1 = x + ((y * 2) - x);
                    randAns2 = rand.Next(1, 100);
                    randAns3 = x - y;
                    randAns4 = x * 2;
                    lblQuestion7.Text = x + " ÷ " + y + " = ?";
                    cbQ7A5.Text = randAns1.ToString();
                    cbQ7A4.Text = answer7.ToString();
                    cbQ7A3.Text = randAns2.ToString();
                    cbQ7A2.Text = randAns3.ToString();
                    cbQ7A1.Text = randAns4.ToString();
                    break;
        //================================================================================
                case 2:
                    //QUESTION 1
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 80);
                    answer1 = x + y;
                    randAns1 = x + y + y;
                    randAns2 = x * x;
                    randAns3 = x + (y - (x * 2));
                    randAns4 = y / (x / 2);
                    lblQuestion1.Text = x + " + " + y + " = ?";
                    cbQ1A4.Text = answer1.ToString();
                    cbQ1A1.Text = randAns1.ToString();
                    cbQ1A2.Text = randAns2.ToString();
                    cbQ1A3.Text = randAns3.ToString();
                    cbQ1A5.Text = randAns4.ToString();
                    //QUESTION 2
                    x = rand.Next(1, 50);
                    y = rand.Next(1, 50);
                    answer2 = x - y;
                    randAns1 = x + y + y;
                    randAns2 = x * x;
                    randAns3 = x + (y - (x * 2));
                    randAns4 = y / (x / 2);
                    lblQuestion2.Text = x + " - " + y + " = ?";
                    cbQ2A1.Text = answer2.ToString();
                    cbQ2A4.Text = randAns1.ToString();
                    cbQ2A2.Text = randAns2.ToString();
                    cbQ2A3.Text = randAns3.ToString();
                    cbQ2A5.Text = randAns4.ToString();
                    //QUESTION 3
                    x = rand.Next(1, 10);
                    y = rand.Next(1, 70);
                    answer3 = x + y;
                    randAns1 = x + y + y;
                    randAns2 = x * x;
                    randAns3 = x + (y - (x * 2));
                    randAns4 = y / (x / 2);
                    lblQuestion3.Text = x + " + " + y + " = ?";
                    cbQ3A3.Text = answer3.ToString();
                    cbQ3A1.Text = randAns1.ToString();
                    cbQ3A2.Text = randAns2.ToString();
                    cbQ3A4.Text = randAns3.ToString();
                    cbQ3A5.Text = randAns4.ToString();
                    //QUESTION 4
                    x = rand.Next(1, 20);
                    y = rand.Next(1, 15);
                    answer4 = x * y;
                    randAns1 = x + y + y;
                    randAns2 = x * x;
                    randAns3 = x + (y - (x * 2));
                    randAns4 = y / (x / 2);
                    lblQuestion4.Text = x + " x " + y + " = ?";
                    cbQ4A5.Text = answer4.ToString();
                    cbQ4A1.Text = randAns1.ToString();
                    cbQ4A2.Text = randAns2.ToString();
                    cbQ4A3.Text = randAns3.ToString();
                    cbQ4A4.Text = randAns4.ToString();
                    //QUESTION 5
                    x = rand.Next(1, 40);
                    y = rand.Next(1, 35);
                    answer5 = x * y;
                    randAns1 = x + y + y;
                    randAns2 = x * x;
                    randAns3 = x + (y - (x * 2));
                    randAns4 = y / (x / 2);
                    lblQuestion5.Text = x + " x " + y + " = ?";
                    cbQ5A2.Text = answer5.ToString();
                    cbQ5A1.Text = randAns1.ToString();
                    cbQ5A4.Text = randAns2.ToString();
                    cbQ5A3.Text = randAns3.ToString();
                    cbQ5A5.Text = randAns4.ToString();
                    //QUESTION 6
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 35);
                    answer6 = x / y;
                    randAns1 = x + y + y;
                    randAns2 = x * x;
                    randAns3 = x + (y - (x * 2));
                    randAns4 = y / (x / 2);
                    lblQuestion6.Text = x + " ÷ " + y + " = ?";
                    cbQ6A5.Text = answer6.ToString();
                    cbQ6A1.Text = randAns1.ToString();
                    cbQ6A2.Text = randAns2.ToString();
                    cbQ6A3.Text = randAns3.ToString();
                    cbQ6A4.Text = randAns4.ToString();
                    //QUESTION 7
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 80);
                    answer7 = x / y;
                    randAns1 = x + y + y;
                    randAns2 = x * x;
                    randAns3 = x + (y - (x * 2));
                    randAns4 = y / (x / 2);
                    lblQuestion7.Text = x + " ÷ " + y + " = ?";
                    cbQ7A3.Text = answer7.ToString();
                    cbQ7A1.Text = randAns1.ToString();
                    cbQ7A2.Text = randAns2.ToString();
                    cbQ7A4.Text = randAns3.ToString();
                    cbQ7A5.Text = randAns4.ToString();
                    break;
        //================================================================================
                case 3:
                    //QUESTION 1
                    x = rand.Next(1, 40);
                    y = rand.Next(1, 60);
                    answer1 = x + y;
                    randAns1 = x - (y + y);
                    randAns2 = x * y;
                    randAns3 = x + (y + (x / 2));
                    randAns4 = y * (x / 6);
                    lblQuestion1.Text = x + " + " + y + " = ?";
                    cbQ1A2.Text = answer1.ToString();
                    cbQ1A1.Text = randAns1.ToString();
                    cbQ1A4.Text = randAns2.ToString();
                    cbQ1A3.Text = randAns3.ToString();
                    cbQ1A5.Text = randAns4.ToString();
                    //QUESTION 2
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 80);
                    answer2 = x - y;
                    randAns1 = x - (y + y);
                    randAns2 = x * y;
                    randAns3 = x + (y + (x / 2));
                    randAns4 = y * (x / 6);
                    lblQuestion2.Text = x + " - " + y + " = ?";
                    cbQ2A3.Text = answer2.ToString();
                    cbQ2A4.Text = randAns1.ToString();
                    cbQ2A2.Text = randAns2.ToString();
                    cbQ2A1.Text = randAns3.ToString();
                    cbQ2A5.Text = randAns4.ToString();
                    //QUESTION 3
                    x = rand.Next(1, 200);
                    y = rand.Next(1, 60);
                    answer3 = x - y;
                    randAns1 = x - (y + y);
                    randAns2 = x * y;
                    randAns3 = x + (y + (x / 2));
                    randAns4 = y * (x / 6);
                    lblQuestion3.Text = x + " - " + y + " = ?";
                    cbQ3A1.Text = answer3.ToString();
                    cbQ3A3.Text = randAns1.ToString();
                    cbQ3A2.Text = randAns2.ToString();
                    cbQ3A4.Text = randAns3.ToString();
                    cbQ3A5.Text = randAns4.ToString();
                    //QUESTION 4
                    x = rand.Next(1, 20);
                    y = rand.Next(1, 50);
                    answer4 = x * y;
                    randAns1 = x - (y + y);
                    randAns2 = x * (y-3);
                    randAns3 = x + (y + (x / 2));
                    randAns4 = y * (x / 6);
                    lblQuestion4.Text = x + " x " + y + " = ?";
                    cbQ4A4.Text = answer4.ToString();
                    cbQ4A1.Text = randAns1.ToString();
                    cbQ4A2.Text = randAns2.ToString();
                    cbQ4A3.Text = randAns3.ToString();
                    cbQ4A5.Text = randAns4.ToString();
                    //QUESTION 5
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 15);
                    answer5 = x / y;
                    randAns1 = x - (y + y);
                    randAns2 = x * (y/2);
                    randAns3 = x + (y + (x / 2));
                    randAns4 = y * (x / 6);
                    lblQuestion5.Text = x + " ÷ " + y + " = ?";
                    cbQ5A5.Text = answer5.ToString();
                    cbQ5A1.Text = randAns1.ToString();
                    cbQ5A4.Text = randAns2.ToString();
                    cbQ5A3.Text = randAns3.ToString();
                    cbQ5A2.Text = randAns4.ToString();
                    //QUESTION 6
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 80);
                    answer6 = x / y;
                    randAns1 = x - (y + y);
                    randAns2 = x * (y-2);
                    randAns3 = x + (y + (x / 2));
                    randAns4 = y * (x / 6);
                    lblQuestion6.Text = x + " ÷ " + y + " = ?";
                    cbQ6A1.Text = answer6.ToString();
                    cbQ6A5.Text = randAns1.ToString();
                    cbQ6A2.Text = randAns2.ToString();
                    cbQ6A3.Text = randAns3.ToString();
                    cbQ6A4.Text = randAns4.ToString();
                    //QUESTION 7
                    x = rand.Next(1, 50);
                    y = rand.Next(1, 15);
                    answer7 = x * y;
                    randAns1 = x - (y + y);
                    randAns2 = x * (y+1);
                    randAns3 = x + (y + (x / 2));
                    randAns4 = y * (x / 6);
                    lblQuestion7.Text = x + " x " + y + " = ?";
                    cbQ7A3.Text = answer7.ToString();
                    cbQ7A1.Text = randAns1.ToString();
                    cbQ7A2.Text = randAns2.ToString();
                    cbQ7A4.Text = randAns3.ToString();
                    cbQ7A5.Text = randAns4.ToString();
                    break;
        //================================================================================
                case 4:
                    //QUESTION 1
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 50);
                    answer1 = x + y;
                    randAns1 = x * 3;
                    randAns2 = x * y;
                    randAns3 = rand.Next(50, 150);
                    randAns4 = y - (x / 6);
                    lblQuestion1.Text = x + " + " + y + " = ?";
                    cbQ1A4.Text = answer1.ToString();
                    cbQ1A1.Text = randAns1.ToString();
                    cbQ1A2.Text = randAns2.ToString();
                    cbQ1A3.Text = randAns3.ToString();
                    cbQ1A5.Text = randAns4.ToString();
                    //QUESTION 2
                    x = rand.Next(1, 200);
                    y = rand.Next(1, 80);
                    answer2 = x - y;
                    randAns1 = x * 3;
                    randAns2 = x * y;
                    randAns3 = rand.Next(50, 150);
                    randAns4 = y - (x / 6);
                    lblQuestion2.Text = x + " - " + y + " = ?";
                    cbQ2A3.Text = answer2.ToString();
                    cbQ2A4.Text = randAns1.ToString();
                    cbQ2A2.Text = randAns2.ToString();
                    cbQ2A1.Text = randAns3.ToString();
                    cbQ2A5.Text = randAns4.ToString();
                    //QUESTION 3
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 60);
                    answer3 = x + y;
                    randAns1 = x * 3;
                    randAns2 = x * y;
                    randAns3 = rand.Next(50, 150);
                    randAns4 = y - (x / 6);
                    lblQuestion3.Text = x + " + " + y + " = ?";
                    cbQ3A1.Text = answer3.ToString();
                    cbQ3A3.Text = randAns1.ToString();
                    cbQ3A2.Text = randAns2.ToString();
                    cbQ3A4.Text = randAns3.ToString();
                    cbQ3A5.Text = randAns4.ToString();
                    //QUESTION 4
                    x = rand.Next(1, 50);
                    y = rand.Next(1, 20);
                    answer4 = x / y;
                    randAns1 = x * 3;
                    randAns2 = x * y;
                    randAns3 = rand.Next(50, 150);
                    randAns4 = y - (x / 6);
                    lblQuestion4.Text = x + " ÷ " + y + " = ?";
                    cbQ4A3.Text = answer4.ToString();
                    cbQ4A1.Text = randAns1.ToString();
                    cbQ4A2.Text = randAns2.ToString();
                    cbQ4A4.Text = randAns3.ToString();
                    cbQ4A5.Text = randAns4.ToString();
                    //QUESTION 5
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 15);
                    answer5 = x / y;
                    randAns1 = x * 3;
                    randAns2 = x * (y-2);
                    randAns3 = rand.Next(50, 150);
                    randAns4 = y - (x / 6);
                    lblQuestion5.Text = x + " ÷ " + y + " = ?";
                    cbQ5A1.Text = answer5.ToString();
                    cbQ5A5.Text = randAns1.ToString();
                    cbQ5A4.Text = randAns2.ToString();
                    cbQ5A3.Text = randAns3.ToString();
                    cbQ5A2.Text = randAns4.ToString();
                    //QUESTION 6
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 80);
                    answer6 = x / y;
                    randAns1 = x * 3;
                    randAns2 = x * (y+1);
                    randAns3 = rand.Next(50, 150);
                    randAns4 = y - (x / 6);
                    lblQuestion6.Text = x + " ÷ " + y + " = ?";
                    cbQ6A2.Text = answer6.ToString();
                    cbQ6A5.Text = randAns1.ToString();
                    cbQ6A1.Text = randAns2.ToString();
                    cbQ6A3.Text = randAns3.ToString();
                    cbQ6A4.Text = randAns4.ToString();
                    //QUESTION 7
                    x = rand.Next(1, 35);
                    y = rand.Next(1, 15);
                    answer7 = x * y;
                    randAns1 = x * 3;
                    randAns2 = x * (y-1);
                    randAns3 = rand.Next(50, 150);
                    randAns4 = y - (x / 6);
                    lblQuestion7.Text = x + " x " + y + " = ?";
                    cbQ7A4.Text = answer7.ToString();
                    cbQ7A1.Text = randAns1.ToString();
                    cbQ7A2.Text = randAns2.ToString();
                    cbQ7A3.Text = randAns3.ToString();
                    cbQ7A5.Text = randAns4.ToString();
                    break;
        //================================================================================
                case 5:
                    //QUESTION 1
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 50);
                    answer1 = x - y;
                    randAns1 = x / 2;
                    randAns2 = x * randAns1;
                    randAns3 = rand.Next(20, 250);
                    randAns4 = y * y;
                    lblQuestion1.Text = x + " - " + y + " = ?";
                    cbQ1A3.Text = answer1.ToString();
                    cbQ1A1.Text = randAns1.ToString();
                    cbQ1A2.Text = randAns2.ToString();
                    cbQ1A4.Text = randAns3.ToString();
                    cbQ1A5.Text = randAns4.ToString();
                    //QUESTION 2
                    x = rand.Next(1, 200);
                    y = rand.Next(1, 80);
                    answer2 = x - y;
                    randAns1 = x / 2;
                    randAns2 = x * randAns1;
                    randAns3 = rand.Next(20, 250);
                    randAns4 = y * y;
                    lblQuestion2.Text = x + " - " + y + " = ?";
                    cbQ2A1.Text = answer2.ToString();
                    cbQ2A4.Text = randAns1.ToString();
                    cbQ2A2.Text = randAns2.ToString();
                    cbQ2A3.Text = randAns3.ToString();
                    cbQ2A5.Text = randAns4.ToString();
                    //QUESTION 3
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 60);
                    answer3 = x + y;
                    randAns1 = x / 2;
                    randAns2 = x * randAns1;
                    randAns3 = rand.Next(20, 250);
                    randAns4 = y * y;
                    lblQuestion3.Text = x + " + " + y + " = ?";
                    cbQ3A4.Text = answer3.ToString();
                    cbQ3A3.Text = randAns1.ToString();
                    cbQ3A2.Text = randAns2.ToString();
                    cbQ3A1.Text = randAns3.ToString();
                    cbQ3A5.Text = randAns4.ToString();
                    //QUESTION 4
                    x = rand.Next(1, 50);
                    y = rand.Next(1, 20);
                    answer4 = x + y;
                    randAns1 = x / 2;
                    randAns2 = x * randAns1;
                    randAns3 = rand.Next(20, 250);
                    randAns4 = y * y;
                    lblQuestion4.Text = x + " + " + y + " = ?";
                    cbQ4A2.Text = answer4.ToString();
                    cbQ4A1.Text = randAns1.ToString();
                    cbQ4A3.Text = randAns2.ToString();
                    cbQ4A4.Text = randAns3.ToString();
                    cbQ4A5.Text = randAns4.ToString();
                    //QUESTION 5
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 15);
                    answer5 = x / y;
                    randAns1 = x / 2;
                    randAns2 = x * randAns1;
                    randAns3 = rand.Next(20, 250);
                    randAns4 = y * y;
                    lblQuestion5.Text = x + " ÷ " + y + " = ?";
                    cbQ5A1.Text = answer5.ToString();
                    cbQ5A5.Text = randAns1.ToString();
                    cbQ5A4.Text = randAns2.ToString();
                    cbQ5A3.Text = randAns3.ToString();
                    cbQ5A2.Text = randAns4.ToString();
                    //QUESTION 6
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 80);
                    answer6 = x / y;
                    randAns1 = x / 2;
                    randAns2 = x * randAns1;
                    randAns3 = rand.Next(20, 250);
                    randAns4 = y * y;
                    lblQuestion6.Text = x + " ÷ " + y + " = ?";
                    cbQ6A5.Text = answer6.ToString();
                    cbQ6A2.Text = randAns1.ToString();
                    cbQ6A1.Text = randAns2.ToString();
                    cbQ6A3.Text = randAns3.ToString();
                    cbQ6A4.Text = randAns4.ToString();
                    //QUESTION 7
                    x = rand.Next(1, 35);
                    y = rand.Next(1, 15);
                    answer7 = x * y;
                    randAns1 = x / 2;
                    randAns2 = x * randAns1;
                    randAns3 = rand.Next(20, 250);
                    randAns4 = y * y;
                    lblQuestion7.Text = x + " x " + y + " = ?";
                    cbQ7A3.Text = answer7.ToString();
                    cbQ7A1.Text = randAns1.ToString();
                    cbQ7A2.Text = randAns2.ToString();
                    cbQ7A4.Text = randAns3.ToString();
                    cbQ7A5.Text = randAns4.ToString();
                    break;
        //================================================================================
                case 6:
                    //QUESTION 1
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 50);
                    answer1 = x + y;
                    randAns1 = x + (y-7);
                    randAns2 = (x*2) - randAns1;
                    randAns3 = rand.Next(10, 90);
                    randAns4 = y * (y-3);
                    lblQuestion1.Text = x + " + " + y + " = ?";
                    cbQ1A5.Text = answer1.ToString();
                    cbQ1A1.Text = randAns1.ToString();
                    cbQ1A2.Text = randAns2.ToString();
                    cbQ1A4.Text = randAns3.ToString();
                    cbQ1A3.Text = randAns4.ToString();
                    //QUESTION 2
                    x = rand.Next(1, 200);
                    y = rand.Next(1, 80);
                    answer2 = x + y;
                    randAns1 = x + (y-7);
                    randAns2 = (x*2) - randAns1;
                    randAns3 = rand.Next(10, 90);
                    randAns4 = y * (y-3);
                    lblQuestion2.Text = x + " + " + y + " = ?";
                    cbQ2A2.Text = answer2.ToString();
                    cbQ2A4.Text = randAns1.ToString();
                    cbQ2A1.Text = randAns2.ToString();
                    cbQ2A3.Text = randAns3.ToString();
                    cbQ2A5.Text = randAns4.ToString();
                    //QUESTION 3
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 60);
                    answer3 = x - y;
                    randAns1 = x + (y-7);
                    randAns2 = (x*2) - randAns1;
                    randAns3 = rand.Next(10, 90);
                    randAns4 = y * (y-3);
                    lblQuestion3.Text = x + " - " + y + " = ?";
                    cbQ3A1.Text = answer3.ToString();
                    cbQ3A3.Text = randAns1.ToString();
                    cbQ3A2.Text = randAns2.ToString();
                    cbQ3A4.Text = randAns3.ToString();
                    cbQ3A5.Text = randAns4.ToString();
                    //QUESTION 4
                    x = rand.Next(1, 50);
                    y = rand.Next(1, 20);
                    answer4 = x * y;
                    randAns1 = x + (y-7);
                    randAns2 = (x*2) - randAns1;
                    randAns3 = rand.Next(10, 90);
                    randAns4 = y * (y-3);
                    lblQuestion4.Text = x + " x " + y + " = ?";
                    cbQ4A4.Text = answer4.ToString();
                    cbQ4A1.Text = randAns1.ToString();
                    cbQ4A3.Text = randAns2.ToString();
                    cbQ4A2.Text = randAns3.ToString();
                    cbQ4A5.Text = randAns4.ToString();
                    //QUESTION 5
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 15);
                    answer5 = x / y;
                    randAns1 = x + (y-7);
                    randAns2 = (x*2) - randAns1;
                    randAns3 = rand.Next(10, 90);
                    randAns4 = y * (y-3);
                    lblQuestion5.Text = x + " ÷ " + y + " = ?";
                    cbQ5A3.Text = answer5.ToString();
                    cbQ5A5.Text = randAns1.ToString();
                    cbQ5A4.Text = randAns2.ToString();
                    cbQ5A1.Text = randAns3.ToString();
                    cbQ5A2.Text = randAns4.ToString();
                    //QUESTION 6
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 80);
                    answer6 = x * y;
                    randAns1 = x + (y-7);
                    randAns2 = (x*2) - randAns1;
                    randAns3 = rand.Next(10, 90);
                    randAns4 = y * (y-3);
                    lblQuestion6.Text = x + " x " + y + " = ?";
                    cbQ6A5.Text = answer6.ToString();
                    cbQ6A2.Text = randAns1.ToString();
                    cbQ6A1.Text = randAns2.ToString();
                    cbQ6A3.Text = randAns3.ToString();
                    cbQ6A4.Text = randAns4.ToString();
                    //QUESTION 7
                    x = rand.Next(1, 35);
                    y = rand.Next(1, 15);
                    answer7 = x / y;
                    randAns1 = x + (y-7);
                    randAns2 = (x*2) - randAns1;
                    randAns3 = rand.Next(10, 90);
                    randAns4 = y * (y-3);
                    lblQuestion7.Text = x + " ÷ " + y + " = ?";
                    cbQ7A2.Text = answer7.ToString();
                    cbQ7A1.Text = randAns1.ToString();
                    cbQ7A3.Text = randAns2.ToString();
                    cbQ7A4.Text = randAns3.ToString();
                    cbQ7A5.Text = randAns4.ToString();
                    break;
        //================================================================================
                case 7:
                    //QUESTION 1
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 80);
                    answer1 = x - y;
                    randAns1 = x + (y + 2);
                    randAns2 = (x / 2) - randAns1;
                    randAns3 = rand.Next(50, 120);
                    randAns4 = y / (x * 6);
                    lblQuestion1.Text = x + " - " + y + " = ?";
                    cbQ1A4.Text = answer1.ToString();
                    cbQ1A1.Text = randAns1.ToString();
                    cbQ1A2.Text = randAns2.ToString();
                    cbQ1A5.Text = randAns3.ToString();
                    cbQ1A3.Text = randAns4.ToString();
                    //QUESTION 2
                    x = rand.Next(1, 80);
                    y = rand.Next(1, 80);
                    answer2 = x + y;
                    randAns1 = x + (y + 2);
                    randAns2 = (x / 2) - randAns1;
                    randAns3 = rand.Next(50, 120);
                    randAns4 = y / (x * 6);
                    lblQuestion2.Text = x + " + " + y + " = ?";
                    cbQ2A5.Text = answer2.ToString();
                    cbQ2A4.Text = randAns1.ToString();
                    cbQ2A1.Text = randAns2.ToString();
                    cbQ2A3.Text = randAns3.ToString();
                    cbQ2A2.Text = randAns4.ToString();
                    //QUESTION 3
                    x = rand.Next(1, 200);
                    y = rand.Next(1, 90);
                    answer3 = x - y;
                    randAns1 = x + (y + 2);
                    randAns2 = (x / 2) - randAns1;
                    randAns3 = rand.Next(50, 120);
                    randAns4 = y / (x * 6);
                    lblQuestion3.Text = x + " - " + y + " = ?";
                    cbQ3A3.Text = answer3.ToString();
                    cbQ3A1.Text = randAns1.ToString();
                    cbQ3A2.Text = randAns2.ToString();
                    cbQ3A4.Text = randAns3.ToString();
                    cbQ3A5.Text = randAns4.ToString();
                    //QUESTION 4
                    x = rand.Next(1, 90);
                    y = rand.Next(1, 20);
                    answer4 = x / y;
                    randAns1 = x + (y + 2);
                    randAns2 = (x / 2) - randAns1;
                    randAns3 = rand.Next(50, 120);
                    randAns4 = y / (x * 6);
                    lblQuestion4.Text = x + " ÷ " + y + " = ?";
                    cbQ4A1.Text = answer4.ToString();
                    cbQ4A4.Text = randAns1.ToString();
                    cbQ4A3.Text = randAns2.ToString();
                    cbQ4A2.Text = randAns3.ToString();
                    cbQ4A5.Text = randAns4.ToString();
                    //QUESTION 5
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 15);
                    answer5 = x / y;
                    randAns1 = x + (y + 2);
                    randAns2 = (x / 2) - randAns1;
                    randAns3 = rand.Next(50, 120);
                    randAns4 = y / (x * 6);
                    lblQuestion5.Text = x + " ÷ " + y + " = ?";
                    cbQ5A2.Text = answer5.ToString();
                    cbQ5A5.Text = randAns1.ToString();
                    cbQ5A4.Text = randAns2.ToString();
                    cbQ5A1.Text = randAns3.ToString();
                    cbQ5A3.Text = randAns4.ToString();
                    //QUESTION 6
                    x = rand.Next(1, 10);
                    y = rand.Next(1, 60);
                    answer6 = x * y;
                    randAns1 = x + (y + 2);
                    randAns2 = (x / 2) - randAns1;
                    randAns3 = rand.Next(50, 120);
                    randAns4 = y / (x * 6);
                    lblQuestion6.Text = x + " x " + y + " = ?";
                    cbQ6A4.Text = answer6.ToString();
                    cbQ6A2.Text = randAns1.ToString();
                    cbQ6A1.Text = randAns2.ToString();
                    cbQ6A3.Text = randAns3.ToString();
                    cbQ6A5.Text = randAns4.ToString();
                    //QUESTION 7
                    x = rand.Next(1, 35);
                    y = rand.Next(1, 15);
                    answer7 = x * y;
                    randAns1 = x + (y + 2);
                    randAns2 = (x / 2) - randAns1;
                    randAns3 = rand.Next(50, 120);
                    randAns4 = y / (x * 6);
                    lblQuestion7.Text = x + " x " + y + " = ?";
                    cbQ7A5.Text = answer7.ToString();
                    cbQ7A1.Text = randAns1.ToString();
                    cbQ7A3.Text = randAns2.ToString();
                    cbQ7A4.Text = randAns3.ToString();
                    cbQ7A2.Text = randAns4.ToString();
                    break;
        //================================================================================
                case 8:
                    //QUESTION 1
                    x = rand.Next(1, 400);
                    y = rand.Next(1, 250);
                    answer1 = x - y;
                    randAns1 = x - (y - 2);
                    randAns2 = (x * 2) - (randAns1 * 2);
                    randAns3 = rand.Next(20, 180);
                    randAns4 = y - (x / 3);
                    lblQuestion1.Text = x + " - " + y + " = ?";
                    cbQ1A5.Text = answer1.ToString();
                    cbQ1A1.Text = randAns1.ToString();
                    cbQ1A2.Text = randAns2.ToString();
                    cbQ1A4.Text = randAns3.ToString();
                    cbQ1A3.Text = randAns4.ToString();
                    //QUESTION 2
                    x = rand.Next(1, 200);
                    y = rand.Next(1, 80);
                    answer2 = x + y;
                    randAns1 = x - (y - 2);
                    randAns2 = (x * 2) - (randAns1 * 2);
                    randAns3 = rand.Next(20, 180);
                    randAns4 = y - (x / 3);
                    lblQuestion2.Text = x + " + " + y + " = ?";
                    cbQ2A3.Text = answer2.ToString();
                    cbQ2A4.Text = randAns1.ToString();
                    cbQ2A1.Text = randAns2.ToString();
                    cbQ2A5.Text = randAns3.ToString();
                    cbQ2A2.Text = randAns4.ToString();
                    //QUESTION 3
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 40);
                    answer3 = x + y;
                    randAns1 = x - (y - 2);
                    randAns2 = (x * 2) - (randAns1 * 2);
                    randAns3 = rand.Next(20, 180);
                    randAns4 = y - (x / 3);
                    lblQuestion3.Text = x + " + " + y + " = ?";
                    cbQ3A1.Text = answer3.ToString();
                    cbQ3A3.Text = randAns1.ToString();
                    cbQ3A2.Text = randAns2.ToString();
                    cbQ3A4.Text = randAns3.ToString();
                    cbQ3A5.Text = randAns4.ToString();
                    //QUESTION 4
                    x = rand.Next(1, 50);
                    y = rand.Next(1, 15);
                    answer4 = x * y;
                    randAns1 = x - (y - 2);
                    randAns2 = (x * 2) - (randAns1 * 2);
                    randAns3 = rand.Next(20, 180);
                    randAns4 = y - (x / 3);
                    lblQuestion4.Text = x + " x " + y + " = ?";
                    cbQ4A3.Text = answer4.ToString();
                    cbQ4A4.Text = randAns1.ToString();
                    cbQ4A1.Text = randAns2.ToString();
                    cbQ4A2.Text = randAns3.ToString();
                    cbQ4A5.Text = randAns4.ToString();
                    //QUESTION 5
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 35);
                    answer5 = x * y;
                    randAns1 = x - (y - 2);
                    randAns2 = (x * 2) - (randAns1 * 2);
                    randAns3 = rand.Next(20, 180);
                    randAns4 = y - (x / 3);
                    lblQuestion5.Text = x + " x " + y + " = ?";
                    cbQ5A2.Text = answer5.ToString();
                    cbQ5A5.Text = randAns1.ToString();
                    cbQ5A4.Text = randAns2.ToString();
                    cbQ5A1.Text = randAns3.ToString();
                    cbQ5A3.Text = randAns4.ToString();
                    //QUESTION 6
                    x = rand.Next(1, 40);
                    y = rand.Next(1, 18);
                    answer6 = x / y;
                    randAns1 = x - (y - 2);
                    randAns2 = (x * 2) - (randAns1 * 2);
                    randAns3 = rand.Next(20, 180);
                    randAns4 = y - (x / 3);
                    lblQuestion6.Text = x + " ÷ " + y + " = ?";
                    cbQ6A4.Text = answer6.ToString();
                    cbQ6A2.Text = randAns1.ToString();
                    cbQ6A1.Text = randAns2.ToString();
                    cbQ6A3.Text = randAns3.ToString();
                    cbQ6A5.Text = randAns4.ToString();
                    //QUESTION 7
                    x = rand.Next(1, 25);
                    y = rand.Next(1, 5);
                    answer7 = x / y;
                    randAns1 = x - (y - 2);
                    randAns2 = (x * 2) - (randAns1 * 2);
                    randAns3 = rand.Next(20, 180);
                    randAns4 = y - (x / 3);
                    lblQuestion7.Text = x + " ÷ " + y + " = ?";
                    cbQ7A1.Text = answer7.ToString();
                    cbQ7A5.Text = randAns1.ToString();
                    cbQ7A3.Text = randAns2.ToString();
                    cbQ7A4.Text = randAns3.ToString();
                    cbQ7A2.Text = randAns4.ToString();
                    break;
        //================================================================================
                case 9:
                    //QUESTION 1
                    x = rand.Next(1, 400);
                    y = rand.Next(1, 250);
                    answer1 = x - y;
                    randAns1 = y * 4;
                    randAns2 = rand.Next(50,250);
                    randAns3 = randAns1 - randAns2;
                    randAns4 = (y * 2) - (x * 3);
                    lblQuestion1.Text = x + " - " + y + " = ?";
                    cbQ1A3.Text = answer1.ToString();
                    cbQ1A1.Text = randAns1.ToString();
                    cbQ1A2.Text = randAns2.ToString();
                    cbQ1A4.Text = randAns3.ToString();
                    cbQ1A5.Text = randAns4.ToString();
                    //QUESTION 2
                    x = rand.Next(1, 200);
                    y = rand.Next(1, 80);
                    answer2 = x + y;
                    randAns1 = y * 4;
                    randAns2 = rand.Next(50,250);
                    randAns3 = randAns1 - randAns2;
                    randAns4 = (y * 2) - (x * 3);
                    lblQuestion2.Text = x + " + " + y + " = ?";
                    cbQ2A4.Text = answer2.ToString();
                    cbQ2A3.Text = randAns1.ToString();
                    cbQ2A1.Text = randAns2.ToString();
                    cbQ2A5.Text = randAns3.ToString();
                    cbQ2A2.Text = randAns4.ToString();
                    //QUESTION 3
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 40);
                    answer3 = x - y;
                    randAns1 = y * 4;
                    randAns2 = rand.Next(50,250);
                    randAns3 = randAns1 - randAns2;
                    randAns4 = (y * 2) - (x * 3);
                    lblQuestion3.Text = x + " - " + y + " = ?";
                    cbQ3A5.Text = answer3.ToString();
                    cbQ3A3.Text = randAns1.ToString();
                    cbQ3A2.Text = randAns2.ToString();
                    cbQ3A4.Text = randAns3.ToString();
                    cbQ3A1.Text = randAns4.ToString();
                    //QUESTION 4
                    x = rand.Next(1, 50);
                    y = rand.Next(1, 15);
                    answer4 = x * y;
                    randAns1 = y * 4;
                    randAns2 = rand.Next(50,250);
                    randAns3 = randAns1 - randAns2;
                    randAns4 = (y * 2) - (x * 3);
                    lblQuestion4.Text = x + " x " + y + " = ?";
                    cbQ4A2.Text = answer4.ToString();
                    cbQ4A4.Text = randAns1.ToString();
                    cbQ4A1.Text = randAns2.ToString();
                    cbQ4A3.Text = randAns3.ToString();
                    cbQ4A5.Text = randAns4.ToString();
                    //QUESTION 5
                    x = rand.Next(1, 200);
                    y = rand.Next(1, 35);
                    answer5 = x / y;
                    randAns1 = y * 4;
                    randAns2 = rand.Next(50,250);
                    randAns3 = randAns1 - randAns2;
                    randAns4 = (y * 2) - (x * 3);
                    lblQuestion5.Text = x + " ÷ " + y + " = ?";
                    cbQ5A3.Text = answer5.ToString();
                    cbQ5A5.Text = randAns1.ToString();
                    cbQ5A4.Text = randAns2.ToString();
                    cbQ5A1.Text = randAns3.ToString();
                    cbQ5A2.Text = randAns4.ToString();
                    //QUESTION 6
                    x = rand.Next(1, 60);
                    y = rand.Next(1, 18);
                    answer6 = x * y;
                    randAns1 = y * 4;
                    randAns2 = rand.Next(50,250);
                    randAns3 = randAns1 - randAns2;
                    randAns4 = (y * 2) - (x * 3);
                    lblQuestion6.Text = x + " x " + y + " = ?";
                    cbQ6A1.Text = answer6.ToString();
                    cbQ6A2.Text = randAns1.ToString();
                    cbQ6A4.Text = randAns2.ToString();
                    cbQ6A3.Text = randAns3.ToString();
                    cbQ6A5.Text = randAns4.ToString();
                    //QUESTION 7
                    x = rand.Next(1, 250);
                    y = rand.Next(1, 25);
                    answer7 = x / y;
                    randAns1 = y * 4;
                    randAns2 = rand.Next(50,250);
                    randAns3 = randAns1 - randAns2;
                    randAns4 = (y * 2) - (x * 3);
                    lblQuestion7.Text = x + " ÷ " + y + " = ?";
                    cbQ7A2.Text = answer7.ToString();
                    cbQ7A5.Text = randAns1.ToString();
                    cbQ7A3.Text = randAns2.ToString();
                    cbQ7A4.Text = randAns3.ToString();
                    cbQ7A1.Text = randAns4.ToString();
                    break;
        //====================================================================================
                case 10:
                    //QUESTION 1
                    x = rand.Next(1, 1000);
                    y = rand.Next(1, 400);
                    answer1 = x - y;
                    randAns1 = (2 * x) - y;
                    randAns2 = (y * 4) - (x + y);
                    randAns3 = rand.Next(1, 150);
                    randAns4 = (4 * x) - randAns3;
                    lblQuestion1.Text = x + " - " + y + " = ?";
                    cbQ1A3.Text = randAns1.ToString();
                    cbQ1A2.Text = answer1.ToString();
                    cbQ1A1.Text = randAns2.ToString();
                    cbQ1A4.Text = randAns3.ToString();
                    cbQ1A5.Text = randAns4.ToString();
                    //QUESTION 2
                    x = rand.Next(1, 60);
                    y = rand.Next(1, 90);
                    answer2 = x + y;
                    randAns1 = (2 * x) - y;
                    randAns2 = (y * 4) - (x + y);
                    randAns3 = rand.Next(1, 150);
                    randAns4 = (4 * x) - randAns3;
                    lblQuestion2.Text = x + " + " + y + " = ?";
                    cbQ2A1.Text = randAns1.ToString();
                    cbQ2A3.Text = answer2.ToString();
                    cbQ2A2.Text = randAns2.ToString();
                    cbQ2A4.Text = randAns3.ToString();
                    cbQ2A5.Text = randAns4.ToString();
                    //QUESTION 3
                    x = rand.Next(1, 100);
                    y = rand.Next(1, 100);
                    answer3 = x + y;
                    randAns1 = (2 * x) - y;
                    randAns2 = (y * 4) - (x + y);
                    randAns3 = rand.Next(1, 150);
                    randAns4 = (4 * x) - randAns3;
                    lblQuestion3.Text = x + " + " + y + " = ?";
                    cbQ3A2.Text = randAns1.ToString();
                    cbQ3A1.Text = answer3.ToString();
                    cbQ3A3.Text = randAns2.ToString();
                    cbQ3A4.Text = randAns3.ToString();
                    cbQ3A5.Text = randAns4.ToString();
                    //QUESTION 4
                    x = rand.Next(1, 300);
                    y = rand.Next(1, 30);
                    answer4 = x / y;
                    randAns1 = (2 * x) - y;
                    randAns2 = (y * 4) - (x + y);
                    randAns3 = rand.Next(1, 150);
                    randAns4 = (4 * x) - randAns3;
                    lblQuestion4.Text = x + " ÷ " + y + " = ?";
                    cbQ4A5.Text = randAns1.ToString();
                    cbQ4A4.Text = answer4.ToString();
                    cbQ4A1.Text = randAns2.ToString();
                    cbQ4A2.Text = randAns3.ToString();
                    cbQ4A3.Text = randAns4.ToString();
                    //QUESTION 5
                    x = rand.Next(1, 50);
                    y = rand.Next(1, 25);
                    answer5 = x * y;
                    randAns1 = (2 * x) - y;
                    randAns2 = (y * 4) - (x + y);
                    randAns3 = rand.Next(1, 150);
                    randAns4 = (4 * x) - randAns3;
                    lblQuestion5.Text = x + " x " + y + " = ?";
                    cbQ5A5.Text = randAns1.ToString();
                    cbQ5A2.Text = answer5.ToString();
                    cbQ5A3.Text = randAns2.ToString();
                    cbQ5A4.Text = randAns3.ToString();
                    cbQ5A1.Text = randAns4.ToString();
                    //QUESTION 6
                    x = rand.Next(1, 1000);
                    y = rand.Next(1, 600);
                    answer6 = x - y;
                    randAns1 = (2 * x) - y;
                    randAns2 = (y * 4) - (x + y);
                    randAns3 = rand.Next(1, 150);
                    randAns4 = (4 * x) - randAns3;
                    lblQuestion6.Text = x + " - " + y + " = ?";
                    cbQ6A2.Text = randAns1.ToString();
                    cbQ6A5.Text = answer6.ToString();
                    cbQ6A3.Text = randAns2.ToString();
                    cbQ6A4.Text = randAns3.ToString();
                    cbQ6A1.Text = randAns4.ToString();
                    //QUESTION 7
                    x = rand.Next(1, 1000);
                    y = rand.Next(1, 60);
                    answer7 = x / y;
                    randAns1 = (2 * x) - y;
                    randAns2 = (y * 4) - (x + y);
                    randAns3 = rand.Next(1, 150);
                    randAns4 = (4 * x) - randAns3;
                    lblQuestion7.Text = x + " ÷ " + y + " = ?";
                    cbQ7A4.Text = randAns1.ToString();
                    cbQ7A3.Text = answer7.ToString();
                    cbQ7A5.Text = randAns2.ToString();
                    cbQ7A2.Text = randAns3.ToString();
                    cbQ7A1.Text = randAns4.ToString();
                    break;
            //================================================================================
                case 11:
                    //QUESTION 1
                    x = rand.Next(1, 60);
                    y = rand.Next(1, 60);
                    answer1 = x + y;
                    randAns1 = (y * 3) - (x - 14);
                    randAns2 = (x + 19) + (y + 20);
                    randAns3 = rand.Next(1, 200);
                    randAns4 = (x / 4) + (randAns3 - y);
                    lblQuestion1.Text = x + " + " + y + " = ?";
                    cbQ1A3.Text = randAns1.ToString();
                    cbQ1A1.Text = answer1.ToString();
                    cbQ1A2.Text = randAns2.ToString();
                    cbQ1A4.Text = randAns3.ToString();
                    cbQ1A5.Text = randAns4.ToString();
                    //QUESTION 2
                    x = rand.Next(1, 160);
                    y = rand.Next(1, 90);
                    answer2 = x - y;
                    randAns1 = (y * 3) - (x - 14);
                    randAns2 = (x + 19) + (y + 20);
                    randAns3 = rand.Next(1, 200);
                    randAns4 = (x / 4) + (randAns3 - y);
                    lblQuestion2.Text = x + " - " + y + " = ?";
                    cbQ2A1.Text = randAns1.ToString();
                    cbQ2A3.Text = answer2.ToString();
                    cbQ2A2.Text = randAns2.ToString();
                    cbQ2A4.Text = randAns3.ToString();
                    cbQ2A5.Text = randAns4.ToString();
                    //QUESTION 3
                    x = rand.Next(1, 400);
                    y = rand.Next(1, 300);
                    answer3 = x + y;
                    randAns1 = (y * 3) - (x - 14);
                    randAns2 = (x + 19) + (y + 20);
                    randAns3 = rand.Next(1, 200);
                    randAns4 = (x / 4) + (randAns3 - y);
                    lblQuestion3.Text = x + " + " + y + " = ?";
                    cbQ3A1.Text = randAns1.ToString();
                    cbQ3A4.Text = answer3.ToString();
                    cbQ3A3.Text = randAns2.ToString();
                    cbQ3A2.Text = randAns3.ToString();
                    cbQ3A5.Text = randAns4.ToString();
                    //QUESTION 4
                    x = rand.Next(1, 50);
                    y = rand.Next(1, 30);
                    answer4 = x * y;
                    randAns1 = (y * 3) - (x - 14);
                    randAns2 = (x + 19) + (y + 20);
                    randAns3 = rand.Next(1, 200);
                    randAns4 = (x / 4) + (randAns3 - y);
                    lblQuestion4.Text = x + " x " + y + " = ?";
                    cbQ4A4.Text = randAns1.ToString();
                    cbQ4A2.Text = answer4.ToString();
                    cbQ4A1.Text = randAns2.ToString();
                    cbQ4A5.Text = randAns3.ToString();
                    cbQ4A3.Text = randAns4.ToString();
                    //QUESTION 5
                    x = rand.Next(1, 40);
                    y = rand.Next(1, 15);
                    answer5 = x * y;
                    randAns1 = (y * 3) - (x - 14);
                    randAns2 = (x + 19) + (y + 20);
                    randAns3 = rand.Next(1, 200);
                    randAns4 = (x / 4) + (randAns3 - y);
                    lblQuestion5.Text = x + " x " + y + " = ?";
                    cbQ5A2.Text = randAns1.ToString();
                    cbQ5A4.Text = answer5.ToString();
                    cbQ5A3.Text = randAns2.ToString();
                    cbQ5A5.Text = randAns3.ToString();
                    cbQ5A1.Text = randAns4.ToString();
                    //QUESTION 6
                    x = rand.Next(1, 1000);
                    y = rand.Next(1, 600);
                    answer6 = x / y;
                    randAns1 = (y * 3) - (x - 14);
                    randAns2 = (x + 19) + (y + 20);
                    randAns3 = rand.Next(1, 200);
                    randAns4 = (x / 4) + (randAns3 - y);
                    lblQuestion6.Text = x + " ÷ " + y + " = ?";
                    cbQ6A2.Text = randAns1.ToString();
                    cbQ6A5.Text = answer6.ToString();
                    cbQ6A3.Text = randAns2.ToString();
                    cbQ6A4.Text = randAns3.ToString();
                    cbQ6A1.Text = randAns4.ToString();
                    //QUESTION 7
                    x = rand.Next(1, 1000);
                    y = rand.Next(1, 90);
                    answer7 = x / y;
                    randAns1 = (y * 3) - (x - 14);
                    randAns2 = (x + 19) + (y + 20);
                    randAns3 = rand.Next(1, 200);
                    randAns4 = (x / 4) + (randAns3 - y);
                    lblQuestion7.Text = x + " ÷ " + y + " = ?";
                    cbQ7A3.Text = randAns1.ToString();
                    cbQ7A2.Text = answer7.ToString();
                    cbQ7A5.Text = randAns2.ToString();
                    cbQ7A4.Text = randAns3.ToString();
                    cbQ7A1.Text = randAns4.ToString();
                    break;
            }



        }
        //Timer to control events and objects
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ticker == 1) ticker++;
            else if (ticker == 2) ticker--;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ticker == 1)
                lblMessage.Text = "*If you do not see an exact answer - Round up or down accordingly!!";
            else if (ticker == 2)
                lblMessage.Text = "*Selecting more than one answer will register as incorrect!!";
        }
        private void AnswerControl()
        {
            //QUESTION 1 ANSWERS
            //if (cbQ1A1.Checked == true)
            //{
            //    //if (cbQ1A1.Checked == true)
            //    //    cbQ1A1.Checked = false;
            //    if (cbQ1A2.Checked == true)
            //        cbQ1A2.Checked = false;
            //    if (cbQ1A3.Checked == true)
            //        cbQ1A3.Checked = false;
            //    if (cbQ1A4.Checked == true)
            //        cbQ1A4.Checked = false;
            //    if (cbQ1A5.Checked == true)
            //        cbQ1A5.Checked = false;
            //}
            //else if (cbQ1A2.Checked == true)
            //{
            //    if (cbQ1A1.Checked == true)
            //        cbQ1A1.Checked = false;
            //    //if (cbQ1A2.Checked == true)
            //    //    cbQ1A2.Checked = false;
            //    if (cbQ1A3.Checked == true)
            //        cbQ1A3.Checked = false;
            //    if (cbQ1A4.Checked == true)
            //        cbQ1A4.Checked = false;
            //    if (cbQ1A5.Checked == true)
            //        cbQ1A5.Checked = false;
            //}
            //else if (cbQ1A3.Checked == true)
            //{
            //    if (cbQ1A1.Checked == true)
            //        cbQ1A1.Checked = false;
            //    if (cbQ1A2.Checked == true)
            //        cbQ1A2.Checked = false;
            //    //if (cbQ1A3.Checked == true)
            //    //    cbQ1A3.Checked = false;
            //    if (cbQ1A4.Checked == true)
            //        cbQ1A4.Checked = false;
            //    if (cbQ1A5.Checked == true)
            //        cbQ1A5.Checked = false;
            //}
            //else if (cbQ1A4.Checked == true)
            //{
            //    if (cbQ1A1.Checked == true)
            //        cbQ1A1.Checked = false;
            //    if (cbQ1A2.Checked == true)
            //        cbQ1A2.Checked = false;
            //    if (cbQ1A3.Checked == true)
            //        cbQ1A3.Checked = false;
            //    //if (cbQ1A4.Checked == true)
            //    //    cbQ1A4.Checked = false;
            //    if (cbQ1A5.Checked == true)
            //        cbQ1A5.Checked = false;
            //}
            //else if (cbQ1A5.Checked == true)
            //{
            //    if (cbQ1A1.Checked == true)
            //        cbQ1A1.Checked = false;
            //    if (cbQ1A2.Checked == true)
            //        cbQ1A2.Checked = false;
            //    if (cbQ1A3.Checked == true)
            //        cbQ1A3.Checked = false;
            //    if (cbQ1A4.Checked == true)
            //        cbQ1A4.Checked = false;
            //    //if (cbQ1A5.Checked == true)
            //    //    cbQ1A5.Checked = false;
        }
        //Check Score from Quiz
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Score();
            btnRetry.Enabled = true;
            btnRetry.Visible = true;
            btnSubmit.Visible = false;
            btnSubmit.Enabled = false;
        }
        //Retry Quiz
        private void btnRetry_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int x = 0;
            if (x <= 5) pbFrameImage.Image = Image.FromFile(frameImage[0]);
            if (x > 5) pbFrameImage.Image = Image.FromFile(frameImage[1]);
            x++;
        }

        

        

        

        

        
    }


}

