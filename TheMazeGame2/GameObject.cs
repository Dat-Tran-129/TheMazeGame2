namespace TheMazeGame2;

public class GameObject : IdentifiableObject
{
    private string _description, _name;

    public GameObject(string[] ids, string name, string desc) : base(ids)
    {
        _name = name;
        _description = desc;
    }

    public string Name
    {
        get => _name;
    }
    
    public virtual string ShortDescription
    {
        get => $"{_name} - {FirstID}";
        
    }

    public virtual string FullDescription
    {
        get =>_description;
    }
}