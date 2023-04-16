using UnityEngine;

public class Gatherer : MonoBehaviour
{
    public float range = 2;
    public int damage = 1;
    public string resourceTag;
    public Transform toolModel;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
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
}
