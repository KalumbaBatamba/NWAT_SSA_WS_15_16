﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace NWAT.Printer
{
    class AnalysisPrinter
    {
       
        Document doc;

        public AnalysisPrinter()

        {
        
        this.doc = new Document();
        
        }

        public void printAnalysis()
        {
        
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("Analysis.pdf", FileMode.Create));
           

        }
    }
}
