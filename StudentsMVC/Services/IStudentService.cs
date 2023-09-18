using StudentsMVC.Models;

namespace StudentsMVC.Services;

// Create a interface for the StudentService class
public interface IStudentService
{
    // Create student
    Task<Student> CreateStudentAsync(Student? student);

    // Get all students
    Task<List<Student?>> GetAllStudentsAsync();

    // Get student by id
    Task<Student?> GetStudentByIdAsync(int id);

    // Update student
    Task<Student?> UpdateStudentAsync(int id, Student student);

    // Delete student
    Task DeleteStudentAsync(int id);
}