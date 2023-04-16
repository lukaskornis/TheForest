using Unity.Mathematics;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int size = 256;
    public int maxHeight = 64;
    
    [Header("Sizes")]
    // sizes
    public float islandSize = 2;
    public float mountainSize = 50;
    public float hillSize = 15;
    public float bumpSize = 6;
    
    [Header("Heights")]
    // height
    public float mountainHeight = 1;
    public float hillHeight = 0.3f;
    public float bumpHeight = 0.02f;
    public float power = 2;
    public AnimationCurve heightCurve;

    [Header("Materials")] 
    public float sandHeight = 0.1f;

    public float grassHeight = 0.2f;
    
    
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
                float Noise(Vector2 pos)=> math.remap(-1,1,0,1,noise.pnoise(pos, size));
                var pos = new float2(x, y);

                var height = Noise(pos / mountainSize) * mountainHeight;
                height = heightCurve.Evaluate(height);
                
                height -=  Noise(pos / hillSize) * hillHeight;
                height += Noise(pos / bumpSize) * bumpHeight;
                
                height *= distance;

                //Set the height
                heightmap[x, y] = height;
            }
        }
        
        //Apply the heightmap
        terrainData.SetHeights(0, 0, heightmap);
        
        
        // PAINT layers on the terrain
        var splatmap = new float[size, size, 3];
        
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                var height = heightmap[x, y];

                if (height < sandHeight)
                {
                    splatmap [x, y, 0] = 1; // SAND
                }
                else if(height < grassHeight)
                {
                    splatmap [x, y, 2] = 1; // GRASS
                }
                else
                {
                    splatmap[x, y, 1] = 1; // STONE
                }
            }
        }

        terrainData.SetAlphamaps(0, 0, splatmap);
        
        
        
        // GRASS PAINT as detail layer
        /*
        var detailmap = new int[size, size];
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                detailmap[x, y] = 0;
            }
        }
        
        terrainData.SetDetailLayer(0,0,0,detailmap);
        */
  

    }
}
