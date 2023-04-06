using UnityEngine;

public class MaterialSource : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Health>().onDie.AddListener(SpawnPhysicsTree);
    }

    void SpawnPhysicsTree()
    {
        print(":-D)");
    }
}
