using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace regex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChek_Click(object sender, EventArgs e)
        {
            string line = "";
            using (WebClient wc = new WebClient())
                line = wc.DownloadString($"http://free.ipwhois.io/xml/{tbInput.Text}");
            Match match = Regex.Match(line, "<country>(.*?)</country>(.*?)<city>(.*?)</city(.*?)<timezone_gmt>(.*?)</timezone_gmt>");
            lblShowData.Text = match.Groups[1].Value + "\n" + match.Groups[3].Value+ "\n" + match.Groups[5].Value;
        }

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(tbInput.Text,"[^0-9-.]"))
            {
                tbInput.Text = tbInput.Text.Remove(tbInput.Text.Length - 1);
                tbInput.SelectionStart = tbInput.TextLength;
            }
        }
    }
}
