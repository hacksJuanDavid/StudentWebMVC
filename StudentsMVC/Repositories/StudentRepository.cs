using StudentsMVC.Interfaces;
using StudentsMVC.Models;
using StudentsMVC.Services;

namespace StudentsMVC.Repositories;

// Create a repository for the Student model
public class StudentRepository : IStudentRepository
{
    private readonly IStudentService _studentService;

    public StudentRepository(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<List<Student>?> GetAllStudentsAsync()
    {
        return await _studentService.GetAllStudentsAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        return await _studentService.GetStudentByIdAsync(id);
    }

    public async Task<Student?> CreateStudentAsync(Student? student)
    {
        return await _studentService.CreateStudentAsync(student);
    }

    public async Task<Student?> UpdateStudentAsync(int id, Student? student)
    {
        return await _studentService.UpdateStudentAsync(id, student);
    }

    public async Task DeleteStudentAsync(int id)
    {
        await _studentService.DeleteStudentAsync(id);
    }
}