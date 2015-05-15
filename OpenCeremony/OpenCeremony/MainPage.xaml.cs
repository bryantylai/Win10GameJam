using OpenCeremony.Model;
using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OpenCeremony
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int currentMsgIndex = 0;
        int nextPersonCounter = 0;
        string cortanaWelcomeMessage = "Welcome {0} to Game Jam 10";
        DispatcherTimer messageTimer = new DispatcherTimer();
        DispatcherTimer flipViewTimer = new DispatcherTimer();
        List<Person> persons;

        public MainPage()
        {
            this.InitializeComponent();

            this.LoadData();

            messageTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            messageTimer.Tick += Timer_Tick;
            messageTimer.Start();

            flipViewTimer.Interval = new TimeSpan(0, 0, 1);
            flipViewTimer.Tick += FlipViewTimer_Tick;
        }

        private void FlipViewTimer_Tick(object sender, object e)
        {
            if (nextPersonCounter == 5)
            {
                flipViewTimer.Stop();

                if (flipView.SelectedIndex == (flipView.Items.Count - 1))
                {
                    this.Frame.Navigate(typeof(VideoPage));
                    return;
                }

                flipView.SelectedIndex += 1;
                cortanDisplay.Text = "";
                currentMsgIndex = 0;
                nextPersonCounter = 0;
                messageTimer.Start();
            }

            nextPersonCounter++;
        }

        private void Timer_Tick(object sender, object e)
        {
            Person selectedPerson = persons.ElementAt(flipView.SelectedIndex);

            if (cortanDisplay.Text.Count() == string.Format(cortanaWelcomeMessage, selectedPerson.Name).Count())
            {
                flipViewTimer.Start();
                messageTimer.Stop();
            }
            else
            {
                cortanDisplay.Text += string.Format(cortanaWelcomeMessage, selectedPerson.Name).ElementAt(currentMsgIndex);
                currentMsgIndex++;
            }
        }

        private void LoadData()
        {
            persons = new List<Person>()
            {
                new Person() { Name = "Test 1", Desc = "Test 1", Organization = "Microsoft", Order = 1 },
                new Person() { Name = "Test 2", Desc = "Test 2", Organization = "Microsoft", Order = 2 },
                new Person() { Name = "Test 3", Desc = "Test 3", Organization = "Microsoft", Order = 3 },
                new Person() { Name = "Test 4", Desc = "Test 4", Organization = "Microsoft", Order = 4 },
                new Person() { Name = "Test 5", Desc = "Test 5", Organization = "Microsoft", Order = 5 },
                //new Person() { Name = "Test 6", Desc = "Test 6", Organization = "Microsoft", Order = 6 },
                //new Person() { Name = "Test 7", Desc = "Test 7", Organization = "Microsoft", Order = 7 },
                //new Person() { Name = "Test 8", Desc = "Test 8", Organization = "Microsoft", Order = 8 },
                //new Person() { Name = "Test 9", Desc = "Test 9", Organization = "Microsoft", Order = 9 },
                //new Person() { Name = "Test 10", Desc = "Test 10", Organization = "Microsoft", Order = 10 }
            };

            this.flipView.ItemsSource = persons.OrderBy(p => p.Order);
        }
    }
}