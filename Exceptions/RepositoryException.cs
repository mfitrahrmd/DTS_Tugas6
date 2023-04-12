namespace DTS_Tugas6.Repositories.Implementations;

public class RepositoryException : Exception
{
    public string Field { get; }
    
    public RepositoryException(string message) : base(message)
    {
        
    }
    
    public RepositoryException(string message, string field) : base(message)
    {
        Field = field;
    }
    
}