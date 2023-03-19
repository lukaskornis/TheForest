using Unity.Mathematics;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int size = 256;
    public int maxHeight = 64;
    public float mountainSize = 50;
    
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

                //Generate the height
                var pos = new float2(x, y) / mountainSize;
                var height = noise.pnoise(pos, size);
                
                //Set the height
                heightmap[x, y] = height;
            }
        }
        
        //Apply the heightmap
        terrainData.SetHeights(0, 0, heightmap);
    }
}
