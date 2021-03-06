﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

using SpatialSlur.SlurCore;
using SpatialSlur.SlurField;
using SpatialSlur.SlurRhino;

/*
 * Notes
 */

namespace SpatialSlur.SlurGH.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class SampleField : GH_Component
    {
        private bool _parallel = true;


        /// <summary>
        /// 
        /// </summary>
        public SampleField()
          : base("Sample Field", "Sample",
              "Samples a field at the coordinates of another field.",
              "SpatialSlur", "Field")
        {
        }


        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("source", "source", "Field to sample", GH_ParamAccess.item);
            pManager.AddGenericParameter("sampler", "sampler", "Field to sample with", GH_ParamAccess.item);
        }


        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("result", "result", "Field containing sampled values", GH_ParamAccess.item);
        }


        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GH_ObjectWrapper sourceGoo = null;
            if (!DA.GetData(0, ref sourceGoo)) return;

            GH_ObjectWrapper sampleGoo = null;
            if (!DA.GetData(1, ref sampleGoo)) return;

            var source = sourceGoo.Value;
            var sampler = sampleGoo.Value;
      
            if (sampler is IDiscreteField3d<double>)
            {
                if (source is IField3d<double>)
                {
                    var f0 = (IField3d<double>)source;
                    var f1 = ((IDiscreteField3d<double>)sampler).Duplicate(false);

                    f1.Sample(f0, _parallel);
                    DA.SetData(0, new GH_ObjectWrapper(f1));
                    return;
                }
            }

            if (sampler is IDiscreteField3d<Vec3d>)
            {
                if (source is IField3d<Vec3d>)
                {
                    var f0 = (IField3d<Vec3d>)source;
                    var f1 = ((IDiscreteField3d<Vec3d>)sampler).Duplicate(false);

                    f1.Sample(f0, _parallel);
                    DA.SetData(0, new GH_ObjectWrapper(f1));
                    return;
                }
            }

            throw new ArgumentException("The given fields could not be cast to an appropriate type.");
        }


        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get { return null; }
        }


        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{1D25C8A1-4BAF-44B4-A31E-8C83374FEA07}"); }
        }
    }
}
