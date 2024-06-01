using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMapObjects
{
    public class moParts : IEnumerable<moPoints>
    {
        #region 字段

        private List<moPoints> _Parts;

        #endregion

        #region 构造函数

        public moParts() { _Parts = new List<moPoints>(); }

        public moParts(moPoints[] parts)
        {
            _Parts = new List<moPoints>();
            _Parts.AddRange(parts);
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取元素数目
        /// </summary>
        public Int32 Count
        {
            get { return _Parts.Count; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取指定索引号的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public moPoints GetItem(Int32 index)
        {
            return _Parts[index];
        }

        /// <summary>
        /// 设置指定索引号的元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="part"></param>
        public void SetItem(Int32 index, moPoints part)
        {
            _Parts[index] = part;
        }

        /// <summary>
        /// 在末尾添加指定元素
        /// </summary>
        /// <param name="part"></param>
        public void Add(moPoints part)
        {
            _Parts.Add(part);
        }

        /// <summary>
        /// 将指定集合的元素添加到末尾
        /// </summary>
        /// <param name="parts"></param>
        public void AddRange(moPoints[] parts)
        {
            _Parts.AddRange(parts);
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public moParts Clone()
        {
            moParts sParts = new moParts();
            Int32 sPartCount = _Parts.Count;
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                moPoints sPart = _Parts[i].Clone();
                sParts.Add(sPart);
            }
            return sParts;
        }

        /// <summary>
        /// 返回此集合的枚举器
        /// </summary>
        /// <returns></returns>
        public IEnumerator<moPoints> GetEnumerator()
        {
            return _Parts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
