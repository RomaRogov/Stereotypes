using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class TerrainMesh : MonoBehaviour
{

    private MeshRenderer mRenderer;
    private MeshFilter mFilter;
    public Material TerrainMat;
    public Texture2D HeightMap;

    void Start()
    {
        
    }

	public void GenerateMesh ()
    {
        if ((mRenderer = gameObject.GetComponent<MeshRenderer>()) == null)
        {
            mRenderer = gameObject.AddComponent<MeshRenderer>();
        }

        if ((mFilter = gameObject.GetComponent<MeshFilter>()) == null)
        {
            mFilter = gameObject.AddComponent<MeshFilter>();
        }

        List<Vector3> verts = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();
        List<int> tris = new List<int>();

        int width = 32;
        int height = 32;

        Vector2 uv = new Vector2();
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                uv = new Vector2((float)x / (float)width, (float)y / (float)height);
                float value = HeightMap.GetPixelBilinear(uv.x, uv.y).grayscale;

                verts.Add(new Vector3(x, value * 10f, y));
                uvs.Add(uv);
                
                if (x == 0 || y == 0)
                    continue;
                
                tris.Add(width * x + y); //Top right
                tris.Add(width * x + y - 1); //Bottom right
                tris.Add(width * (x - 1) + y - 1); //Bottom left - First triangle
                tris.Add(width * (x - 1) + y - 1); //Bottom left 
                tris.Add(width * (x - 1) + y); //Top left
                tris.Add(width * x + y); //Top right - Second triangle
            }

        mFilter.sharedMesh.vertices = verts.ToArray();
        mFilter.sharedMesh.triangles = tris.ToArray();
        mFilter.sharedMesh.uv = uvs.ToArray();
        mFilter.sharedMesh.RecalculateNormals();

        mRenderer.material = TerrainMat;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
