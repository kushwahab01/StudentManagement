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
            return db.students.Where(x =>x.IsActive==1).ToList();
        }
        public Student GetStudentById(int id) {
            var stud = db.students.Find(id);
            return stud;
        
        }
        public int AddStudent(Student stud)
        {
            stud.IsActive = 1;
            db.students.Add(stud);
            int result=db.SaveChanges();
            return result;
        }
        public int UpdateStudent(Student stud)
        {
            int result = 0;
            stud.IsActive = 1;
            var s=db.students.Where(x=>x.Id==stud.Id).FirstOrDefault();
            if(s!=null)
            {
                s.StudentName = stud.StudentName;
                s.FatherName= stud.FatherName;
                s.MotherName= stud.MotherName;
                s.StudentAge= stud.StudentAge;
                s.Address= stud.Address;
                s.IsActive= stud.IsActive;
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
               /* db.students.Remove(s);*/
               s.IsActive = 0;
                result=db.SaveChanges();
            }
            return result;
        }
        public List<Student> SearchStudents(string searchString)
        {
            DateTime searchDate;
            if (DateTime.TryParse(searchString, out searchDate))
            {
                var searchResults = db.students
                    .Where(s => s.StudentName.Contains(searchString) ||
                                s.Address.Contains(searchString) ||
                                s.RegistrationDate == searchDate)
                    .ToList();

                return searchResults;
            }
            else
            {

                var searchResults = db.students
                    .Where(s => s.StudentName.Contains(searchString) ||
                                s.Address.Contains(searchString))
                    .ToList();

                return searchResults;
            }
        }
      

    }
}
