using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace SimpleIOC
{
    public class IOCContainer
    {
		private static readonly Dictionary<string,object> ClassList = new Dictionary<string, object>();
	    private static IOCContainer _instance;

	    public static IOCContainer Instance => _instance ?? (_instance = new IOCContainer());

	    public void AddObject<T>(string interfaceName, T theObject)
	    {
		    ClassList.Add(interfaceName,theObject);
	    }

	    public object GetObject(string interfaceName)
	    {
		    return ClassList[interfaceName];
	    }

	    public void Clear()
	    {
		    ClassList.Clear();
	    }
    }
}
