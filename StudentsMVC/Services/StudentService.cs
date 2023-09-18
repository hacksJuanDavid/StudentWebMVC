using Microsoft.AspNetCore.Http.HttpResults;
using StudentsMVC.Models;

namespace StudentsMVC.Services;

public class StudentService : IStudentService
{
    // Create a list of students
    private static List<Student?> _students = LoadStudents();

    private static List<Student?> LoadStudents()
    {
        List<Student?> students = new List<Student?>();

        students.Add(new Student()
            { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 10, 10), Sex = 'M' });
        students.Add(new Student()
            { Id = 2, FirstName = "Barry", LastName = "Allen", DateOfBirth = new DateTime(2001, 7, 7), Sex = 'M' });
        students.Add(new Student()
            { Id = 3, FirstName = "Diana", LastName = "Prince", DateOfBirth = new DateTime(1950, 8, 8), Sex = 'F' });

        return students;
    }

    public Task<Student> CreateStudentAsync(Student? student)
    {
        // if student is null, return null
        if (student == null)
        {
            return Task.FromResult<Student>(null!);
        }

        student.Id = _students.Max(s => s.Id) + 1;

        // Add student to list
        _students.Add(student);

        // Return student
        return Task.FromResult(student);
    }

    public Task<List<Student?>> GetAllStudentsAsync()
    {
        return Task.FromResult(_students);
    }

    public Task<Student?> GetStudentByIdAsync(int id)
    {
        // Get student by id
        var student = _students.FirstOrDefault(s => s != null && s.Id == id);

        // Return student
        return Task.FromResult(student);
    }

    public Task<Student?> UpdateStudentAsync(int id, Student student)
    {
        // Get student by id
        var studentToUpdate = _students.FirstOrDefault(s => s != null && s.Id == id);

        if (studentToUpdate != null)
        {
            // Update student
            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.DateOfBirth = student.DateOfBirth;
            studentToUpdate.Sex = student.Sex;
        }

        // Return student
        return Task.FromResult(studentToUpdate);
    }

    public Task DeleteStudentAsync(int id)
    {
        // Get student by id
        var studentToDelete = _students.FirstOrDefault(s => s != null && s.Id == id);

        if (studentToDelete != null)
        {
            // Delete student
            _students.Remove(studentToDelete);
        }

        return Task.CompletedTask;
    }
}