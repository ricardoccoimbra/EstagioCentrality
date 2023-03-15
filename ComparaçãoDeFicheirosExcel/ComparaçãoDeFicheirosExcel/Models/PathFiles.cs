using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;

namespace ComparaçãoDeFicheirosExcel.Models
{
    public class PathFiles
    {
        [Required(ErrorMessage = "Por favor, selecione um arquivo para upload.")]
        [DataType(DataType.Upload)]
        public string path_ficheiro1 { get; set; }
        public string path_ficheiro2 { get; set; }
        public string path_ficheiroMudancas { get; set; }

        
    }
}