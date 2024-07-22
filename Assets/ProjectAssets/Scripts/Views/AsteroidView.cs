
using System.Collections.Generic;
using Game.World;
using UnityEngine;


public class AsteroidView : UpdatedView
{
    [SerializeField] MeshFilter _meshFilter;
    AsteroidEntity _asteroidEntity;
    public void Init(AsteroidEntity model)
    {
        _asteroidEntity = model;
        int count = _asteroidEntity.points.Length;
        List<int> indices = new (count);
        for (int i = 0; i < count; i++)
        {
            indices.Add(i);
        }
        indices.Add(0);
        Mesh mesh = new Mesh();
        mesh.SetVertices(_asteroidEntity.points);
        mesh.SetIndices(indices,MeshTopology.LineStrip, 0);
        mesh.UploadMeshData(true);
        _meshFilter.mesh = mesh;
        UpdateView();
    }

    public override void UpdateView()
    {
        transform.position = _asteroidEntity.position;
    }

}
