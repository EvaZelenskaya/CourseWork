using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Interactivity;

using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Net;
using System.Web;
using System.IO;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace Coursework
{
    
    public partial class WorkWindow : Window
    {
        public WorkWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            lblDate.Content = DateTime.Today.ToShortDateString();
            comBox_Currency.SelectionChanged += comBox_Currency_SelectedIndexChanged; 
            //pop += comBox_Currency_SelectedIndexChanged;
            /* if (comBox_Currency.SelectedItem == comBox_Currency.Items[0]) 
            { 
            lbl_buy_Now_currently.Content = fora_Bank_buy_USD();
            lbl_sell_Now_currently.Content = fora_Bank_sell_USD();
            }*/


        }

        

        private String fora_Bank_sell_USD()
        {
            WebClient wc = new WebClient();
            String Responte = wc.DownloadString("https://www.banki.ru/products/currency/exchange/11442/");
            String Rate = Regex.Match(Responte, @"data-currencies-rate-sell=""([0-9]+\.[0-9]+)""").Groups[1].Value;
            return Rate;
        }
        private String fora_Bank_buy_USD()
        {
            WebClient wc = new WebClient();
            String Responte = wc.DownloadString("https://www.banki.ru/products/currency/exchange/11442/");
            String Rate = Regex.Match(Responte, @"data-currencies-rate-buy=""([0-9]+\.[0-9]+)""").Groups[1].Value;
            return Rate;
        }
        //ЦБ онлайн
        /*private String GetUSDRate()
        {
            string url = "http://www.cbr.ru/scripts/XML_daily.asp";
            //XmlDocument xml_doc = new XmlDocument();
            //xml_doc.Load(url);
            DataSet ds = new DataSet();
            ds.ReadXml(url);
            DataTable currency = ds.Tables["Valute"];
            foreach (DataRow row in currency.Rows)
            {
                if (row["CharCode"].ToString() == "USD")//Ищу нужный код валюты
                {
                    return row["Value"].ToString(); //Возвращаю значение курсы валюты
                }
            }
            return "";
        }*/
       
        

        void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
            
        }
        private void comBox_Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            switch (comBox_Currency.SelectedItem.ToString())
             {

                 case "Доллар США $":
                     {
                         lbl_buy_Now_currently.Content = fora_Bank_buy_USD();
                         lbl_sell_Now_currently.Content = fora_Bank_sell_USD();
                     }
                    break;
                 case "Евро €":
                     {
                         lbl_buy_Now_currently.Content = "0";
                         lbl_sell_Now_currently.Content = "0";
                     }
                    break;
                 case "Белорусский рубль Br":
                     {
                         lbl_buy_Now_currently.Content = "1";
                         lbl_sell_Now_currently.Content = "1";
                     }
                    break;
                 case "Украинская гривна ₴":
                     {
                         lbl_buy_Now_currently.Content = "2";
                         lbl_sell_Now_currently.Content = "2";
                     }
                   break;
                 case "Фунт стерлингов £":
                     {

                         lbl_buy_Now_currently.Content = "3";
                         lbl_sell_Now_currently.Content = "3";
                     }
                   break;
                 case "Российский рубль ₽":
                     {
                         lbl_buy_Now_currently.Content = "4";
                         lbl_sell_Now_currently.Content = "4";
                     }
                   break;



        }

        }
    }
}
