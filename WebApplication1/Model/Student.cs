using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebApplication1.Model
{
    public class Student
    {
        public string imie { get; set; }
        public string nazwisko { set; get; }
        public string numerIndeksu { get; set; }
        public string dataUrodzenia { get; set; }
        public string studia { get; set; }
        public string tryb { get; set; }
        public string email { get; set; }
        public string imieOjca { get; set; }
        public string imieMatki { get; set; }




        public Student(string nameIN, string surnameIN, string indexIn, string dateIn, string studiaIn, string trybyIn, string emailIn, string imOjIn, string imMatIn)
        {
            imie = nameIN;
            nazwisko = surnameIN;
            numerIndeksu = indexIn;
            dataUrodzenia = dateIn;
            studia = studiaIn;
            tryb = trybyIn;
            email = emailIn;
            imieOjca = imOjIn;
            imieMatki = imMatIn;


        }

        public Student(string jsonIn)
        {

            Student student = Deserialize<Student>(jsonIn);
            imie = student.imie;
            nazwisko = student.nazwisko;
            numerIndeksu = student.numerIndeksu;
            dataUrodzenia = Replacer(student.dataUrodzenia);
            studia = student.studia;
            tryb = student.tryb;
            email = student.email;
            imieOjca = student.imieOjca;
            imieMatki = student.imieMatki;



        }

        public Student(Student student)
        {
            imie = student.imie;
            nazwisko = student.nazwisko;
            numerIndeksu = student.numerIndeksu;
            dataUrodzenia = student.dataUrodzenia;
            studia = student.studia;
            tryb = student.tryb;
            email = student.email;
            imieOjca = student.imieOjca;
            imieMatki = student.imieMatki;

        }


        public Student()
        {

        }

        public static Student Deserialize<Student>(string json)
        {
            Student obj = Activator.CreateInstance<Student>();
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(@json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            obj = (Student)serializer.ReadObject(ms);
            ms.Close();
            return obj;
        }

        public static string Test(Student st)
        {

            bool nameTest = true;
            bool nazwiskoTest = true;
            bool numerIndeksuTest = true;
            bool dataUrodzeniaTest = true;
            bool studiaTest = true;
            bool trybTest = true;
            bool emailTest = true;
            bool imieOjcaTest = true;
            bool imieMatkiTest = true;

            bool validIndex = true;
         //   bool emptyIndex = true;

            StringBuilder myStringBuilder = new StringBuilder();

            if (st.imie == null) {
                nameTest = false;
                myStringBuilder.Append("KOD 1:Brak imienia; ");
            }
            if (st.nazwisko == null) {
                nazwiskoTest = false;
                myStringBuilder.Append("KOD 2:Brak nazwiska; ");
            }
            if (st.numerIndeksu == null)
            {
                numerIndeksuTest = false;
                myStringBuilder.Append("KOD 3:Brak indeksu; ");

            }
             if (IndexVerification(st.numerIndeksu) == -1)
             {
                    validIndex = false;
                    myStringBuilder.Append("KOD 3.1:Zły format indexu; ");
             }

            //  if (IndexVerification(st.numerIndeksu) == 0)
           //   {
           //         emptyIndex = false;
           //         myStringBuilder.Append("KOD 3.2:Index jest pusty; ");
           //  }
            if (st.dataUrodzenia == null)
            {
                dataUrodzeniaTest = false;
                myStringBuilder.Append("KOD 4:Brak daty; ");
            }

            if (st.studia == null) {
                studiaTest = false;
                myStringBuilder.Append("KOD 5:Brak studiow; ");
            }

            if (st.tryb == null) {
                trybTest = false;
                myStringBuilder.Append("KOD 6:Brak trybu; ");
            }


            if (st.email == null)
            {
                emailTest = false;
                myStringBuilder.Append("KOD 7:Brak emaila; ");
            }

            if (st.imieOjca == null) { 
            imieOjcaTest = false;
            myStringBuilder.Append("KOD 8:Brak imienia ojca; ");
              }
            if (st.imieMatki == null)
            {
                imieMatkiTest = false;
                myStringBuilder.Append("KOD 9:Brak matki;");
            }

            if (
             nameTest == true &&
             nazwiskoTest == true &&
             numerIndeksuTest == true &&
             dataUrodzeniaTest == true &&
             studiaTest == true &&
             trybTest == true &&
             emailTest == true &&
             imieOjcaTest == true &&
             imieMatkiTest == true &&
             validIndex == true //&&
          //   emptyIndex == true
             
             )
            {
                return "ok";
            }
            else
            {
                return myStringBuilder.ToString();
            } 


        }


        public static int IndexVerification (string str)
        {

            int tmp = 1;
            Regex regex = new Regex("^s[0-9]{4}$");
            Match match = regex.Match(str);

            if (!match.Success)
            {
                tmp = -1;
            }   
           
            return tmp;

        }

        public int CompareIndex(string str)
        {
            int tmp = 0;
            if (this.numerIndeksu.Equals(str))
                tmp = -1;
            else
                tmp = 1;

            return tmp;
        }

        public static string Replacer(string str)
        {
            string outString = str.Replace("%2F", @"/");

            return outString;

        }

    }
}
