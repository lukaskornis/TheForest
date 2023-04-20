using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public int size = 8;
    public Item[] items;

    public UnityEvent onItemChanged;

    private void Start()
    {
        items = new Item[size];
    }

    public void Add(Item item)
    {
        items[0] = item;
        onItemChanged.Invoke();
    }

    public void Remove(Item item)
    {
        items[0] = null;
        onItemChanged.Invoke();
    }
    
    // get free slot id funkcija
}
