using GeradorTestes.Domain;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes.Infra.PDF
{
    public static class GerarPDFTestes
    {
        public static void GerarPDF(Teste teste, string caminho)
        {
            try
            {
                
                Document doc = new Document();

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

                doc.Open();
                doc.Add(new Paragraph( + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year));
                doc.Add(new Paragraph("Série: " + teste.listaQuestao[0].materia.serie.Nome + "  Bimestre: " + teste.listaQuestao[0].Bimestre));
                doc.Add(new Paragraph("Matéria: " + teste.listaQuestao[0].materia.Nome + "    Disciplina: " + teste.listaQuestao[0].materia.disciplina.Nome));
                doc.Add(new Paragraph(" "));
                int i = 0;
                foreach (var item in teste.listaQuestao)
                {
                    i++;
                    doc.Add(new Paragraph(i + " - " + item.Pergunta));
                    doc.Add(new Paragraph("A) " + item.Alternativa.A));
                    doc.Add(new Paragraph("B) " + item.Alternativa.B));
                    doc.Add(new Paragraph("C) " + item.Alternativa.C));
                    doc.Add(new Paragraph("D) " + item.Alternativa.D));
                    doc.Add(new Paragraph(" "));
                }

                doc.NewPage();
                doc.Add(new Paragraph("Gabarito:"));

                int y = 1;
                foreach (var item in teste.listaQuestao)
                {
                    doc.Add(new Paragraph(y + "-" + item.Pergunta));
                    doc.Add(new Paragraph(item.Alternativa.Correta));
                    doc.Add(new Paragraph(" "));
                    y++;
                }
                doc.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}