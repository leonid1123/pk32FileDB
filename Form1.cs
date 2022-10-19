using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace pk32FileDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void WriteFurryToFile(string _furryName, string _furrySpecies, string _furryGenere, 
            string _furryCreateYear,string _furryRedesignYear, string _furryCreator, 
            string _furryPersonality, string _furryState)
        {
            string folder = @"C:\Temp\";
            string fileName = "Furrry.txt";
            string fullPath = folder + fileName;
 
            string[] furry = {_furryName,_furrySpecies,_furryGenere, _furryCreateYear,
            _furryRedesignYear, _furryCreator, _furryPersonality, _furryState,";"};

            File.AppendAllLines(fullPath, furry);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string furryName="";
            string furrySpecies = "";
            string furryGenre = "";
            int furryCreateYear = 0;
            int furryRedesignYear = 0;
            string furryCreator = "";
            string furryPersonality = "";
            string furryState = "";

            string errMsg = "";
            bool hasError = false;

            furryName = textBox1.Text;
            furrySpecies = textBox2.Text;
            furryGenre = textBox3.Text;
            furryCreateYear = dateTimePicker1.Value.Year;
            furryRedesignYear = dateTimePicker2.Value.Year;
            furryCreator = textBox4.Text;
            furryPersonality = textBox5.Text;
            furryState = textBox6.Text;

            if (furryName.Length<2)
            {
                hasError = true;
                errMsg += "Имя слишком короткое. ";
                label1.ForeColor = Color.Red;
                textBox1.ForeColor = Color.Red;
            } else
            {
                label1.ForeColor = Color.Black;
                textBox1.ForeColor = Color.Black;
            }
            if (furrySpecies.Length<3)
            {
                hasError= true;
                errMsg += "Порода указана неверно. ";
            }
            if (furryGenre.Length<5)
            {
                hasError = true;
                errMsg += "Жанр музыки указан неверно. ";
            }
            if (furryCreateYear<1990)
            {
                hasError = true;
                errMsg += "Год создания указан неверно. ";
            }
            if (furryRedesignYear<furryCreateYear)
            {
                hasError = true;
                errMsg += "Год редизайна указан неверно. ";
            }
            if (furryCreator.Length<5)
            {
                hasError = true;
                errMsg += "Имя создателя слишком короткое. ";
            }
            if (furryPersonality.Length<5)
            {
                hasError = true;
                errMsg += "Личные качества содержат очень мало информации. ";
            }
            if (furryState.Length<3)
            {
                hasError = true;
                errMsg += "В статус написали хрень( ";
            }
            if(hasError)
            {
                textBox7.Text = errMsg;
                hasError = false;
                errMsg = "";
            } else
            {
                WriteFurryToFile(furryName,furrySpecies,
                    furryGenre,furryCreateYear.ToString(),furryRedesignYear.ToString(),
                    furryCreator,furryPersonality,furryState);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] res = File.ReadAllLines(@"C:\Temp\Furrry.txt");
            foreach (string s in res)
            {
                listBox1.Items.Add(s);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {//выбрать персонажа
            listBox2.Items.Clear();
            string[] res = File.ReadAllLines(@"C:\Temp\Furrry.txt");
            for(int i = 0; i < res.Length; i++)
            {
                if (res[i] == "2020")
                {
                    for(int j = -3;j<6;j++)
                    {
                        listBox2.Items.Add(res[i+j]);
                    }
                }
            }
        }
    }
}
