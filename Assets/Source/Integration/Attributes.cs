namespace MEdge
{
	public class CategoryAttribute : System.Attribute
	{
		public readonly string CategoryName;
		public CategoryAttribute( string categoryName = "" )
		{
			CategoryName = categoryName;
		}
	}
	public class editconstAttribute : System.Attribute {}
	public class exportAttribute : System.Attribute {}
	public class noexportAttribute : System.Attribute {}
	public class editinlineAttribute : System.Attribute {}
	public class transientAttribute : System.Attribute {}
	public class ConstAttribute : System.Attribute {}
	public class localizedAttribute : System.Attribute {}
	public class nativeAttribute : System.Attribute {}
	public class noclearAttribute : System.Attribute {}
	public class configAttribute : System.Attribute {}
	public class globalconfigAttribute : System.Attribute {}
	public class interpAttribute : System.Attribute {}
	public class repnotifyAttribute : System.Attribute {}
	public class editoronlyAttribute : System.Attribute {}
	public class duplicatetransientAttribute : System.Attribute {}
	public class noimportAttribute : System.Attribute {}
	public class initAttribute : System.Attribute {}
	public class databindingAttribute : System.Attribute {}
	public class editfixedsizeAttribute : System.Attribute {}
	public class nontransactionalAttribute : System.Attribute {}
	public class deprecatedAttribute : System.Attribute {}
	public class archetypeAttribute : System.Attribute {}
	public class editinlineuseAttribute : System.Attribute {}
	public class inputAttribute : System.Attribute {}
}