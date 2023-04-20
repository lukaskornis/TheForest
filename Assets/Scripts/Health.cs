using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHp = 100;
    public int hp;
    public bool autoDestroy = true;
    public GameObject dieEffect;
    public GameObject damageEffect;

    public UnityEvent onDamage;
    public UnityEvent onDie;

    private void Awake()
    {
        if (hp <= 0) hp = maxHp;
    }

    public void Damage(int value)
    {
        hp -= value;
        onDamage.Invoke();
        if (damageEffect) Instantiate(damageEffect, transform.position, transform.rotation);

        if (hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        onDie.Invoke();
        if (dieEffect) Instantiate(dieEffect, transform.position, transform.rotation);
        if(autoDestroy)Destroy(gameObject);
    }
}
