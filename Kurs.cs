using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KlasaKurs
{
    class Kurs
    {
        string naziv;
        int cena;
        public Kurs()
        {
            naziv = string.Empty;
            cena = 0;
        }
        public Kurs(string naziv, int cena)
        {
            if (cena < 0)

                throw new Exception("Cena mora da bude >=0");

            if (naziv.Equals(string.Empty))

                throw new Exception("Mora da ima naziv");

            this.naziv = naziv;
            this.cena = cena;
        }
        public void CitajIzFajla(StreamReader f)
        {
            naziv = f.ReadLine();
            cena = Convert.ToInt32(f.ReadLine());
            if (cena < 0 || naziv.Equals(string.Empty))
                throw new Exception("Mora da ima naziv i cenu >=0");
        }
        public override string ToString()
        {
            return naziv + " - " + cena + "din";
        }
        public bool SkupljiOd(Kurs k)
        {
            return cena > k.cena;
        }
    }
}
