using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public Item item;

    private void Start()=> SetVisuals();
    
    private void SetVisuals()
    {
        if (item.data.dropPrefab == null) return;
 // removes previous visual object
        Destroy(transform.GetChild(0).GetChild(0).gameObject);
        
        var visuals = Instantiate(item.data.dropPrefab,transform.GetChild(0));
        visuals.transform.localPosition = Vector3.zero;

        var scale = 1f / visuals.GetComponent<MeshRenderer>().localBounds.size.x;
        visuals.transform.localScale = Vector3.one * scale;

    }
}
