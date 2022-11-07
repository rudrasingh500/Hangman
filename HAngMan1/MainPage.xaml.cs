using Bickers.Twaddle.Core;
using CodenameGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HAngMan1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string[] randomWord = {"which","there","their","about","would","these","other","words","could","write","first","water","after","where","right","think","three","years","place","sound","great","again","still","every","small","found","those","never","under","might","while","house","world","below","asked","going","large","until","along","shall","being","often","earth","began","since","study","night", "light","above","paper"};
        string ranWord;
        public MainPage()
        {
            this.InitializeComponent();
            Random random = new Random();

            int ran = random.Next(50);
            ranWord = randomWord[ran];
            
        }

        
        
        int incorrect = 1;
        

        private void check_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Text = "";

            char letterEntered;

            char.TryParse(inputLetter.Text.ToUpper(), out letterEntered);

            string WordsUsed = ICLetters.Text;

            string word = ranWord.ToUpper();

            
                   


            if (WordsUsed.Contains(letterEntered))
            {
                ErrorMessage.Text = "Letter already entered";
                return;
            }


            if (word.ToString().Contains(letterEntered))
            {
                if (letterEntered.Equals(word[0]))
                {
                    a.Text = letterEntered.ToString();
                }

                if (letterEntered.Equals(word[1]))
                {
                    b.Text = letterEntered.ToString();
                }

                if (letterEntered.Equals(word[2]))
                {
                    c.Text = letterEntered.ToString();
                }

                if (letterEntered.Equals(word[3]))
                {
                    d.Text = letterEntered.ToString();
                }

                if (letterEntered.Equals(word[4]))
                {
                    f.Text = letterEntered.ToString();
                }

                if (!a.Text.Equals("") && !b.Text.Equals("") && !c.Text.Equals("") && !d.Text.Equals("") && !f.Text.Equals("")) {
                    this.Frame.Navigate(typeof(YouWin));
                }
                

            }
            else
            {
                incorrect++;
                int x = incorrect;

                BitmapImage image = new BitmapImage();
                switch (x) {
                    
                    case 2:
                        image = new BitmapImage(new Uri(@"ms-appx:///Assets/HangmanStage2.png"));
                        break;
                    case 3:
                        image = new BitmapImage(new Uri(@"ms-appx:///Assets/HangmanStage3.png"));
                        break;
                    case 4:
                        image = new BitmapImage(new Uri(@"ms-appx:///Assets/HangmanStage4.png"));
                        break;
                    case 5:
                        image = new BitmapImage(new Uri(@"ms-appx:///Assets/HangmanStage5.png"));
                        break;
                    case 6:
                        image = new BitmapImage(new Uri(@"ms-appx:///Assets/HangmanStage6.png"));
                        break;
                    case 7:
                        image = new BitmapImage(new Uri(@"ms-appx:///Assets/HangmanDed.png"));
                        break;
                    default:
                        this.Frame.Navigate(typeof(BlankPage1));
                        break;

                }
                img.Source = image;               

            }
            WordsUsed += " " + letterEntered;
            ICLetters.Text = WordsUsed;

            inputLetter.Text = "";
            
            
        }

        private void inputLetter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(inputLetter.Text.Length > 1)
            {
                inputLetter.Text = "";
                ErrorMessage.Text = "Only Enter 1 letter";
            }
            //char[] IPLetter = inputLetter.Text.ToCharArray();

            if (inputLetter.Text.Contains("0") || inputLetter.Text.Contains("1") || inputLetter.Text.Contains("2") || inputLetter.Text.Contains("3") || inputLetter.Text.Contains("4") || inputLetter.Text.Contains("5") || inputLetter.Text.Contains("6") || inputLetter.Text.Contains("7") || inputLetter.Text.Contains("8") || inputLetter.Text.Contains("9"))
            {
                ErrorMessage.Text = "Don't Enter Numbers";
                inputLetter.Text = "";
                //Thread.Sleep(10000);
                //ErrorMessage.Text = "";
            }
        }

        private void returnToMenu_Click(object sender, RoutedEventArgs e)
        {

            //To show an simple Yes / No message, you can do it like this:

            MessageDialog dialog = new MessageDialog("Yes or no?");
            dialog.Commands.Add(new UICommand("Yes", null));
            dialog.Commands.Add(new UICommand("No", null));
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;
            var cmd = dialog.ShowAsync();

            if (1 == 1);
            this.Frame.Navigate(typeof(Menu));

        }
    }
}
