using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CombineChildrenMeshes : MonoBehaviour
{
    void Start()
    {
        // Parent �zerindeki t�m MeshFilter bile�enlerini al
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        var combineList = new List<CombineInstance>();
        var materialList = new List<Material>();

        foreach (MeshFilter mf in meshFilters)
        {
            MeshRenderer mr = mf.GetComponent<MeshRenderer>();
            if (mr == null) continue;

            Mesh mesh = mf.sharedMesh;
            Material[] mats = mr.sharedMaterials;

            // Her sub-mesh i�in ayr� CombineInstance olu�tur
            for (int sub = 0; sub < mesh.subMeshCount; sub++)
            {
                CombineInstance ci = new CombineInstance();
                ci.mesh = mesh;
                ci.subMeshIndex = sub;
                ci.transform = mf.transform.localToWorldMatrix;
                combineList.Add(ci);

                // Sub-mesh'e kar��l�k gelen materyali ekle
                materialList.Add(mats.Length > sub ? mats[sub] : mats[0]);
            }

            // Orijinal alt objeyi gizle
            mf.gameObject.SetActive(false);
        }

        // Yeni mesh'i olu�tur ve birle�tir
        Mesh finalMesh = new Mesh();
        finalMesh.name = "CombinedMesh";
        finalMesh.CombineMeshes(combineList.ToArray(), mergeSubMeshes: false, useMatrices: true);

        // Parent'a MeshFilter ve MeshRenderer ata
        MeshFilter parentFilter = GetComponent<MeshFilter>();
        parentFilter.mesh = finalMesh;

        MeshRenderer parentRenderer = GetComponent<MeshRenderer>();
        parentRenderer.materials = materialList.ToArray();
    }
}
