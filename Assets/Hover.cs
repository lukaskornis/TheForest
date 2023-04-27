using UnityEngine;

public class Hover : MonoBehaviour
{
    public Vector3 direction = Vector3.up;
    public float speed = 2;
    
    private void Update()
    {
        transform.localPosition = direction * Mathf.Sin(Time.time * speed * 6.28f);
    }
}
