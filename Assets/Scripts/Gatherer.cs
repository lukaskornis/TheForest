using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Gatherer : MonoBehaviour
{

    public float cooldownTime = 1;
    
    public float range = 2;
    public int damage = 1;
    public string resourceTag;
    public  bool canUse = true;
    
    private void Update()
    {
        if (canUse && Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(CooldownRoutine());
            
            transform
                .DOLocalRotate(new Vector3(0, 0, -90), 0.15f)
                .SetLoops(2, LoopType.Yoyo)
                .OnComplete(() => transform.localEulerAngles = Vector3.zero);
            
            
            var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            
            if (Physics.Raycast(ray,out var hit,range))
            {
                if (hit.collider.CompareTag(resourceTag))
                {
                    hit.collider.GetComponent<Health>()?.Damage(damage);
                }
            }
        }
    }

    IEnumerator CooldownRoutine()
    {
        canUse = false;
        yield return new WaitForSeconds(cooldownTime);
        canUse = true;
    }
}
