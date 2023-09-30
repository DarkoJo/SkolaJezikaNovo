using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaNovo
{
    public class Kurs


    {
        public int Id;
        private int maxBrojStudenata;

        public string ImeKursa { get; set; }
        public List<Student> UpisaniStudenti { get; set; } = new List<Student>();

        public string Jezici { get; set; }

        public bool SuAktivni { get; set; }

        public int MaxBrojStudenata { get; set; }
        public int BrojStudenata { get;  set;}

        public Kurs(string ImeKursa, int MaxBrojStudenata)
        {
            this.ImeKursa = ImeKursa;
            Jezici = Jezici;
            Id= 0;
            SuAktivni = true;
          this.MaxBrojStudenata = MaxBrojStudenata;

        }
    }
}
