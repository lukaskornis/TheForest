using Unity.Mathematics;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int size = 256;
    public int maxHeight = 64;
    public float mountainSize = 50;

    public float islandSize = 2;
    
    public bool autoGenerate = true;
    private Terrain terrain;

    private void Start()
    {
        if(autoGenerate)Generate();
    }

    public void Generate()
    {
        terrain = GetComponent<Terrain>();
        
        //Get the terrain data
        var terrainData = terrain.terrainData;
        
        //Set the size of the terrain
        terrainData.heightmapResolution = size;
        terrainData.size = new Vector3(size, maxHeight, size);
        
        //Generate the heightmap
        var heightmap = new float[size, size];
        
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                // distance from center
                var center = new Vector2(size / 2, size / 2);
                var distance = Vector2.Distance(center, new Vector2(x, y));
                distance /= islandSize;
                distance = math.remap(0, size, 1, 0, distance);
                
                //Generate the height
                var pos = new float2(x, y) / mountainSize;
                var height = math.remap(-1,1,0,1,noise.pnoise(pos, size));
                height *= distance;
                
                //Set the height
                heightmap[x, y] = height;
            }
        }
        
        //Apply the heightmap
        terrainData.SetHeights(0, 0, heightmap);
    }
}
