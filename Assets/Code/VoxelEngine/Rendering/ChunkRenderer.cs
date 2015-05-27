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

        private Mesh GenerateMesh()
        {
            var mesh = new Mesh();
            mesh.vertices = new[]
            {
                Vector3.left + Vector3.up,
                Vector3.right + Vector3.up,
                Vector3.right + Vector3.down
            };


            mesh.triangles = new[]
            {
                0, 1, 2
            };

            return mesh;
        }
    }
}
