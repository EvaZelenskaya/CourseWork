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
            
            lbl_buy_Now_currently.Content= GetUSDRate();
            sum_cash.Text= Msk_Bank();

            
        }

        private String Msk_Bank()
        {
            WebClient wc = new WebClient();
            String Responte = wc.DownloadString(@"https://mkb.ru");
            String Rate = Regex.Match(Responte, @"<td class='data al_right'>([0-9]+\.[0-9]+)</td>").Groups[1].Value;
            return Rate;
        }
        public static String FindText(string source, string prefix, string suffix)
        {
            var prefixPosition = source.IndexOf(prefix, StringComparison.OrdinalIgnoreCase);
            var suffixPosition = source.IndexOf(suffix, prefixPosition + prefix.Length, StringComparison.OrdinalIgnoreCase);

            if ((prefixPosition >= 0) && (suffixPosition >= 0) && (suffixPosition > prefixPosition) && ((prefixPosition + prefix.Length) <= suffixPosition))
            {
                return source.Substring(
                                prefixPosition + prefix.Length,
                                suffixPosition - prefixPosition - prefix.Length
                    );
            }
            else
            {
                return String.Empty;
            }
        }
        private String GetUSDRate()
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
        }
       
        

        void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
            
        }
    }
}
