using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.IO;
using Accord.MachineLearning;
using Accord.Statistics.Models.Regression;

namespace BUS
{
    public class BUS_AI
    {
        private TFIDF codebook;
        private LogisticRegression reg;

        public BUS_AI()
        {
            // get model
            // tf-idf
            string filenameLogisticRegression = Path.Combine(Directory.GetCurrentDirectory(), "LogisticRegression.accord");
            string filenameTFIDF = Path.Combine(Directory.GetCurrentDirectory(), "TFIDF.accord");

            Serializer.Load(filenameTFIDF + ".gz", out codebook);
            Serializer.Load(filenameLogisticRegression + ".gz", out reg);
        }

        public bool getResult(string pBinhLuan)
        {
            double[] bow = codebook.Transform(pBinhLuan.Tokenize());

            return reg.Decide(bow);
        }
    }
}
