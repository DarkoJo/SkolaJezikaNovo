

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkolaJezikaNovo;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UpisNaTest
    {
        [TestMethod]
        public void UpisStudentaNaKursUspesno()
        {
           var Kurs= new Kurs("matematika", 12);
            var Student = new Student("pera", "Peric");

            Program.DodajNovogStudenta(Student.Ime, Student.Prezime);
            Kurs nemacki = Program.kursevi.Find(kurs => kurs.ImeKursa == "nemacki");

            Assert.IsTrue(Program.studenti.Count == 1);
            Assert.IsTrue(nemacki.BrojStudenata == 0);

            Program.DodajStudentaNaKurs(Student.Ime, Student.Prezime, nemacki.ImeKursa);

            Assert.IsTrue(nemacki.BrojStudenata == 1);
            //Assert.AreEqual(6, Kurs.BrojStudenata);
            //CollectionAssert.Contains(Student.KursevaPohadja, Kurs);




        }

    
    }

}

