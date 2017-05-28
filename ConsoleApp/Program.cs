using System;
using MyClasses;
using SimpleIOC;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			ContainerSetup();

			var myRootClass = (IMyRootClass)IOCContainer.Instance.GetObject("IMyRootClass");
			myRootClass.Increment();

			Console.WriteLine(myRootClass.CountExceeded());
			Console.ReadKey();
		}

		private static void ContainerSetup()
		{
			IOCContainer.Instance.AddObject<IChildClass>("IChildClass",new ChildClass());
			IOCContainer.Instance.AddObject<IMyRootClass>("IMyRootClass",new MyRootClass());
			IOCContainer.Instance.AddObject<IFileSystem>("IFileSystem", new FileSystem());
		}
	}
}
