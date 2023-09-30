using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaNovo
{
    public class Student
    {
        public int BrojStudenata;
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public List<string>KursevaPohadja { get; set; }

        public Student(string ime, string prezime)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            KursevaPohadja = new List<string>();
        }
    }
}
