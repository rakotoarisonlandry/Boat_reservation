using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PdfSharp;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.Core.Entities;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using System.Windows;
using System.Globalization;

namespace BoatReservation
{
    class PdfConverter
    {
        public bool ConvertHtmlToPdf(string htmlTemplatePath, string outputPdfPath, string[] var)
        {
            string mode;
            if (var[9] == "TP")
            {
                mode = "Tout Payé";
            } else if (var[9] == "AA")
            {
                mode = "Avec Avance";
            } else
            {
                mode = "Sans Avance";
            }

            try
            {
                string htmlTemplate = File.ReadAllText(htmlTemplatePath);
                string filledTemplate = htmlTemplate
                    .Replace("{{date_res}}", var[0])
                    .Replace("{{prenom}}", var[1])
                    .Replace("{{tel}}", var[2])
                    .Replace("{{itineraire}}", var[3])
                    .Replace("{{bateaux}}", var[4])
                    .Replace("{{depart}}", var[5])
                    .Replace("{{class_a}}", var[6])
                    .Replace("{{class_b}}", var[7])
                    .Replace("{{class_c}}", var[8])
                    .Replace("{{payement}}", mode)
                    .Replace("{{somme}}", var[10])
                    .Replace("{{reste}}", var[11]);

                PdfDocument pdf = PdfGenerator.GeneratePdf(filledTemplate, PageSize.A4);
                pdf.Save(outputPdfPath);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Ticket au format PDF generer avec succes ");
            return true;
        }

        public bool GivePDF(string[] data)
        {
            DateTime currentDate = DateTime.Now;
            CultureInfo frenchCulture = new CultureInfo("fr-FR");
            string date_res = currentDate.ToString("yyyy-MM-dd HH_mm_ss", frenchCulture);


            string htmlTemplatePath = "template.html";
            string folderPath = "../../pdf/";
            //string outputPdfPath = "output.pdf";
            string outputPdfPath = Path.Combine(folderPath, "Ticket" + date_res + ".pdf");

            if (ConvertHtmlToPdf(htmlTemplatePath, outputPdfPath, data))
            {
                return true;
            } else
            {
                return false;
            }
            
        }
    }
}
