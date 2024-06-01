using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMapObjects
{
    public class moFeatures : IEnumerable<moFeature>
    {
        #region 字段

        private List<moFeature> _Features;

        #endregion

        #region 构造函数

        public moFeatures()
        {
            _Features = new List<moFeature>();
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取要素数目
        /// </summary>
        public Int32 Count
        {
            get { return _Features.Count; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取指定索引号的要素
        /// </summary>
        /// <param name="index">索引号</param>
        public moFeature GetItem(Int32 index)
        {
            return _Features[index];
        }

        /// <summary>
        /// 设置指定索引号的要素
        /// </summary>
        /// <param name="index">索引号</param>
        /// <param name="feature">新要素</param>
        public void SetItem(int index, moFeature feature)
        {
            if (index >= 0 && index < _Features.Count)
            {
                _Features[index] = feature;
            }
        }

        /// <summary>
        /// 在末尾增加一个要素
        /// </summary>
        /// <param name="feature"></param>
        public void Add(moFeature feature)
        {
            _Features.Add(feature);
        }

        /// <summary>
        /// 删除指定索引号的要素
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(Int32 index)
        {
            _Features.RemoveAt(index);
        }

        /// <summary>
        /// 将所有要素复制到一个新的数组中
        /// </summary>
        /// <returns></returns>
        public moFeature[] ToArray()
        {
            return _Features.ToArray();
        }

        /// <summary>
        /// 删除所有要素
        /// </summary>
        public void Clear()
        {
            _Features.Clear();
        }

        public IEnumerator<moFeature> GetEnumerator()
        {
            return _Features.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Features.GetEnumerator();
        }

        #endregion
    }
}
