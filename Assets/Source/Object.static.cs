using System;
using System.Dynamic;
using System.Reflection;

namespace MEdge.Core
{
    public partial class Object
    {
        public dynamic Static => new StaticMembersDynamicWrapper(this is Class c ? c.CSharpType : GetType());

        class StaticMembersDynamicWrapper : DynamicObject
        {
            private readonly Type _type;

            public StaticMembersDynamicWrapper(Type type) => _type = type;

            // Handle static properties
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                PropertyInfo prop = _type.GetProperty(binder.Name,
                    BindingFlags.FlattenHierarchy | BindingFlags.Static | BindingFlags.Public);
                if (prop == null)
                {
                    result = null;
                    return false;
                }

                result = prop.GetValue(null, null);
                return true;
            }

            // Handle static methods
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
            {
                MethodInfo method = _type.GetMethod(binder.Name,
                    BindingFlags.FlattenHierarchy | BindingFlags.Static | BindingFlags.Public);
                if (method == null)
                {
                    result = null;
                    return false;
                }

                result = method.Invoke(null, args);
                return true;
            }
        }
    }
}