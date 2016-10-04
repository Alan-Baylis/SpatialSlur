﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpatialSlur.SlurCore
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct Vec3i
    {
        #region Static

        /// <summary>
        /// 
        /// </summary>
        public static Vec3i UnitX
        {
            get { return new Vec3i(1, 0, 0); }
        }


        /// <summary>
        /// 
        /// </summary>
        public static Vec3i UnitY
        {
            get { return new Vec3i(0, 1, 0); }
        }


        /// <summary>
        /// 
        /// </summary>
        public static Vec3i UnitZ
        {
            get { return new Vec3i(0, 0, 1); }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static bool operator ==(Vec3i v0, Vec3i v1)
        {
            return (v0.x == v1.x) && (v0.y == v1.y) && (v0.z == v1.z);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static bool operator !=(Vec3i v0, Vec3i v1)
        {
            return (v0.x != v1.x) || (v0.y != v1.y) || (v0.z != v1.z);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static Vec3i operator +(Vec3i v0, Vec3i v1)
        {
            v0.x += v1.x;
            v0.y += v1.y;
            v0.z += v1.z;
            return v0;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static Vec3i operator -(Vec3i v0, Vec3i v1)
        {
            v0.x -= v1.x;
            v0.y -= v1.y;
            v0.z -= v1.z;
            return v0;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vec3i operator -(Vec3i v)
        {
            v.x = -v.x;
            v.y = -v.y;
            v.z = -v.z;
            return v;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vec3i operator *(Vec3i v, int t)
        {
            v.x *= t;
            v.y *= t;
            v.z *= t;
            return v;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vec3i operator *(int t, Vec3i v)
        {
            v.x *= t;
            v.y *= t;
            v.z *= t;
            return v;
        }


        /// <summary>
        /// Returns the dot product of two vectors.
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static int operator *(Vec3i v0, Vec3i v1)
        {
            return v0.x * v1.x + v0.y * v1.y + v0.z * v1.z;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static double Dot(Vec3i v0, Vec3i v1)
        {
            return v0.x * v1.x + v0.y * v1.y + v0.z * v1.z;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static Vec3i Cross(Vec3i v0, Vec3i v1)
        {
            return new Vec3i(
                v0.y * v1.z - v0.z * v1.y, 
                v0.z * v1.x - v0.x * v1.z, 
                v0.x * v1.y - v0.y * v1.x);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static implicit operator Vec3i(Vec2i v)
        {
            return new Vec3i(v.x, v.y, 0);
        }

        #endregion


        public int x, y, z;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vec3i(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Length
        {
            get { return Math.Sqrt(SquareLength); }
        }


        /// <summary>
        /// 
        /// </summary>
        public int SquareLength
        {
            get { return x * x + y * y + z * z; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ManhattanLength
        {
            get { return Math.Abs(x) + Math.Abs(y) + Math.Abs(z); }
        }


        /// <summary>
        /// Returns the largest component in the vector.
        /// </summary>
        /// <returns></returns>
        public int Max
        {
            get { return Math.Max(x, Math.Max(y, z)); }
        }


        /// <summary>
        /// Returns the smallest component in the vector.
        /// </summary>
        /// <returns></returns>
        public int Min
        {
            get { return Math.Min(x, Math.Min(y, z)); }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vec3i Abs
        {
            get { return new Vec3i(Math.Abs(x), Math.Abs(y), Math.Abs(z)); }
        }


        /// <summary>
        /// 
        /// </summary>
        public bool IsZero
        {
            get { return x == 0 && y == 0 && z == 0; }
        }


        /// <summary>
        /// 
        /// </summary>
        public bool IsUnit
        {
            get { return SquareLength == 1; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("({0},{1},{2})", x, y, z);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void Set(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        /// <summary>
        /// https://msdn.microsoft.com/en-us/library/336aedhh(v=VS.71).aspx
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + x.GetHashCode();
            hash = hash * 23 + y.GetHashCode();
            hash = hash * 23 + z.GetHashCode();
            return hash;
        }
     

        /// <summary>
        /// https://msdn.microsoft.com/en-us/library/336aedhh(v=VS.71).aspx
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Vec3i && this == (Vec3i)obj;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public double DistanceTo(Vec3i other)
        {
            other -= this;
            return other.Length;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int SquareDistanceTo(Vec3i other)
        {
            other -= this;
            return other.SquareLength;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int ManhattanDistanceTo(Vec3i other)
        {
            other -= this;
            return other.ManhattanLength;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int[] ToArray()
        {
            return new int[] { x, y, z };
        }
    }
}
