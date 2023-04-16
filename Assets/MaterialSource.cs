using DG.Tweening;
using UnityEngine;

public class MaterialSource : MonoBehaviour
{
    public GameObject depletedModel;
    
    
    private void Start()
    {
        GetComponent<Health>().onDie.AddListener(SpawnPhysicsTree);
        GetComponent<Health>().onDamage.AddListener(CollectResource);
    }

    void SpawnPhysicsTree()
    {

        if(depletedModel)Instantiate(depletedModel, transform.position, transform.rotation);
    }

    void CollectResource()
    {
        //transform.DORotate(new Vector3(1,0,0), 0.05f).SetLoops(4,LoopType.Yoyo);
        transform.DOShakeRotation(0.4f, 5, 10, 10);
    }
    
}
