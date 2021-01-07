using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebResourceHookWpf.Lib
{
    public enum FileHeadEnum 
    {
        [Remark("PNG")]
        PNG,
        [Remark("DDS")]
        DDS
    }

    public class RemarkAttribute : Attribute
    {
        public RemarkAttribute(string remark)
        {
            this._Remark = remark;
        }
        public string _Remark = null;

        public string GetRemark()
        {

            return this._Remark;
        }
    }



    /// <summary>
    /// 获取枚举中的注释 通过特性方法 + 反射
    /// </summary>
    public static class RemarkExtension
    {
        public static string GetRemark(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            // 判断是否加了特性注解
            if (fieldInfo.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute remark = (RemarkAttribute)fieldInfo.GetCustomAttribute(typeof(RemarkAttribute), true);
                return remark.GetRemark();
            }
            else
            {
                return value.ToString();
            }

        }


    }
}
