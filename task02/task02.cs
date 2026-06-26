using System.Linq;
namespace task02;
public class Student
{
    public required string Name { get; set; }
    public required string Faculty { get; set; }
    public required List<int> Grades { get; set; }
}


public class StudentService
{
    private readonly List<Student> _students;

    public StudentService(List<Student> students) => _students = students;
    public IEnumerable<Student> GetStudentsByFaculty(string faculty)
    => from student in _students
           where student.Faculty == faculty
           select student;
    public IEnumerable<Student> GetStudentsWithMinAverageGrade(double minAverageGrade) => from student in _students
           where student.Grades.Average() >= minAverageGrade
           select student;

    public IEnumerable<Student> GetStudentsOrderedByName()
        => from student in _students
           orderby student.Name
           select student;
    public ILookup<string, Student> GroupStudentsByFaculty() => _students.ToLookup(student => student.Faculty);
    public string GetFacultyWithHighestAverageGrade()
    {
        var groupByFaculty = from student in _students group student.Grades.Average() by student.Faculty;
        var groupByOrderAverageGrade = from studentAverageGrade in groupByFaculty orderby studentAverageGrade.Average()  descending select studentAverageGrade;
        return groupByOrderAverageGrade.First().Key; 
    }
}