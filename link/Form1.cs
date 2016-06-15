using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace link
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox2.Text = "没有转换记录";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"[a-zA-Z0-9]");
            int length = 0;
            char[] Temp = textBox1.Text.ToCharArray();
            StringBuilder strb = new StringBuilder();
            string link_source = textBox1.Text;
            for (int i=0; i < link_source.Length; i++)
            {
                if (reg.IsMatch(link_source.Substring(i, 1)))
                {
                    length += 1;
                    strb.Append(Temp[i]);
                }
            }
            switch (length)
            {
                case 6: //新浪链接
                    textBox2.Text = "http://t.cn/" + strb.ToString();
                    break;
                case 8: //百度无加密链接
                    textBox2.Text = "http://pan.baidu.com/s/" + strb.ToString();
                    break;
                case 12: //百度加密链接
                    textBox2.Text = "http://pan.baidu.com/s/" + strb.ToString();
                    break;
                case 17: //tumblr视频链接
                    textBox2.Text = "http://vt.tumblr.com/tumblr_" + strb.ToString();
                    break;
                case 40: //磁力链接
                    textBox2.Text = "magnet:?xt=urn:btih:" + strb.ToString();
                    break;
                default: //无效链接
                    textBox2.Text = "无效链接";
                    break;
            }
            //Match match = reg.Match(textBox1.Text);
            //textBox2.Text = length.ToString();
        }
    }
}
