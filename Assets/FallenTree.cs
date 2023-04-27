using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenTree : MonoBehaviour
{
    public GameObject resourcePrefab;
    public void OnDamage(Vector3 hitPosition)
    {
        Instantiate(resourcePrefab, hitPosition, Quaternion.Euler(0, 0, 0));
    }
}
