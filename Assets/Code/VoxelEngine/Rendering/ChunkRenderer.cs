using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.VoxelEngine.Rendering
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshFilter))]
    public class ChunkRenderer : MonoBehaviour
    {
        /// <summary>
        /// Поле для сохранения ссылки на компонент после поиска в геттере MeshFilter
        /// </summary>
        private MeshFilter _cachedMeshFilter;

        /// <summary>
        /// Свойство возвращающее ссылку на компонент MeshFilter присоединенный к gameObject
        /// </summary>
        public MeshFilter MeshFilter
        {
            get
            {
                if (!_cachedMeshFilter)
                {
                    _cachedMeshFilter = GetComponent<MeshFilter>();
                    if (!_cachedMeshFilter)
                        throw new NullReferenceException("Where is mine Mesh Filter?!");
                }

                return _cachedMeshFilter;
            }
        }

        void Start()
        {
            MeshFilter.mesh = GenerateMesh();
        }

        private int[] GetQuadTriangles(ref int offset)
        {
            var quad = new[]
            {
                offset + 0, // first triangle
                offset + 1,
                offset + 2,
                offset + 2, // seconds one
                offset + 3,
                offset + 0,
            };

            offset += 4;
            return quad;
        }

        private Vector3[] GetQuadVertices()
        {
            return new[]
            {
                Vector3.left + Vector3.up + Vector3.back,
                Vector3.right + Vector3.up + Vector3.back,
                Vector3.right + Vector3.down + Vector3.back,
                Vector3.left + Vector3.down + Vector3.back
            };
        }

        private Mesh GenerateMesh()
        {
            var mesh = new Mesh();
            var vertices = new List<Vector3>();
            var triangles = new List<int>();

            vertices.AddRange(RotateVertices(GetQuadVertices(), new Vector3(0, 0, 0)));
            vertices.AddRange(RotateVertices(GetQuadVertices(), new Vector3(0, 90, 0)));
            vertices.AddRange(RotateVertices(GetQuadVertices(), new Vector3(0, 180, 0)));
            vertices.AddRange(RotateVertices(GetQuadVertices(), new Vector3(0, -90, 0)));
            vertices.AddRange(RotateVertices(GetQuadVertices(), new Vector3(90, 0, 0)));
            vertices.AddRange(RotateVertices(GetQuadVertices(), new Vector3(-90, 0, 0)));

            var offset = 0;
            triangles.AddRange(GetQuadTriangles(ref offset));
            triangles.AddRange(GetQuadTriangles(ref offset));
            triangles.AddRange(GetQuadTriangles(ref offset));
            triangles.AddRange(GetQuadTriangles(ref offset));
            triangles.AddRange(GetQuadTriangles(ref offset));
            triangles.AddRange(GetQuadTriangles(ref offset));

            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();
            mesh.RecalculateNormals();
            return mesh;
        }

        private Vector3[] RotateVertices(Vector3[] vertices, Vector3 rotate)
        {
            var mtx = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(rotate), Vector3.one);
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = mtx * vertices[i];
            }

            return vertices;
        }
    }
}
