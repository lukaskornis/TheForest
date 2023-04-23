using UnityEngine;


[SelectionBase]
public class Player : MonoBehaviour
{
    private Health health;
    private Inventory inventory;

    private void Start()
    {
        health = GetComponent<Health>();
        inventory = GetComponent<Inventory>();
        
        //inventory.Add(new Item{ stackSize = 10});
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            health.Damage(1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            var item = collision.gameObject.GetComponent<ItemDrop>().item;
            inventory.Add(item);
            Destroy(collision.gameObject);
        }
    }
}
