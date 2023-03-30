using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class VolumeSpawner : MonoBehaviour
{
    public Collider renderer;
    public GameObject prefab;
    public bool spawnAtStart = true;
    public bool randomRotation = true;

    public Vector2 count;
    public float height = 50;
    public float gapSize = 50;
    public float offset = 20;
    public float spawnChance = 0.8f;
    
    private void Start()
    {
        if(spawnAtStart)Spawn();
    }


    public void Spawn()
    {
        var bounds = renderer.bounds;
        
        for (var z = bounds.min.z; z < bounds.max.z; z+=gapSize)
        {
            for (var x = bounds.min.x; x < bounds.max.x; x+=gapSize)
            {
                var chance = Random.Range(0f,1f);
                if(chance > spawnChance)continue;
                
                var pos = new Vector3(x, height, z);
                pos += Random.insideUnitSphere * offset;

                var rot = Quaternion.Euler(0, 0, 0);
                if (randomRotation)
                {
                    rot = Quaternion.Euler(0, Random.Range(0f,360f), 0);
                }
            
                Instantiate(prefab,pos,rot);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (!renderer) return;
        
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube( renderer.bounds.center + Vector3.up * height, renderer.bounds.size);
    }
}
