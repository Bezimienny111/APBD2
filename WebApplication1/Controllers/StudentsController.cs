using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
    
        static string data = @".\Data\baza.csv";

    [HttpGet("{indexNumber}")]
    public IActionResult GetStudent(String indexNumber){

            Students st = new Students(data);
            if (st.indexTester(indexNumber) == true)
            {
                Student tmp = st.listReturn().First(p => p.numerIndeksu == indexNumber);
                return Ok(tmp);
            }
            return Ok("Bład 12: Brak studenta na liście");


        }



    [HttpGet]
    public IActionResult GetStudents()
    {
            
            Students st = new Students(data);
       // var list = new List<Student>();
       // list.Add(new Student { index = "15", name = "rob", surname = "kow" });



        return Ok(st.listReturn());


    }

    [HttpPost("{studentData}")]
        public IActionResult CreateStudents(String studentData)
        {


            Students st = new Students(data);

            Student newIn = new Student(studentData);

            string test = Student.Test(newIn);

            if (test.Equals("ok"))
            {
                if (st.uniIndex(newIn) == true)
                    return Ok("Błąd 10: Index już występuje.;");
                else
                {

                    st.adder(newIn);
                    st.csvWritter(data);
                    return Ok(st.listReturn());
                }
            }
            return Ok(test);
        }



        [HttpPut("{studentData}")]
        public IActionResult UpdateStudents(String studentData)
        {

            Students st = new Students(data);

            Student newIn = new Student(studentData);

            string test = Student.Test(newIn);

            if (test.Equals("ok")) {
                if (!st.uniGetter(newIn).Equals(-1))
                {
                    st.listReturn()[st.uniGetter(newIn)] = newIn;
                    st.csvWritter(data);
                    return Ok(st.listReturn());
                }
                else
                    return Ok("Bład 11: nie ma takiego indeksu.;");
            }
            return Ok(test);
        }



    
    [HttpDelete("{indexNumber}")]
    public IActionResult DeleteStudents(String indexNumber){

            Students st = new Students(data);

            if (st.Deleter(indexNumber) == true)
            {
                st.csvWritter(data);
                return Ok(st.listReturn());
            }

            return Ok("Bład 12: Nie ma takiego studenta");


    }


    }
}
