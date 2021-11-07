using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CombineMeshes()
    {
        Quaternion oldRot = transform.rotation;
        Vector3 oldPos = transform.position;
        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();
        Mesh finalMesh = new Mesh();
        CombineInstance[] combiners = new CombineInstance[filters.Length];
        Color[] colors = new Color[filters.Length];
        for(int i = 0; i < filters.Length; i++)
        {
            colors[i] = new Color(0.5f, 0.5f, 0.5f);
            if (filters[i].transform == transform)
                continue;
            
            combiners[i].subMeshIndex = 0;
            combiners[i].mesh = filters[i].sharedMesh;
            combiners[i].transform = filters[i].transform.localToWorldMatrix;
        }
        finalMesh.CombineMeshes(combiners);
        GetComponent<MeshFilter>().sharedMesh = finalMesh;
        GetComponent<MeshFilter>().sharedMesh.colors = colors;
        transform.rotation = oldRot;
        transform.position = oldPos;
        Debug.Log("Combining " + filters.Length + " Meshes");
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
