using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMapObjects
{
    /// <summary>
    /// 要素属性值集合类型
    /// </summary>
    public class moAttributes
    {
        #region 字段

        private List<object> _Attributes;

        #endregion

        #region 构造函数

        public moAttributes() { _Attributes = new List<object>(); }

        #endregion

        #region 方法

        /// <summary>
        /// 获取指定索引号的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object GetItem(Int32 index)
        {
            return _Attributes[index];
        }

        /// <summary>
        /// 设置指定索引号的元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetItem(Int32 index, object value)
        {
            _Attributes[index] = value;
        }

        /// <summary>
        /// 将所有值复制到一个数组中
        /// </summary>
        /// <returns></returns>
        public object[] ToArray()
        {
            return _Attributes.ToArray();
        }

        /// <summary>
        /// 从数组中获取所有值
        /// </summary>
        /// <param name="values"></param>
        public void FromArray(object[] values)
        {
            _Attributes.Clear();
            _Attributes.AddRange(values);
        }

        /// <summary>
        /// 在末尾增加指定值
        /// </summary>
        /// <param name="value"></param>
        public void Append(object value)
        {
            _Attributes.Add(value);
        }

        /// <summary>
        /// 删除指定索引号的元素
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(Int32 index)
        {
            _Attributes.RemoveAt(index);
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public moAttributes Clone()
        {
            moAttributes sAttributes = new moAttributes();
            sAttributes._Attributes.AddRange(_Attributes);
            return sAttributes;
        }

        #endregion
    }
}
