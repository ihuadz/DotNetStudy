using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _06特性.Extend
{
    public static class ValidateExtension
    {
        /// <summary>
        /// 建议泛型方法
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Validate(this object obj)
        {
            Type type = obj.GetType();
            foreach (var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(BaseValidateAtrribute), true))
                {
                    object[] atrributes = prop.GetCustomAttributes(typeof(BaseValidateAtrribute), true);
                    //LongAtrribute atrribute = (LongAtrribute)prop.GetCustomAttribute(typeof(LongAtrribute));
                    foreach (BaseValidateAtrribute atrribute in atrributes)
                    {
                        if (!atrribute.Validate(prop.GetValue(obj)))
                        {
                            return false;
                        }
                    }
                    
                }
            }

            return true;
        }
    }

    public abstract class BaseValidateAtrribute : Attribute
    {
        public abstract bool Validate(object value);
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class LongAtrribute : BaseValidateAtrribute
    {
        private long _Min = 0;
        private long _Max = 0;

        public LongAtrribute(long min, long max)
        {
            _Min = min;
            _Max = max;
        }

        public override bool Validate(object value)
        {
            //if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            //{
            //    if (long.TryParse(value.ToString(), out long lResult))
            //    {
            //        if (lResult > this._Min && lResult < this._Max)
            //        {
            //            return true;
            //        }
            //    }
            //}

            return value != null && !string.IsNullOrWhiteSpace(value.ToString()) && long.Parse(value.ToString()) > _Min && long.Parse(value.ToString()) < _Max;

            //return false;
        }
    }
}
