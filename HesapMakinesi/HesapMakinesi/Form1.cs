using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HesapMakinesi
{
    public partial class Form1 : Form
    {
        char _islem;
        bool _EkranTemizleme;
        private Font _defaultFont;

        public Form1()
        {
            InitializeComponent();
            _defaultFont = EkranLabel.Font;
        }

        private void Rakam1Buton_Click(object sender, EventArgs e)
        {
            RakamEkle("1");
        }

        private void Rakam3Buton_Click(object sender, EventArgs e)
        {
            RakamEkle("3");
        }

        private void Rakam6Buton_Click(object sender, EventArgs e)
        {
            RakamEkle("6");
        }

        private void Rakam9Buton_Click(object sender, EventArgs e)
        {
            RakamEkle("9");
        }

        private void Rakam4Buton_Click(object sender, EventArgs e)
        {
            RakamEkle("4");
        }

        private void Rakam7Buton_Click(object sender, EventArgs e)
        {
            RakamEkle("7");
        }

        private void Rakam8Buton_Click(object sender, EventArgs e)
        {
            RakamEkle("8");
        }

        private void Rakam2Buton_Click(object sender, EventArgs e)
        {
            RakamEkle("2");
        }

        private void Rakam0Buton_Click(object sender, EventArgs e)
        {
            RakamEkle("0");
        }

        private void Rakam5Buton_Click(object sender, EventArgs e)
        {
            RakamEkle("5");
        }

        private void RakamEkle(string rakam)
        {
            try
            {
                if (_EkranTemizleme)
                {
                    EkranLabel.Text = "";
                    _EkranTemizleme = false;
                }
                if (EkranLabel.Text == "0")
                {
                    EkranLabel.Text = "";
                }
                EkranLabel.Text += rakam;
                AyarlaFontBoyutu();
            }
            catch (Exception ex)
            {
                EkranLabel.Font = new Font(EkranLabel.Font.FontFamily, 10);
                EkranLabel.Text = "HATA: " + ex.Message;
            }
        }

        private void ToplamaButonu_Click(object sender, EventArgs e)
        {
            IslemEkle('+');
        }

        private void ÇıkarmaButonu_Click(object sender, EventArgs e)
        {
            IslemEkle('-');
        }

        private void ÇarpmaButonu_Click(object sender, EventArgs e)
        {
            IslemEkle('*');
        }

        private void BölmeButonu_Click(object sender, EventArgs e)
        {
            IslemEkle('/');
        }
        private void IslemEkle(char islem)
        {
            try
            {
                if (EkranLabel.Text.EndsWith(" + ") || EkranLabel.Text.EndsWith(" - ") || EkranLabel.Text.EndsWith(" * ") || EkranLabel.Text.EndsWith(" / "))
                {
                    throw new InvalidOperationException("Ardışık iki işlem işareti giremezsiniz.");
                }
                if (_EkranTemizleme)
                {
                    _EkranTemizleme = false;
                }
                EkranLabel.Text += " " + islem + " ";
                AyarlaFontBoyutu();
            }
            catch (Exception ex)
            {
                EkranLabel.Font = new Font(EkranLabel.Font.FontFamily, 10);
                EkranLabel.Text = "HATA: " + ex.Message;
            }
        }

        private void EşittirButonu_Click(object sender, EventArgs e)
        {
            try
            {
                string[] parts = EkranLabel.Text.Split(' ');
                for (int i = 0; i < parts.Length; i++)
                {
                    if (parts[i] == "/" && parts[i + 1] == "0")
                    {
                        throw new DivideByZeroException("Bir sayı sıfıra bölünemez.");
                    }
                }
                DataTable dt = new DataTable();
                var sonuc = dt.Compute(EkranLabel.Text, "");
                EkranLabel.Font = _defaultFont;
                EkranLabel.Text = Convert.ToString(sonuc);
                _EkranTemizleme = true;
                AyarlaFontBoyutu();
            }
            catch (Exception ex)
            {
                EkranLabel.Font = new Font(EkranLabel.Font.FontFamily, 10);
                EkranLabel.Text = "HATA: " + ex.Message;
            }
        }

        private void SilmeButonu_Click(object sender, EventArgs e)
        {
            EkranLabel.Font = _defaultFont;
            EkranLabel.Text = "0";
        }

        private void AyarlaFontBoyutu()
        {
            int maxLength = 10;
            if (EkranLabel.Text.Length > maxLength)
            {
                float newSize = _defaultFont.Size * maxLength / EkranLabel.Text.Length;
                EkranLabel.Font = new Font(_defaultFont.FontFamily, newSize);
            }
            else
            {
                EkranLabel.Font = _defaultFont;
            }
        }
    }
}