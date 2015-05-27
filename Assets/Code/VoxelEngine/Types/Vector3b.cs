using System;
using UnityEngine;

namespace Assets.Code.VoxelEngine.Types
{
    /// <summary>
    /// Базовый тип вектора определяющего позицию блока внутри чанка
    /// </summary>
    [Serializable]
    public struct Vector3b
    {
        public byte X;
        public byte Y;
        public byte Z;

        public Vector3b(byte x, byte y, byte z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Вспомогательный конструктор для автоматического приведения типов
        /// </summary>
        /// <param name="x">В диапазоне 0...255</param>
        /// <param name="y">В диапазоне 0...255</param>
        /// <param name="z">В диапазоне 0...255</param>
        public Vector3b(int x, int y, int z) 
            : this((byte) x, (byte) y, (byte) z)
        {
        }


        /// <summary>
        /// Вспомогательный конструктор для автоматического приведения типов
        /// </summary>
        /// <param name="x">В диапазоне 0...255</param>
        /// <param name="y">В диапазоне 0...255</param>
        /// <param name="z">В диапазоне 0...255</param>
        public Vector3b(float x, float y, float z)
            : this((byte)x, (byte)y, (byte)z)
        {
        }


        /// <summary>
        /// Вспомогательный конструктор для автоматического приведения типов
        /// </summary>
        /// <param name="x">В диапазоне 0...255</param>
        /// <param name="y">В диапазоне 0...255</param>
        /// <param name="z">В диапазоне 0...255</param>
        public Vector3b(double x, double y, double z)
            : this((byte)x, (byte)y, (byte)z)
        {
        }

        /// <summary>
        /// Оператор присвоения с приведением типа к Vector3.
        /// Облегчает работу с векторами — предоставляет доступ к методам юнити
        /// </summary>
        public static implicit operator Vector3(Vector3b v)
        {
            return new Vector3(v.X, v.Y, v.Z);
        }

        /// <summary>
        /// Оператор присвоения с приведением типа к Vector3b.
        /// Облегчает работу с векторами — предоставляет доступ к методам юнити
        /// </summary>
        public static implicit operator Vector3b(Vector3 v)
        {
            return new Vector3b(v.x, v.y, v.z);
        }
    }
}