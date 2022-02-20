using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace WebApplication1.Model
{
    public class Students
    {
        List<Student> listOfStud = new List<Student>();


        public Students(String pathIn)
        {
            listOfStud = csvReader(pathIn);
        }


        public List<Student> csvReader(String pathIn)
        {
            List<Student> tmpList = new List<Student>();
            var path = pathIn;
            using (TextFieldParser csvParser = new TextFieldParser(path))


            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                
   
                while (!csvParser.EndOfData)
                {
                  

                    string[] fields = csvParser.ReadFields();
                    Student tmp = new Student(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6], fields[7], fields[8]);
                    tmpList.Add(tmp);
                }




            }

            return tmpList;
        }

        public void csvWritter(string path)
        {
            var info = typeof(Student).GetProperties();
            var sb = new StringBuilder();
            File.WriteAllText(path, string.Empty);


            foreach (var obj in listOfStud)
            
            {

                sb = new StringBuilder();
                var line = "";
                foreach(var prop in info)
                {
                    line += prop.GetValue(obj, null) + ",";
                }
                line = line.Substring(0, line.Length - 2);
                sb.AppendLine(line);
                TextWriter sw = new StreamWriter(path, true);
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();


            }




        }


        public List<Student> listReturn()
        {
            return listOfStud;
        }

        public void adder(Student st)
        {
            listOfStud.Add(st);
        }

        public bool uniIndex(Student st)
        {
            int tester = this.listOfStud.FindIndex(tmp => tmp.numerIndeksu == st.numerIndeksu);
            if(tester >= 0)
            {
                return true;
            }
            return false;

        }

        public int uniGetter(Student st)
        {
            int tester = this.listOfStud.FindIndex(tmp => tmp.numerIndeksu == st.numerIndeksu);
            if (tester >= 0)
            {
                return tester;
            }
            return -1;


        }



        public bool Replacer(Student st)
        {
            int tester = this.listOfStud.FindIndex(tmp => tmp.numerIndeksu == st.numerIndeksu);
            if (tester >= 0)
            {
                listOfStud[tester] = st;
                return true;
            }
            return false;

        }

        public bool Deleter(string indexIn)
        {
            int tester = this.listOfStud.FindIndex(tmp => tmp.numerIndeksu == indexIn);
            if (tester >= 0)
            {
               this.listOfStud.RemoveAll(x => x.numerIndeksu.Equals(indexIn));
                return true;
            }
            return false;
        }


        public bool indexTester(string indexIn)
        {
            int tester = this.listOfStud.FindIndex(tmp => tmp.numerIndeksu == indexIn);
            if (tester >= 0)
            {
                return true;
            }
            return false;
        }


        //  public Student(string indexIn)
        //  {
        //      Student tmpSt = listOfStud.Find(x => x.index == indexIn);
        //  

        //      return tmpSt;
        //  } 
    }
}
