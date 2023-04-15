using System.ComponentModel.DataAnnotations;
using API.Repositories.Contracts;

namespace API_Tests;

public class Entity : IEntity<int>
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthdate { get; set; }
    public bool IsMarried { get; set; }

    public int Pk
    {
        get => Id;
        set => Id = value;
    }

    public override string ToString()
    {
        return $"Id : {Id}\n" +
               $"Name : {Name}\n" +
               $"Birth Date : {Birthdate}\n" +
               $"Is Married : {IsMarried}\n";
    }
    
    public static Entity Random()
    {
        var alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var random = new Random();

        string name = new string(Enumerable.Repeat(alphabet, 5).Select(s => s[random.Next(s.Length)]).ToArray());
        DateTime birthdate = new DateTime(1970, 1, 1).AddDays(random.Next((DateTime.Today - new DateTime(1970, 1, 1)).Days));
        bool isMarried = random.NextDouble() >= .5;

        return new Entity
        {
            Name = name,
            Birthdate = birthdate,
            IsMarried = isMarried
        };
    }
}