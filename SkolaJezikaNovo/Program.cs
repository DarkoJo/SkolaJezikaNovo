using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaNovo

{

    public class Program
    {
        public static List<Kurs> kursevi = new List<Kurs>()
        {
            new Kurs("nemacki",10),
            new Kurs("kneski",6),
            new Kurs("francuski", 15)
        };

        public static List<Student> studenti = new List<Student>()
        {

        };

        public static void StampajPDFKursa()
        {
            Console.WriteLine("unesi naziv kursa za stampu:");
            string naziv = Console.ReadLine();
            var kurs = kursevi.Find(k=> k.ImeKursa==naziv);
            if (kurs == null)
            {
                Console.WriteLine( "Ne postoji kurs! Uneti postojeci kurs!");

            }else
            {
                PdfGenerator.KurseviPdf(kurs);
            }
            // Preko konzole unesi ime kursa
            // uneseni naziv pronadji iz liste kursevi, ako ne postoji odstampaj gresku
            // ako postoji stampaj (pozovi funkciju iz PdfGeneratora i prosledi Kurs kao parametar)
        }

        static void Main()
        {
            bool nastaviIspis = true;           

            while (nastaviIspis)
            {
                Console.WriteLine("1.Pirikazi sve kurseve:");

                Console.WriteLine("2.Dodaj novog studenta:");

                Console.WriteLine("3.Dodaj studentu kurs:");

                Console.WriteLine("4.Eksport kurseva:");

                Console.WriteLine("5.Izadji");

                Console.Write("Izaberi opciju:");


                if (int.TryParse(Console.ReadLine(), out int opcija))

                    switch (opcija)
                    {
                        case 1:
                            PrikaziSveKurseve();
                            break;
                        case 2:
                            DodajNovogStudenta();
                            break;
                        case 3:
                            DodajStudentuNoviKurs();
                            break;
                        case 4:
                            StampajPDFKursa();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Nepravilan unos! pokusati unos ponovo");
                            break;


                    }
                else
                {
                    Console.WriteLine("nepravilan unos");
                }
            }
            

            

            }
        static void PrikaziSveKurseve()
        {
            if (kursevi.Count == 0)
            {
                Console.WriteLine("Nije pronadjen kurs");
            }
            else
            {
                Console.WriteLine("Lista kurseva:");
                foreach (var kurs in kursevi)
                {
                    Console.WriteLine($"Kurs:{kurs.ImeKursa}");

                    Console.WriteLine($"Aktivan:{(kurs.SuAktivni ? "DA" : "NE")}");

                    Console.WriteLine($"Broj upisanih studenata:{kurs.UpisaniStudenti.Count}");

                    Console.WriteLine();

                }
            }
        }

        public static void DodajNovogStudenta(string ime, string prezime)
        {
            Student newStudent = new Student(ime, prezime);
            studenti.Add(newStudent);
            Console.WriteLine($"Student {ime} {prezime} je dodat.");
        }

        public void UpisiImeIPrezimeNovogStudenta()
        {
            Console.WriteLine("Unesi ime studenta:");
            string Ime = Console.ReadLine();
            Console.WriteLine("Unesi prezime:");
            string Prezime = Console.ReadLine();

            DodajNovogStudenta(Ime, Prezime);
        }
        static void DodajNovogStudenta()
        {
            Console.WriteLine("Unesi ime studenta:");
            string Ime = Console.ReadLine();
            Console.WriteLine("Unesi prezime:");
            string Prezime= Console.ReadLine();

            Student newStudent = new Student(Ime, Prezime);
            studenti.Add(newStudent);
            Console.WriteLine($"Student {Ime} {Prezime} je dodat.");
        }

        public static string DodajStudentaNaKurs(string ime, string prezime, string nazivKursa)
        {
            var student = studenti.Find(s => s.Ime == ime && s.Prezime == prezime);

            if (student == null)
            {
                return "Student nije pronadjen";
            }

            var kurs = kursevi.Find(k => k.ImeKursa == nazivKursa);
            if (kurs == null)
            {
                return "kurs nije pronadjen";
            }

            if (kurs.MaxBrojStudenata > kurs.UpisaniStudenti.Count)
            {
                student.KursevaPohadja.Add(nazivKursa);
                kurs.BrojStudenata++;
                kurs.UpisaniStudenti.Add(student);

                return $"Student {ime}  {prezime}  upisan na kurs {nazivKursa}.";
            }
            else
            {
                return "Kurs je popunjen";
            }
        }
        static void DodajStudentuNoviKurs()
        {
            Console.WriteLine("Unesi studentovo ime:");
            string Ime = Console.ReadLine();
            Console.WriteLine("Unesi studentovo prezime");
            string Prezime= Console.ReadLine();

            Console.WriteLine("Izaberi kurs da dodas studentu:");

            string ImeKursa = Console.ReadLine();

            Console.WriteLine(DodajStudentaNaKurs(Ime, Prezime, ImeKursa)); 

        }
         

        }
    }


        


    
