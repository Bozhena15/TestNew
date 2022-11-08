namespace ConsoleSt;

enum Color { Red, Yellow, Black }

/// <summary>
/// Model of <c>Student</c>
/// </summary>
public class Student
{
    /// <summary>
    /// Student's firstname
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// Student's lastname
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// Student's age
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Get student's marks
    /// </summary>
    /// <param name="student">info about student</param>
    /// <returns>Marks</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="student"/> is null</exception>
    public static List<int> GetStudentsMarks(Student student)
    {
        if (student == null)
            throw new ArgumentNullException();

        return new List<int> { 3, 2, 4, 2, 2, 3, 1, 12, 1 };
    }
}
