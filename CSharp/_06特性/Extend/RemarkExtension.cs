using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _06特性.Extend
{
    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserState
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Remark("正常")]
        Normal = 0,
        /// <summary>
        /// 冻结
        /// </summary>
        [Remark("冻结")]
        Frozen = 1,
        /// <summary>
        /// 已删除
        /// </summary>
        [Remark("已删除")] 
        Deleted = 2
    }

    public class RemarkAttribute : Attribute
    {
        public RemarkAttribute(string remark)
        {
            this._Remark = remark;
        }

        private string _Remark = null;

        public string GetRemark()
        {
            return this._Remark;
        }
    }

    public static class RemarkExtension
    {

        public static string GetRemark(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo field = type.GetField(value.ToString());
            if (field.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute attribute = (RemarkAttribute)field.GetCustomAttribute(typeof(RemarkAttribute), true);
                return attribute.GetRemark();
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
