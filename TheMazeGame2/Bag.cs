﻿namespace TheMazeGame2;

public class Bag : Item, IHaveInventory
{
    private Inventory _inventory;

    public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
    {
        _inventory = new Inventory();
    }

    public GameObject Locate(string id)
    {
        if (AreYou(id))
        {
            return this;
        } else if (_inventory.HasItem(id))
        {
            return _inventory.Fetch(id);
        }

        return null;
    }

    public override string FullDescription
    {
        get => $"{this.Name}, containing:\n" + _inventory.ItemList;
    }

    public Inventory Inventory
    {
        get => _inventory;
    }
}