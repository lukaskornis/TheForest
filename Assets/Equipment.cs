using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public Transform hand;

    public void Equip(Item item)
    {
        if (hand.childCount > 0)
        {
            Destroy(hand.GetChild(0).gameObject);
        }
        
        var obj = Instantiate(item.data.toolPrefab,hand);
        obj.transform.localPosition = Vector3.zero;
    }
}
