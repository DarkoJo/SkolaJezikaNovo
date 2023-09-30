using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaNovo
{
     class PdfGenerator
    {
        public static void KurseviPdf(Kurs kurs)
        {
            Document document = new Document();

            string filePath = $"Kurs_{kurs.ImeKursa}.pdf";

            FileStream fs = new FileStream(filePath, FileMode.Create);

            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.Open();

            document.Add(new Paragraph($"Naziv kursa: {kurs.ImeKursa}"));

        foreach(var student in kurs.UpisaniStudenti)
            {
                document.Add(new Paragraph($"Ime student :{student.Ime} {student.Prezime}"));
            }
            




            document.Close();
            writer.Close();
            fs.Close();

        }
    }
}
