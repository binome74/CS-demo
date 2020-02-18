using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AI_04 {
    public delegate void ListsChangedEvent();
    public delegate void WVectorChangeEvent();

    class Neural {
        // Коэффициент скорости обучения
        private const double C = 0.1;
        private const string saveFormat = "G20";

        private List<double[]> PDF;
        private List<double[]> nonPDF;
        private double[] W;

        public event ListsChangedEvent ListsChanged;
        public event WVectorChangeEvent WVectorChange;

        public Neural() {
            PDF = new List<double[]>();
            nonPDF = new List<double[]>();
            W = null;
        }

        public int PDFVectorsCount {
            get { return PDF.Count; }
        }

        public int NonPDFVectorsCount {
            get { return nonPDF.Count; }
        }

        public bool WVectorState {
            get { return (W != null); }
        }

        public bool VectorsEmpty {
            get { return (PDF.Count == 0 && nonPDF.Count == 0); }
        }

        public void ClearVectors() {
            PDF.Clear();
            nonPDF.Clear();
            ListsChangedEvent temp = ListsChanged;
            if (temp != null) temp();
        }

        public void CreateInputVector(string filename, bool isPDF) {
            FileStream fileRead = new FileStream(@filename, FileMode.Open);
            double[] Vector = new double[256];
            int read;

            Array.Clear(Vector, 0, Vector.Length);
            while ((read = fileRead.ReadByte()) >= 0) {
                Vector[read] += 1.0;
            }
            for (int i = 0; i < Vector.Length; i++) {
                Vector[i] /= fileRead.Length;
            }

            if (isPDF == true) {
                PDF.Add(Vector);
                ListsChangedEvent temp = ListsChanged;
                if (temp != null) temp();
            } else {
                nonPDF.Add(Vector);
                ListsChangedEvent temp = ListsChanged;
                if (temp != null) temp();
            }

            fileRead.Close();
        }

        public void CreateInputVectors(string list, bool isPDF) {
            String line;

            using (StreamReader sr = new StreamReader(@list)) {
                while ((line = sr.ReadLine()) != null)  {
                    CreateInputVector(line, isPDF);
                }
            }
        }

        public void SaveVectorsToFile(string path) {
            using (StreamWriter sw = new StreamWriter(@path)) {
                foreach (double[] v in PDF) {
                    sw.Write("PDF");
                    for (int i = 0; i < v.Length; i++) {
                        sw.Write(":");
                        sw.Write(v[i].ToString(saveFormat));
                    }
                    sw.WriteLine(";");
                }
                foreach (double[] v in nonPDF) {
                    sw.Write("OTH");
                    for (int i = 0; i < v.Length; i++) {
                        sw.Write(":");
                        sw.Write(v[i].ToString(saveFormat));
                    }
                    sw.WriteLine(";");
                }
            }
        }

        public void ReadVectorsFromFile(string path) {
            String line;
            String[] buf;
            double[] Vector;

            //ClearVectors();

            using (StreamReader sr = new StreamReader(@path)) {
                while ((line = sr.ReadLine()) != null) {
                    buf = line.Substring(0, line.Length - 1).Split(new Char[] {':'});
                    if (buf.Length != 257) throw new Exception("Файл не соответствует принятому формату");
                    if ((buf[0] != "PDF") && (buf[0] != "OTH")) throw new Exception("Файл не соответствует принятому формату");
                    Vector = new double[256];
                    for (int i = 1; i < buf.Length; i++) {
                        Vector[i - 1] = Convert.ToDouble(buf[i]);
                    }
                    if (buf[0] == "PDF") {
                        PDF.Add(Vector);
                        ListsChangedEvent temp = ListsChanged;
                        if (temp != null) temp();
                    } else {
                        nonPDF.Add(Vector);
                        ListsChangedEvent temp = ListsChanged;
                        if (temp != null) temp();
                    }
                }
            }
        }

        private int Determine(double[] vector) {
            double sum = 0.0;
            for (int i = 0; i < vector.Length; i++) {
                sum += vector[i] * W[i];
            }
            if (sum > 0.0) {
                return 1;
            } else {
                return -1;
            }
        }

        public string DetermineFileFormat(string filename) {
            FileStream fileRead = new FileStream(@filename, FileMode.Open);
            double[] Vector = new double[256];
            int read;

            if (W == null) throw new ArgumentNullException("Вектор весовых коэффициентов пуст");

            Array.Clear(Vector, 0, Vector.Length);
            while ((read = fileRead.ReadByte()) >= 0) {
                Vector[read] += 1.0;
            }
            for (int i = 0; i < Vector.Length; i++) {
                Vector[i] /= fileRead.Length;
            }

            fileRead.Close();

            if (Determine(Vector) > 0) {
                return "PDF";
            } else {
                return "не PDF";
            }
        }


        public double Teach() {
            double quality = 0.0;
            double[] v = null;
            Random Rand = new Random();
            int i, it_counter = 0;
            int pdf_pos, non_pos, now;

            if (PDF.Count == 0) throw new Exception("Нет входных векторов для PDF");
            if (nonPDF.Count == 0) throw new Exception("Нет входных векторов для не PDF");

            W = (double[])PDF[0].Clone();

            while ((quality < 0.925) || (it_counter < 5)) {
                quality = 0.0;
                pdf_pos = non_pos = 0;

                while ((pdf_pos < PDF.Count) || (non_pos < nonPDF.Count)) {
                    // Выдаем векторы в случайном порядке
                    now = Rand.Next(2);
                    if (((now == 0) && (pdf_pos < PDF.Count)) || (non_pos >= nonPDF.Count)) {
                        v = PDF[pdf_pos++];
                        if (Determine(v) < 0) {
                            // сеть ошиблась
                            for (i = 0; i < W.Length; i++) {
                                W[i] += 2.0 * C * v[i];
                            }
                        } else {
                            // сеть молодец
                            quality += 1.0;
                        }
                    } else if (non_pos < nonPDF.Count) {
                        v = nonPDF[non_pos++];
                        if (Determine(v) > 0) {
                            // сеть ошиблась
                            for (i = 0; i < W.Length; i++) {
                                W[i] -= 2.0 * C * v[i];
                            }
                        } else {
                            // сеть молодец
                            quality += 1.0;
                        }
                    }
                }

                /*foreach (double[] v in nonPDF) {
                    if (Determine(v) > 0) {
                        // сеть ошиблась
                        for (i = 0; i < W.Length; i++) {
                            W[i] -= 2.0 * C * v[i];
                        }
                    } else {
                        // сеть молодец
                        quality += 1.0;
                    }
                }
                foreach (double[] v in PDF) {
                    if (Determine(v) < 0) {
                        // сеть ошиблась
                        for (i = 0; i < W.Length; i++) {
                            W[i] += 2.0 * C * v[i];
                        }
                    } else {
                        // сеть молодец
                        quality += 1.0;
                    }
                }*/
                quality /= PDF.Count + nonPDF.Count;
                if (++it_counter > 10000) {
                    W = null;
                    throw new Exception("Алгоритм зациклился");
                }
            }
            WVectorChangeEvent temp = WVectorChange;
            if (temp != null) temp();
            return quality;
        }

        public void SaveWToFile(string path) {
            if (W == null) throw new ArgumentNullException("Вектор W пуст");

            using (StreamWriter sw = new StreamWriter(@path)) {
                sw.Write("WV");
                for (int i = 0; i < W.Length; i++) {
                    sw.Write(":");
                    sw.Write(W[i].ToString(saveFormat));
                }
                sw.WriteLine(";");
            }
        }

        public void ReadWFromFile(string path) {
            String line;
            String[] buf;

            W = null;

            using (StreamReader sr = new StreamReader(@path)) {
                while ((line = sr.ReadLine()) != null) {
                    buf = line.Substring(0, line.Length - 1).Split(new Char[] { ':' });
                    if (buf.Length != 257) throw new Exception("Файл не соответствует принятому формату");
                    if (buf[0] != "WV") throw new Exception("Файл не соответствует принятому формату");
                    W = new double[256];
                    for (int i = 1; i < buf.Length; i++) {
                        W[i - 1] = Convert.ToDouble(buf[i]);
                    }
                }
            }
            if (W == null) {
                throw new Exception("Файл не соответствует принятому формату");
            } else {
                WVectorChangeEvent temp = WVectorChange;
                if (temp != null) temp();
            }
        }
    }
}
