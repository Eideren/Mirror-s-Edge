
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
                if (_class != null)
                    return _class;
                Type constructedType = typeof(_classImp<>).MakeGenericType(GetType());
                var prop = constructedType.GetField( "Singleton", BindingFlags.Static | BindingFlags.Public );
                return _class = (Class)prop.GetValue(constructedType);
            }
        }

        private MEdge.Core.Class _class;
        public static MEdge.Core._classImp<T> ClassT<T>() where T : Object, new() => MEdge.Core._classImp<T>.Singleton;
    }
}

namespace MEdge.Core
{
    public partial class Class : Object
    {
        public static int InSpawningDefault;
        
        public Class() => throw new InvalidOperationException();
        protected Class(bool b) { }
        public virtual String Name => throw new InvalidOperationException();
        public virtual T DefaultAs<T>() where T : class => throw new InvalidOperationException();
        public virtual Type CSharpType => throw new InvalidOperationException();
        public virtual bool IsBaseOf( Class c ) => throw new InvalidOperationException();
        public override bool IsA( name typeName ) => throw new InvalidOperationException();

        public override bool Equals(object obj) => obj is Class c && this == c;
        public static bool operator ==(Class a, Class b) => a?.GetType() == b?.GetType();
        public static bool operator !=(Class a, Class b) => !(a == b);
    }
    
    public interface ClassT<out T>
    {
        public T2 DefaultAs<T2>() where T2 : class;
        public T New(Object outer = null);
        public bool IsA(name typeName);
        public bool IsA(Class type);
        public dynamic Static { get; }
        public bool IsBaseOf( Class c );
        public String Name{ get; }
    }
        

    public class _classImp<CType> : Class, ClassT<CType> where CType : Object, new()
    {
        public static readonly _classImp<CType> Singleton = new _classImp<CType>();
        CType _defaultCached;
        
        public override String Name => typeof(CType).Name;
        _classImp() : base(true) { }
        
        public CType New(Object outer = null) => new CType(){ Outer = outer };



        public override T2 DefaultAs<T2>() where T2 : class
        {
            if( _defaultCached == null )
            {
                try
                {
                    InSpawningDefault++;
                    _defaultCached = new CType();
                }
                finally
                {
                    InSpawningDefault--;
                }
            }

            return _defaultCached as T2;
        }
        public override Type CSharpType => typeof(CType);
        public virtual bool IsA(Class type) => type.IsBaseOf( this );
        public override bool IsBaseOf( Class c ) => c is ClassT<CType>;
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