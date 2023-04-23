using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public int size = 8;
    public Item[] items;

    public UnityEvent<int> onItemChanged;

    private void Awake()
    {
        items = new Item[size];
    }

    public void Add(Item item)
    {
        var i = GetFirstEmptySlot();
        items[i] = item;
        onItemChanged.Invoke(i);
    }

    public void Remove(Item item)
    {
        items[0] = null;
        onItemChanged.Invoke(0); // TODO paskeist sita nesamone!
    }
    
    // get free slot id funkcija
    int GetFirstEmptySlot()
    {
        for (int i = 0; i < size; i++)
        {
            if (items[i] == null) return i;
            if (items[i].data == null) return i;
        }
        return -1;
    }
}
