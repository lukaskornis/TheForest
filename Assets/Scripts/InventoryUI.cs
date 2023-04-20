using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;

    private void Start()
    {
        inventory.onItemChanged.AddListener(ItemChanged);
    }

    void ItemChanged()
    {
        print(":D");
    }
}
