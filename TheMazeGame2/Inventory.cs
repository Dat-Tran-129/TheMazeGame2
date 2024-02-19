namespace TheMazeGame2;

public class Inventory
{
    private List<Item> _items;

    public Inventory()
    {
        _items = new List<Item>();
    }

    public bool HasItem(string id)
    {
        foreach (Item i in _items)
        {
            if (i.AreYou(id))
            {
                return true;
            }

        }
        return false;
    }

    public void Put(Item item)
    {
        _items.Add(item);
    }

    public Item Take(string id)
    {
        Item takeitem = this.Fetch(id);
        _items.Remove(takeitem);
        return takeitem;
    }

    public Item Fetch(string id)
    {
        foreach (Item i in _items)
        {
            if (i.AreYou(id))
            {
                return i;
            }
        }
        return null;
    }

    public string ItemList
    {
        get
        {
            string listitem = "";
            foreach (Item i in _items)
            {
                listitem = listitem + i.ShortDescription + "\n";
            }
            return listitem;
        }
    }

    public int Count
    {
        get => _items.Count;
    }
}