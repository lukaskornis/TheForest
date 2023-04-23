using System;
using UnityEngine;


[SelectionBase]
public class Player : MonoBehaviour
{
    private Health health;
    private Inventory inventory;
    private Equipment equipment;

    private void Start()
    {
        health = GetComponent<Health>();
        inventory = GetComponent<Inventory>();
        equipment = GetComponent<Equipment>();

        //inventory.Add(new Item{ stackSize = 10});
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            equipment.Equip(inventory.items[0]);
        }
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
