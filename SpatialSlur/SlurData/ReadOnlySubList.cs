﻿using System;
using System.Collections;
using System.Collections.Generic;

using SpatialSlur.SlurCore;

using static SpatialSlur.SlurCore.CoreUtil;

/*
Notes
*/

namespace SpatialSlur.SlurData
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public struct ReadOnlySubList<T> : IReadOnlyList<T>
    {
        private readonly IReadOnlyList<T> _source;
        private readonly int _start;
        private readonly int _count;


        /// <summary>
        /// 
        /// </summary>
        public int Start
        {
            get { return _start; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return _count; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                BoundsCheck(index, _count);
                return _source[index + _start];
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        public ReadOnlySubList(IReadOnlyList<T> source, int start, int count)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (start < 0 || start >= source.Count)
                throw new ArgumentOutOfRangeException("start");

            if (count < 0 || start + count > source.Count)
                throw new ArgumentOutOfRangeException("count");

            // avoid performance degradation from recursive referencing
            if (source is ReadOnlySubList<T>)
            {
                var other = (ReadOnlySubList<T>)source;
                _source = other._source;
                _start = start + other._start;
            }
            else
            {
                _source = source;
                _start = start;
            }

            _count = count;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
                yield return _source[i + _start];
        }


        #region Explicit interface implementations

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
