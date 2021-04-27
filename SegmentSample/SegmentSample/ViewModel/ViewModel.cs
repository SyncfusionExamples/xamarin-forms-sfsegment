using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Xamarin.Forms;

namespace SegmentSample
{
    class ViewModel : INotifyPropertyChanged
    {
        private string fromText = "";
        public string FromText
        {
            get { return fromText; }
            set { fromText = value; NotifyPropertyChanged("FromText"); }
        }
        private string toText = "";
        public string ToText
        {
            get { return toText; }
            set { toText = value; NotifyPropertyChanged("ToText"); }
        }
        public ViewModel()
        {
            ItemCollection = new ObservableCollection<SfSegmentItem>
                    {
                        new SfSegmentItem() {  Text = "Seater"},
                        new SfSegmentItem() {  Text = "Sleeper"},
                    };
            ViewCollection = new ObservableCollection<View>
                    {
                       ResetViewButton,
                       GoViewButton
                    };

            ResetViewButton.Clicked += ResetViewButton_Clicked;
            GoViewButton.Clicked += GoViewButton_Clicked;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ObservableCollection<SfSegmentItem> itemCollection = new ObservableCollection<SfSegmentItem>();
        private ObservableCollection<View> viewCollection = new ObservableCollection<View>();
        public ObservableCollection<SfSegmentItem> ItemCollection
        {
            get { return itemCollection; }
            set { itemCollection = value; }
        }
        public ObservableCollection<View> ViewCollection
        {
            get { return viewCollection; }
            set { viewCollection = value; }
        }
        private Button ResetViewButton = new Button
        {
            Text = "Reset",
            TextColor = Color.FromHex("#979797"),
            BackgroundColor = Color.White,
            BorderColor = Color.FromHex("#979797"),
            BorderWidth = 1,
            CornerRadius = 4,
            HeightRequest = 50,
            VerticalOptions = LayoutOptions.Center
        };
        private Button GoViewButton = new Button
        {
            Text = "Go",
            TextColor = Color.FromHex("#979797"),
            BackgroundColor = Color.White,
            BorderColor = Color.FromHex("#979797"),
            BorderWidth = 1,
            CornerRadius = 4,
            HeightRequest = 50,
            VerticalOptions = LayoutOptions.Center
        };
        private void GoViewButton_Clicked(object sender, EventArgs e)
        {
            if (FromText == "")
            {
                SendMessage("Please enter your origin city");
            }
            else if (ToText == "")
            {
                SendMessage("Please enter your destination city");
            }
            else
                SendMessage("Your ticket has been booked");
        }

        private void ResetViewButton_Clicked(object sender, EventArgs e)
        {
            FromText = "";
            ToText = "";
            Application.Current.MainPage.DisplayAlert("Status", "Fields has been refreshed", null, "Ok");
        }

        internal void SendMessage(string message)
        {
            Application.Current.MainPage.DisplayAlert(message, null, "Ok");
        }
    }
}