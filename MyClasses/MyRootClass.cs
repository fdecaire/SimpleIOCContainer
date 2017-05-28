using SimpleIOC;

namespace MyClasses
{
	public class MyRootClass : IMyRootClass
	{
		readonly IChildClass _childClass = (IChildClass)IOCContainer.Instance.GetObject("IChildClass");

		public bool CountExceeded()
		{
			if (_childClass.TotalNumbers() > 5)
			{
				return true;
			}
			return false;
		}

		public void Increment()
		{
			_childClass.IncrementIfTempDirectoryExists();
		}
	}
}
