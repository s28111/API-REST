using WebApplication1.Models;

namespace WebApplication1;

public class Db
{
    public static List<Student> Students = new()
    {
        new Student { Id = 1, FirstName = "John", LastName = "Doe" },
        // new Student(1, " John", "Doe")
        new Student { Id = 2, FirstName = "Jane", LastName = "Doe" },
        new Student { Id = 3, FirstName = "Alice", LastName = "Smith" },
        new Student { Id = 4, FirstName = "Bob", LastName = "Smith" }
    };
}