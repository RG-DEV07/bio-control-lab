using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BioControlLab.Utils
{
    public static class Exportador
    {
        public static void ExportarCSV(DataGridView dgv, string nombreArchivo)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Archivo CSV (*.csv)|*.csv";
            save.FileName = nombreArchivo;

            if (save.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    sb.Append(dgv.Columns[i].HeaderText);
                    if (i < dgv.Columns.Count - 1) sb.Append(",");
                }
                sb.AppendLine();

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        sb.Append(row.Cells[i].Value?.ToString() ?? "");
                        if (i < dgv.Columns.Count - 1) sb.Append(",");
                    }
                    sb.AppendLine();
                }

                File.WriteAllText(save.FileName, sb.ToString());
                MessageBox.Show("Datos exportados correctamente.");
            }
        }

        public static void ExportarPDF(DataGridView dgv, string nombreArchivo, string titulo)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Archivo PDF (*.pdf)|*.pdf";
            save.FileName = nombreArchivo;

            if (save.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
                PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));
                doc.Open();

                Font fontTitulo = FontFactory.GetFont("Arial", 16, Font.BOLD);
                Paragraph p = new Paragraph(titulo, fontTitulo);
                p.Alignment = Element.ALIGN_CENTER;
                p.SpacingAfter = 15;
                doc.Add(p);

                PdfPTable tabla = new PdfPTable(dgv.Columns.Count);
                tabla.WidthPercentage = 100;

                Font fontHeader = FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.WHITE);
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText, fontHeader));
                    cell.BackgroundColor = new BaseColor(52, 152, 219);
                    cell.Padding = 5;
                    tabla.AddCell(cell);
                }

                Font fontCelda = FontFactory.GetFont("Arial", 9);
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        tabla.AddCell(new Phrase(cell.Value?.ToString() ?? "", fontCelda));
                    }
                }

                doc.Add(tabla);
                doc.Close();

                MessageBox.Show("PDF exportado correctamente.");
            }
        }
    }
}