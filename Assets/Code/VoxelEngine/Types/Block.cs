using System;
namespace Assets.Code.VoxelEngine.Types
{
    /// <summary>
    /// Базовый тип описывающий минимальный объем данных движка - блок
    /// TODO: добавить индекс материала\текстуры
    /// </summary>
    [Serializable]
    public struct Block
    {
        public Vector3b Position;

        public Block(Vector3b position)
        {
            Position = position;
        }

        public Block(byte x, byte y, byte z)
        {
            Position = new Vector3b(x,y,z);
        }
    }
}
