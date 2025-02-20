namespace SharedModels;

public class Parent
{
    public HashSet<Child> Children { get; set; } = [];
}