using StudentManagement.Data;
using System.Data.SqlClient;

namespace StudentManagement.Models
{
    public class StudentDAL
    {
        private readonly ApplicationDbContext db;
        public StudentDAL(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return db.students.ToList();
        }
        public Student GetStudentById(int id) {
            var stud = db.students.Find(id);
            return stud;
        
        }
        public int AddStudent(Student stud)
        {
            db.students.Add(stud);
            int result=db.SaveChanges();
            return result;
        }
        public int UpdateStudent(Student stud)
        {
            int result = 0;
            var s=db.students.Where(x=>x.Id==stud.Id).FirstOrDefault();
            if(s!=null)
            {
                s.StudentName = stud.StudentName;
                s.FatherName= stud.FatherName;
                s.MotherName= stud.MotherName;
                s.StudentAge= stud.StudentAge;
                s.Address= stud.Address;
               result=db.SaveChanges();

            }
            return result;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;
            var s=db.students.Where(x=>x.Id == id).FirstOrDefault();
            if(s!=null)
            {
                db.students.Remove(s);
                result=db.SaveChanges();
            }
            return result;
        }
        public List<Student> SearchStudents(string searchString)
        {
            // Implement the logic to search for students based on the search string
            // For example, you can use LINQ to query the database
            var searchResults = db.students.Where(s => s.StudentName.Contains(searchString)).ToList();
            return searchResults;
        }
    }
}
