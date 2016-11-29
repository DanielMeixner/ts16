using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MyListView.ItemsSource = MyQuotes;

            MyQuotes.Add(new Quote { QuoteText = "First Quoote" });
            MyQuotes.Add(new Quote { QuoteText = "Second Quoote" });
            MyQuotes.Add(new Quote { QuoteText = "Third Quoote" });
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Question?", "Do you like it?", "Yes", "No");
            Debug.WriteLine("Answer: " + answer);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {

        }

        private async void btnClick(object sender, EventArgs e)
        {
            await DisplayAlert("hello", "Hello Xamarin Forms", "nöa");
        }

        ObservableCollection<Quote> MyQuotes = new ObservableCollection<Quote>();


        

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            ObservableCollection<Quote> UpdatedQuotees = new ObservableCollection<Quote>();
            UpdatedQuotees.Add(new Quote { QuoteText = "Second Quoote" });
            UpdatedQuotees.Add(new Quote { QuoteText = "Updated Quoote" });
            UpdatedQuotees.Add(new Quote { QuoteText = "Third Quoote" });

            MyListView.ItemsSource = UpdatedQuotees;
        }


        public async Task RetrieveValuesAsync()
        {
            
            //request.ContentType = "application/json";
            //request.Method = "GET";
            HttpClient cl = new HttpClient();
            
            var resp = await cl.GetStringAsync("http://DESKTOP-P6V5K7O:55614/api/values");
            var newList = JsonConvert.DeserializeObject(resp);


        }
    }
 
}
public class Quote
{
    public string QuoteText { get; set; }
}