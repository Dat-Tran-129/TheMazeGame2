﻿namespace TheMazeGame2;

public class Player : GameObject, IHaveInventory
{
    private Inventory _inventory;
    private Location _location;

    public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
    {
        _inventory = new Inventory();
    }

    public GameObject Locate(string id)
    {
        if (AreYou(id))
        {
            return this;
        }
        GameObject obj = _inventory.Fetch(id);
        if (obj != null)
        {
            return obj;
        }
        if (_location != null)
        {
            obj = _location.Locate(id);
            return obj;
        }
        else
        {
            return null;
        }
    }

    public override string FullDescription
    {
        get => $"You are {Name}, you are carrying\n{_inventory.ItemList}";
    }

    public Inventory Inventory
    {
        get => _inventory;
        
    }

    public Location Location
    {
        get => _location;
        set => _location = value;
    }

    public void Move(Path path)
    {
        if (path.Destination != null)
        {
            _location = path.Destination;
        }
    }

}