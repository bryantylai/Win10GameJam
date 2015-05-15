using OpenCeremony.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OpenCeremony
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        string welcomeMessage = "Welcome to Windows 10 Game Jam!";
        string thankYouMessage = "Thank you to all of our partners!";
        int currentIndex = 0;
        int messageType = 0;
        List<Person> persons;

        public HomePage()
        {
            this.InitializeComponent();

            this.LoadData();

            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {

            if (messageType == 0)
            {
                if (welcomeTextBlock.Text.Count() == welcomeMessage.Count())
                {
                    messageType++;
                    welcomeTextBlock.Text = "";
                    currentIndex = -1;
                }
                else
                    welcomeTextBlock.Text += welcomeMessage.ElementAt(currentIndex);
            }
            else if (messageType == 1)
            {
                if (welcomeTextBlock.Text.Count() == thankYouMessage.Count())
                {
                    messageType++;
                    welcomeTextBlock.Text = "";
                    this.flipView.Visibility = Visibility.Visible;
                    currentIndex = -1;
                }
                else
                    welcomeTextBlock.Text += thankYouMessage.ElementAt(currentIndex);
            }
            else if (messageType == 2)
            {
                if (currentIndex % 10 == 0)
                {
                    if (this.flipView.SelectedIndex == (persons.Count - 1))
                    {
                        this.Frame.Navigate(typeof(VideoPage));
                        timer.Stop();
                    }
                    else
                        this.flipView.SelectedIndex++;
                }
            }
            //else
            //{
            //    this.Frame.Navigate(typeof(VideoPage));
            //    timer.Stop();
            //}

            currentIndex++;
        }

        private void LoadData()
        {
            persons = new List<Person>()
            {
                new Person() { Order = 0 }, // Hack code
                new Person() { Desc = "Brought to You By", ImagePath = new Uri("ms-appx:///Assets/Partners/MSFT.png", UriKind.RelativeOrAbsolute), Order = 1 },
                new Person() { Desc = "Platinum Partner", ImagePath = new Uri("ms-appx:///Assets/Partners/MDEC.png", UriKind.RelativeOrAbsolute), Order = 2 },
                new Person() { Desc = "Gold Partner", ImagePath = new Uri("ms-appx:///Assets/Partners/MCMC.png", UriKind.RelativeOrAbsolute), Order = 3 },
                new Person() { Desc = "Official Host", ImagePath = new Uri("ms-appx:///Assets/Partners/KDU.png", UriKind.RelativeOrAbsolute), Order = 4 },
                new Person() { Desc = "Official Hardware Partner", ImagePath = new Uri("ms-appx:///Assets/Partners/Acer.png", UriKind.RelativeOrAbsolute), Order = 5 },
                new Person() { Desc = "Special Moment Partner", ImagePath = new Uri("ms-appx:///Assets/Partners/Winprovise.png", UriKind.RelativeOrAbsolute), Order = 6 },
                new Person() { Desc = "Special Moment Partner", ImagePath = new Uri("ms-appx:///Assets/Partners/Avanade.png", UriKind.RelativeOrAbsolute), Order = 7 },
                new Person() { Desc = "Special Moment Partner", ImagePath = new Uri("ms-appx:///Assets/Partners/Mygamedev.png", UriKind.RelativeOrAbsolute), Order = 8 }
            };

            this.flipView.ItemsSource = persons.OrderBy(p => p.Order);
        }
    }
}
