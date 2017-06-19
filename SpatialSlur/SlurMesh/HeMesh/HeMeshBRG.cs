﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpatialSlur.SlurCore;

/*
 * Notes
 */ 

namespace SpatialSlur.SlurMesh
{
    /// <summary>
    /// Static constructors and extension methods for an HeGraph with extendable user defined properties.
    /// </summary>
    public static class HeMeshBRG
    {
        /// <summary></summary>
        public static readonly HeMeshFactory<V,E,F> Factory = HeMeshFactory.Create(() => new V(), () => new E(), () => new F());


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertexCapacity"></param>
        /// <param name="hedgeCapacity"></param>
        /// <param name="faceCapacity"></param>
        /// <returns></returns>
        public static HeMesh<V,E,F> Create(int vertexCapacity = 4, int hedgeCapacity = 4, int faceCapacity = 4)
        {
            return Factory.Create(vertexCapacity, hedgeCapacity, faceCapacity);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesh"></param>
        public static HeMesh<V, E, F> Duplicate(this HeMesh<V, E, F> mesh)
        {
            return Factory.CreateCopy(mesh, (v0, v1) => v0.Data.Set(v1.Data), (he0, he1) => he0.Data.Set(he1.Data), (f0, f1) => f0.Data.Set(f1.Data));
        }


        /// <summary>
        /// 
        /// </summary>
        public class V : HeVertex<V, E, F>
        {
            /// <summary></summary>
            public Dictionary<string, object> Data { get; } = new Dictionary<string, object>
            {
                { "x", 0.0 },
                { "y", 0.0 },
                { "z", 0.0 }
            };
        }


        /// <summary>
        /// 
        /// </summary>
        public class E : Halfedge<V, E, F>
        {
            /// <summary></summary>
            public Dictionary<string, object> Data { get; } = new Dictionary<string, object>();
        }


        /// <summary>
        ///
        /// </summary>
        public class F : HeFace<V, E, F>
        {
            /// <summary></summary>
            public Dictionary<string, object> Data { get; } = new Dictionary<string, object>();
        }
    }
}
