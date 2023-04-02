using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class VolumeSpawner : MonoBehaviour
{
    public int seed;
    public Collider renderer;
    public List<GameObject> prefabs;
    public bool spawnAtStart = true;
    public bool randomRotation = true;
    public bool raycastDown;
    public string targetTag;

    public Vector2 count;
    public float height = 50;
    public float gapSize = 50;
    public float offset = 20;
    public float spawnChance = 0.8f;
    
    private void Start()
    {
        if(spawnAtStart)Spawn();
        Random.InitState(seed);
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

                if (raycastDown)
                {
                    var ray = new Ray(pos, Vector3.down);
                    if (Physics.Raycast(ray,out var hit,999))
                    {
                        if(targetTag != "" && !hit.collider.CompareTag(targetTag))continue;
                        pos = hit.point;
                    }
                    else
                    {
                        continue;
                    }
                }

                var rot = Quaternion.Euler(0, 0, 0);
                if (randomRotation)
                {
                    rot = Quaternion.Euler(0, Random.Range(0f,360f), 0);
                }
            
                var prefab = prefabs[Random.Range(0, prefabs.Count)]; 
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
