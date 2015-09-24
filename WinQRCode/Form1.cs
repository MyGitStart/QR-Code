using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinQRCode
{
    using ThoughtWorks.QRCode.Codec;
    using ThoughtWorks.QRCode.Codec.Data;
    using ThoughtWorks.QRCode.Codec.Util;
    using System.IO;
    using PdfToImage;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                Cursor.Current = Cursors.WaitCursor;
                if (textBox1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("不能为空.");
                    return;
                }
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();               
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 7;             
               qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;               
                System.Drawing.Image image;
                String data = textBox1.Text;
                //编码
                //string code = Server.UrlEncode(this.txtSourc.Text.Trim().ToString());
                image = qrCodeEncoder.Encode(data,Encoding.UTF8);
                //图片显示
                this.pictureBox1.Image = image;
                Cursor.Current = Cursors.Default;

            }
        }
        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Bitmap b = this.pictureBox1.Image as Bitmap;
            try
            {
                QRCodeDecoder decoder = new QRCodeDecoder();
                //解码
                String decodedString = decoder.decode(new QRCodeBitmapImage(b),Encoding.UTF8);
                //显示解码信息
                this.lbl解码信息.Text += decodedString ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
