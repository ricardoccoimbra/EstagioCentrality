using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ComparaçãoDeFicheirosExcel.Models
{
    public class CompararFicheiros
    {

         public static bool CompareExcelSheets(string file1, string file2)
         {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            using (var package1 = new ExcelPackage(new FileInfo(file1)))
            using (var package2 = new ExcelPackage(new FileInfo(file2)))
            {
                var sheet1 = package1.Workbook.Worksheets["Folha1"];
                var sheet2 = package2.Workbook.Worksheets["Folha1"];

                // Comparar valores nas células
                for (int row = sheet1.Dimension.Start.Row; row <= sheet1.Dimension.End.Row; row++)
                {
                    //Verificar o porquê de ir até a coluna 6, visto que só está ocupar 2 colunas
                    for (int col = sheet1.Dimension.Start.Column; col <= sheet1.Dimension.End.Column; col++)
                    {
                        var val1 = sheet1.Cells[row, col].Value;
                        var val2 = sheet2.Cells[row, col].Value;

                        if (!object.Equals(val1, val2))
                        {
                            // As células não são iguais
                            return false;
                        }
                    }
                }

                // Todas as células são iguais
                return true;
            }
        }

    }
}