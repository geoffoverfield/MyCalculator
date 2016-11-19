/***************************
 *      Geoff Overfield    *
 *        June 7, 2016     *
 *  Scientific Calculator  *
 **************************/

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
using System.Media;

/*TO DO LIST:
 *  Debug Keyboard Input
 *  Figure out || Remove parenthesis 
 *  Figure out || Remove rad/deg      
 *  Tutorials                           */

namespace Calculator
{
    
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            //==================DELETE THESE AFTER TRIG FUNCTIONS ENCORPORATED===========
            btnRad.Enabled = false;
            btnDeg.Enabled = false;
            //==================DELETE THESE AFTER ( ) FUNCTIONS ENCORPORATED============
            btnLParen.Enabled = false;
            btnRParen.Enabled = false;

            location = Directory.GetCurrentDirectory().ToString() + "/";
            imageLocation = location + "Theme_Images/";
            soundLocation = location + "Theme_Sounds/";
            MLBSound = soundLocation + "MLB_Sounds/";
            MMASound = soundLocation + "MMA_Sounds/";
            NBASound = soundLocation + "NBA_Sounds/";
            NFLSound = soundLocation + "NFL_Sounds/";
            ShowSound = soundLocation + "TVShows_Sounds/";
            gameSound = soundLocation + "VideoGame_Sounds/";
            MilitarySound = soundLocation + "Military_Sounds/";

            LoadImage();
        }


        const double pi = 3.141592653589793;
        const double e = 2.718281828459045;
        MyMath math = new MyMath();                             //Initalize Math class created by myself
        string display = "";                                    //to be displayed to label
        double op1 = 0, op2 = 0;                                //left and right opperands
        double mr = 0, mr2 = 0;                                 //stored memory variables for user
        double result;                                          //result of arithmetic
        int opr;                                                //operator
        bool SecondClicked = false;                             //Controls the 2nd button
        bool themeShrink = false;                               //Shrink and rearrange buttons for themes
        bool decimalClicked = false;                            //To ensure users cannot continually add decimals
        bool invertClick = false;                               //for inverted colors
        bool forward = true;                                    //for Knight Rider theme
        bool knightRiderOn = false;                             //for Knight Rider theme
        bool soundOn = true;                                    //Turn sound on and off
        string location, imageLocation, soundLocation;          //To locate files for themes
        string MilitarySound, MMASound, NBASound;               //specify file of images & sounds
        string MLBSound, NHLSound, NFLSound;                    //specify file of sounds
        string MovieSound, ShowSound, gameSound;                //specify file of sounds
        string myImage, mySound;                                //Specific file to select
        
        
        Image[] myThemeImage = new Bitmap[225];                 //Image Array to store backgrounds upon loading rather than pull individually as needed
        //Tutorial Windows
        Teach_Me___Arithmetic windowArithmetic = new Teach_Me___Arithmetic();
        Teach_Me___Algebra windowAlgebra = new Teach_Me___Algebra();
        Teach_Me___Exponents windowExponents = new Teach_Me___Exponents();
        Teach_Me___Logarithms windowLogarithms = new Teach_Me___Logarithms();
        Teach_Me___Trigonometry windowTrig = new Teach_Me___Trigonometry();
            
        //Load Compressed Images
        private void LoadImage()
        {
            pbLogo.Image = Image.FromFile(location + "BOSSGames.png");
            for (int i = 0; i < 225; i++)
                myThemeImage[i] = Image.FromFile(imageLocation + i + ".jpg");
        }
        //Dispose of Images
        private void DisposeImages()
        {
            for (int i = 0; i < 225; i++)
                myThemeImage[i].Dispose();
        }
        //Load Sound Clips
        private void LoadSound()
        {

        }
        //Dispose of Sound Clips
        private void DisposeSound()
        {

        }
        //Allows users to continue using numbers in display for equations
        private void Concatonate()
        {
            if (result != 0)
            {
                op1 = result;
            }
            try
            {
                op2 = Convert.ToDouble(display);
            }
            catch
            {
                op2 = 0.0;
                display = "";
                MessageBox.Show("Fatal Error Occurred.  Goodbye!");
                Application.Exit();
            }
            
            result = 0.0;
        }
        //For displaying numbers in window
        private void Display(long n)                                           
        {
            display = display + n.ToString();
        }
        //Refreshes display every 10milSec
        private void timer1_Tick(object sender, EventArgs ev)
        {
            //lblDisplay.Text = "*Pre-Alpha   Version  2.7.2";
            
            lblDisplay.Text = display;
            if (display == "")
                btnClear.Text = "AC";
            else btnClear.Text = "C";
            Second();
            //Button Size
            if (themeShrink)
                ShrinkDisplay();
            else
                DefaultDisplay();
            //Knight Rider scrolling label
            if (!knightRiderOn)
                StopKnight();

            if (windowArithmetic.IsDisposed || windowAlgebra.IsDisposed || windowExponents.IsDisposed 
                || windowLogarithms.IsDisposed || windowTrig.IsDisposed)
                this.Show();
        }
        //Starts and Stops the Knight Rider scrolling label
        private void StartKnight()
        {
            lblKR1.Left = 150;
            lblKR1.Visible = true;
            tmrKnightRider.Enabled = true;
            tmrKnightRider.Start();
        }
        private void StopKnight()
        {
            lblKR1.Visible = false;
            tmrKnightRider.Stop();
            tmrKnightRider.Enabled = false;
        }
        //Cursor Controls
        private void btnEquals_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.PanNorth;
        }
        private void btnEquals_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
        //Button 0
        private void btn0_Click(object sender, EventArgs e)
        {
            Display(0);
        }
        //Button 1
        private void btn1_Click(object sender, EventArgs e)
        {
            Display(1);
        }
        //Button 2
        private void btn2_Click(object sender, EventArgs e)
        {
            Display(2);
        }
        //Button 3
        private void btn3_Click(object sender, EventArgs e)
        {
            Display(3);
        }
        //Button 4
        private void btn4_Click(object sender, EventArgs e)
        {
            Display(4);
        }
        //Button 5
        private void btn5_Click(object sender, EventArgs e)
        {
            Display(5);
        }
        //Button 6
        private void btn6_Click(object sender, EventArgs e)
        {
            Display(6);
        }
        //Button 7
        private void btn7_Click(object sender, EventArgs e)
        {
            Display(7);
        }
        //Button 8
        private void btn8_Click(object sender, EventArgs e)
        {
            Display(8);
        }
        //Button 9
        private void btn9_Click(object sender, EventArgs e)
        {
            Display(9);
        }
        //Decimal Point
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!decimalClicked)
            {
                display = display + ".";
                lblDisplay.Text = display;
            }
            decimalClicked = true;
        }
        //Keyboard Input
        private void KeyboardInput(object sender, KeyEventArgs ev)
        {
            //===========0===========
            if (ev.KeyValue == 48)
                Display(0);
            else if (ev.KeyValue == 96)
                Display(0);
            else if (ev.KeyCode == Keys.D0)
                Display(0);
            else if (ev.KeyCode == Keys.NumPad0)
                Display(0);
            //===========1===========
            if (ev.KeyValue == 49)
                Display(1);
            else if (ev.KeyValue == 97)
                Display(1);
            else if (ev.KeyCode == Keys.D1)
                Display(1);
            else if (ev.KeyCode == Keys.NumPad1)
                Display(1);
            //===========2===========
            if (ev.KeyValue == 50)
                Display(2);
            else if (ev.KeyValue == 98)
                Display(2);
            else if (ev.KeyCode == Keys.D2)
                Display(2);
            else if (ev.KeyCode == Keys.NumPad2)
                Display(2);
            //===========3===========
            if (ev.KeyValue == 51)
                Display(3);
            else if (ev.KeyValue == 99)
                Display(3);
            else if (ev.KeyCode == Keys.D3)
                Display(3);
            else if (ev.KeyCode == Keys.NumPad3)
                Display(3);
            //===========4===========
            if (ev.KeyValue == 52)
                Display(4);
            else if (ev.KeyValue == 100)
                Display(4);
            else if (ev.KeyCode == Keys.D4)
                Display(4);
            else if (ev.KeyCode == Keys.NumPad4)
                Display(4);
            //===========5===========
            if (ev.KeyValue == 53)
                Display(5);
            else if (ev.KeyValue == 101)
                Display(5);
            else if (ev.KeyCode == Keys.D5)
                Display(5);
            else if (ev.KeyCode == Keys.NumPad5)
                Display(5);
            //===========6===========
            if (ev.KeyValue == 54)
                Display(6);
            else if (ev.KeyValue == 102)
                Display(6);
            else if (ev.KeyCode == Keys.D6)
                Display(6);
            else if (ev.KeyCode == Keys.NumPad6)
                Display(6);
            //===========7===========
            if (ev.KeyValue == 55)
                Display(7);
            else if (ev.KeyValue == 103)
                Display(7);
            else if (ev.KeyCode == Keys.D7)
                Display(7);
            else if (ev.KeyCode == Keys.NumPad7)
                Display(7);
            //===========8=========
            if (ev.KeyValue == 56)
                Display(8);
            else if (ev.KeyValue == 104)
                Display(8);
            else if (ev.KeyCode == Keys.D8)
                Display(8);
            else if (ev.KeyCode == Keys.NumPad8)
                Display(8);
            //===========9=========
            if (ev.KeyValue == 57)
                Display(9);
            else if (ev.KeyValue == 105)
                Display(9);
            else if (ev.KeyCode == Keys.D9)
                Display(9);
            else if (ev.KeyCode == Keys.NumPad9)
                Display(9);
            //=========Add()=======
            if (ev.KeyCode == Keys.Oemplus)
            {
                opr = 1;
                op1 = Convert.ToDouble(display);
                display = "";
                decimalClicked = false;
            }
            else if (ev.KeyCode == Keys.Add)
            {
                opr = 1;
                op1 = Convert.ToDouble(display);
                display = "";
                decimalClicked = false;
            }
            else if (ev.KeyValue == 107)
            {
                opr = 1;
                op1 = Convert.ToDouble(display);
                display = "";
                decimalClicked = false;
            }
            else if ((ev.KeyValue == 16) && (ev.KeyValue == 187))
            {
                opr = 1;
                op1 = Convert.ToDouble(display);
                display = "";
                decimalClicked = false;
            }
            //======Subtract()=======
            if (ev.KeyCode == Keys.OemMinus)
            {
                opr = 2;
                op1 = Convert.ToDouble(display);
                display = "";
                decimalClicked = false;
            }
            else if (ev.KeyCode == Keys.Subtract)
            {
                opr = 2;
                op1 = Convert.ToDouble(display);
                display = "";
                decimalClicked = false;
            }
            else if (ev.KeyValue == 109)
            {
                opr = 2;
                op1 = Convert.ToDouble(display);
                display = "";
                decimalClicked = false;
            }
            else if (ev.KeyValue == 189)
            {
                opr = 2;
                op1 = Convert.ToDouble(display);
                display = "";
                decimalClicked = false;
            }
            //======Multiply()=======
            if (ev.KeyCode == Keys.Multiply)
            {
                opr = 3;
                op1 = Convert.ToDouble(display);
                display = "";
                decimalClicked = false;
            }
            else if ((ev.KeyCode == Keys.Shift) && (ev.KeyCode == Keys.D8))
            {
                opr = 3;
                op1 = Convert.ToDouble(display);
                display = "";
                decimalClicked = false;
            }
            else if ((ev.KeyValue == 16) && (ev.KeyValue == 56))
            {
                opr = 3;
                op1 = Convert.ToDouble(display);
                display = "";
                decimalClicked = false;
            }
            //======Divide()=======
            if (ev.KeyValue == 191)
            {
                opr = 4;
                op1 = Convert.ToDouble(display);
                display = "";
                decimalClicked = false;
            }
            else if (ev.KeyValue == 111)
            {
                opr = 4;
                op1 = Convert.ToDouble(display);
                display = "";
                decimalClicked = false;
            }
            else if (ev.KeyCode == Keys.Divide)
            {
                opr = 4;
                op1 = Convert.ToDouble(display);
                display = "";
                decimalClicked = false;
            }
            //===========^===========
            //=Will be used for x^y()
            if ((ev.KeyValue == 16) && (ev.KeyValue == 54))
            {
                opr = 5;
                op1 = Convert.ToDouble(display);
                display = "";
            }
            else if ((ev.KeyCode == Keys.Shift) && (ev.KeyCode == Keys.D6))
            {
                opr = 5;
                op1 = Convert.ToDouble(display);
                display = "";
            }
            //===========%===========
            if ((ev.KeyValue == 16) && (ev.KeyValue == 53))
            {
                op1 = Convert.ToDouble(display);
                op1 = math.Percentage(op1);
                display = op1.ToString();
            }
            //====Decimal Point====
            if (ev.KeyCode == Keys.OemPeriod)
            {
                if (!decimalClicked)
                {
                    display = display + ".";
                    lblDisplay.Text = display;
                }
                decimalClicked = true;
            }
            else if (ev.KeyCode == Keys.Decimal)
            {
                if (!decimalClicked)
                {
                    display = display + ".";
                    lblDisplay.Text = display;
                }
                decimalClicked = true;
            }
            else if (ev.KeyValue == 190)
            {
                if (!decimalClicked)
                {
                    display = display + ".";
                    lblDisplay.Text = display;
                }
                decimalClicked = true;
            }
            else if (ev.KeyValue == 110)
            {
                if (!decimalClicked)
                {
                    display = display + ".";
                    lblDisplay.Text = display;
                }
                decimalClicked = true;
            }
            //========Enter========
            if (ev.KeyValue == 13)
                Solve();
            else if (ev.KeyCode == Keys.Return)
                Solve();
            //========Quit=========
            if (ev.KeyCode == Keys.Escape)
            {
                DisposeImages();
                DisposeSound();
                Application.Exit();
            }
            else if (ev.KeyValue == 27)
            {
                DisposeImages();
                DisposeSound();
                Application.Exit();
            }
            else if (ev.KeyValue == 81)
            {
                DisposeImages();
                DisposeSound();
                Application.Exit();
            }
            else if (ev.KeyCode == Keys.Q)
            {
                DisposeImages();
                DisposeSound();
                Application.Exit();
            }
            //========Clear========
            if (ev.KeyCode == Keys.C)
            {
                if (display == "")
                {
                    op1 = 0.0;
                    op2 = 0.0;
                    result = 0.0;
                }
                else if (display != "")
                {
                    display = "";
                }
                display = "";
                decimalClicked = false;
            }
            else if (ev.KeyValue == 67)
            {
                if (display == "")
                {
                    op1 = 0.0;
                    op2 = 0.0;
                    result = 0.0;
                }
                else if (display != "")
                {
                    display = "";
                }
                display = "";
                decimalClicked = false;
            }
            else if (ev.KeyValue == 8)
            {
                if (display == "")
                {
                    op1 = 0.0;
                    op2 = 0.0;
                    result = 0.0;
                }
                else if (display != "")
                {
                    display = "";
                }
                display = "";
                decimalClicked = false;
            }
            else if (ev.KeyCode == Keys.Back)
            {
                if (display == "")
                {
                    op1 = 0.0;
                    op2 = 0.0;
                    result = 0.0;
                }
                else if (display != "")
                {
                    display = "";
                }
                display = "";
                decimalClicked = false;
            }
            else if (ev.KeyCode == Keys.Delete)
            {
                if (display == "")
                {
                    op1 = 0.0;
                    op2 = 0.0;
                    result = 0.0;
                }
                else if (display != "")
                {
                    display = "";
                }
                display = "";
                decimalClicked = false;
            }
            else if (ev.KeyValue == 46)
            {
                if (display == "")
                {
                    op1 = 0.0;
                    op2 = 0.0;
                    result = 0.0;
                }
                else if (display != "")
                {
                    display = "";
                }
                display = "";
                decimalClicked = false;
            }
        }
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            //KeyboardInput(sender, e);
        }

        //====================BUTTONS FOR BASIC MATHEMATIC FUNCTIONS=====================
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (display == "")
            {
                op1 = 0.0;
                op2 = 0.0;
                result = 0.0;
            }
            else if (display != "")
            {
                display = "";
            }
            display = "";
            decimalClicked = false;
        }
        //Add Button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            opr = 1;
            if (op1 != null)
                op1 = op1 + Convert.ToDouble(display);
            else
                op1 = Convert.ToDouble(display);
            display = "";
            decimalClicked = false;
        }
        //Subtract Button
        private void btnSubtract_Click(object sender, EventArgs e)
        {
            opr = 2;
            op1 = Convert.ToDouble(display);
            display = "";
            decimalClicked = false;
        }
        //Multiply Button
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            opr = 3;
            op1 = Convert.ToDouble(display);
            display = "";
            decimalClicked = false;
        }
        //Divide Button
        private void btnDivide_Click(object sender, EventArgs e)
        {
            opr = 4;
            op1 = Convert.ToDouble(display);
            display = "";
            decimalClicked = false;
        }
        //Percentage Button
        private void btnPercentage_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            op1 = math.Percentage(op1);
            display = op1.ToString();
        }
        //Positive/Negative Button
        private void btnPosNeg_Click(object sender, EventArgs e)
        {
            if (display != null)
            {
                op1 = Convert.ToDouble(display);
                op1 = math.PosNeg(op1);
                display = op1.ToString();
            }
        }
        
        //==============BUTTONS FOR SCIENTIFIC MATHEMATIC FUNCTIONS======================
        //Add to Memory Button
        private void btnMem_Click(object sender, EventArgs e)
        {
            mr = Convert.ToDouble(lblDisplay.Text);
            display = "";
            decimalClicked = false;
        }
        //Clear Memory Button
        private void btnMemClr_Click(object sender, EventArgs e)
        {
            mr = 0.0;
            mr2 = 0.0;
        }
        //m- Button
        //Subtracts stored memory value from number displayed
        private void btnSubMem_Click(object sender, EventArgs e)
        {
            if (SecondClicked)
            {
                double temp = Convert.ToDouble(display);
                temp = temp - mr2;
                display = temp.ToString();
                temp = 0.0;
            }
            else
            {
                double temp = Convert.ToDouble(display);
                temp = temp - mr;
                display = temp.ToString();
                temp = 0.0;
            }
        }
        //m+ Button
        //Adds stored memory value from number displayed 
        private void btnAddMem_Click(object sender, EventArgs e)
        {
            if (SecondClicked)
            {
                double temp = Convert.ToDouble(display);
                temp = temp + mr2;
                display = temp.ToString();
                temp = 0.0;
            }
            else
            {
                double temp = Convert.ToDouble(display);
                temp = temp + mr;
                display = temp.ToString();
                temp = 0.0;
            }
        }
        //2nd Button - Enables extra functions
        private void Second()
        {
            if (SecondClicked)
            {
                btnMem2.Visible = true;
                btnMem2.Enabled = true;
                btnLogX.Visible = true;
                btnLogX.Enabled = true;
                btnLog2.Visible = true;
                btnLog2.Enabled = true;
                btnLog3.Visible = true;
                btnLog3.Enabled = true;
                btnDeg.Visible = true;
                btnDeg.Enabled = true;
                btnRad.Enabled = false;
                btnSin.Text = "sin\n^-1";
                btnCos.Text = "cos\n^-1";
                btnTan.Text = "tan\n^-1";
                btnSinH.Text = "sinh\n^-1";
                btnCosH.Text = "cosh\n^-1";
                btnTanH.Text = "tanh\n^-1";
            }
            if (!SecondClicked)
            {
                btnMem2.Visible = false;
                btnMem2.Enabled = false;
                btnLogX.Visible = false;
                btnLogX.Enabled = false;
                btnLog2.Visible = false;
                btnLog2.Enabled = false;
                btnLog3.Visible = false;
                btnLog3.Enabled = false;
                btnDeg.Visible = false;
                btnDeg.Enabled = false;
                btnRad.Enabled = true;
                btnSin.Text = "sin";
                btnCos.Text = "cos";
                btnTan.Text = "tan";
                btnSinH.Text = "sinh";
                btnCosH.Text = "cosh";
                btnTanH.Text = "tanh";
            }
        }
        private void btn2nd_Click(object sender, EventArgs e)
        {
            if (!SecondClicked)
            {
                SecondClicked = true;
            }
            else if (SecondClicked)
            {
                SecondClicked = false;
            }
        }
        //Pi Button
        private void btnPi_Click(object sender, EventArgs e)
        {
            if (op1 == null)
            {
                op1 = Convert.ToDouble(display);
                display = "";
                display = pi.ToString();
            }
            else
            {
                op1 = pi;
                display = pi.ToString();
            }
        }
        //e Button
        private void btnE_Click(object sender, EventArgs eventArg)
        {
            if (op1 == null)
            {
                op1 = Convert.ToDouble(display);
                display = "";
                display = e.ToString();
            }
            else
            {
                op1 = e;
                display = e.ToString();
            }
        }
        //Rand Button - generates random number
        private void btnRand_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            double newRand = rand.Next(0, 100);
            display = newRand.ToString();
        }
        //EE Button
        private void btnEE_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            display = "";
            display = math.EE(op1).ToString();
        }
        //1/x (Fraction) Button
        private void btnFraction_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            op1 = math.Fraction(op1);
            display = op1.ToString();
        }
        //!x (Factorial) Button
        private void btnFactorial_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            int temp = Convert.ToInt16(op1);
            temp = math.Factorial(temp);
            op1 = Convert.ToDouble(temp);
            display = op1.ToString();
        }
    
        //==========================EXPONENTIAL FUNCTIONS================================
        //x^2 Button
        private void btnSquared_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            op1 = math.squared(op1);
            display = op1.ToString();
        }
        //x^3 Button
        private void btnCubed_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            op1 = math.cubed(op1);
            display = op1.ToString();
        }
        //e^x Button
        private void btnEToTheX_Click(object sender, EventArgs eventArg)
        {
            op1 = Convert.ToDouble(display);
            op1 = math.pow(e, op1);
            display = op1.ToString();
        }
        //10^x Button
        private void btn10ToTheX_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            op1 = math.pow(10, op1);
            display = op1.ToString();
        }
        //x^y Button
        private void btnXToTheY_Click(object sender, EventArgs e)
        {
            opr = 5;
            op1 = Convert.ToDouble(display);
            display = "";
        }

        //==============================ROOT FUNCTIONS===================================
        //√2 Button
        private void btnSqrt_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            op1 = math.sqrt(op1);
            display = op1.ToString();
        }
        //√3 Button
        private void btnCubedRoot_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            op1 = math.cbdrt(op1);
            display = op1.ToString();
        }
        //y√x Button
        private void btnYRoot_Click(object sender, EventArgs e)
        {
            opr = 6;
            op1 = Convert.ToDouble(display);
            display = "";
        }

        //==============================LOGARITHMIC FUNCTIONS============================
        //log2 Button
        private void btnLog2_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            op1 = math.log2(op1);
            display = op1.ToString();
        }
        //Natural Logarithm Button (base e)
        private void btnNaturalLogarithm_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            op1 = math.naturalLog(op1);
            display = op1.ToString();
        }
        //log3 Button
        private void btnLog3_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            op1 = math.log3(op1);
            display = op1.ToString();
        }
        //log10 Button
        private void btnLog10_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            op1 = math.log10(op1);
            display = op1.ToString();
        }
        //logX Button
        private void btnLogX_Click(object sender, EventArgs e)
        {
            opr = 7;
            op1 = Convert.ToDouble(display);
            display = "";
        }

        //============================TRIGONOMETRY FUNCTIONS=============================
        //============ALL FUNCTIONS RETURN RADIANS BY DEFAULT - NOT DEGREES============== 
        //sin Button
        private void btnSin_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            if (!SecondClicked)
                opr = 8;
            else if (SecondClicked)
                opr = 14;
            Solve();
        }
        //cos Button
        private void buttonCos_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            if (!SecondClicked)
                opr = 9;
            else if (SecondClicked)
                opr = 15;
            Solve();
        }
        //tan Button
        private void btnTan_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            if (!SecondClicked)
                opr = 10;
            else if (SecondClicked)
                opr = 16;
            Solve();
        }
        //sinH Button
        private void btnSinH_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            if (!SecondClicked)
                opr = 11;
            else if (SecondClicked)
                opr = 17;
            Solve();
        }
        //cosH Button
        private void btnCosH_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            if (!SecondClicked)
                opr = 12;
            else if (SecondClicked)
                opr = 18;
            Solve();
        }
        //tanH Button
        private void btnTanH_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
            if (!SecondClicked)
                opr = 13;
            else if (SecondClicked)
                opr = 19;
            Solve();
        }
        //Degrees Button
        private void btnDeg_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
        }
        //Radians Button
        private void btnRad_Click(object sender, EventArgs e)
        {
            op1 = Convert.ToDouble(display);
        }

        //==========================SOLVE || = FUNCTION==================================
        private void Solve()
        {
            Concatonate();
            switch (opr)
            {
                case 1:
                    result = math.add(op1, op2);
                    break;
                case 2:
                    result = math.subtract(op1, op2);
                    break;
                case 3:
                    result = math.multiply(op1, op2);
                    break;
                case 4:
                    result = math.divide(op1, op2);
                    break;
                case 5:
                    result = math.pow(op1, op2);
                    break;
                case 6:
                    result = math.yRoot(op1, op2);
                    break;
                case 7:
                    result = math.logXofY(op1, op2);
                    break;
                case 8:
                    result = Math.Sin(op1);
                    break;
                case 9:
                    result = Math.Cos(op1);
                    break;
                case 10:
                    result = Math.Tan(op1);
                    break;
                case 11:
                    result = Math.Sinh(op1);
                    break;
                case 12:
                    result = Math.Cosh(op1);
                    break;
                case 13:
                    result = Math.Tanh(op1);
                    break;
                case 14:
                    result = Math.Pow(Math.Sin(op1), -1.0);
                    break;
                case 15:
                    result = Math.Pow(Math.Cos(op1), -1.0);
                    break;
                case 16:
                    result = Math.Pow(Math.Tan(op1), -1.0);
                    break;
                case 17:
                    result = Math.Pow(Math.Sinh(op1), -1.0);
                    break;
                case 18:
                    result = Math.Pow(Math.Cosh(op1), -1.0);
                    break;
                case 19:
                    result = Math.Pow(Math.Tanh(op1), -1.0);
                    break;
                default:
                    MessageBox.Show("Fatal Error Occured!");
                    break;
            }
            display = result.ToString();
            op2 = 0.0;
        }
        private void btnEquals_Click(object sender, EventArgs e)
        {
            Solve();
        }

        /*============================THEME OPTIONS======================================
        //===============================================================================
        //=============================================================================*/
        //===============FUNCTIONS RELATED TO SCREEN MODIFICATIONS=======================
        public void Inverted(bool inverted)
        {
            if (inverted)
            {
                lblDisplay.ForeColor = Color.Ivory;
                btnEquals.ForeColor = Color.Ivory;
                btn0.ForeColor = Color.Ivory;
                btn1.ForeColor = Color.Ivory;
                btn2.ForeColor = Color.Ivory;
                btn3.ForeColor = Color.Ivory;
                btn4.ForeColor = Color.Ivory;
                btn5.ForeColor = Color.Ivory;
                btn6.ForeColor = Color.Ivory;
                btn7.ForeColor = Color.Ivory;
                btn8.ForeColor = Color.Ivory;
                btn9.ForeColor = Color.Ivory;
                btnDecimal.ForeColor = Color.Ivory;
                btnAdd.ForeColor = Color.Ivory;
                btnSubtract.ForeColor = Color.Ivory;
                btnMultiply.ForeColor = Color.Ivory;
                btnDivide.ForeColor = Color.Ivory;
                btnClear.ForeColor = Color.Ivory;
                btnPercentage.ForeColor = Color.Ivory;
                btnPosNeg.ForeColor = Color.Ivory;
                btnRand.ForeColor = Color.Ivory;
                btnEE.ForeColor = Color.Ivory;
                btnLog10.ForeColor = Color.Ivory;
                btn10ToTheX.ForeColor = Color.Ivory;
                btnMem.ForeColor = Color.Ivory;
                btnSubMem.ForeColor = Color.Ivory;
                btnEToTheX.ForeColor = Color.Ivory;
                btnNaturalLogarithm.ForeColor = Color.Ivory;
                btnE.ForeColor = Color.Ivory;
                btnPi.ForeColor = Color.Ivory;
                btnTanH.ForeColor = Color.Ivory;
                btnTan.ForeColor = Color.Ivory;
                btnYRoot.ForeColor = Color.Ivory;
                btnXToTheY.ForeColor = Color.Ivory;
                btnAddMem.ForeColor = Color.Ivory;
                btnMemClr.ForeColor = Color.Ivory;
                btnCubed.ForeColor = Color.Ivory;
                btnCubedRoot.ForeColor = Color.Ivory;
                btnCos.ForeColor = Color.Ivory;
                btnCosH.ForeColor = Color.Ivory;
                btnSinH.ForeColor = Color.Ivory;
                btnSin.ForeColor = Color.Ivory;
                btnSqrt.ForeColor = Color.Ivory;
                btnSquared.ForeColor = Color.Ivory;
                btnLParen.ForeColor = Color.Ivory;
                btnRParen.ForeColor = Color.Ivory;
                btn2nd.ForeColor = Color.Ivory;
                btnFraction.ForeColor = Color.Ivory;
                btnFactorial.ForeColor = Color.Ivory;
                btnRad.ForeColor = Color.Ivory;
                btnDeg.ForeColor = Color.Ivory;
                btnLog3.ForeColor = Color.Ivory;
                btnLog2.ForeColor = Color.Ivory;
                btnLogX.ForeColor = Color.Ivory;
                btnMem2.ForeColor = Color.Ivory;
            }
            if (!inverted)
            {
                lblDisplay.ForeColor = Color.Black;
                btnEquals.ForeColor = Color.Black;
                btn0.ForeColor = Color.Black;
                btn1.ForeColor = Color.Black;
                btn2.ForeColor = Color.Black;
                btn3.ForeColor = Color.Black;
                btn4.ForeColor = Color.Black;
                btn5.ForeColor = Color.Black;
                btn6.ForeColor = Color.Black;
                btn7.ForeColor = Color.Black;
                btn8.ForeColor = Color.Black;
                btn9.ForeColor = Color.Black;
                btnDecimal.ForeColor = Color.Black;
                btnAdd.ForeColor = Color.Black;
                btnSubtract.ForeColor = Color.Black;
                btnMultiply.ForeColor = Color.Black;
                btnDivide.ForeColor = Color.Black;
                btnClear.ForeColor = Color.Black;
                btnPercentage.ForeColor = Color.Black;
                btnPosNeg.ForeColor = Color.Black;
                btnRand.ForeColor = Color.Black;
                btnEE.ForeColor = Color.Black;
                btnLog10.ForeColor = Color.Black;
                btn10ToTheX.ForeColor = Color.Black;
                btnMem.ForeColor = Color.Black;
                btnSubMem.ForeColor = Color.Black;
                btnEToTheX.ForeColor = Color.Black;
                btnNaturalLogarithm.ForeColor = Color.Black;
                btnE.ForeColor = Color.Black;
                btnPi.ForeColor = Color.Black;
                btnTanH.ForeColor = Color.Black;
                btnTan.ForeColor = Color.Black;
                btnYRoot.ForeColor = Color.Black;
                btnXToTheY.ForeColor = Color.Black;
                btnAddMem.ForeColor = Color.Black;
                btnMemClr.ForeColor = Color.Black;
                btnCubed.ForeColor = Color.Black;
                btnCubedRoot.ForeColor = Color.Black;
                btnCos.ForeColor = Color.Black;
                btnCosH.ForeColor = Color.Black;
                btnSinH.ForeColor = Color.Black;
                btnSin.ForeColor = Color.Black;
                btnSqrt.ForeColor = Color.Black;
                btnSquared.ForeColor = Color.Black;
                btnLParen.ForeColor = Color.Black;
                btnRParen.ForeColor = Color.Black;
                btn2nd.ForeColor = Color.Black;
                btnFraction.ForeColor = Color.Black;
                btnFactorial.ForeColor = Color.Black;
                btnRad.ForeColor = Color.Black;
                btnDeg.ForeColor = Color.Black;
                btnLog3.ForeColor = Color.Black;
                btnLog2.ForeColor = Color.Black;
                btnLogX.ForeColor = Color.Black;
                btnMem2.ForeColor = Color.Black;
            }
        }
        public void ShrinkDisplay()
        {
            //implement font sizes to buttons
            float fontSize = 16.2f;
            float smallFont = 10.8f;

            const int boxSize = 63;
            const int spaceSize = 5;
            int[] column = new int[18];
            int[] row = new int[3];
            row[0] = this.Bottom - (boxSize + spaceSize + 90);
            column[0] = 7;
            //populate arrays with column/row (x,y) coordinates for btns
            //rows go bottom to top
            for (int i = 1; i < 3; i++)
            {
                row[i] = row[i - 1] - (boxSize + spaceSize);
            }
            //columns go right to left
            for (int i = 1; i < 18; i++)
            {
                column[i] = column[i - 1] + (boxSize + spaceSize);
            }

            //lblDisplay
            lblDisplay.Height = 70;
            lblDisplay.Width = 542;
            lblDisplay.Top = 50;
            lblDisplay.Left = this.Right - (lblDisplay.Width + 55);
            lblDisplay.Font = new Font("Quartz MS", 20.2f, FontStyle.Bold);
            //btnEquals
            btnEquals.Height = boxSize;
            btnEquals.Width = boxSize;
            btnEquals.Left = column[17];
            btnEquals.Top = row[0];
            btnEquals.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn0
            btn0.Height = boxSize;
            btn0.Width = (boxSize * 2) + spaceSize;
            btn0.Left = column[10];
            btn0.Top = row[0];
            btn0.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn1
            btn1.Height = boxSize;
            btn1.Width = boxSize;
            btn1.Left = column[12];
            btn1.Top = row[0];
            btn1.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn2
            btn2.Height = boxSize;
            btn2.Width = boxSize;
            btn2.Left = column[13];
            btn2.Top = row[0];
            btn2.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn3
            btn3.Height = boxSize;
            btn3.Width = boxSize;
            btn3.Left = column[14];
            btn3.Top = row[0];
            btn3.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn4
            btn4.Height = boxSize;
            btn4.Width = boxSize;
            btn4.Left = column[12];
            btn4.Top = row[1];
            btn4.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn5
            btn5.Height = boxSize;
            btn5.Width = boxSize;
            btn5.Left = column[13];
            btn5.Top = row[1];
            btn5.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn6
            btn6.Height = boxSize;
            btn6.Width = boxSize;
            btn6.Left = column[14];
            btn6.Top = row[1];
            btn6.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn7
            btn7.Height = boxSize;
            btn7.Width = boxSize;
            btn7.Left = column[12];
            btn7.Top = row[2];
            btn7.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn8
            btn8.Height = boxSize;
            btn8.Width = boxSize;
            btn8.Left = column[13];
            btn8.Top = row[2];
            btn8.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn9
            btn9.Height = boxSize;
            btn9.Width = boxSize;
            btn9.Left = column[14];
            btn9.Top = row[2];
            btn9.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnDecimal
            btnDecimal.Height = boxSize;
            btnDecimal.Width = boxSize; 
            btnDecimal.Left = column[15];
            btnDecimal.Top = row[0];
            btnDecimal.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnAdd
            btnAdd.Height = boxSize;
            btnAdd.Width = boxSize; 
            btnAdd.Left = column[17];
            btnAdd.Top = row[1];
            btnAdd.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnSubtract
            btnSubtract.Height = boxSize;
            btnSubtract.Width = boxSize;
            btnSubtract.Left = column[17];
            btnSubtract.Top = row[2];
            btnSubtract.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnMultiply
            btnMultiply.Height = boxSize;
            btnMultiply.Width = boxSize;
            btnMultiply.Left = column[16];
            btnMultiply.Top = row[0];
            btnMultiply.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnDivide
            btnDivide.Height = boxSize;
            btnDivide.Width = boxSize;
            btnDivide.Left = column[16];
            btnDivide.Top = row[1];
            btnDivide.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnClear
            btnClear.Height = boxSize;
            btnClear.Width = boxSize;
            btnClear.Left = column[15];
            btnClear.Top = row[2];
            btnClear.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnPercentage
            btnPercentage.Height = boxSize;
            btnPercentage.Width = boxSize;
            btnPercentage.Left = column[16];
            btnPercentage.Top = row[2];
            btnPercentage.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnPosNeg
            btnPosNeg.Height = boxSize;
            btnPosNeg.Width = boxSize;
            btnPosNeg.Left = column[15];
            btnPosNeg.Top = row[1];
            btnPosNeg.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnRand
            btnRand.Height = boxSize;
            btnRand.Width = boxSize;
            btnRand.Left = column[11];
            btnRand.Top = row[1];
            btnRand.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnEE
            btnEE.Height = boxSize;
            btnEE.Width = boxSize;
            btnEE.Left = column[11];
            btnEE.Top = row[2];
            btnEE.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnLog10
            btnLog10.Height = boxSize;
            btnLog10.Width = boxSize;
            btnLog10.Left = column[9];
            btnLog10.Top = row[1];
            btnLog10.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btn10ToTheX
            btn10ToTheX.Height = boxSize;
            btn10ToTheX.Width = boxSize;
            btn10ToTheX.Left = column[9];
            btn10ToTheX.Top = row[2];
            btn10ToTheX.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnMem
            btnMem.Height = boxSize;
            btnMem.Width = boxSize;
            btnMem.Left = column[9];
            btnMem.Top = row[0];
            btnMem.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnSubMem
            btnSubMem.Height = boxSize;
            btnSubMem.Width = boxSize;
            btnSubMem.Left = column[8];
            btnSubMem.Top = row[0];
            btnSubMem.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnEToTheX
            btnEToTheX.Height = boxSize;
            btnEToTheX.Width = boxSize;
            btnEToTheX.Left = column[8];
            btnEToTheX.Top = row[2];
            btnEToTheX.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnNaturalLogarithm
            btnNaturalLogarithm.Height = boxSize;
            btnNaturalLogarithm.Width = boxSize;
            btnNaturalLogarithm.Left = column[8];
            btnNaturalLogarithm.Top = row[1];
            btnNaturalLogarithm.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnE
            btnE.Height = boxSize;
            btnE.Width = boxSize;
            btnE.Left = column[10];
            btnE.Top = row[2];
            btnE.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnPi
            btnPi.Height = boxSize;
            btnPi.Width = boxSize;
            btnPi.Left = column[10];
            btnPi.Top = row[1];
            btnPi.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnTanH
            btnTanH.Height = boxSize;
            btnTanH.Width = boxSize;
            btnTanH.Left = column[3];
            btnTanH.Top = row[0];
            btnTanH.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnTan
            btnTan.Height = boxSize;
            btnTan.Width = boxSize;
            btnTan.Left = column[4];
            btnTan.Top = row[0];
            btnTan.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnYRoot
            btnYRoot.Height = boxSize;
            btnYRoot.Width = boxSize;
            btnYRoot.Left = column[7];
            btnYRoot.Top = row[1];
            btnYRoot.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnXToTheY
            btnXToTheY.Height = boxSize;
            btnXToTheY.Width = boxSize;
            btnXToTheY.Left = column[7];
            btnXToTheY.Top = row[2];
            btnXToTheY.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnAddMem
            btnAddMem.Height = boxSize;
            btnAddMem.Width = boxSize;
            btnAddMem.Left = column[7];
            btnAddMem.Top = row[0];
            btnAddMem.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnMemClr
            btnMemClr.Height = boxSize;
            btnMemClr.Width = boxSize;
            btnMemClr.Left = column[6];
            btnMemClr.Top = row[0];
            btnMemClr.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnCubed
            btnCubed.Height = boxSize;
            btnCubed.Width = boxSize;
            btnCubed.Left = column[6];
            btnCubed.Top = row[2];
            btnCubed.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnCubedRoot
            btnCubedRoot.Height = boxSize;
            btnCubedRoot.Width = boxSize;
            btnCubedRoot.Left = column[6];
            btnCubedRoot.Top = row[1];
            btnCubedRoot.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnCos
            btnCos.Height = boxSize;
            btnCos.Width = boxSize;
            btnCos.Left = column[4];
            btnCos.Top = row[2];
            btnCos.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnCosH
            btnCosH.Height = boxSize;
            btnCosH.Width = boxSize;
            btnCosH.Left = column[3];
            btnCosH.Top = row[2];
            btnCosH.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnSinH
            btnSinH.Height = boxSize;
            btnSinH.Width = boxSize;
            btnSinH.Left = column[3];
            btnSinH.Top = row[1];
            btnSinH.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnSin
            btnSin.Height = boxSize;
            btnSin.Width = boxSize;
            btnSin.Left = column[4];
            btnSin.Top = row[1];
            btnSin.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnSqrt
            btnSqrt.Height = boxSize;
            btnSqrt.Width = boxSize;
            btnSqrt.Left = column[5];
            btnSqrt.Top = row[1];
            btnSqrt.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnSquared
            btnSquared.Height = boxSize;
            btnSquared.Width = boxSize;
            btnSquared.Left = column[5];
            btnSquared.Top = row[2];
            btnSquared.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnLParen
            btnLParen.Height = boxSize;
            btnLParen.Width = boxSize;
            btnLParen.Left = column[0];
            btnLParen.Top = row[2];
            btnLParen.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnRParen
            btnRParen.Height = boxSize;
            btnRParen.Width = boxSize;
            btnRParen.Left = column[1];
            btnRParen.Top = row[2];
            btnRParen.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btn2nd
            btn2nd.Height = boxSize;
            btn2nd.Width = boxSize;
            btn2nd.Left = column[2];
            btn2nd.Top = row[2];
            btn2nd.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnFraction
            btnFraction.Height = boxSize;
            btnFraction.Width = boxSize;
            btnFraction.Left = column[2];
            btnFraction.Top = row[1];
            btnFraction.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnFactorial
            btnFactorial.Height = boxSize;
            btnFactorial.Width = boxSize;
            btnFactorial.Left = column[5];
            btnFactorial.Top = row[0];
            btnFactorial.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnRad
            btnRad.Height = boxSize;
            btnRad.Width = boxSize;
            btnRad.Left = column[2];
            btnRad.Top = row[0];
            btnRad.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnDeg
            btnDeg.Height = boxSize;
            btnDeg.Width = boxSize;
            btnDeg.Left = column[2];
            btnDeg.Top = row[0];
            btnDeg.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnLog3
            btnLog3.Height = boxSize;
            btnLog3.Width = boxSize;
            btnLog3.Left = column[1];
            btnLog3.Top = row[0];
            btnLog3.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnLog2
            btnLog2.Height = boxSize;
            btnLog2.Width = boxSize;
            btnLog2.Left = column[1];
            btnLog2.Top = row[1];
            btnLog2.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnLogX
            btnLogX.Height = boxSize;
            btnLogX.Width = boxSize;
            btnLogX.Left = column[0];
            btnLogX.Top = row[0];
            btnLogX.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnMem2
            btnMem2.Height = boxSize;
            btnMem2.Width = boxSize;
            btnMem2.Left = column[0];
            btnMem2.Top = row[1];
            btnMem2.Font = new Font("Forte", smallFont, FontStyle.Bold);
        }
        public void DefaultDisplay()
        {
            //implement font sizes to buttons
            float fontSize = 22.2f;
            float smallFont = 16.2f;

            const int boxSize = 90;
            const int spaceSize = 6;
            int[] column = new int[11];
            int[] row = new int[5];
            row[0] = 563;
            column[0] = 53;
            //populate arrays with column/row (x,y) coordinates for btns
            //rows go bottom to top
            for (int i = 1; i < 5; i++)
            {
                row[i] = row[i - 1] - (boxSize + spaceSize);
            }
            //columns go right to left
            for (int i = 1; i < 11; i++)
            {
                if (i == 7)
                {
                    column[i] = column[i - 1] + (boxSize + 114);
                }
                else
                    column[i] = column[i - 1] + (boxSize + spaceSize);
            }
            //lblDisplay
            lblDisplay.Height = 100;
            lblDisplay.Width = 870;
            lblDisplay.Top = 55;
            lblDisplay.Left = 341;
            lblDisplay.Font = new Font("Quartz MS", 25.8f , FontStyle.Bold);
            //btnEquals
            btnEquals.Height = boxSize;
            btnEquals.Width = boxSize;
            btnEquals.Left = column[10];
            btnEquals.Top = row[0];
            btnEquals.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn0
            btn0.Height = boxSize;
            btn0.Width = (boxSize * 2) + spaceSize;
            btn0.Left = column[7];
            btn0.Top = row[0];
            btn0.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn1
            btn1.Height = boxSize;
            btn1.Width = boxSize;
            btn1.Left = column[7];
            btn1.Top = row[1];
            btn1.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn2
            btn2.Height = boxSize;
            btn2.Width = boxSize;
            btn2.Left = column[8];
            btn2.Top = row[1];
            btn2.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn3
            btn3.Height = boxSize;
            btn3.Width = boxSize;
            btn3.Left = column[9];
            btn3.Top = row[1];
            btn3.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn4
            btn4.Height = boxSize;
            btn4.Width = boxSize;
            btn4.Left = column[7];
            btn4.Top = row[2];
            btn4.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn5
            btn5.Height = boxSize;
            btn5.Width = boxSize;
            btn5.Left = column[8];
            btn5.Top = row[2];
            btn5.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn6
            btn6.Height = boxSize;
            btn6.Width = boxSize;
            btn6.Left = column[9];
            btn6.Top = row[2];
            btn6.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn7
            btn7.Height = boxSize;
            btn7.Width = boxSize;
            btn7.Left = column[7];
            btn7.Top = row[3];
            btn7.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn8
            btn8.Height = boxSize;
            btn8.Width = boxSize;
            btn8.Left = column[8];
            btn8.Top = row[3];
            btn8.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btn9
            btn9.Height = boxSize;
            btn9.Width = boxSize;
            btn9.Left = column[9];
            btn9.Top = row[3];
            btn9.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnDecimal
            btnDecimal.Height = boxSize;
            btnDecimal.Width = boxSize;
            btnDecimal.Left = column[9];
            btnDecimal.Top = row[0];
            btnDecimal.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnAdd
            btnAdd.Height = boxSize;
            btnAdd.Width = boxSize;
            btnAdd.Left = column[10];
            btnAdd.Top = row[1];
            btnAdd.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnSubtract
            btnSubtract.Height = boxSize;
            btnSubtract.Width = boxSize;
            btnSubtract.Left = column[10];
            btnSubtract.Top = row[2];
            btnSubtract.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnMultiply
            btnMultiply.Height = boxSize;
            btnMultiply.Width = boxSize;
            btnMultiply.Left = column[10];
            btnMultiply.Top = row[3];
            btnMultiply.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnDivide
            btnDivide.Height = boxSize;
            btnDivide.Width = boxSize;
            btnDivide.Left = column[10];
            btnDivide.Top = row[4];
            btnDivide.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnClear
            btnClear.Height = boxSize;
            btnClear.Width = boxSize;
            btnClear.Left = column[7];
            btnClear.Top = row[4];
            btnClear.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnPercentage
            btnPercentage.Height = boxSize;
            btnPercentage.Width = boxSize;
            btnPercentage.Left = column[9];
            btnPercentage.Top = row[4];
            btnPercentage.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnPosNeg
            btnPosNeg.Height = boxSize;
            btnPosNeg.Width = boxSize;
            btnPosNeg.Left = column[8];
            btnPosNeg.Top = row[4];
            btnPosNeg.Font = new Font("Forte", fontSize, FontStyle.Bold);
            //btnRand
            btnRand.Height = boxSize;
            btnRand.Width = boxSize;
            btnRand.Left = column[6];
            btnRand.Top = row[0];
            btnRand.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnEE
            btnEE.Height = boxSize;
            btnEE.Width = boxSize;
            btnEE.Left = column[6];
            btnEE.Top = row[1];
            btnEE.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnLog10
            btnLog10.Height = boxSize;
            btnLog10.Width = boxSize;
            btnLog10.Left = column[6];
            btnLog10.Top = row[2];
            btnLog10.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btn10ToTheX
            btn10ToTheX.Height = boxSize;
            btn10ToTheX.Width = boxSize;
            btn10ToTheX.Left = column[6];
            btn10ToTheX.Top = row[3];
            btn10ToTheX.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnMem
            btnMem.Height = boxSize;
            btnMem.Width = boxSize;
            btnMem.Left = column[6];
            btnMem.Top = row[4];
            btnMem.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnSubMem
            btnSubMem.Height = boxSize;
            btnSubMem.Width = boxSize;
            btnSubMem.Left = column[5];
            btnSubMem.Top = row[4];
            btnSubMem.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnEToTheX
            btnEToTheX.Height = boxSize;
            btnEToTheX.Width = boxSize;
            btnEToTheX.Left = column[5];
            btnEToTheX.Top = row[3];
            btnEToTheX.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnNaturalLogarithm
            btnNaturalLogarithm.Height = boxSize;
            btnNaturalLogarithm.Width = boxSize;
            btnNaturalLogarithm.Left = column[5];
            btnNaturalLogarithm.Top = row[2];
            btnNaturalLogarithm.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnE
            btnE.Height = boxSize;
            btnE.Width = boxSize;
            btnE.Left = column[5];
            btnE.Top = row[1];
            btnE.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnPi
            btnPi.Height = boxSize;
            btnPi.Width = boxSize;
            btnPi.Left = column[5];
            btnPi.Top = row[0];
            btnPi.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnTanH
            btnTanH.Height = boxSize;
            btnTanH.Width = boxSize;
            btnTanH.Left = column[4];
            btnTanH.Top = row[0];
            btnTanH.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnTan
            btnTan.Height = boxSize;
            btnTan.Width = boxSize;
            btnTan.Left = column[4];
            btnTan.Top = row[1];
            btnTan.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnYRoot
            btnYRoot.Height = boxSize;
            btnYRoot.Width = boxSize;
            btnYRoot.Left = column[4];
            btnYRoot.Top = row[2];
            btnYRoot.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnXToTheY
            btnXToTheY.Height = boxSize;
            btnXToTheY.Width = boxSize;
            btnXToTheY.Left = column[4];
            btnXToTheY.Top = row[3];
            btnXToTheY.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnAddMem
            btnAddMem.Height = boxSize;
            btnAddMem.Width = boxSize;
            btnAddMem.Left = column[4];
            btnAddMem.Top = row[4];
            btnAddMem.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnMemClr
            btnMemClr.Height = boxSize;
            btnMemClr.Width = boxSize;
            btnMemClr.Left = column[3];
            btnMemClr.Top = row[4];
            btnMemClr.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnCubed
            btnCubed.Height = boxSize;
            btnCubed.Width = boxSize;
            btnCubed.Left = column[3];
            btnCubed.Top = row[3];
            btnCubed.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnCubedRoot
            btnCubedRoot.Height = boxSize;
            btnCubedRoot.Width = boxSize;
            btnCubedRoot.Left = column[3];
            btnCubedRoot.Top = row[2];
            btnCubedRoot.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnCos
            btnCos.Height = boxSize;
            btnCos.Width = boxSize;
            btnCos.Left = column[3];
            btnCos.Top = row[1];
            btnCos.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnCosH
            btnCosH.Height = boxSize;
            btnCosH.Width = boxSize;
            btnCosH.Left = column[3];
            btnCosH.Top = row[0];
            btnCosH.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnSinH
            btnSinH.Height = boxSize;
            btnSinH.Width = boxSize;
            btnSinH.Left = column[2];
            btnSinH.Top = row[0];
            btnSinH.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnSin
            btnSin.Height = boxSize;
            btnSin.Width = boxSize;
            btnSin.Left = column[2];
            btnSin.Top = row[1];
            btnSin.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnSqrt
            btnSqrt.Height = boxSize;
            btnSqrt.Width = boxSize;
            btnSqrt.Left = column[2];
            btnSqrt.Top = row[2];
            btnSqrt.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnSquared
            btnSquared.Height = boxSize;
            btnSquared.Width = boxSize;
            btnSquared.Left = column[2];
            btnSquared.Top = row[3];
            btnSquared.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnLParen
            btnLParen.Height = boxSize;
            btnLParen.Width = boxSize;
            btnLParen.Left = column[1];
            btnLParen.Top = row[4];
            btnLParen.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnRParen
            btnRParen.Height = boxSize;
            btnRParen.Width = boxSize;
            btnRParen.Left = column[2];
            btnRParen.Top = row[4];
            btnRParen.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btn2nd
            btn2nd.Height = boxSize;
            btn2nd.Width = boxSize;
            btn2nd.Left = column[1];
            btn2nd.Top = row[3];
            btn2nd.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnFraction
            btnFraction.Height = boxSize;
            btnFraction.Width = boxSize;
            btnFraction.Left = column[1];
            btnFraction.Top = row[2];
            btnFraction.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnFactorial
            btnFactorial.Height = boxSize;
            btnFactorial.Width = boxSize;
            btnFactorial.Left = column[1];
            btnFactorial.Top = row[1];
            btnFactorial.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnRad
            btnRad.Height = boxSize;
            btnRad.Width = boxSize;
            btnRad.Left = column[1];
            btnRad.Top = row[0];
            btnRad.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnDeg
            btnDeg.Height = boxSize;
            btnDeg.Width = boxSize;
            btnDeg.Left = column[0];
            btnDeg.Top = row[0];
            btnDeg.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnLog3
            btnLog3.Height = boxSize;
            btnLog3.Width = boxSize;
            btnLog3.Left = column[0];
            btnLog3.Top = row[2];
            btnLog3.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnLog2
            btnLog2.Height = boxSize;
            btnLog2.Width = boxSize;
            btnLog2.Left = column[0];
            btnLog2.Top = row[3];
            btnLog2.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnLogX
            btnLogX.Height = boxSize;
            btnLogX.Width = boxSize;
            btnLogX.Left = column[0];
            btnLogX.Top = row[1];
            btnLogX.Font = new Font("Forte", smallFont, FontStyle.Bold);
            //btnMem2
            btnMem2.Height = boxSize;
            btnMem2.Width = boxSize;
            btnMem2.Left = column[0];
            btnMem2.Top = row[4];
            btnMem2.Font = new Font("Forte", smallFont, FontStyle.Bold);
        }
        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = false;
            BackgroundDispose();
            this.BackColor = Color.DarkSlateGray;
            OliveButton();
        }
        private void BackgroundDispose()
        {
            knightRiderOn = false;
            if (this.BackgroundImage != null)
                this.BackgroundImage = null;
        }
        //Sound On Menu Strip
        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            soundOn = true;
        }
        //Sound Off Menu Strip
        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            soundOn = false;
        }
        
        //==============================FONT COLORS======================================
        public void BlueFont()
        {
            lblDisplay.ForeColor = Color.DarkBlue;
            btnEquals.ForeColor = Color.DarkBlue;
            btn0.ForeColor = Color.DarkBlue;
            btn1.ForeColor = Color.DarkBlue;
            btn2.ForeColor = Color.DarkBlue;
            btn3.ForeColor = Color.DarkBlue;
            btn4.ForeColor = Color.DarkBlue;
            btn5.ForeColor = Color.DarkBlue;
            btn6.ForeColor = Color.DarkBlue;
            btn7.ForeColor = Color.DarkBlue;
            btn8.ForeColor = Color.DarkBlue;
            btn9.ForeColor = Color.DarkBlue;
            btnDecimal.ForeColor = Color.DarkBlue;
            btnAdd.ForeColor = Color.DarkBlue;
            btnSubtract.ForeColor = Color.DarkBlue;
            btnMultiply.ForeColor = Color.DarkBlue;
            btnDivide.ForeColor = Color.DarkBlue;
            btnClear.ForeColor = Color.DarkBlue;
            btnPercentage.ForeColor = Color.DarkBlue;
            btnPosNeg.ForeColor = Color.DarkBlue;
            btnRand.ForeColor = Color.DarkBlue;
            btnEE.ForeColor = Color.DarkBlue;
            btnLog10.ForeColor = Color.DarkBlue;
            btn10ToTheX.ForeColor = Color.DarkBlue;
            btnMem.ForeColor = Color.DarkBlue;
            btnSubMem.ForeColor = Color.DarkBlue;
            btnEToTheX.ForeColor = Color.DarkBlue;
            btnNaturalLogarithm.ForeColor = Color.DarkBlue;
            btnE.ForeColor = Color.DarkBlue;
            btnPi.ForeColor = Color.DarkBlue;
            btnTanH.ForeColor = Color.DarkBlue;
            btnTan.ForeColor = Color.DarkBlue;
            btnYRoot.ForeColor = Color.DarkBlue;
            btnXToTheY.ForeColor = Color.DarkBlue;
            btnAddMem.ForeColor = Color.DarkBlue;
            btnMemClr.ForeColor = Color.DarkBlue;
            btnCubed.ForeColor = Color.DarkBlue;
            btnCubedRoot.ForeColor = Color.DarkBlue;
            btnCos.ForeColor = Color.DarkBlue;
            btnCosH.ForeColor = Color.DarkBlue;
            btnSinH.ForeColor = Color.DarkBlue;
            btnSin.ForeColor = Color.DarkBlue;
            btnSqrt.ForeColor = Color.DarkBlue;
            btnSquared.ForeColor = Color.DarkBlue;
            btnLParen.ForeColor = Color.DarkBlue;
            btnRParen.ForeColor = Color.DarkBlue;
            btn2nd.ForeColor = Color.DarkBlue;
            btnFraction.ForeColor = Color.DarkBlue;
            btnFactorial.ForeColor = Color.DarkBlue;
            btnRad.ForeColor = Color.DarkBlue;
            btnDeg.ForeColor = Color.DarkBlue;
            btnLog3.ForeColor = Color.DarkBlue;
            btnLog2.ForeColor = Color.DarkBlue;
            btnLogX.ForeColor = Color.DarkBlue;
            btnMem2.ForeColor = Color.DarkBlue;
        }
        public void GreenFont()
        {
            lblDisplay.ForeColor = Color.DarkGreen;
            btnEquals.ForeColor = Color.DarkGreen;
            btn0.ForeColor = Color.DarkGreen;
            btn1.ForeColor = Color.DarkGreen;
            btn2.ForeColor = Color.DarkGreen;
            btn3.ForeColor = Color.DarkGreen;
            btn4.ForeColor = Color.DarkGreen;
            btn5.ForeColor = Color.DarkGreen;
            btn6.ForeColor = Color.DarkGreen;
            btn7.ForeColor = Color.DarkGreen;
            btn8.ForeColor = Color.DarkGreen;
            btn9.ForeColor = Color.DarkGreen;
            btnDecimal.ForeColor = Color.DarkGreen;
            btnAdd.ForeColor = Color.DarkGreen;
            btnSubtract.ForeColor = Color.DarkGreen;
            btnMultiply.ForeColor = Color.DarkGreen;
            btnDivide.ForeColor = Color.DarkGreen;
            btnClear.ForeColor = Color.DarkGreen;
            btnPercentage.ForeColor = Color.DarkGreen;
            btnPosNeg.ForeColor = Color.DarkGreen;
            btnRand.ForeColor = Color.DarkGreen;
            btnEE.ForeColor = Color.DarkGreen;
            btnLog10.ForeColor = Color.DarkGreen;
            btn10ToTheX.ForeColor = Color.DarkGreen;
            btnMem.ForeColor = Color.DarkGreen;
            btnSubMem.ForeColor = Color.DarkGreen;
            btnEToTheX.ForeColor = Color.DarkGreen;
            btnNaturalLogarithm.ForeColor = Color.DarkGreen;
            btnE.ForeColor = Color.DarkGreen;
            btnPi.ForeColor = Color.DarkGreen;
            btnTanH.ForeColor = Color.DarkGreen;
            btnTan.ForeColor = Color.DarkGreen;
            btnYRoot.ForeColor = Color.DarkGreen;
            btnXToTheY.ForeColor = Color.DarkGreen;
            btnAddMem.ForeColor = Color.DarkGreen;
            btnMemClr.ForeColor = Color.DarkGreen;
            btnCubed.ForeColor = Color.DarkGreen;
            btnCubedRoot.ForeColor = Color.DarkGreen;
            btnCos.ForeColor = Color.DarkGreen;
            btnCosH.ForeColor = Color.DarkGreen;
            btnSinH.ForeColor = Color.DarkGreen;
            btnSin.ForeColor = Color.DarkGreen;
            btnSqrt.ForeColor = Color.DarkGreen;
            btnSquared.ForeColor = Color.DarkGreen;
            btnLParen.ForeColor = Color.DarkGreen;
            btnRParen.ForeColor = Color.DarkGreen;
            btn2nd.ForeColor = Color.DarkGreen;
            btnFraction.ForeColor = Color.DarkGreen;
            btnFactorial.ForeColor = Color.DarkGreen;
            btnRad.ForeColor = Color.DarkGreen;
            btnDeg.ForeColor = Color.DarkGreen;
            btnLog3.ForeColor = Color.DarkGreen;
            btnLog2.ForeColor = Color.DarkGreen;
            btnLogX.ForeColor = Color.DarkGreen;
            btnMem2.ForeColor = Color.DarkGreen;
        }
        public void RedFont()
        {
            lblDisplay.ForeColor = Color.DarkRed;
            btnEquals.ForeColor = Color.DarkRed;
            btn0.ForeColor = Color.DarkRed;
            btn1.ForeColor = Color.DarkRed;
            btn2.ForeColor = Color.DarkRed;
            btn3.ForeColor = Color.DarkRed;
            btn4.ForeColor = Color.DarkRed;
            btn5.ForeColor = Color.DarkRed;
            btn6.ForeColor = Color.DarkRed;
            btn7.ForeColor = Color.DarkRed;
            btn8.ForeColor = Color.DarkRed;
            btn9.ForeColor = Color.DarkRed;
            btnDecimal.ForeColor = Color.DarkRed;
            btnAdd.ForeColor = Color.DarkRed;
            btnSubtract.ForeColor = Color.DarkRed;
            btnMultiply.ForeColor = Color.DarkRed;
            btnDivide.ForeColor = Color.DarkRed;
            btnClear.ForeColor = Color.DarkRed;
            btnPercentage.ForeColor = Color.DarkRed;
            btnPosNeg.ForeColor = Color.DarkRed;
            btnRand.ForeColor = Color.DarkRed;
            btnEE.ForeColor = Color.DarkRed;
            btnLog10.ForeColor = Color.DarkRed;
            btn10ToTheX.ForeColor = Color.DarkRed;
            btnMem.ForeColor = Color.DarkRed;
            btnSubMem.ForeColor = Color.DarkRed;
            btnEToTheX.ForeColor = Color.DarkRed;
            btnNaturalLogarithm.ForeColor = Color.DarkRed;
            btnE.ForeColor = Color.DarkRed;
            btnPi.ForeColor = Color.DarkRed;
            btnTanH.ForeColor = Color.DarkRed;
            btnTan.ForeColor = Color.DarkRed;
            btnYRoot.ForeColor = Color.DarkRed;
            btnXToTheY.ForeColor = Color.DarkRed;
            btnAddMem.ForeColor = Color.DarkRed;
            btnMemClr.ForeColor = Color.DarkRed;
            btnCubed.ForeColor = Color.DarkRed;
            btnCubedRoot.ForeColor = Color.DarkRed;
            btnCos.ForeColor = Color.DarkRed;
            btnCosH.ForeColor = Color.DarkRed;
            btnSinH.ForeColor = Color.DarkRed;
            btnSin.ForeColor = Color.DarkRed;
            btnSqrt.ForeColor = Color.DarkRed;
            btnSquared.ForeColor = Color.DarkRed;
            btnLParen.ForeColor = Color.DarkRed;
            btnRParen.ForeColor = Color.DarkRed;
            btn2nd.ForeColor = Color.DarkRed;
            btnFraction.ForeColor = Color.DarkRed;
            btnFactorial.ForeColor = Color.DarkRed;
            btnRad.ForeColor = Color.DarkRed;
            btnDeg.ForeColor = Color.DarkRed;
            btnLog3.ForeColor = Color.DarkRed;
            btnLog2.ForeColor = Color.DarkRed;
            btnLogX.ForeColor = Color.DarkRed;
            btnMem2.ForeColor = Color.DarkRed;
        }
        public void CyanFont()
        {
            lblDisplay.ForeColor = Color.DarkSlateGray;
            btnEquals.ForeColor = Color.DarkSlateGray;
            btn0.ForeColor = Color.DarkSlateGray;
            btn1.ForeColor = Color.DarkSlateGray;
            btn2.ForeColor = Color.DarkSlateGray;
            btn3.ForeColor = Color.DarkSlateGray;
            btn4.ForeColor = Color.DarkSlateGray;
            btn5.ForeColor = Color.DarkSlateGray;
            btn6.ForeColor = Color.DarkSlateGray;
            btn7.ForeColor = Color.DarkSlateGray;
            btn8.ForeColor = Color.DarkSlateGray;
            btn9.ForeColor = Color.DarkSlateGray;
            btnDecimal.ForeColor = Color.DarkSlateGray;
            btnAdd.ForeColor = Color.DarkSlateGray;
            btnSubtract.ForeColor = Color.DarkSlateGray;
            btnMultiply.ForeColor = Color.DarkSlateGray;
            btnDivide.ForeColor = Color.DarkSlateGray;
            btnClear.ForeColor = Color.DarkSlateGray;
            btnPercentage.ForeColor = Color.DarkSlateGray;
            btnPosNeg.ForeColor = Color.DarkSlateGray;
            btnRand.ForeColor = Color.DarkSlateGray;
            btnEE.ForeColor = Color.DarkSlateGray;
            btnLog10.ForeColor = Color.DarkSlateGray;
            btn10ToTheX.ForeColor = Color.DarkSlateGray;
            btnMem.ForeColor = Color.DarkSlateGray;
            btnSubMem.ForeColor = Color.DarkSlateGray;
            btnEToTheX.ForeColor = Color.DarkSlateGray;
            btnNaturalLogarithm.ForeColor = Color.DarkSlateGray;
            btnE.ForeColor = Color.DarkSlateGray;
            btnPi.ForeColor = Color.DarkSlateGray;
            btnTanH.ForeColor = Color.DarkSlateGray;
            btnTan.ForeColor = Color.DarkSlateGray;
            btnYRoot.ForeColor = Color.DarkSlateGray;
            btnXToTheY.ForeColor = Color.DarkSlateGray;
            btnAddMem.ForeColor = Color.DarkSlateGray;
            btnMemClr.ForeColor = Color.DarkSlateGray;
            btnCubed.ForeColor = Color.DarkSlateGray;
            btnCubedRoot.ForeColor = Color.DarkSlateGray;
            btnCos.ForeColor = Color.DarkSlateGray;
            btnCosH.ForeColor = Color.DarkSlateGray;
            btnSinH.ForeColor = Color.DarkSlateGray;
            btnSin.ForeColor = Color.DarkSlateGray;
            btnSqrt.ForeColor = Color.DarkSlateGray;
            btnSquared.ForeColor = Color.DarkSlateGray;
            btnLParen.ForeColor = Color.DarkSlateGray;
            btnRParen.ForeColor = Color.DarkSlateGray;
            btn2nd.ForeColor = Color.DarkSlateGray;
            btnFraction.ForeColor = Color.DarkSlateGray;
            btnFactorial.ForeColor = Color.DarkSlateGray;
            btnRad.ForeColor = Color.DarkSlateGray;
            btnDeg.ForeColor = Color.DarkSlateGray;
            btnLog3.ForeColor = Color.DarkSlateGray;
            btnLog2.ForeColor = Color.DarkSlateGray;
            btnLogX.ForeColor = Color.DarkSlateGray;
            btnMem2.ForeColor = Color.DarkSlateGray;
        }
        public void TealFont()
        {
            lblDisplay.ForeColor = Color.Turquoise;
            btnEquals.ForeColor = Color.Turquoise;
            btn0.ForeColor = Color.Turquoise;
            btn1.ForeColor = Color.Turquoise;
            btn2.ForeColor = Color.Turquoise;
            btn3.ForeColor = Color.Turquoise;
            btn4.ForeColor = Color.Turquoise;
            btn5.ForeColor = Color.Turquoise;
            btn6.ForeColor = Color.Turquoise;
            btn7.ForeColor = Color.Turquoise;
            btn8.ForeColor = Color.Turquoise;
            btn9.ForeColor = Color.Turquoise;
            btnDecimal.ForeColor = Color.Turquoise;
            btnAdd.ForeColor = Color.Turquoise;
            btnSubtract.ForeColor = Color.Turquoise;
            btnMultiply.ForeColor = Color.Turquoise;
            btnDivide.ForeColor = Color.Turquoise;
            btnClear.ForeColor = Color.Turquoise;
            btnPercentage.ForeColor = Color.Turquoise;
            btnPosNeg.ForeColor = Color.Turquoise;
            btnRand.ForeColor = Color.Turquoise;
            btnEE.ForeColor = Color.Turquoise;
            btnLog10.ForeColor = Color.Turquoise;
            btn10ToTheX.ForeColor = Color.Turquoise;
            btnMem.ForeColor = Color.Turquoise;
            btnSubMem.ForeColor = Color.Turquoise;
            btnEToTheX.ForeColor = Color.Turquoise;
            btnNaturalLogarithm.ForeColor = Color.Turquoise;
            btnE.ForeColor = Color.Turquoise;
            btnPi.ForeColor = Color.Turquoise;
            btnTanH.ForeColor = Color.Turquoise;
            btnTan.ForeColor = Color.Turquoise;
            btnYRoot.ForeColor = Color.Turquoise;
            btnXToTheY.ForeColor = Color.Turquoise;
            btnAddMem.ForeColor = Color.Turquoise;
            btnMemClr.ForeColor = Color.Turquoise;
            btnCubed.ForeColor = Color.Turquoise;
            btnCubedRoot.ForeColor = Color.Turquoise;
            btnCos.ForeColor = Color.Turquoise;
            btnCosH.ForeColor = Color.Turquoise;
            btnSinH.ForeColor = Color.Turquoise;
            btnSin.ForeColor = Color.Turquoise;
            btnSqrt.ForeColor = Color.Turquoise;
            btnSquared.ForeColor = Color.Turquoise;
            btnLParen.ForeColor = Color.Turquoise;
            btnRParen.ForeColor = Color.Turquoise;
            btn2nd.ForeColor = Color.Turquoise;
            btnFraction.ForeColor = Color.Turquoise;
            btnFactorial.ForeColor = Color.Turquoise;
            btnRad.ForeColor = Color.Turquoise;
            btnDeg.ForeColor = Color.Turquoise;
            btnLog3.ForeColor = Color.Turquoise;
            btnLog2.ForeColor = Color.Turquoise;
            btnLogX.ForeColor = Color.Turquoise;
            btnMem2.ForeColor = Color.Turquoise;
        }
        public void BrownFont()
        {
            lblDisplay.ForeColor = Color.SaddleBrown;
            btnEquals.ForeColor = Color.SaddleBrown;
            btn0.ForeColor = Color.SaddleBrown;
            btn1.ForeColor = Color.SaddleBrown;
            btn2.ForeColor = Color.SaddleBrown;
            btn3.ForeColor = Color.SaddleBrown;
            btn4.ForeColor = Color.SaddleBrown;
            btn5.ForeColor = Color.SaddleBrown;
            btn6.ForeColor = Color.SaddleBrown;
            btn7.ForeColor = Color.SaddleBrown;
            btn8.ForeColor = Color.SaddleBrown;
            btn9.ForeColor = Color.SaddleBrown;
            btnDecimal.ForeColor = Color.SaddleBrown;
            btnAdd.ForeColor = Color.SaddleBrown;
            btnSubtract.ForeColor = Color.SaddleBrown;
            btnMultiply.ForeColor = Color.SaddleBrown;
            btnDivide.ForeColor = Color.SaddleBrown;
            btnClear.ForeColor = Color.SaddleBrown;
            btnPercentage.ForeColor = Color.SaddleBrown;
            btnPosNeg.ForeColor = Color.SaddleBrown;
            btnRand.ForeColor = Color.SaddleBrown;
            btnEE.ForeColor = Color.SaddleBrown;
            btnLog10.ForeColor = Color.SaddleBrown;
            btn10ToTheX.ForeColor = Color.SaddleBrown;
            btnMem.ForeColor = Color.SaddleBrown;
            btnSubMem.ForeColor = Color.SaddleBrown;
            btnEToTheX.ForeColor = Color.SaddleBrown;
            btnNaturalLogarithm.ForeColor = Color.SaddleBrown;
            btnE.ForeColor = Color.SaddleBrown;
            btnPi.ForeColor = Color.SaddleBrown;
            btnTanH.ForeColor = Color.SaddleBrown;
            btnTan.ForeColor = Color.SaddleBrown;
            btnYRoot.ForeColor = Color.SaddleBrown;
            btnXToTheY.ForeColor = Color.SaddleBrown;
            btnAddMem.ForeColor = Color.SaddleBrown;
            btnMemClr.ForeColor = Color.SaddleBrown;
            btnCubed.ForeColor = Color.SaddleBrown;
            btnCubedRoot.ForeColor = Color.SaddleBrown;
            btnCos.ForeColor = Color.SaddleBrown;
            btnCosH.ForeColor = Color.SaddleBrown;
            btnSinH.ForeColor = Color.SaddleBrown;
            btnSin.ForeColor = Color.SaddleBrown;
            btnSqrt.ForeColor = Color.SaddleBrown;
            btnSquared.ForeColor = Color.SaddleBrown;
            btnLParen.ForeColor = Color.SaddleBrown;
            btnRParen.ForeColor = Color.SaddleBrown;
            btn2nd.ForeColor = Color.SaddleBrown;
            btnFraction.ForeColor = Color.SaddleBrown;
            btnFactorial.ForeColor = Color.SaddleBrown;
            btnRad.ForeColor = Color.SaddleBrown;
            btnDeg.ForeColor = Color.SaddleBrown;
            btnLog3.ForeColor = Color.SaddleBrown;
            btnLog2.ForeColor = Color.SaddleBrown;
            btnLogX.ForeColor = Color.SaddleBrown;
            btnMem2.ForeColor = Color.SaddleBrown;
        }
        public void VioletFont()
        {
            lblDisplay.ForeColor = Color.DarkViolet;
            btnEquals.ForeColor = Color.DarkViolet;
            btn0.ForeColor = Color.DarkViolet;
            btn1.ForeColor = Color.DarkViolet;
            btn2.ForeColor = Color.DarkViolet;
            btn3.ForeColor = Color.DarkViolet;
            btn4.ForeColor = Color.DarkViolet;
            btn5.ForeColor = Color.DarkViolet;
            btn6.ForeColor = Color.DarkViolet;
            btn7.ForeColor = Color.DarkViolet;
            btn8.ForeColor = Color.DarkViolet;
            btn9.ForeColor = Color.DarkViolet;
            btnDecimal.ForeColor = Color.DarkViolet;
            btnAdd.ForeColor = Color.DarkViolet;
            btnSubtract.ForeColor = Color.DarkViolet;
            btnMultiply.ForeColor = Color.DarkViolet;
            btnDivide.ForeColor = Color.DarkViolet;
            btnClear.ForeColor = Color.DarkViolet;
            btnPercentage.ForeColor = Color.DarkViolet;
            btnPosNeg.ForeColor = Color.DarkViolet;
            btnRand.ForeColor = Color.DarkViolet;
            btnEE.ForeColor = Color.DarkViolet;
            btnLog10.ForeColor = Color.DarkViolet;
            btn10ToTheX.ForeColor = Color.DarkViolet;
            btnMem.ForeColor = Color.DarkViolet;
            btnSubMem.ForeColor = Color.DarkViolet;
            btnEToTheX.ForeColor = Color.DarkViolet;
            btnNaturalLogarithm.ForeColor = Color.DarkViolet;
            btnE.ForeColor = Color.DarkViolet;
            btnPi.ForeColor = Color.DarkViolet;
            btnTanH.ForeColor = Color.DarkViolet;
            btnTan.ForeColor = Color.DarkViolet;
            btnYRoot.ForeColor = Color.DarkViolet;
            btnXToTheY.ForeColor = Color.DarkViolet;
            btnAddMem.ForeColor = Color.DarkViolet;
            btnMemClr.ForeColor = Color.DarkViolet;
            btnCubed.ForeColor = Color.DarkViolet;
            btnCubedRoot.ForeColor = Color.DarkViolet;
            btnCos.ForeColor = Color.DarkViolet;
            btnCosH.ForeColor = Color.DarkViolet;
            btnSinH.ForeColor = Color.DarkViolet;
            btnSin.ForeColor = Color.DarkViolet;
            btnSqrt.ForeColor = Color.DarkViolet;
            btnSquared.ForeColor = Color.DarkViolet;
            btnLParen.ForeColor = Color.DarkViolet;
            btnRParen.ForeColor = Color.DarkViolet;
            btn2nd.ForeColor = Color.DarkViolet;
            btnFraction.ForeColor = Color.DarkViolet;
            btnFactorial.ForeColor = Color.DarkViolet;
            btnRad.ForeColor = Color.DarkViolet;
            btnDeg.ForeColor = Color.DarkViolet;
            btnLog3.ForeColor = Color.DarkViolet;
            btnLog2.ForeColor = Color.DarkViolet;
            btnLogX.ForeColor = Color.DarkViolet;
            btnMem2.ForeColor = Color.DarkViolet;
        }
        public void OrangeFont()
        {
            lblDisplay.ForeColor = Color.OrangeRed;
            btnEquals.ForeColor = Color.OrangeRed;
            btn0.ForeColor = Color.OrangeRed;
            btn1.ForeColor = Color.OrangeRed;
            btn2.ForeColor = Color.OrangeRed;
            btn3.ForeColor = Color.OrangeRed;
            btn4.ForeColor = Color.OrangeRed;
            btn5.ForeColor = Color.OrangeRed;
            btn6.ForeColor = Color.OrangeRed;
            btn7.ForeColor = Color.OrangeRed;
            btn8.ForeColor = Color.OrangeRed;
            btn9.ForeColor = Color.OrangeRed;
            btnDecimal.ForeColor = Color.OrangeRed;
            btnAdd.ForeColor = Color.OrangeRed;
            btnSubtract.ForeColor = Color.OrangeRed;
            btnMultiply.ForeColor = Color.OrangeRed;
            btnDivide.ForeColor = Color.OrangeRed;
            btnClear.ForeColor = Color.OrangeRed;
            btnPercentage.ForeColor = Color.OrangeRed;
            btnPosNeg.ForeColor = Color.OrangeRed;
            btnRand.ForeColor = Color.OrangeRed;
            btnEE.ForeColor = Color.OrangeRed;
            btnLog10.ForeColor = Color.OrangeRed;
            btn10ToTheX.ForeColor = Color.OrangeRed;
            btnMem.ForeColor = Color.OrangeRed;
            btnSubMem.ForeColor = Color.OrangeRed;
            btnEToTheX.ForeColor = Color.OrangeRed;
            btnNaturalLogarithm.ForeColor = Color.OrangeRed;
            btnE.ForeColor = Color.OrangeRed;
            btnPi.ForeColor = Color.OrangeRed;
            btnTanH.ForeColor = Color.OrangeRed;
            btnTan.ForeColor = Color.OrangeRed;
            btnYRoot.ForeColor = Color.OrangeRed;
            btnXToTheY.ForeColor = Color.OrangeRed;
            btnAddMem.ForeColor = Color.OrangeRed;
            btnMemClr.ForeColor = Color.OrangeRed;
            btnCubed.ForeColor = Color.OrangeRed;
            btnCubedRoot.ForeColor = Color.OrangeRed;
            btnCos.ForeColor = Color.OrangeRed;
            btnCosH.ForeColor = Color.OrangeRed;
            btnSinH.ForeColor = Color.OrangeRed;
            btnSin.ForeColor = Color.OrangeRed;
            btnSqrt.ForeColor = Color.OrangeRed;
            btnSquared.ForeColor = Color.OrangeRed;
            btnLParen.ForeColor = Color.OrangeRed;
            btnRParen.ForeColor = Color.OrangeRed;
            btn2nd.ForeColor = Color.OrangeRed;
            btnFraction.ForeColor = Color.OrangeRed;
            btnFactorial.ForeColor = Color.OrangeRed;
            btnRad.ForeColor = Color.OrangeRed;
            btnDeg.ForeColor = Color.OrangeRed;
            btnLog3.ForeColor = Color.OrangeRed;
            btnLog2.ForeColor = Color.OrangeRed;
            btnLogX.ForeColor = Color.OrangeRed;
            btnMem2.ForeColor = Color.OrangeRed;
        }
        public void YellowFont()
        {
            lblDisplay.ForeColor = Color.Gold;
            btnEquals.ForeColor = Color.Gold;
            btn0.ForeColor = Color.Gold;
            btn1.ForeColor = Color.Gold;
            btn2.ForeColor = Color.Gold;
            btn3.ForeColor = Color.Gold;
            btn4.ForeColor = Color.Gold;
            btn5.ForeColor = Color.Gold;
            btn6.ForeColor = Color.Gold;
            btn7.ForeColor = Color.Gold;
            btn8.ForeColor = Color.Gold;
            btn9.ForeColor = Color.Gold;
            btnDecimal.ForeColor = Color.Gold;
            btnAdd.ForeColor = Color.Gold;
            btnSubtract.ForeColor = Color.Gold;
            btnMultiply.ForeColor = Color.Gold;
            btnDivide.ForeColor = Color.Gold;
            btnClear.ForeColor = Color.Gold;
            btnPercentage.ForeColor = Color.Gold;
            btnPosNeg.ForeColor = Color.Gold;
            btnRand.ForeColor = Color.Gold;
            btnEE.ForeColor = Color.Gold;
            btnLog10.ForeColor = Color.Gold;
            btn10ToTheX.ForeColor = Color.Gold;
            btnMem.ForeColor = Color.Gold;
            btnSubMem.ForeColor = Color.Gold;
            btnEToTheX.ForeColor = Color.Gold;
            btnNaturalLogarithm.ForeColor = Color.Gold;
            btnE.ForeColor = Color.Gold;
            btnPi.ForeColor = Color.Gold;
            btnTanH.ForeColor = Color.Gold;
            btnTan.ForeColor = Color.Gold;
            btnYRoot.ForeColor = Color.Gold;
            btnXToTheY.ForeColor = Color.Gold;
            btnAddMem.ForeColor = Color.Gold;
            btnMemClr.ForeColor = Color.Gold;
            btnCubed.ForeColor = Color.Gold;
            btnCubedRoot.ForeColor = Color.Gold;
            btnCos.ForeColor = Color.Gold;
            btnCosH.ForeColor = Color.Gold;
            btnSinH.ForeColor = Color.Gold;
            btnSin.ForeColor = Color.Gold;
            btnSqrt.ForeColor = Color.Gold;
            btnSquared.ForeColor = Color.Gold;
            btnLParen.ForeColor = Color.Gold;
            btnRParen.ForeColor = Color.Gold;
            btn2nd.ForeColor = Color.Gold;
            btnFraction.ForeColor = Color.Gold;
            btnFactorial.ForeColor = Color.Gold;
            btnRad.ForeColor = Color.Gold;
            btnDeg.ForeColor = Color.Gold;
            btnLog3.ForeColor = Color.Gold;
            btnLog2.ForeColor = Color.Gold;
            btnLogX.ForeColor = Color.Gold;
            btnMem2.ForeColor = Color.Gold;
        }
        public void WhiteFont()
        {
            lblDisplay.ForeColor = Color.Ivory;
            btnEquals.ForeColor = Color.Ivory;
            btn0.ForeColor = Color.Ivory;
            btn1.ForeColor = Color.Ivory;
            btn2.ForeColor = Color.Ivory;
            btn3.ForeColor = Color.Ivory;
            btn4.ForeColor = Color.Ivory;
            btn5.ForeColor = Color.Ivory;
            btn6.ForeColor = Color.Ivory;
            btn7.ForeColor = Color.Ivory;
            btn8.ForeColor = Color.Ivory;
            btn9.ForeColor = Color.Ivory;
            btnDecimal.ForeColor = Color.Ivory;
            btnAdd.ForeColor = Color.Ivory;
            btnSubtract.ForeColor = Color.Ivory;
            btnMultiply.ForeColor = Color.Ivory;
            btnDivide.ForeColor = Color.Ivory;
            btnClear.ForeColor = Color.Ivory;
            btnPercentage.ForeColor = Color.Ivory;
            btnPosNeg.ForeColor = Color.Ivory;
            btnRand.ForeColor = Color.Ivory;
            btnEE.ForeColor = Color.Ivory;
            btnLog10.ForeColor = Color.Ivory;
            btn10ToTheX.ForeColor = Color.Ivory;
            btnMem.ForeColor = Color.Ivory;
            btnSubMem.ForeColor = Color.Ivory;
            btnEToTheX.ForeColor = Color.Ivory;
            btnNaturalLogarithm.ForeColor = Color.Ivory;
            btnE.ForeColor = Color.Ivory;
            btnPi.ForeColor = Color.Ivory;
            btnTanH.ForeColor = Color.Ivory;
            btnTan.ForeColor = Color.Ivory;
            btnYRoot.ForeColor = Color.Ivory;
            btnXToTheY.ForeColor = Color.Ivory;
            btnAddMem.ForeColor = Color.Ivory;
            btnMemClr.ForeColor = Color.Ivory;
            btnCubed.ForeColor = Color.Ivory;
            btnCubedRoot.ForeColor = Color.Ivory;
            btnCos.ForeColor = Color.Ivory;
            btnCosH.ForeColor = Color.Ivory;
            btnSinH.ForeColor = Color.Ivory;
            btnSin.ForeColor = Color.Ivory;
            btnSqrt.ForeColor = Color.Ivory;
            btnSquared.ForeColor = Color.Ivory;
            btnLParen.ForeColor = Color.Ivory;
            btnRParen.ForeColor = Color.Ivory;
            btn2nd.ForeColor = Color.Ivory;
            btnFraction.ForeColor = Color.Ivory;
            btnFactorial.ForeColor = Color.Ivory;
            btnRad.ForeColor = Color.Ivory;
            btnDeg.ForeColor = Color.Ivory;
            btnLog3.ForeColor = Color.Ivory;
            btnLog2.ForeColor = Color.Ivory;
            btnLogX.ForeColor = Color.Ivory;
            btnMem2.ForeColor = Color.Ivory;
        }
        public void BlackFont()
        {
            lblDisplay.ForeColor = Color.Black;
            btnEquals.ForeColor = Color.Black;
            btn0.ForeColor = Color.Black;
            btn1.ForeColor = Color.Black;
            btn2.ForeColor = Color.Black;
            btn3.ForeColor = Color.Black;
            btn4.ForeColor = Color.Black;
            btn5.ForeColor = Color.Black;
            btn6.ForeColor = Color.Black;
            btn7.ForeColor = Color.Black;
            btn8.ForeColor = Color.Black;
            btn9.ForeColor = Color.Black;
            btnDecimal.ForeColor = Color.Black;
            btnAdd.ForeColor = Color.Black;
            btnSubtract.ForeColor = Color.Black;
            btnMultiply.ForeColor = Color.Black;
            btnDivide.ForeColor = Color.Black;
            btnClear.ForeColor = Color.Black;
            btnPercentage.ForeColor = Color.Black;
            btnPosNeg.ForeColor = Color.Black;
            btnRand.ForeColor = Color.Black;
            btnEE.ForeColor = Color.Black;
            btnLog10.ForeColor = Color.Black;
            btn10ToTheX.ForeColor = Color.Black;
            btnMem.ForeColor = Color.Black;
            btnSubMem.ForeColor = Color.Black;
            btnEToTheX.ForeColor = Color.Black;
            btnNaturalLogarithm.ForeColor = Color.Black;
            btnE.ForeColor = Color.Black;
            btnPi.ForeColor = Color.Black;
            btnTanH.ForeColor = Color.Black;
            btnTan.ForeColor = Color.Black;
            btnYRoot.ForeColor = Color.Black;
            btnXToTheY.ForeColor = Color.Black;
            btnAddMem.ForeColor = Color.Black;
            btnMemClr.ForeColor = Color.Black;
            btnCubed.ForeColor = Color.Black;
            btnCubedRoot.ForeColor = Color.Black;
            btnCos.ForeColor = Color.Black;
            btnCosH.ForeColor = Color.Black;
            btnSinH.ForeColor = Color.Black;
            btnSin.ForeColor = Color.Black;
            btnSqrt.ForeColor = Color.Black;
            btnSquared.ForeColor = Color.Black;
            btnLParen.ForeColor = Color.Black;
            btnRParen.ForeColor = Color.Black;
            btn2nd.ForeColor = Color.Black;
            btnFraction.ForeColor = Color.Black;
            btnFactorial.ForeColor = Color.Black;
            btnRad.ForeColor = Color.Black;
            btnDeg.ForeColor = Color.Black;
            btnLog3.ForeColor = Color.Black;
            btnLog2.ForeColor = Color.Black;
            btnLogX.ForeColor = Color.Black;
            btnMem2.ForeColor = Color.Black;
        }
        //=============================COLOR THEMES======================================
        //Blue Theme
        private void BlueBack()
        {
            themeShrink = false;
            this.BackColor = Color.MidnightBlue;
            BackgroundDispose();
        }
        private void BlueButton()
        {
            invertClick = false;
            Inverted(invertClick);
            lblDisplay.BackColor = Color.CornflowerBlue;
            btnEquals.BackColor = Color.CornflowerBlue;
            btn0.BackColor = Color.CornflowerBlue;
            btn1.BackColor = Color.CornflowerBlue;
            btn2.BackColor = Color.CornflowerBlue;
            btn3.BackColor = Color.CornflowerBlue;
            btn4.BackColor = Color.CornflowerBlue;
            btn5.BackColor = Color.CornflowerBlue;
            btn6.BackColor = Color.CornflowerBlue;
            btn7.BackColor = Color.CornflowerBlue;
            btn8.BackColor = Color.CornflowerBlue;
            btn9.BackColor = Color.CornflowerBlue;
            btnDecimal.BackColor = Color.CornflowerBlue;
            btnAdd.BackColor = Color.CornflowerBlue;
            btnSubtract.BackColor = Color.CornflowerBlue;
            btnMultiply.BackColor = Color.CornflowerBlue;
            btnDivide.BackColor = Color.CornflowerBlue;
            btnClear.BackColor = Color.CornflowerBlue;
            btnPercentage.BackColor = Color.CornflowerBlue;
            btnPosNeg.BackColor = Color.CornflowerBlue;
            btnRand.BackColor = Color.CornflowerBlue;
            btnEE.BackColor = Color.CornflowerBlue;
            btnLog10.BackColor = Color.CornflowerBlue;
            btn10ToTheX.BackColor = Color.CornflowerBlue;
            btnMem.BackColor = Color.CornflowerBlue;
            btnSubMem.BackColor = Color.CornflowerBlue;
            btnEToTheX.BackColor = Color.CornflowerBlue;
            btnNaturalLogarithm.BackColor = Color.CornflowerBlue;
            btnE.BackColor = Color.CornflowerBlue;
            btnPi.BackColor = Color.CornflowerBlue;
            btnTanH.BackColor = Color.CornflowerBlue;
            btnTan.BackColor = Color.CornflowerBlue;
            btnYRoot.BackColor = Color.CornflowerBlue;
            btnXToTheY.BackColor = Color.CornflowerBlue;
            btnAddMem.BackColor = Color.CornflowerBlue;
            btnMemClr.BackColor = Color.CornflowerBlue;
            btnCubed.BackColor = Color.CornflowerBlue;
            btnCubedRoot.BackColor = Color.CornflowerBlue;
            btnCos.BackColor = Color.CornflowerBlue;
            btnCosH.BackColor = Color.CornflowerBlue;
            btnSinH.BackColor = Color.CornflowerBlue;
            btnSin.BackColor = Color.CornflowerBlue;
            btnSqrt.BackColor = Color.CornflowerBlue;
            btnSquared.BackColor = Color.CornflowerBlue;
            btnLParen.BackColor = Color.CornflowerBlue;
            btnRParen.BackColor = Color.CornflowerBlue;
            btn2nd.BackColor = Color.CornflowerBlue;
            btnFraction.BackColor = Color.CornflowerBlue;
            btnFactorial.BackColor = Color.CornflowerBlue;
            btnRad.BackColor = Color.CornflowerBlue;
            btnDeg.BackColor = Color.CornflowerBlue;
            btnLog3.BackColor = Color.CornflowerBlue;
            btnLog2.BackColor = Color.CornflowerBlue;
            btnLogX.BackColor = Color.CornflowerBlue;
            btnMem2.BackColor = Color.CornflowerBlue;
        }
        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlueBack();
            BlueButton();
        }
        //Blue Background
        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = false;
            if (!themeShrink)
                DefaultDisplay();
            BlueBack();
        }
        //Blue Buttons and Labels
        private void buttonsAndLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlueButton();
        }
        //Green Theme
        private void GreenBack()
        {
            themeShrink = false;
            this.BackColor = Color.DarkGreen;
            BackgroundDispose();
        }
        private void GreenButton()
        {
            invertClick = false;
            Inverted(invertClick);
            lblDisplay.BackColor = Color.MediumSeaGreen;
            btnEquals.BackColor = Color.MediumSeaGreen;
            btn0.BackColor = Color.MediumSeaGreen;
            btn1.BackColor = Color.MediumSeaGreen;
            btn2.BackColor = Color.MediumSeaGreen;
            btn3.BackColor = Color.MediumSeaGreen;
            btn4.BackColor = Color.MediumSeaGreen;
            btn5.BackColor = Color.MediumSeaGreen;
            btn6.BackColor = Color.MediumSeaGreen;
            btn7.BackColor = Color.MediumSeaGreen;
            btn8.BackColor = Color.MediumSeaGreen;
            btn9.BackColor = Color.MediumSeaGreen;
            btnDecimal.BackColor = Color.MediumSeaGreen;
            btnAdd.BackColor = Color.MediumSeaGreen;
            btnSubtract.BackColor = Color.MediumSeaGreen;
            btnMultiply.BackColor = Color.MediumSeaGreen;
            btnDivide.BackColor = Color.MediumSeaGreen;
            btnClear.BackColor = Color.MediumSeaGreen;
            btnPercentage.BackColor = Color.MediumSeaGreen;
            btnPosNeg.BackColor = Color.MediumSeaGreen;
            btnRand.BackColor = Color.MediumSeaGreen;
            btnEE.BackColor = Color.MediumSeaGreen;
            btnLog10.BackColor = Color.MediumSeaGreen;
            btn10ToTheX.BackColor = Color.MediumSeaGreen;
            btnMem.BackColor = Color.MediumSeaGreen;
            btnSubMem.BackColor = Color.MediumSeaGreen;
            btnEToTheX.BackColor = Color.MediumSeaGreen;
            btnNaturalLogarithm.BackColor = Color.MediumSeaGreen;
            btnE.BackColor = Color.MediumSeaGreen;
            btnPi.BackColor = Color.MediumSeaGreen;
            btnTanH.BackColor = Color.MediumSeaGreen;
            btnTan.BackColor = Color.MediumSeaGreen;
            btnYRoot.BackColor = Color.MediumSeaGreen;
            btnXToTheY.BackColor = Color.MediumSeaGreen;
            btnAddMem.BackColor = Color.MediumSeaGreen;
            btnMemClr.BackColor = Color.MediumSeaGreen;
            btnCubed.BackColor = Color.MediumSeaGreen;
            btnCubedRoot.BackColor = Color.MediumSeaGreen;
            btnCos.BackColor = Color.MediumSeaGreen;
            btnCosH.BackColor = Color.MediumSeaGreen;
            btnSinH.BackColor = Color.MediumSeaGreen;
            btnSin.BackColor = Color.MediumSeaGreen;
            btnSqrt.BackColor = Color.MediumSeaGreen;
            btnSquared.BackColor = Color.MediumSeaGreen;
            btnLParen.BackColor = Color.MediumSeaGreen;
            btnRParen.BackColor = Color.MediumSeaGreen;
            btn2nd.BackColor = Color.MediumSeaGreen;
            btnFraction.BackColor = Color.MediumSeaGreen;
            btnFactorial.BackColor = Color.MediumSeaGreen;
            btnRad.BackColor = Color.MediumSeaGreen;
            btnDeg.BackColor = Color.MediumSeaGreen;
            btnLog3.BackColor = Color.MediumSeaGreen;
            btnLog2.BackColor = Color.MediumSeaGreen;
            btnLogX.BackColor = Color.MediumSeaGreen;
            btnMem2.BackColor = Color.MediumSeaGreen;
        }
        private void OliveButton()
        {
            invertClick = false;
            Inverted(invertClick);
            lblDisplay.BackColor = Color.OliveDrab;
            btnEquals.BackColor = Color.OliveDrab;
            btn0.BackColor = Color.OliveDrab;
            btn1.BackColor = Color.OliveDrab;
            btn2.BackColor = Color.OliveDrab;
            btn3.BackColor = Color.OliveDrab;
            btn4.BackColor = Color.OliveDrab;
            btn5.BackColor = Color.OliveDrab;
            btn6.BackColor = Color.OliveDrab;
            btn7.BackColor = Color.OliveDrab;
            btn8.BackColor = Color.OliveDrab;
            btn9.BackColor = Color.OliveDrab;
            btnDecimal.BackColor = Color.OliveDrab;
            btnAdd.BackColor = Color.OliveDrab;
            btnSubtract.BackColor = Color.OliveDrab;
            btnMultiply.BackColor = Color.OliveDrab;
            btnDivide.BackColor = Color.OliveDrab;
            btnClear.BackColor = Color.OliveDrab;
            btnPercentage.BackColor = Color.OliveDrab;
            btnPosNeg.BackColor = Color.OliveDrab;
            btnRand.BackColor = Color.OliveDrab;
            btnEE.BackColor = Color.OliveDrab;
            btnLog10.BackColor = Color.OliveDrab;
            btn10ToTheX.BackColor = Color.OliveDrab;
            btnMem.BackColor = Color.OliveDrab;
            btnSubMem.BackColor = Color.OliveDrab;
            btnEToTheX.BackColor = Color.OliveDrab;
            btnNaturalLogarithm.BackColor = Color.OliveDrab;
            btnE.BackColor = Color.OliveDrab;
            btnPi.BackColor = Color.OliveDrab;
            btnTanH.BackColor = Color.OliveDrab;
            btnTan.BackColor = Color.OliveDrab;
            btnYRoot.BackColor = Color.OliveDrab;
            btnXToTheY.BackColor = Color.OliveDrab;
            btnAddMem.BackColor = Color.OliveDrab;
            btnMemClr.BackColor = Color.OliveDrab;
            btnCubed.BackColor = Color.OliveDrab;
            btnCubedRoot.BackColor = Color.OliveDrab;
            btnCos.BackColor = Color.OliveDrab;
            btnCosH.BackColor = Color.OliveDrab;
            btnSinH.BackColor = Color.OliveDrab;
            btnSin.BackColor = Color.OliveDrab;
            btnSqrt.BackColor = Color.OliveDrab;
            btnSquared.BackColor = Color.OliveDrab;
            btnLParen.BackColor = Color.OliveDrab;
            btnRParen.BackColor = Color.OliveDrab;
            btn2nd.BackColor = Color.OliveDrab;
            btnFraction.BackColor = Color.OliveDrab;
            btnFactorial.BackColor = Color.OliveDrab;
            btnRad.BackColor = Color.OliveDrab;
            btnDeg.BackColor = Color.OliveDrab;
            btnLog3.BackColor = Color.OliveDrab;
            btnLog2.BackColor = Color.OliveDrab;
            btnLogX.BackColor = Color.OliveDrab;
            btnMem2.BackColor = Color.OliveDrab;
        }
        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GreenBack();
            GreenButton();
        }
        //Green Background
        private void backgroundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GreenBack();
        }
        //Green Buttons and Labels
        private void buttonsAndLabelsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GreenButton();
        }
        //Red Theme
        private void RedBack()
        {
            themeShrink = false;
            this.BackColor = Color.Crimson;
            BackgroundDispose();
        }
        private void RedButton()
        {
            invertClick = false;
            Inverted(invertClick);
            lblDisplay.BackColor = Color.Firebrick;
            btnEquals.BackColor = Color.Firebrick;
            btn0.BackColor = Color.Firebrick;
            btn1.BackColor = Color.Firebrick;
            btn2.BackColor = Color.Firebrick;
            btn3.BackColor = Color.Firebrick;
            btn4.BackColor = Color.Firebrick;
            btn5.BackColor = Color.Firebrick;
            btn6.BackColor = Color.Firebrick;
            btn7.BackColor = Color.Firebrick;
            btn8.BackColor = Color.Firebrick;
            btn9.BackColor = Color.Firebrick;
            btnDecimal.BackColor = Color.Firebrick;
            btnAdd.BackColor = Color.Firebrick;
            btnSubtract.BackColor = Color.Firebrick;
            btnMultiply.BackColor = Color.Firebrick;
            btnDivide.BackColor = Color.Firebrick;
            btnClear.BackColor = Color.Firebrick;
            btnPercentage.BackColor = Color.Firebrick;
            btnPosNeg.BackColor = Color.Firebrick;
            btnRand.BackColor = Color.Firebrick;
            btnEE.BackColor = Color.Firebrick;
            btnLog10.BackColor = Color.Firebrick;
            btn10ToTheX.BackColor = Color.Firebrick;
            btnMem.BackColor = Color.Firebrick;
            btnSubMem.BackColor = Color.Firebrick;
            btnEToTheX.BackColor = Color.Firebrick;
            btnNaturalLogarithm.BackColor = Color.Firebrick;
            btnE.BackColor = Color.Firebrick;
            btnPi.BackColor = Color.Firebrick;
            btnTanH.BackColor = Color.Firebrick;
            btnTan.BackColor = Color.Firebrick;
            btnYRoot.BackColor = Color.Firebrick;
            btnXToTheY.BackColor = Color.Firebrick;
            btnAddMem.BackColor = Color.Firebrick;
            btnMemClr.BackColor = Color.Firebrick;
            btnCubed.BackColor = Color.Firebrick;
            btnCubedRoot.BackColor = Color.Firebrick;
            btnCos.BackColor = Color.Firebrick;
            btnCosH.BackColor = Color.Firebrick;
            btnSinH.BackColor = Color.Firebrick;
            btnSin.BackColor = Color.Firebrick;
            btnSqrt.BackColor = Color.Firebrick;
            btnSquared.BackColor = Color.Firebrick;
            btnLParen.BackColor = Color.Firebrick;
            btnRParen.BackColor = Color.Firebrick;
            btn2nd.BackColor = Color.Firebrick;
            btnFraction.BackColor = Color.Firebrick;
            btnFactorial.BackColor = Color.Firebrick;
            btnRad.BackColor = Color.Firebrick;
            btnDeg.BackColor = Color.Firebrick;
            btnLog3.BackColor = Color.Firebrick;
            btnLog2.BackColor = Color.Firebrick;
            btnLogX.BackColor = Color.Firebrick;
            btnMem2.BackColor = Color.Firebrick;
        }
        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RedBack();
            RedButton();
        }
        //Red Background
        private void backgroundToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RedBack();
        }
        //Red Buttons and Labels
        private void buttonsAndLabelsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RedButton();
        }
        //Orange Theme
        private void OrangeBack()
        {
            themeShrink = false;
            this.BackColor = Color.Orange;
            BackgroundDispose();
        }
        private void OrangeButton()
        {
            invertClick = false;
            Inverted(invertClick);
            lblDisplay.BackColor = Color.OrangeRed;
            btnEquals.BackColor = Color.OrangeRed;
            btn0.BackColor = Color.OrangeRed;
            btn1.BackColor = Color.OrangeRed;
            btn2.BackColor = Color.OrangeRed;
            btn3.BackColor = Color.OrangeRed;
            btn4.BackColor = Color.OrangeRed;
            btn5.BackColor = Color.OrangeRed;
            btn6.BackColor = Color.OrangeRed;
            btn7.BackColor = Color.OrangeRed;
            btn8.BackColor = Color.OrangeRed;
            btn9.BackColor = Color.OrangeRed;
            btnDecimal.BackColor = Color.OrangeRed;
            btnAdd.BackColor = Color.OrangeRed;
            btnSubtract.BackColor = Color.OrangeRed;
            btnMultiply.BackColor = Color.OrangeRed;
            btnDivide.BackColor = Color.OrangeRed;
            btnClear.BackColor = Color.OrangeRed;
            btnPercentage.BackColor = Color.OrangeRed;
            btnPosNeg.BackColor = Color.OrangeRed;
            btnRand.BackColor = Color.OrangeRed;
            btnEE.BackColor = Color.OrangeRed;
            btnLog10.BackColor = Color.OrangeRed;
            btn10ToTheX.BackColor = Color.OrangeRed;
            btnMem.BackColor = Color.OrangeRed;
            btnSubMem.BackColor = Color.OrangeRed;
            btnEToTheX.BackColor = Color.OrangeRed;
            btnNaturalLogarithm.BackColor = Color.OrangeRed;
            btnE.BackColor = Color.OrangeRed;
            btnPi.BackColor = Color.OrangeRed;
            btnTanH.BackColor = Color.OrangeRed;
            btnTan.BackColor = Color.OrangeRed;
            btnYRoot.BackColor = Color.OrangeRed;
            btnXToTheY.BackColor = Color.OrangeRed;
            btnAddMem.BackColor = Color.OrangeRed;
            btnMemClr.BackColor = Color.OrangeRed;
            btnCubed.BackColor = Color.OrangeRed;
            btnCubedRoot.BackColor = Color.OrangeRed;
            btnCos.BackColor = Color.OrangeRed;
            btnCosH.BackColor = Color.OrangeRed;
            btnSinH.BackColor = Color.OrangeRed;
            btnSin.BackColor = Color.OrangeRed;
            btnSqrt.BackColor = Color.OrangeRed;
            btnSquared.BackColor = Color.OrangeRed;
            btnLParen.BackColor = Color.OrangeRed;
            btnRParen.BackColor = Color.OrangeRed;
            btn2nd.BackColor = Color.OrangeRed;
            btnFraction.BackColor = Color.OrangeRed;
            btnFactorial.BackColor = Color.OrangeRed;
            btnRad.BackColor = Color.OrangeRed;
            btnDeg.BackColor = Color.OrangeRed;
            btnLog3.BackColor = Color.OrangeRed;
            btnLog2.BackColor = Color.OrangeRed;
            btnLogX.BackColor = Color.OrangeRed;
            btnMem2.BackColor = Color.OrangeRed;
        }
        private void orangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrangeBack();
            OrangeButton();
        }
        //Orange Background
        private void backgroundToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OrangeBack();
        }
        //Orange Buttons and Labels
        private void buttonsAndLabelsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OrangeButton();
        }
        //Yellow Theme
        private void YellowBack()
        {
            themeShrink = false;
            this.BackColor = Color.DarkGoldenrod;
            BackgroundDispose();
        }
        private void YellowButton()
        {
            invertClick = false;
            Inverted(invertClick);
            lblDisplay.BackColor = Color.Gold;
            btnEquals.BackColor = Color.Gold;
            btn0.BackColor = Color.Gold;
            btn1.BackColor = Color.Gold;
            btn2.BackColor = Color.Gold;
            btn3.BackColor = Color.Gold;
            btn4.BackColor = Color.Gold;
            btn5.BackColor = Color.Gold;
            btn6.BackColor = Color.Gold;
            btn7.BackColor = Color.Gold;
            btn8.BackColor = Color.Gold;
            btn9.BackColor = Color.Gold;
            btnDecimal.BackColor = Color.Gold;
            btnAdd.BackColor = Color.Gold;
            btnSubtract.BackColor = Color.Gold;
            btnMultiply.BackColor = Color.Gold;
            btnDivide.BackColor = Color.Gold;
            btnClear.BackColor = Color.Gold;
            btnPercentage.BackColor = Color.Gold;
            btnPosNeg.BackColor = Color.Gold;
            btnRand.BackColor = Color.Gold;
            btnEE.BackColor = Color.Gold;
            btnLog10.BackColor = Color.Gold;
            btn10ToTheX.BackColor = Color.Gold;
            btnMem.BackColor = Color.Gold;
            btnSubMem.BackColor = Color.Gold;
            btnEToTheX.BackColor = Color.Gold;
            btnNaturalLogarithm.BackColor = Color.Gold;
            btnE.BackColor = Color.Gold;
            btnPi.BackColor = Color.Gold;
            btnTanH.BackColor = Color.Gold;
            btnTan.BackColor = Color.Gold;
            btnYRoot.BackColor = Color.Gold;
            btnXToTheY.BackColor = Color.Gold;
            btnAddMem.BackColor = Color.Gold;
            btnMemClr.BackColor = Color.Gold;
            btnCubed.BackColor = Color.Gold;
            btnCubedRoot.BackColor = Color.Gold;
            btnCos.BackColor = Color.Gold;
            btnCosH.BackColor = Color.Gold;
            btnSinH.BackColor = Color.Gold;
            btnSin.BackColor = Color.Gold;
            btnSqrt.BackColor = Color.Gold;
            btnSquared.BackColor = Color.Gold;
            btnLParen.BackColor = Color.Gold;
            btnRParen.BackColor = Color.Gold;
            btn2nd.BackColor = Color.Gold;
            btnFraction.BackColor = Color.Gold;
            btnFactorial.BackColor = Color.Gold;
            btnRad.BackColor = Color.Gold;
            btnDeg.BackColor = Color.Gold;
            btnLog3.BackColor = Color.Gold;
            btnLog2.BackColor = Color.Gold;
            btnLogX.BackColor = Color.Gold;
            btnMem2.BackColor = Color.Gold;
        }
        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YellowBack();
            YellowButton();
        }
        //Yellow Background
        private void backgroundToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            YellowBack();
        }
        //Yellow Buttons and Labels
        private void buttonsAndLabelsToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            YellowButton();
        }
        //Cyan Theme
        private void CyanBack()
        {
            themeShrink = false;
            this.BackColor = Color.DarkSlateGray;
            BackgroundDispose();
        }
        private void CyanButton()
        {
            invertClick = false;
            Inverted(invertClick);
            lblDisplay.BackColor = Color.MediumTurquoise;
            btnEquals.BackColor = Color.MediumTurquoise;
            btn0.BackColor = Color.MediumTurquoise;
            btn1.BackColor = Color.MediumTurquoise;
            btn2.BackColor = Color.MediumTurquoise;
            btn3.BackColor = Color.MediumTurquoise;
            btn4.BackColor = Color.MediumTurquoise;
            btn5.BackColor = Color.MediumTurquoise;
            btn6.BackColor = Color.MediumTurquoise;
            btn7.BackColor = Color.MediumTurquoise;
            btn8.BackColor = Color.MediumTurquoise;
            btn9.BackColor = Color.MediumTurquoise;
            btnDecimal.BackColor = Color.MediumTurquoise;
            btnAdd.BackColor = Color.MediumTurquoise;
            btnSubtract.BackColor = Color.MediumTurquoise;
            btnMultiply.BackColor = Color.MediumTurquoise;
            btnDivide.BackColor = Color.MediumTurquoise;
            btnClear.BackColor = Color.MediumTurquoise;
            btnPercentage.BackColor = Color.MediumTurquoise;
            btnPosNeg.BackColor = Color.MediumTurquoise;
            btnRand.BackColor = Color.MediumTurquoise;
            btnEE.BackColor = Color.MediumTurquoise;
            btnLog10.BackColor = Color.MediumTurquoise;
            btn10ToTheX.BackColor = Color.MediumTurquoise;
            btnMem.BackColor = Color.MediumTurquoise;
            btnSubMem.BackColor = Color.MediumTurquoise;
            btnEToTheX.BackColor = Color.MediumTurquoise;
            btnNaturalLogarithm.BackColor = Color.MediumTurquoise;
            btnE.BackColor = Color.MediumTurquoise;
            btnPi.BackColor = Color.MediumTurquoise;
            btnTanH.BackColor = Color.MediumTurquoise;
            btnTan.BackColor = Color.MediumTurquoise;
            btnYRoot.BackColor = Color.MediumTurquoise;
            btnXToTheY.BackColor = Color.MediumTurquoise;
            btnAddMem.BackColor = Color.MediumTurquoise;
            btnMemClr.BackColor = Color.MediumTurquoise;
            btnCubed.BackColor = Color.MediumTurquoise;
            btnCubedRoot.BackColor = Color.MediumTurquoise;
            btnCos.BackColor = Color.MediumTurquoise;
            btnCosH.BackColor = Color.MediumTurquoise;
            btnSinH.BackColor = Color.MediumTurquoise;
            btnSin.BackColor = Color.MediumTurquoise;
            btnSqrt.BackColor = Color.MediumTurquoise;
            btnSquared.BackColor = Color.MediumTurquoise;
            btnLParen.BackColor = Color.MediumTurquoise;
            btnRParen.BackColor = Color.MediumTurquoise;
            btn2nd.BackColor = Color.MediumTurquoise;
            btnFraction.BackColor = Color.MediumTurquoise;
            btnFactorial.BackColor = Color.MediumTurquoise;
            btnRad.BackColor = Color.MediumTurquoise;
            btnDeg.BackColor = Color.MediumTurquoise;
            btnLog3.BackColor = Color.MediumTurquoise;
            btnLog2.BackColor = Color.MediumTurquoise;
            btnLogX.BackColor = Color.MediumTurquoise;
            btnMem2.BackColor = Color.MediumTurquoise;
        }
        private void cyanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CyanBack();
            CyanButton();
        }
        //Cyan Background
        private void backgroundToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            CyanBack();
        }
        //Cyan Buttons and Labels
        private void buttonsAndLabelsToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            CyanButton();
        }
        //Violet Theme
        private void VioletBack()
        {
            themeShrink = false;
            this.BackColor = Color.Purple;
            BackgroundDispose();
        }
        private void VioletButton()
        {
            invertClick = false;
            Inverted(invertClick);
            lblDisplay.BackColor = Color.Violet;
            btnEquals.BackColor = Color.Violet;
            btn0.BackColor = Color.Violet;
            btn1.BackColor = Color.Violet;
            btn2.BackColor = Color.Violet;
            btn3.BackColor = Color.Violet;
            btn4.BackColor = Color.Violet;
            btn5.BackColor = Color.Violet;
            btn6.BackColor = Color.Violet;
            btn7.BackColor = Color.Violet;
            btn8.BackColor = Color.Violet;
            btn9.BackColor = Color.Violet;
            btnDecimal.BackColor = Color.Violet;
            btnAdd.BackColor = Color.Violet;
            btnSubtract.BackColor = Color.Violet;
            btnMultiply.BackColor = Color.Violet;
            btnDivide.BackColor = Color.Violet;
            btnClear.BackColor = Color.Violet;
            btnPercentage.BackColor = Color.Violet;
            btnPosNeg.BackColor = Color.Violet;
            btnRand.BackColor = Color.Violet;
            btnEE.BackColor = Color.Violet;
            btnLog10.BackColor = Color.Violet;
            btn10ToTheX.BackColor = Color.Violet;
            btnMem.BackColor = Color.Violet;
            btnSubMem.BackColor = Color.Violet;
            btnEToTheX.BackColor = Color.Violet;
            btnNaturalLogarithm.BackColor = Color.Violet;
            btnE.BackColor = Color.Violet;
            btnPi.BackColor = Color.Violet;
            btnTanH.BackColor = Color.Violet;
            btnTan.BackColor = Color.Violet;
            btnYRoot.BackColor = Color.Violet;
            btnXToTheY.BackColor = Color.Violet;
            btnAddMem.BackColor = Color.Violet;
            btnMemClr.BackColor = Color.Violet;
            btnCubed.BackColor = Color.Violet;
            btnCubedRoot.BackColor = Color.Violet;
            btnCos.BackColor = Color.Violet;
            btnCosH.BackColor = Color.Violet;
            btnSinH.BackColor = Color.Violet;
            btnSin.BackColor = Color.Violet;
            btnSqrt.BackColor = Color.Violet;
            btnSquared.BackColor = Color.Violet;
            btnLParen.BackColor = Color.Violet;
            btnRParen.BackColor = Color.Violet;
            btn2nd.BackColor = Color.Violet;
            btnFraction.BackColor = Color.Violet;
            btnFactorial.BackColor = Color.Violet;
            btnRad.BackColor = Color.Violet;
            btnDeg.BackColor = Color.Violet;
            btnLog3.BackColor = Color.Violet;
            btnLog2.BackColor = Color.Violet;
            btnLogX.BackColor = Color.Violet;
            btnMem2.BackColor = Color.Violet;
        }
        private void violetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VioletBack();
            VioletButton();
        }
        //Violet Background
        private void backgroundToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            VioletBack();
        }
        //Voilet Buttons and Labels
        private void buttonsAndLabelsToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            VioletButton();
        }
        //Brown Theme
        private void BrownBack()
        {
            themeShrink = false;
            this.BackColor = Color.SaddleBrown;
            BackgroundDispose();
        }
        private void BrownButton() 
        {
            invertClick = false;
            Inverted(invertClick);
            lblDisplay.BackColor = Color.Peru;
            btnEquals.BackColor = Color.Peru;
            btn0.BackColor = Color.Peru;
            btn1.BackColor = Color.Peru;
            btn2.BackColor = Color.Peru;
            btn3.BackColor = Color.Peru;
            btn4.BackColor = Color.Peru;
            btn5.BackColor = Color.Peru;
            btn6.BackColor = Color.Peru;
            btn7.BackColor = Color.Peru;
            btn8.BackColor = Color.Peru;
            btn9.BackColor = Color.Peru;
            btnDecimal.BackColor = Color.Peru;
            btnAdd.BackColor = Color.Peru;
            btnSubtract.BackColor = Color.Peru;
            btnMultiply.BackColor = Color.Peru;
            btnDivide.BackColor = Color.Peru;
            btnClear.BackColor = Color.Peru;
            btnPercentage.BackColor = Color.Peru;
            btnPosNeg.BackColor = Color.Peru;
            btnRand.BackColor = Color.Peru;
            btnEE.BackColor = Color.Peru;
            btnLog10.BackColor = Color.Peru;
            btn10ToTheX.BackColor = Color.Peru;
            btnMem.BackColor = Color.Peru;
            btnSubMem.BackColor = Color.Peru;
            btnEToTheX.BackColor = Color.Peru;
            btnNaturalLogarithm.BackColor = Color.Peru;
            btnE.BackColor = Color.Peru;
            btnPi.BackColor = Color.Peru;
            btnTanH.BackColor = Color.Peru;
            btnTan.BackColor = Color.Peru;
            btnYRoot.BackColor = Color.Peru;
            btnXToTheY.BackColor = Color.Peru;
            btnAddMem.BackColor = Color.Peru;
            btnMemClr.BackColor = Color.Peru;
            btnCubed.BackColor = Color.Peru;
            btnCubedRoot.BackColor = Color.Peru;
            btnCos.BackColor = Color.Peru;
            btnCosH.BackColor = Color.Peru;
            btnSinH.BackColor = Color.Peru;
            btnSin.BackColor = Color.Peru;
            btnSqrt.BackColor = Color.Peru;
            btnSquared.BackColor = Color.Peru;
            btnLParen.BackColor = Color.Peru;
            btnRParen.BackColor = Color.Peru;
            btn2nd.BackColor = Color.Peru;
            btnFraction.BackColor = Color.Peru;
            btnFactorial.BackColor = Color.Peru;
            btnRad.BackColor = Color.Peru;
            btnDeg.BackColor = Color.Peru;
            btnLog3.BackColor = Color.Peru;
            btnLog2.BackColor = Color.Peru;
            btnLogX.BackColor = Color.Peru;
            btnMem2.BackColor = Color.Peru;
        }
        private void brownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrownBack();
            BrownButton();
        }
        //Brown Background
        private void backgroundToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            BrownBack();
        }
        //Brown Buttons and Labels
        private void buttonsAndLabelsToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            BrownButton();
        }
        //Silver Theme
        private void SilverBack()
        {
            themeShrink = false;
            this.BackColor = Color.Silver;
            BackgroundDispose();
        }
        private void SilverButton()
        {
            invertClick = false;
            Inverted(invertClick);
            lblDisplay.BackColor = Color.Silver;
            btnEquals.BackColor = Color.Silver;
            btn0.BackColor = Color.Silver;
            btn1.BackColor = Color.Silver;
            btn2.BackColor = Color.Silver;
            btn3.BackColor = Color.Silver;
            btn4.BackColor = Color.Silver;
            btn5.BackColor = Color.Silver;
            btn6.BackColor = Color.Silver;
            btn7.BackColor = Color.Silver;
            btn8.BackColor = Color.Silver;
            btn9.BackColor = Color.Silver;
            btnDecimal.BackColor = Color.Silver;
            btnAdd.BackColor = Color.Silver;
            btnSubtract.BackColor = Color.Silver;
            btnMultiply.BackColor = Color.Silver;
            btnDivide.BackColor = Color.Silver;
            btnClear.BackColor = Color.Silver;
            btnPercentage.BackColor = Color.Silver;
            btnPosNeg.BackColor = Color.Silver;
            btnRand.BackColor = Color.Silver;
            btnEE.BackColor = Color.Silver;
            btnLog10.BackColor = Color.Silver;
            btn10ToTheX.BackColor = Color.Silver;
            btnMem.BackColor = Color.Silver;
            btnSubMem.BackColor = Color.Silver;
            btnEToTheX.BackColor = Color.Silver;
            btnNaturalLogarithm.BackColor = Color.Silver;
            btnE.BackColor = Color.Silver;
            btnPi.BackColor = Color.Silver;
            btnTanH.BackColor = Color.Silver;
            btnTan.BackColor = Color.Silver;
            btnYRoot.BackColor = Color.Silver;
            btnXToTheY.BackColor = Color.Silver;
            btnAddMem.BackColor = Color.Silver;
            btnMemClr.BackColor = Color.Silver;
            btnCubed.BackColor = Color.Silver;
            btnCubedRoot.BackColor = Color.Silver;
            btnCos.BackColor = Color.Silver;
            btnCosH.BackColor = Color.Silver;
            btnSinH.BackColor = Color.Silver;
            btnSin.BackColor = Color.Silver;
            btnSqrt.BackColor = Color.Silver;
            btnSquared.BackColor = Color.Silver;
            btnLParen.BackColor = Color.Silver;
            btnRParen.BackColor = Color.Silver;
            btn2nd.BackColor = Color.Silver;
            btnFraction.BackColor = Color.Silver;
            btnFactorial.BackColor = Color.Silver;
            btnRad.BackColor = Color.Silver;
            btnDeg.BackColor = Color.Silver;
            btnLog3.BackColor = Color.Silver;
            btnLog2.BackColor = Color.Silver;
            btnLogX.BackColor = Color.Silver;
            btnMem2.BackColor = Color.Silver;
        }
        //Black and White Theme
        private void BlackBack()
        {
            themeShrink = false;
            this.BackColor = Color.Black;
            BackgroundDispose();
        }
        private void WhiteButton()
        {
            invertClick = false;
            Inverted(invertClick);
            lblDisplay.BackColor = Color.Ivory;
            btnEquals.BackColor = Color.Ivory;
            btn0.BackColor = Color.Ivory;
            btn1.BackColor = Color.Ivory;
            btn2.BackColor = Color.Ivory;
            btn3.BackColor = Color.Ivory;
            btn4.BackColor = Color.Ivory;
            btn5.BackColor = Color.Ivory;
            btn6.BackColor = Color.Ivory;
            btn7.BackColor = Color.Ivory;
            btn8.BackColor = Color.Ivory;
            btn9.BackColor = Color.Ivory;
            btnDecimal.BackColor = Color.Ivory;
            btnAdd.BackColor = Color.Ivory;
            btnSubtract.BackColor = Color.Ivory;
            btnMultiply.BackColor = Color.Ivory;
            btnDivide.BackColor = Color.Ivory;
            btnClear.BackColor = Color.Ivory;
            btnPercentage.BackColor = Color.Ivory;
            btnPosNeg.BackColor = Color.Ivory;
            btnRand.BackColor = Color.Ivory;
            btnEE.BackColor = Color.Ivory;
            btnLog10.BackColor = Color.Ivory;
            btn10ToTheX.BackColor = Color.Ivory;
            btnMem.BackColor = Color.Ivory;
            btnSubMem.BackColor = Color.Ivory;
            btnEToTheX.BackColor = Color.Ivory;
            btnNaturalLogarithm.BackColor = Color.Ivory;
            btnE.BackColor = Color.Ivory;
            btnPi.BackColor = Color.Ivory;
            btnTanH.BackColor = Color.Ivory;
            btnTan.BackColor = Color.Ivory;
            btnYRoot.BackColor = Color.Ivory;
            btnXToTheY.BackColor = Color.Ivory;
            btnAddMem.BackColor = Color.Ivory;
            btnMemClr.BackColor = Color.Ivory;
            btnCubed.BackColor = Color.Ivory;
            btnCubedRoot.BackColor = Color.Ivory;
            btnCos.BackColor = Color.Ivory;
            btnCosH.BackColor = Color.Ivory;
            btnSinH.BackColor = Color.Ivory;
            btnSin.BackColor = Color.Ivory;
            btnSqrt.BackColor = Color.Ivory;
            btnSquared.BackColor = Color.Ivory;
            btnLParen.BackColor = Color.Ivory;
            btnRParen.BackColor = Color.Ivory;
            btn2nd.BackColor = Color.Ivory;
            btnFraction.BackColor = Color.Ivory;
            btnFactorial.BackColor = Color.Ivory;
            btnRad.BackColor = Color.Ivory;
            btnDeg.BackColor = Color.Ivory;
            btnLog3.BackColor = Color.Ivory;
            btnLog2.BackColor = Color.Ivory;
            btnLogX.BackColor = Color.Ivory;
            btnMem2.BackColor = Color.Ivory;
        }
        private void blackWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlackBack();
            WhiteButton();
        }
        //Black Background
        private void backgroundToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            BlackBack();
        }
        //Ivory Buttons
        private void buttonsAndLabelsToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            WhiteButton();
        }
        //Inverted Theme
        private void InvertBack()
        {
            themeShrink = false;
            this.BackColor = Color.Ivory;
            BackgroundDispose();
        }
        private void InvertButton()
        {
            invertClick = true;
            Inverted(invertClick);
            lblDisplay.BackColor = Color.Black;
            btnEquals.BackColor = Color.Black;
            btn0.BackColor = Color.Black;
            btn1.BackColor = Color.Black;
            btn2.BackColor = Color.Black;
            btn3.BackColor = Color.Black;
            btn4.BackColor = Color.Black;
            btn5.BackColor = Color.Black;
            btn6.BackColor = Color.Black;
            btn7.BackColor = Color.Black;
            btn8.BackColor = Color.Black;
            btn9.BackColor = Color.Black;
            btnDecimal.BackColor = Color.Black;
            btnAdd.BackColor = Color.Black;
            btnSubtract.BackColor = Color.Black;
            btnMultiply.BackColor = Color.Black;
            btnDivide.BackColor = Color.Black;
            btnClear.BackColor = Color.Black;
            btnPercentage.BackColor = Color.Black;
            btnPosNeg.BackColor = Color.Black;
            btnRand.BackColor = Color.Black;
            btnEE.BackColor = Color.Black;
            btnLog10.BackColor = Color.Black;
            btn10ToTheX.BackColor = Color.Black;
            btnMem.BackColor = Color.Black;
            btnSubMem.BackColor = Color.Black;
            btnEToTheX.BackColor = Color.Black;
            btnNaturalLogarithm.BackColor = Color.Black;
            btnE.BackColor = Color.Black;
            btnPi.BackColor = Color.Black;
            btnTanH.BackColor = Color.Black;
            btnTan.BackColor = Color.Black;
            btnYRoot.BackColor = Color.Black;
            btnXToTheY.BackColor = Color.Black;
            btnAddMem.BackColor = Color.Black;
            btnMemClr.BackColor = Color.Black;
            btnCubed.BackColor = Color.Black;
            btnCubedRoot.BackColor = Color.Black;
            btnCos.BackColor = Color.Black;
            btnCosH.BackColor = Color.Black;
            btnSinH.BackColor = Color.Black;
            btnSin.BackColor = Color.Black;
            btnSqrt.BackColor = Color.Black;
            btnSquared.BackColor = Color.Black;
            btnLParen.BackColor = Color.Black;
            btnRParen.BackColor = Color.Black;
            btn2nd.BackColor = Color.Black;
            btnFraction.BackColor = Color.Black;
            btnFactorial.BackColor = Color.Black;
            btnRad.BackColor = Color.Black;
            btnDeg.BackColor = Color.Black;
            btnLog3.BackColor = Color.Black;
            btnLog2.BackColor = Color.Black;
            btnLogX.BackColor = Color.Black;
            btnMem2.BackColor = Color.Black;
        }
        private void invertedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertBack();
            InvertButton();
        }
        //Ivory Background
        private void backgroundToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            InvertBack();
        }
        //Inverted Buttons and Labels
        private void buttonsAndLabelsToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            InvertButton();
        }
        /*===========================END OF COLOR THEMES=================================
        //=============================================================================*/
        
        /*=============================SPORTS THEMES=====================================
        //=============================================================================*/
        /*=================================MLB===========================================
        //=============================================================================*/
        //Baltimore Orioles
        private void baltimoreOriolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[21];
            OrangeButton();
            CyanFont();
        }
        //Boston Red Sox
        private void bostonRedSoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[28];
            RedButton();
        }
        //Chicago White Sox
        private void chicagoWhiteSoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[33];
            InvertButton();
        }
        //Cleveland Indians
        private void clevelandIndiansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[16];
            InvertButton();
            RedFont();
        }
        //Detroit Tigers
        private void detriotTigersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[31];
            OrangeButton();
            BlueFont();
        }
        //Houston Astros
        private void houstonAstrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[7];
            BrownButton();
        }
        //Kansas City Royals
        private void kansasCityRoyalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[30];
            WhiteButton();
            BlueFont();
        }
        //Los Angeles Angels
        private void losAngelesAngelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[5];
            WhiteButton();
            RedFont();
        }
        //Minnesota Twins
        private void minnesottaTwinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[32];
            BlueButton();
            RedFont();
        }
        //New York Yankees
        private void newYorkYankeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[34];
            WhiteButton();
            CyanFont();
        }
        //Oakland A's
        private void oaklandAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[6];
            GreenButton();
        }
        //Seattle Mariners
        private void seattleMarinersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[17];
            InvertButton();
            BlueFont();
        }
        //Tampa Bay Rays
        private void tampaBayRaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[26];
            WhiteButton();
            BlueFont();
        }
        //Texas Rangers
        private void texasRangersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[25];
            InvertButton();
            RedFont();
        }
        //Toronto Blue Jays
        private void torontoBlueJaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[8];
            BlueButton();
            RedFont();
            
        }
        //Atlanta Braves
        private void atlantaBravesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[9];
            RedButton();
            BlueFont();
        }
        //Arizona Diamondbacks
        private void arizonaDiamondbacksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[13];
            InvertButton();
            RedFont();
        }
        //Chicago Cubs
        private void chicagoCubsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[12];
            BrownButton();
            RedFont();
        }
        //Cinncinatti Reds
        private void cinncinattiRedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[27]; 
            InvertButton();
        }
        //Colorado Rockies
        private void coloradoRockiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[29];
            VioletButton();
            WhiteFont();
        }
        //Los Angeles Dodgers
        private void losAngelesDodgersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[14];
            WhiteButton();
            BlueFont();
        }
        //Miami Marlins
        private void miamiMarlinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[18];
            BlueButton();
            OrangeFont();
        }
        //Milwaukee Brewers
        private void milwalkieBrewersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[10];
            RedButton();
            YellowFont();
        }
        //New York Mets
        private void newYorkMetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[19];
            OrangeButton();
            BlueFont();
        }
        //Pittsburgh Pirates
        private void pittsburgPiratesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[24];
            YellowButton();
        }
        //Philadelpia Phillies
        private void philidelphiaPhillesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[23]; 
            InvertButton();
            BlueFont();
        }
        //San Diego Padres
        private void sanDiegoPadresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[22];
            OrangeButton();
            WhiteFont();
        }
        //San Francisco Giants
        private void sanFranciscoGiantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[15];
            OrangeButton();
        }
        //St Louis Cardinals
        private void stLouisCardinalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[11];
            WhiteButton();
            RedFont();
        }
        //Washington Nationals
        private void washingtonNationalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[20];
            RedButton();
            WhiteFont();
        }

        /*=================================NHL===========================================
        //=============================================================================*/
        //Chicago Blackhawks
        private void chicagoBlackhawksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[114];
            InvertButton();
            RedFont();
        }
        //Colorado Avalanche
        private void coloradoAvalancheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[113];
            InvertButton();
            RedFont();
        }
        //Dallas Stars
        private void dallasStarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[141];
            InvertButton();
            GreenFont();
        }
        //Minnesota Wild
        private void minnesotaWildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[142];
            InvertButton();
            GreenFont();
        }
        //Nashville Predators
        private void nashvillePredatorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[135];
            InvertButton();
            YellowFont();
        }
        //St Louis Blues
        private void stLouisBluesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[116];
            InvertButton();
            BlueFont();
        }
        //Winnipeg Jets
        private void winnipegJetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[128];
            InvertButton();
            BlueFont();
        }
        //Boston Bruind
        private void bostonBruinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[117];
            InvertButton();
            YellowFont();
        }
        //Buffalo Sabres
        private void buffaloSabresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[138];
            InvertButton();
            YellowFont();
        }
        //Detroit Red Wings
        private void detroitRedWingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[137];
            InvertButton();
            RedFont();
        }
        //Florida Panthers
        private void floridaPanthersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[133];
            InvertButton();
            YellowFont();
        }
        //Montreal Canadiens
        private void montrealCanadiansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[118];
            InvertButton();
            BlueFont();
        }
        //Ottawa Senators
        private void ottawaSenatorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[139];
            InvertButton();
            YellowFont();
        }
        //Tampa Bay Lightning
        private void tampaBayLightningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[130];
            InvertButton();
            BlueFont();
        }
        //Toronto Maple Leafs
        private void torontoMapleLeafsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[131];
            InvertButton();
            BlueFont();
        }
        //Anaheim Ducks
        private void anaheimDucksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[123];
            InvertButton();
            OrangeFont();
        }
        //Arizona Coyotes
        private void arizonaCoyotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[121];
            InvertButton();
            RedFont();
        }
        //Calgary Flames
        private void calgaryFlamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[124];
            InvertButton();
            RedFont();
        }
        //Edmonton Oilers
        private void edmontonOilersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[132];
            InvertButton();
            OrangeFont();
        }
        //Los Angeles Kings
        private void losAnglesKingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[129];
            InvertButton();
            CyanFont();
        }
        //San Jose Sharks
        private void sanJoseSharksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[140];
            InvertButton();
            TealFont();
        }
        //Vancounver Canucks
        private void vancouverCanucksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[119];
            InvertButton();
            GreenFont();
        }
        //Carolina Hurricanes
        private void carolinaHurricanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[126];
            InvertButton();
            RedFont();
        }
        //Columbus Blue Jackets
        private void columbusBlueJacketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[115];
            InvertButton();
            RedFont();
        }
        //New Jersey Devils
        private void newJerseyDevilsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[122];
            InvertButton();
            RedFont();
        }
        //New York Islanders
        private void newYorkIslandersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[127];
            InvertButton();
            OrangeFont();
        }
        //New York Rangers
        private void newYorkRangersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[136];
            InvertButton();
            BlueFont();
        }
        //Philadelphia Flyers
        private void philadelphiaFlyersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[125];
            InvertButton();
            OrangeFont();
        }
        //Pittsburgh Penguins
        private void pittsburgPenguinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[134];
            InvertButton();
            YellowFont();
        }
        //Washington Capitals
        private void washingtonCapitalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[120];
            InvertButton();
            RedFont();
        }

        /*=================================NBA===========================================
        //=============================================================================*/
        //Boston Celtics
        private void bostonCelticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[55];
            WhiteButton();
            GreenFont();
        }
        //Brooklyn Nets
        private void brooklynNetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[67];
            RedButton();
            WhiteFont();
        }
        //New York Knicks
        private void newYorkKnicksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[63];
            InvertButton();
            OrangeFont();
        }
        //Philadelphia 76ers
        private void philadelphia76ersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[51];
            WhiteButton();
            RedFont();
        }
        //Toronto Raptors
        private void torontoRaptorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[72];
            RedButton();
        }
        //Golden State Warriors
        private void goldenStateWarriorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[79];
            InvertButton();
            YellowFont();
        }
        //Los Angeles Clippers
        private void losAngelesClippersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[56];
            RedButton();
        }
        //Pheonix Suns
        private void phoenixSunsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[75];
            OrangeButton();
        }
        //Los Angeles Lakers
        private void losAngelesLakersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[64];
            OrangeButton();
        }
        //Sacramento Kings
        private void sacramentoKingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[62];
            OrangeButton();
        }
        //Chicago Bulls
        private void chicagoBullsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[53];
            WhiteButton();
        }
        //Cleveland Cavaliers
        private void clevelandCavaliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[54];
            RedButton();
            YellowFont();
        }
        //Detriot Pistons
        private void detriotPistonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[71];
            InvertButton();
            CyanFont();
        }
        //Indiana Pacers
        private void indianaPacersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[69];
            CyanButton();
            YellowFont();
        }
        //Milwaukee Bucks
        private void milwukeeBucksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[52];
            InvertButton();
            GreenFont();
        }
        //Dallas Mavericks
        private void dallasMavericksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[66];
            BlueButton();
            WhiteFont();
        }
        //Houston Rockets
        private void houstonRocketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[73];
            InvertButton();
        }
        //Memphis Grizzlies
        private void memphisGrizzliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[57];
            InvertButton();
            YellowFont();
        }
        //New Orleans Pelicans
        private void newOrleansPelicansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[70];
            OrangeButton();
            WhiteFont();
        }
        //San Antonio Spurs
        private void sanAntonioSpursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[74];
            BlueButton();
        }
        //Atlanta Hawks
        private void atlantaHawksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[58];
            YellowButton();
            RedFont();
        }
        //Charlotte Hornets
        private void charlotteHornetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[60];
            OrangeButton();
            BlueFont();
        }
        //Miami Heat
        private void miamiHeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[59];
            OrangeButton();
        }
        //Orlando Magic
        private void orlandoMagicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[65];
            InvertButton();
            BlueFont();
        }
        //Washington Wizards
        private void washingtonWizardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[80];
            OrangeButton();
            WhiteFont();
        }
        //Denver Nuggets
        private void denverNuggetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[68];
            InvertButton();
            YellowFont();
        }
        //Minnesota Timberwolves
        private void minnesotaTimberwolvesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[77];
            CyanButton();
            CyanFont();
        }
        //Oklahoma City Thunder
        private void oklahomaCityThunderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[76];
            OrangeButton();
        }
        //Portland Trail Blazers
        private void portlandTrailBlazersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[78];
            InvertButton();
        }
        //Utah Jazz
        private void utahJazzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[61];
            VioletButton();
            YellowFont();
        }

        /*=================================MMA===========================================
        //=============================================================================*/
        //Anderson Silva
        private void andersonSilvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[35];
            OrangeButton();
        }
        //BJ Penn
        private void bJPennToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[36];
            InvertButton();
            RedFont();
        }
        //Chris Weidman
        private void chrisWeidmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[37];
            RedButton();
            BlueFont();
            lblDisplay.ForeColor = Color.Ivory;
        }
        //Chuck Liddell
        private void chuckLiddellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[38];
            InvertButton();
            BlueFont();
        }
        //Conor McGregor
        private void conorMcGregorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[39];
            GreenButton();
            OrangeFont();
        }
        //Daniel Cormier
        private void danielCormierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[40];
            InvertButton();
        }
        //Demetrious Johnson
        private void demetriousJohnsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[41];
            InvertButton();
        }
        //Dominick Cruz
        private void dominickCruzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[42];
            InvertButton();
        }
        //Fabricio Werdum
        private void fabricioWerdumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[43];
            InvertButton();
        }
        //George St Pierre
        private void georgeStPierreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[44];
            InvertButton();
            RedFont();
        }
        //Jon Jones
        private void jonJonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[45];
            InvertButton();
            RedFont();
        }
        //Jose Aldo
        private void joseAldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[46];
            InvertButton();
        }
        //Luke Rockhold
        private void lukeRockholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[47];
            InvertButton();
            BlueFont();
        }
        //Lyoto Machida
        private void lyotoMachidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[48];
            InvertButton();
            RedFont();
        }
        //Rafael Dos Anjos
        private void rafaelDosAnjosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[49];
            InvertButton();
            BlueFont();
        }
        //Ronda Rousey
        private void rondaRouseyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[50];
            InvertButton();
            RedFont();
        }

        /*==========================END OF SPORTS THEMES=================================
        //=============================================================================*/
        
        /*==============================MILITARY THEMES==================================
        //=============================================================================*/
        //USAF
        private void airForceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[0];
            InvertButton();
            BlueFont();
        }
        //USA
        private void armyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[1];
            YellowButton();
        }
        //USCG
        private void coastGuardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[2];
            WhiteButton();
            BlueFont();
        }
        //USMC
        private void marinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[3];
            RedButton();
        }
        //USN
        private void navyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[4];
            YellowButton();
            BlueFont();
        }

        /*===========================END OF MILITARY THEMES==============================
        //=============================================================================*/

        /*===============================TV SHOW THEMES==================================
        //=============================================================================*/
        //American Horror Story
        private void americanHorrorStoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[144];
            BlueButton();
        }
        //Archer
        private void archerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[145];
            RedButton();
        }
        //Bar Rescue
        private void barRescueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[146];
            OrangeButton();
        }
        //Bob's Burgers
        private void bobsBurgersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[147];
            GreenButton();
        }
        //Breaking Bad
        private void breakingBadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[148];
            InvertButton();
            YellowFont();
        }
        //Dexter
        private void dexterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[149];
            InvertButton();
            RedFont();
        }
        //Dragon Ball Z
        private void dragonBallZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[150];
            BlueButton();
            OrangeFont();
        }
        //Family Guy
        private void familyGuyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[151];
            CyanButton();
        }
        //Game Of Thrones
        private void gameOfThronesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[152];
            InvertButton();
            CyanFont();
        }
        //Heroes
        private void heroesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[153];
            BlueButton();
        }
        //House of Cards
        private void houseOfCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[154];
            RedButton();
        }
        //Always Sunny
        private void itsAlwaysSunnyInPhiladelphiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[143];
            InvertButton();
            YellowFont();
        }
        //Knight Rider
        private void tmrKnightRider_Tick(object sender, EventArgs e)
        {
            if (forward == true)
            {
                if (lblKR1.Right < 1200)
                {
                    lblKR1.Left += 10;
                    if (lblKR1.Right == 1200) forward = false;
                }
            }
            if (forward == false)
            {
                if (lblKR1.Left > (50))
                {
                    lblKR1.Left -= 10;
                    if (lblKR1.Left == 50) forward = true;
                } 
            }
        }
        private void knightRiderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            knightRiderOn = true;
            StartKnight();
            this.BackgroundImage = myThemeImage[156];
            InvertButton();
            RedFont();
        }
        //LOST
        private void lOSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[157];
            InvertButton();
        }
        //The Office
        private void theOfficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[167];
            InvertButton();
        }
        //Oz
        private void oZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[158];
            CyanButton();
        }
        //Parks and Rec
        private void parksAndRecreationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[159];
            BrownButton();
        }
        //Pokemon
        private void pokemonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[161];
            InvertButton();
            YellowFont();
        }
        //Robot Chicken
        private void robotChickenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[162];
            RedButton();
        }
        //The Simpsons
        private void theSimpsonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[168];
            InvertButton();
        }
        //SNL
        private void saturdayNightLiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[164];
            InvertButton();
        }
        //Silicon Valley
        private void siliconValleyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[163];
            InvertButton();
        }
        //VEEP
        private void veepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[170];
            InvertButton();
        }
        //Weeds
        private void weedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[173];
            GreenButton();
        }

        /*=========================END OF TV SHOW THEMES=================================
        //=============================================================================*/

        /*===========================VIDEO GAME THEMES===================================
        ===============================================================================*/
        //Alan Wake
        private void alanWakeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[174];
            BlueButton();
        }
        //Assassins Creed
        private void assassinsCreedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[176];
            CyanButton();
        }
        //Banjo Kazooie
        private void banjoKazooieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[177];
            OrangeButton();
        }
        //Bioshock
        private void bioShockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[179];
            CyanButton();
        }
        //Call of Duty
        private void callOfDutyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[182];
            BrownButton();
        }
        //Castlevania
        private void castlevanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[180];
            VioletButton();
        }
        //Charlie Murder
        private void charlieMurderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[181];
            VioletButton();
        }
        //Destiny
        private void destinyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[185];
            BlueButton(); 
            WhiteFont();
        }
        //Fable
        private void fableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[187];
            BrownButton();
        }
        //Forza
        private void forzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[189];
            InvertButton();
            OrangeFont();
        }
        //Gears of War
        private void gearsOfWarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[190];
            InvertButton();
            RedFont();
        }
        //GoldenEye 007
        private void goldenEye007ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[191];
            InvertButton();
            GreenFont();
        }
        //Halo
        private void haloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[193];
            CyanButton();
        }
        //Killer Instinct
        private void killerInstinctToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[197];
            BlueButton();
            OrangeFont();
            
        }
        //Kirby's Dreamland
        private void kirbysDreamlandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[198];
            GreenButton();
        }
        //Krusty's Super Fun House
        private void krustysSuperFunHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[199];
            BrownButton();
        }
        //Legend of Zelda
        private void legendOfZeldaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[223];
            BlueButton();
            RedFont();
        }
        //Minecraft
        private void minecraftToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[203];
            YellowButton();
        }
        //Ori and The Blind Forest
        private void oriAndTheBlindForrestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[207];
            BlueButton();
            YellowFont();
        }
        //Pacman
        private void pacmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[208];
            InvertButton();
            BlueFont();
        }
        //Pokemon Snap
        private void pokemonSnapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[210];
            YellowButton();
            OrangeFont();
        }
        //South Park: The Stick of Truth
        private void southParkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[215];
            OrangeButton();
        }
        //Super Mario Bros.
        private void superMarioBrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[200];
            BrownButton();
            BlueFont();
        }
        //UFC Undisputed
        private void uFCUndisputedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[218];
            InvertButton();
            RedFont();
        }
        //The Witcher 3
        private void theWitcherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[220];
            GreenButton();
        }
        //Yoshi's Story
        private void yoshisStoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[222];
            BrownButton();
        }
        //Zombies Ate My Neighbors
        private void zombiesAteMyNeighborsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeShrink = true;
            BackgroundDispose();
            this.BackgroundImage = myThemeImage[224];
            OrangeButton();
        }

        /*===============================END OF THEMES===================================
        =================================================================================
        ===============================================================================*/

        /*=============================MENU STRIPS=====================================
        ===============================================================================
        ===============================================================================
        ===============================================================================
        ===============================================================================
        ===============================================================================
        =============================================================================*/
        //Info->Credits Menu Strip
        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Independently developed by Geoff Overfield\nProgramming by Geoff Overfield\n"+
            "UI Development by Geoff Overfield\nUX Development by Geoff Overfield", "Credits",
            MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        //Info->Legal Menu Strip
        private void legalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("With respect to Images and/or Sounds Associated (*henceforth known as content) with 'Themes' within this application:\n\n" +
            "Geoff Overfield or BOSS Games does not own any of the content included in this application that is included in these 'Themes'\n\n" +
            "The content for the following 'Themes' and all of it's rights belong to the following companies, organizations, developers or publishers:\n\n" + 
            "//ENTER YOUR (COMPANY/ORGANIZATION/PUBLISHER/DEVELOPER)'S\n NAME AND TITLE OF IP HERE WITH ALL COPYWRITE AND/OR LICENSING INFORMATION WITH HYPERLINKS TO APPROPRIATE WEBSITES", 
            "Legal Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        //Funtion to quit and close calculator from menu strip
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisposeImages();
            DisposeSound();
            Application.Exit();
        }
        //Want More? Menu Strip
        private void wantMoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Want more?  We want to hear all about it!\n\nSend any of your requests or suggestions to:\nbossgamesdevteam@gmail.com\n\nIf we can make it happen, we will!");
        }
        //What Does the MR Button Do?
        private void mrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The 'mr' Button stores the value that is in the display to memory as a variable.\n" +
                "This variable can then be used later in the same or seperate equations.", "What Does The mr Button Do?",MessageBoxButtons.OK, MessageBoxIcon.Question);
            
        }
        //What Does the M- Button Do?
        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The 'm-' Button is used to SUBTRACT the variable stored in memory (mr)\n" +
                "from the current value in the display.", "What Does The m- Button Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What Does the M+ Button Do?
        private void mToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The 'm+' Button is used to ADD the variable stored in memory (mr)" +
                "to the current value in the display.", "What Does The m+ Button Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What Does the MC Button Do?
        private void mcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The 'mc' Button is used to remove, or clear-out the variable stored in the memory (mr)",
                "What Does The mr Button Do?",MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What Does the e Button Do?
        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The 'e' Button will place the constant mathematical value of 'e' in to the display."
                , "What Does The e Button Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What Does the EE Button Do?
        private void eEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The 'EE' Button will return a value of 'x' times 10 to the power of the 'x' where 'x' is the value in the display when the button is clicked.\n\n" + 
                "For example, is there is a 2 in the display when the 'EE' Button is clicked, it will return a value of 200"
                , "What Does The EE Button Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What Does the +/- Button Do?
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The '+/-' Button, or Positive/Negative Button will return the inverse value of what is displayed.\n\n" +
                "For example, if 150 is displayed, it will return a value of -150.  If -150 is displayed, it will return 150"
                , "What Does The +/- Button Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What Does the % Button Do?
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The '%' or Percentage Button will return a decimal value which reflects how the number would be displayed\n" +
                "on a number line.  For example, if you wanted to get a decimal value for 67%, this button will return a value of .67.\n" +
                "Percentages larger than 100% will return larger decimals with integers to the left of the decimal point.\n" +
                "For example, 150% shows as 1.5; 275% shows as 2.75."
                , "What Does The % Button Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What Does the x! Button Do?
        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The x! Button is known as the Factorial Button.\n" +
                "This function returns a value of the integer displayed multiplied by every positive integer below it.\n" +
                "For example, a Factorial of 10 will return a value of 3,628,800.  This is because the calculator multiplied:\n" +
                "1 x 2 x 3 x 4 x 5 x 6 x 7 x 8 x 9 x 10\n\n" +
                "For more help with Multiplication, see our tutorials under the Arithmetic Functions tab"
                , "What Does The x! Button Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What Does the 1/x Button Do?
        private void xToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The '1/x' Button, or Fraction Button, will return a decimal value of what 1/x equals.\n" +
                "'x' is the varible in the display at the time the button is clicked.\n" +
                "For example, 1/5 returns a value of .2; 1/10 returns a value of .1\n\n" +
                "For more help with Fractions, see our tutorials under the Arithmetic Functions tab"
                , "What Does The 1/x Button Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What Does the e^x Button Do?
        private void exToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The 'e^x' Button will return a value of the constant mathematical value of e to the 'x' power\n" +
                "where 'x' is the value in the display at the time the button is clicked.\n\n" +
                "For more help with Exponents, see our tutorials under the Exponential Functions tab"
                , "What Does The e^x Button Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What Does the 10^x Button Do?
        private void xToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The 10^x Button will return a value of 10 to the 'x' power\n" +
                "where 'x' is the value in the display at the time the button is clicked.\n\n" +
                "For more help with Exponents, see our tutorials under the Exponential Functions tab"
                , "What Does The 10^x Button Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What do the sin/sinh Buttons Do?
        private void sinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The sin Button is used for Trigonometry Functions.\n" +
                "It returns the sin of angle 'x' where 'x' is the value in the display\n" +
                "at the time the button is clicked.\n\n" +
                "The sinh Button returns the hyperbolic sin of angle 'x'.\n\n" +
                "For more information on sin/sinh, see our tutorials on Trigonomtry Functions"
                , "What Do The sin/sinh Buttons Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What do the cos/cosh Buttons Do?
        private void cosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The cos Button is used for Trigonometry Functions.\n" +
                "It returns the cosine of angle 'x' where 'x' is the value in the display\n" +
                "at the time the button is clicked.\n\n" +
                "The cosh Button returns the hyperbolic cosine of angle 'x'.\n\n" +
                "For more information on cos/cosh, see our tutorials on Trigonomtry Functions"
                , "What Do The cos/cosh Buttons Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What do the tan/tanh Buttons Do?
        private void tanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The tan Button is used for Trigonometry Functions.\n" +
                "It returns the tangent of angle 'x' where 'x' is the value in the display\n" +
                "at the time the button is clicked.\n\n" +
                "The tanh Button returns the hyperbolic tangent of angle 'x'.\n\n" +
                "For more information on tan/tanh, see our tutorials on Trigonomtry Functions"
                , "What Do The tan/tanh Buttons Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What Does the ln Button Do?
        private void lnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The 'ln' Button performs what is known as a 'Natural Logarithm'\n" +
                "A Natural Logarithm operates with a base of e.\n\n" +
                "For More information on Logarithms, see our tutorials under the Logarithmic Functions tab"
                , "What Does The ln Button Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What does the log2 Button Do?
        private void log2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The 'log2' Button performs a logarithm with a base of 2.\n\n" +
                "For More information on Logarithms, see our tutorials under the Logarithmic Functions tab"
                , "What Does The log2 Button Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What does the log3 Button Do?
        private void log3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The 'log3' Button performs a logarithm with a base of 3.\n\n" +
                "For More information on Logarithms, see our tutorials under the Logarithmic Functions tab"
                , "What Does The log3 Button Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What does the log10 Button Do?
        private void log10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The 'log10' Button performs a logarithm with a base of 10.\n\n" +
                "For More information on Logarithms, see our Tutorials under the Logarithmic Functions tab"
                , "What Does The log10 Button Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //What does the logX Button Do?
        private void logXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The 'logX' Button performs a logarithm with a base of 2.\n\n" +
                "For More information on Logarithms, see our tutorials under the Logarithmic Functions tab"
                , "What Does The logX Button Do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        //How Do I Use Arithmetic Functions?
        private void arithmeticFunctionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Arithmetic:
            if (MessageBox.Show("There are four basic Arithmetic Functions offered by this calculator:\n" +
            "1.\tAddition\n2.\tSubtraction\n3.\tMultiplication, and\n4.\tDivision\n\n" +
            "Click 'Yes' you would like to see how to use the Addition Function, or 'No' TO QUIT",
            "Arithmetic Functions", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (MessageBox.Show("To use the Addition function, enter the first number, or variable\n" +
                "in to the display by clicking the numbers on the pad, or by using your keyboard.\n\n" +
                "Then click the '+' button.  This will store the value of the first variable to the\n" +
                "calculators memory.  It will also clear out the display to ready for the next variable.\n\n" +
                "After entering your second variable, click the '=' button, and it will display the final solution.\n" +
                "This number can be used to continue ADDing without clicking the '=' Button.\n\n" +
                "To move on to SUBTRACTION, click 'Yes', or click 'No' to QUIT this tutorial", "How to use ADDITION",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (MessageBox.Show("To use the Subtraction function, enter the first number, or variable\n" +
                    "in to the display by clicking the numbers on the pad, or by using your keyboard.\n\n" +
                    "Then click the '-' button.  This will store the value of the first variable to the\n" +
                    "calculators memory.  It will also clear out the display to ready for the next variable.\n\n" +
                    "After entering your second variable, click the '=' button, and it will display the final solution.\n" +
                    "This number can be used to continue SUBTRACTing, but the equals sign MUST be clicked EVERY TIME.\n\n" +
                    "To move on to MULTIPLICATION, click 'Yes', or click 'No' to QUIT this tutorial", "How To Use SUBTRACTION",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("To use the Multiplication function, enter the first number, or variable\n" +
                        "in to the display by clicking the numbers on the pad, or by using your keyboard.\n\n" +
                        "Then click the 'x' button.  This will store the value of the first variable to the\n" +
                        "calculators memory.  It will also clear out the display to ready for the next variable.\n\n" +
                        "After entering your second variable, click the '=' button, and it will display the final solution.\n" +
                        "This number can be used to continue ADDing, but the equals sign MUST be clicked EVERY TIME.\n\n" +
                        "To move on to DIVISION, click 'Yes', or click 'No' to QUIT this tutorial", "How to use MULTIPLICATION",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("To use the Division function, enter the first number, or variable\n" +
                            "in to the display by clicking the numbers on the pad, or by using your keyboard.\n\n" +
                            "Then click the '÷' button.  This will store the value of the first variable to the\n" +
                            "calculators memory.  It will also clear out the display to ready for the next variable.\n\n" +
                            "After entering your second variable, click the '=' button, and it will display the final solution.\n" +
                            "This number can be used to continue DIVIDEing, but the equals sign MUST be clicked EVERY TIME.\n\n" +
                            "To RESTART this tutorial, click 'Yes', or click 'No' to QUIT this tutorial", "How To Use DIVISION", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                goto Arithmetic;
                            }
                        }
                    }
                }
            }
            

        }
        //How Do I Use Exponential Functions?
        private void exponentialFunctionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exponents:
            if (MessageBox.Show("There are two main groups of Exponential Functions on this" +
            " calculator (and most others).  They are:\n" +
            "1.\tExponential Functions, and\n2.\tRoot Functions\n\n" +
            "Click 'Yes' if you would like to see how to use Exponential Functions, click 'No' TO QUIT", "Exponential Functions", 
            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (MessageBox.Show("You will notice that there are several basic Exponent buttons.  They are:\n" +
                "1.\tx^2\n2.\tx^3\n3.\tx^y\n4.\te^x, and\n5.\t10^x\n\n" +
                "Number 1 provides the square of a number, and Number 2 the cube.\n\n" +
                "For example, if you enter a base integer of 5 and click the x^2 Button, it will return a value of 25.  " +
                "That is because Exponents multiply the base number by itself as many times as deemed by the Exponent.\n\n" +
                "By that, 5^2 is really saying 5 x 5.  5^3, or 5 cubed, is really saying 5 x 5 x 5, and returns a value of 125.\n\n" +
                "To move on to x^y, click 'Yes', or click 'No' to QUIT this tutorial", "Using Exponents",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (MessageBox.Show("Like the Squared and Cubed Buttons, the x^y, or (X) to the (Y), also looks for the base number first.\n\n" +
                    "The main differnece between this function and the previous is that YOU input the exponent." +
                    "Begin by selecting your base number, or your (X).  Then click the x^y button.  This will clear the display and store your X variable." +
                    "  Next, select your Exponent, or (Y) variable.  After your have eneterd your Y variable, click the '=' Button and you will be given your result.\n\n" +
                    "For example, if you select a base (X) of 4 and an exponent (Y) of 6, you want the calculator to give you 4^6, or\n\t\t4 x 4 x 4 x 4 x 4 x 4\n\n" +
                    "To move on to e^x, click 'Yes', or click 'No' to QUIT this tutorial", "Using X to the Y", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("The e^x, or (e) to the (X), Button differs from our other buttons slightly." +
                        "  Previously, we were selecting a base (X).  For this function, we have a base of the constant mathematical value of (e)." +
                        "  This button's (X) value is the exponent to which we are applying to (e)\n\n" +
                        "To use this function, simply select your exponential value (X) and click the button.  Your result will be displayed.\n\n" +
                        "To move on to 10^x, click 'Yes', or click 'No' to QUIT this tutorial", "Using e to the X",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("The 10^x, or (10) to the (X), Button is exactly like our e^x Button." +
                            "  Previously, we were selecting a base (X).  For this function, we have a base of (10)." +
                            "  This button's (X) value is the exponent to which we are applying to (10)\n\n" +
                            "To use this function, simply select your exponential value (X) and click the button.  Your result will be displayed.\n\n" +
                            "To move on to Root Functions, click 'Yes', or click 'No' to QUIT this tutorial", "Using 10 to the X",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                if (MessageBox.Show("You will notice that there are three Root buttons.  They are:\n" +
                                "1.\t2√x\n2.\t3√x\n3.\ty√x\n\n" + 
                                "The first thing that we need to understand is that Root Functions are the EXACT OPPOSITE of EXPONENTIAL FUNCTIONS; " +
                                "Much like how division is the opposite of multiplication.\n\n" +
                                "Number 1 provides the square root of a number, and Number 2 the cubed root.\n\n" +
                                "For example, if you enter a base integer of 25 and click the 2√x Button, it will return a value of 5.  " +
                                "That is because Roots ask a question, rather than make a statement.\n\n" +
                                "By that, the question is this: 'What number times itself will return a value of (X).\n\n" +
                                "Square Roots can be shown like this:\n\t\t2√25 = X\n\t\tX x X = 25\n\t\tX = ?\n\n" +
                                "For our Square and Cubed Root Functions, enter your base number and click the button." +
                                "The calculator will give you the root." +
                                "To move on to y√x, click 'Yes', or click 'No' to QUIT this tutorial", "Using Roots",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    if (MessageBox.Show("The difference between the Square Root and Cubed Root Buttons, and the (Y) Root Button is obvious:  " +
                                    "YOU are selecting the 'Root Of' Value.n\n" +
                                    "Previous, we were trying to get the 2nd Root or 3rd Root of a variable.  But what happens when we need to " +
                                    "use a larger root?  Let's say we need to know what the 6th root of 961.389...\n\n" +
                                    "Fortunately, we are stiil posed with the same question: 'What number times itself will return a value of (X).\n\n" +
                                    "Our 6th Root can be shown like this:\n\t\t6√961.389 = X\n\t\tX x X x X x X x X x X = 961.389\n\t\tX = ?\n\n" +
                                    "For our Y Root Function, enter your base number (X) and click the 'y√x' button.  The display will clear, and store our X value." +
                                    "Then input our (Y) Value, and click the '=' Button.  " +
                                    "The calculator will give you the root.\n\n" +
                                    "See?...  It's not so hard!!  In fact, it's as easy as Pi!\n\n" +
                                    "To REPEAT this tutorial, click 'Yes', or click 'No' to QUIT this tutorial", "Using Y√X - Y Root of X",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                    {
                                        goto Exponents;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //How Do I Use Logarithmic Functions?
        private void logarithmicFunctionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logarithms:
            if (MessageBox.Show("The Logarithmic Functions performed by this calulator (and many others) " +
            " solve Logarithms with a given base.  Buttons you will see on this calculator offer bases of:\n" +
            "1.\t(2)\n2.\t(3)\n3.\t(10)\n4.\t(e), and\n5.\t(X)\n\n" +
            "For Tutorials on what Logarithms are, see our lesson on Logarithms under the Tutorials Tab\n\n" +
            "To CONTINUE to Using Logarithms, click 'Yes', or click 'No' to QUIT this tutorial", "Logarithmic Functions", 
            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (MessageBox.Show("The Logairthmic Functions performed by this calculator (and many others) will return the exponential (T) solution of Logarithms for the given result (R)." +
                "The standard bases of (2), (3), and (10) are shown as 'log2', 'log3', and 'log10' respectively.\n\n" +
                "Let's breifly clarify that last part with the following equation:\n" +
                "\t\t(R) = 64\n\t\tlog2(64) = (T)\nWe are searching for (T)...\nThis can be re-written as:\n" +
                "\t\t2^(T) = (R)\n\t\t       or\n\t\t2^(T) = 64\n\nTherefore:\n\t\tlog2(64) = 6\n\n" +
                "To use these functions, simply enter your (R) Value and click the respective base button.  The Function will return your (T) Value\n\n" +
                "To CONTINUE to Natural Logarithms, click 'Yes', or click 'No' to QUIT this tutorial", "Using Logarithms", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (MessageBox.Show("Natural Logarithms have a base of (e), and perform the same as the Logarithmic Functions" +
                    " with the Bases of 2, 3, and 10 as described in the previous window, and is the 'ln' Button.  The ammended formula looks like this:\n" +
                    "\t\tlog(e) = (T)\n\nSo if we wanted to solve\n\t\tlog(e)(148.41) = (T)\n" +
                    "We would input 148.41, and click the 'ln' Button, giving us a result of 4.99 or 5\n\n" +
                    "To CONTINUE to Base (X) Logarithms, click 'Yes', or click 'No' to QUIT this tutorial", "Natural Logarithms",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (MessageBox.Show(" Base (X) Logarithms perform the same as all other Logarithms.  It just takes an extra click on your behalf.  " +
                        "The amended formula is:\n\t\tlog(X)(R) = (T)\n\n" +
                        "To use this function, first select your BASE (X).  Then click the 'logX' Button.  " +
                        "This will clear the display and store your (X) variable.  Then select your (R)esult, or (Y) variable and click the '=' Button.  " +
                        "This will give your your (T).  For Example:\n\n" +
                        "\t\t(X) = 6\n\t\t(R) = (Y)\n\t\t(Y) = 92\nThis can be written as:\n\t\tlog6(92) = (T)\n\n" +
                        "Therefore:\n\t\tlog6(92) = 2.524\n\n" +
                        "To REPEAT this Tutorial, click 'Yes', or click 'No' to QUIT this tutorial", "Base (X) Logarithms",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            goto Logarithms;

                        }
                    }
                }
            }
        }

        /*=============================TUTORIAL WINDOWS==================================
        =================================================================================
        ===============================================================================*/
        //Arithmetic Tutorial
        private void arithmeticFunctionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            windowArithmetic.Show();
            this.Hide();
        }
        //Algebra Tutorial
        private void algebraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            windowAlgebra.Show();
            this.Hide();
        }
        //Exponents Tutorial
        private void exponentialFunctionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            windowExponents.Show();
            this.Hide();
        }
        //Logarithms Tutorial
        private void logarithmicFunctionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            windowLogarithms.Show();
            this.Hide();
        }
        //Trigonometry Tutorial
        private void trigonometryFunctionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            windowTrig.Show();
            this.Hide();
        }

        
    }
}
