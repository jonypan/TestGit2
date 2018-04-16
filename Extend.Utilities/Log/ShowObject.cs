using System;
using System.Linq;
using System.Text;

namespace Extend.Utilities
{
    public static class ShowObject
    {
        public static string GetValueOfObject(object ob)
        {
            var sb = new StringBuilder();
            try
            {
                foreach (System.Reflection.PropertyInfo piOrig in ob.GetType().GetProperties())
                {
                    object editedVal = ob.GetType().GetProperty(piOrig.Name).GetValue(ob, null);
                    sb.AppendFormat("{0}:{1} \n", piOrig.Name, editedVal);
                }
            }
            catch
            {
            }
            return sb.ToString();
        }
    }
}