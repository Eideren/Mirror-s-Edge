
using System;
using System.Reflection;
using MEdge.Engine;

namespace MEdge.Core
{
    public partial class Object
    {
        public T DefaultAs<T>() where T : class => Class.DefaultAs<T>();
        
        public MEdge.Core.Class Class
        {
            get
            {
                if (_Class != null)
                    return _Class;
                Type constructedType = typeof(_classImp<>).MakeGenericType(GetType());
                return _Class = (Class)Activator.CreateInstance(constructedType, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            }
        }

        private MEdge.Core.Class _Class;
        public static MEdge.Core._classImp<T> ClassT<T>() where T : Object, new() => MEdge.Core._classImp<T>.Singleton;
    }
}

namespace MEdge.Core
{
    public partial class Class : Object
    {
        public Class() => throw new InvalidOperationException();
        protected Class(bool b) { }
        public virtual string Name => throw new InvalidOperationException();
        public virtual T DefaultAs<T>() where T : class => throw new InvalidOperationException();
        public virtual Type CSharpType => throw new InvalidOperationException();

        public override bool Equals(object obj) => obj is Class c && this == c;
        public static bool operator ==(Class a, Class b) => a?.GetType() == b?.GetType();
        public static bool operator !=(Class a, Class b) => !(a == b);
        
        public virtual bool IsParentOf( Class c ) => throw new InvalidOperationException();
        public override bool IsA( name typeName ) => throw new InvalidOperationException();
    }
    
    public interface ClassT<out T>
    {
        public T2 DefaultAs<T2>() where T2 : class;
        public T New(Object outer = null);
        public bool IsA(name typeName);
        public bool IsA(Class type);
        public dynamic Static { get; }
        public bool IsParentOf( Class c );
    }
        

    public class _classImp<CType> : Class, ClassT<CType> where CType : Object, new()
    {
        public static readonly _classImp<CType> Singleton = new _classImp<CType>();
        
        public override string Name => typeof(CType).Name;
        _classImp() : base(true) { }
        
        public CType New(Object outer = null) => new CType(){ Outer = outer };
        public override T2 DefaultAs<T2>() where T2 : class => new CType() as T2;
        public override Type CSharpType => typeof(CType);
        public virtual bool IsA(Class type) => type.IsParentOf( this );
        public override bool IsParentOf( Class c ) => c is ClassT<CType>;
        public override bool IsA( name typeName )
        {
            for( var t = CSharpType; t != null; t = t.BaseType )
            {
                if( t.Name == typeName )
                    return true;
            }
            return CSharpType.GetInterface( typeName ) != null;
        }
    }
}