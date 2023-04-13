using UnityEngine;

public class MaterialSource : MonoBehaviour
{
    public GameObject depletedModel;
    
    
    private void Start()
    {
        GetComponent<Health>().onDie.AddListener(SpawnPhysicsTree);
    }

    void SpawnPhysicsTree()
    {
        print(":-D)");
        if(depletedModel)Instantiate(depletedModel, transform.position, transform.rotation);
    }
}
