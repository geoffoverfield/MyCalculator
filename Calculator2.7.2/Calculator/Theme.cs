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

namespace Calculator
{
    //This works in theory...  Cannot figure out implementation at the moment...
    // 1. Create a Theme Object.
    // 2. If there is no current Theme Object (which there always will be, with the exception of opening the app, 
    //          it places the default/selected theme as the theme.
    // 3. Theme class modifies the background image
    // 4. Theme class modifies the sounds played by media player
    // 5. Theme class modifies size and/or appearance of buttons
    //If  new Theme is selected, sets the current Theme as the previous Theme and 
    //      disposes of all aspects, and goes back to step 1...
    
    //I will need to completely change all implementations for this to work.
    //This will include fonts, buttons (including the sizing) and colors along with backgrounds.
    //Complete overhaul???
    //If so, save for a much later verson.
    //Tutorials are main focus.

    //IS THIS EVEN NECCESSARY??  
    //Will it save me lines of code and thereby file size?
    //Will this improve time effeciency and/or lag??
    //Current theme setting work flawlessley.  Regards of whether or not this is the right corse of
    //      action, this must be saved for later!!!

    class Theme
    {
        private Bitmap myBackground;
        private Color backColor;
        private Color foreColor;
        private Color fontColor;
        private SoundPlayer themeSound;
        private SoundPlayer clickSound;
        private SoundPlayer solveSound;
        public Theme()
        {
            myBackground = myBackground;
            backColor = backColor;
            foreColor = foreColor;
            fontColor = fontColor;
        }
        Theme currentTheme;
        Theme prevTheme;
        public void updateTheme(Bitmap back, Color c1, SoundPlayer s1)
        {
            currentTheme = prevTheme;
            currentTheme.myBackground = back;
            currentTheme.backColor = c1;
            currentTheme.themeSound = s1;
            prevTheme.themeDispose();
        }
        public void updateTheme(Bitmap back, Color c1, Color c2, SoundPlayer s1, SoundPlayer s2) 
        {
            currentTheme = prevTheme;
            currentTheme.myBackground = back;
            currentTheme.backColor = c1;
            currentTheme.fontColor = c2;
            currentTheme.themeSound = s1;
            currentTheme.solveSound = s2;
            prevTheme.themeDispose();
        }
        public void updateTheme(Bitmap back, Color c1, Color c2, Color c3, SoundPlayer s1, SoundPlayer s2, SoundPlayer s3)
        {
            currentTheme = prevTheme;
            currentTheme.myBackground = back;
            currentTheme.backColor = c1;
            currentTheme.foreColor = c2;
            currentTheme.fontColor = c3;
            currentTheme.themeSound = s1;
            currentTheme.clickSound = s2;
            currentTheme.solveSound = s3;
            prevTheme.themeDispose();
        }
        private void themeDispose()
        {
            myBackground.Dispose();
            backColor = Color.Transparent;
            foreColor = Color.Transparent;
            fontColor = Color.Transparent;
            themeSound.Dispose();
            clickSound.Dispose();
            solveSound.Dispose();
            prevTheme = null;
        }
    }


}
