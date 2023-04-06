using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            health.Damage(1);
        }
    }
}
