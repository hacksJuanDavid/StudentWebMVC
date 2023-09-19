using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StudentsMVC.Models;
using RestSharp;
using StudentsMVC.Settings;

namespace StudentsMVC.Services;

public class StudentService : IStudentService
{   
    private readonly RestClient _client;

    public StudentService(IOptions<AppSettings> appSettings, RestClient client)
    {   
        // Client
        _client = client;
        
        // ApiStudentUrl
        var apiStudentUrl = appSettings.Value.ApiStudentUrl;
        
        // Client Init with ApiStudentUrl
        if (apiStudentUrl != null) _client = new RestClient(apiStudentUrl);
    }
    
    // Function CreateStudent
    public async Task<Student?> CreateStudentAsync(Student? student)
    {
        // POST Student with RestSharp
        var request = new RestRequest("students/");

        // Json not null
        if (student == null)
        {
            return null;
        }

        // Serializar el objeto student a JSON
        var studentJson = JsonConvert.SerializeObject(student);

        // Agregar el JSON serializado al cuerpo de la solicitud
        request.AddParameter("application/json", studentJson, ParameterType.RequestBody);

        // Print Json body
        Console.WriteLine($"Request JSON Body Post: {studentJson}");

        // Execute request
        var response = await _client.PostAsync(request);

        if (response.IsSuccessful)
        {
            return response.IsSuccessful ? student : null;
        }
        else
        {
            // Aquí puedes manejar errores de solicitud, por ejemplo, lanzar una excepción.
            throw new ArgumentNullException($"Error al crear estudiante: {response.StatusCode}");
        }
    }

    // Function GetAllStudents
    public async Task<List<Student>?> GetAllStudentsAsync()
    {
        // GET Request with RestSharp
        var request = new RestRequest("students/");
        var response = await _client.ExecuteAsync<List<Student>>(request);

        if (response.IsSuccessful)
        {
            return response.Data;
        }
        else
        {
            // Aquí puedes manejar errores de solicitud, por ejemplo, lanzar una excepción.
            throw new ArgumentNullException($"Error al obtener estudiantes: {response.StatusCode}");
        }
    }

    // Function GetStudentById
    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        // GET Student by id with RestSharp
        var request = new RestRequest("students/{id}");

        // Add id to request
        request.AddUrlSegment("id", id);

        // Execute request
        var response = await _client.ExecuteAsync<Student>(request);

        if (response.IsSuccessful)
        {
            return response.Data;
        }

        // Aquí puedes manejar errores de solicitud, por ejemplo, lanzar una excepción.
        throw new ArgumentNullException($"Error al obtener estudiante: {response.StatusCode}");
    }

    // Function UpdateStudent
    public async Task<Student?> UpdateStudentAsync(int id, Student? student)
    {
        // PUT Student by id with RestSharp
        var request = new RestRequest("students/{id}");

        // Add id to request
        request.AddUrlSegment("id", id);

        // Json not null
        if (student == null)
        {
            return null;
        }

        // Serializar el objeto student a JSON
        var studentJson = JsonConvert.SerializeObject(student);

        // Agregar el JSON serializado al cuerpo de la solicitud
        request.AddParameter("application/json", studentJson, ParameterType.RequestBody);

        // Print Json body
        Console.WriteLine($"Request JSON Body Put: {studentJson}");

        // Execute request
        var response = await _client.PutAsync(request);

        if (response.IsSuccessful)
        {
            return response.IsSuccessful ? student : null;
        }
        else
        {
            // Aquí puedes manejar errores de solicitud, por ejemplo, lanzar una excepción.
            throw new ArgumentNullException($"Error al actualizar estudiante: {response.StatusCode}");
        }
    }

    // Function DeleteStudent
    public async Task DeleteStudentAsync(int id)
    {
        // DELETE Student by id with RestSharp
        var request = new RestRequest("students/{id}");

        // Add id to request
        request.AddUrlSegment("id", id);

        // Execute request
        var response = await _client.DeleteAsync(request);

        if (!response.IsSuccessful)
        {
            // Aquí puedes manejar errores de solicitud, por ejemplo, lanzar una excepción.
            throw new ArgumentNullException($"Error al eliminar estudiante: {response.StatusCode}");
        }
    }
}