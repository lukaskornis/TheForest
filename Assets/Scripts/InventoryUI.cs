using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public GameObject slotPrefab;
    public Transform horizontalGroup;

    private List<ItemSlotUI> slots = new();

    private void Start()
    {
        inventory.onItemChanged.AddListener(ItemChanged);

        for (int i = 0; i < inventory.size; i++)
        {
            var slot = Instantiate(slotPrefab,horizontalGroup);
            slots.Add(slot.GetComponent<ItemSlotUI>());
        }
    }

    void ItemChanged(int i)
    {
        print(":D" + i);
        slots[i].UpdateUI(inventory.items[i]);
    }
}
