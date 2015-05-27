using System;

namespace Assets.Code.VoxelEngine.Types
{
    /// <summary>
    /// Базовый тип описывающий множество блоков в определенной точке мира
    /// </summary>
    [Serializable]
    public struct Chunk
    {
        public Vector3b Position;
        public Block[]  Blocks;

        public Chunk(Vector3b position, Block[] blocks)
        {
            Position = position;
            Blocks = blocks;
        }
    }
}