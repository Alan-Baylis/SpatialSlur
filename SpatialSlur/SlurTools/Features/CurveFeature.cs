﻿#if USING_RHINO

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpatialSlur.SlurCore;
using Rhino.Geometry;

/*
 * Notes
 */

namespace SpatialSlur.SlurTools.Features
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CurveFeature : IFeature
    {
        private Curve _curve;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="curve"></param>
        public CurveFeature(Curve curve)
        {
            _curve = curve;
        }


        /// <summary>
        /// 
        /// </summary>
        public int Rank
        {
            get { return 1; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Vec3d ClosestPoint(Vec3d point)
        {
            _curve.ClosestPoint(point, out double t);
            return _curve.PointAt(t);
        }
    }
}

#endif