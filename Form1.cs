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

namespace KlasaKurs
{
    public partial class Form1 : Form
    {
        List<Kurs> kursevi = new List<Kurs>();
        Kurs k;
        StreamReader f;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try {
                f = new StreamReader("kursevi.txt");
                while (!f.EndOfStream)
                {
                    k = new Kurs();
                    k.CitajIzFajla(f);
                    listBox1.Items.Add(k.ToString());
                    kursevi.Add(k);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i, j;

            for( i = 0; i < kursevi.Count - 1; ++i )
                for( j = i + 1; j < kursevi.Count - 1; ++j )
                    if( kursevi[i].SkupljiOd(kursevi[j]) )
                    {
                        k = kursevi[i];
                        kursevi[i] = kursevi[j];
                        kursevi[j] = k;
                    }
            listBox1.Items.Clear();
            foreach(Kurs g in kursevi)
            {
                listBox1.Items.Add(g.ToString());
            }
        }
    }
}
