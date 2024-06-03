using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMapObjects
{
    public class moFields : IEnumerable<moField>
    {
        #region 字段

        private List<moField> _Fields; //字段集合
        private string _PrimaryField = ""; //主字段
        private bool _ShowAlias = false; //指示是否显示别名

        #endregion

        #region 构造函数

        public moFields()
        {
            _Fields = new List<moField>();
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取元素数目
        /// </summary>
        public Int32 Count
        {
            get { return _Fields.Count(); }
        }

        /// <summary>
        /// 获取或设置字段名称
        /// </summary>
        public string PrimaryField
        {
            get { return _PrimaryField; }
            set { _PrimaryField = value; }
        }

        /// <summary>
        /// 指示是否显示别名
        /// </summary>
        public bool ShowAlias
        {
            get { return _ShowAlias; }
            set { _ShowAlias = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取指定索引号的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public moField GetItem(Int32 index)
        {
            return _Fields[index];
        }

        /// <summary>
        /// 获取指定名称的元素
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public moField GetItem(string name)
        {
            return _Fields[FindField(name)];
        }

        /// <summary>
        /// 查找指定名称的字段，返回其索引号，如无则返回-1
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Int32 FindField(string name)
        {
            Int32 sFieldCount = _Fields.Count;
            for (Int32 i = 0; i <= sFieldCount - 1; i++)
            {
                if (_Fields[i].Name.ToLower() == name.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 追加一个字段
        /// </summary>
        /// <param name="field"></param>
        public void Append(moField field)
        {
            if (FindField(field.Name) >= 0)
                throw new Exception("Fields对象不能存在重名的字段！");
            else
            {
                _Fields.Add(field);

                //触发事件
                if (FieldAppended != null) //是否有程序正在监听，如果有程序监听
                    FieldAppended(this, field); //则广播，有字段加入了
            }
        }

        /// <summary>
        /// 删除指定索引号下的字段
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(Int32 index) //如果index超出数组，程序会自动报错，我们不用手动管理了
        {
            moField sField = _Fields[index];
            _Fields.RemoveAt(index);

            //触发事件
            if (FieldRemoved != null)
                FieldRemoved(this, index, sField);
        }

        #endregion

        #region IEnumerable<moField> 成员

        public IEnumerator<moField> GetEnumerator()
        {
            return _Fields.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region 事件

        /// <summary>
        /// 有字段被加入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="fieldAppended"></param>
        internal delegate void FieldAppendedHandle(object sender, moField fieldAppended);
        internal event FieldAppendedHandle FieldAppended;

        /// <summary>
        /// 有字段被删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="fieldIndex"></param>
        /// <param name="fieldRemoved"></param>
        internal delegate void FieldRemovedHandle(object sender, Int32 fieldIndex, moField fieldRemoved);
        internal event FieldRemovedHandle FieldRemoved;

        #endregion
    }
}
