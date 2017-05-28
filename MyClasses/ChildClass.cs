using SimpleIOC;

namespace MyClasses
{
	public class ChildClass : IChildClass
	{
		private int _myNumber;
		private readonly IFileSystem _fileSystem = (IFileSystem)IOCContainer.Instance.GetObject("IFileSystem");

		public int TotalNumbers()
		{
			return _myNumber;
		}

		public void IncrementIfTempDirectoryExists()
		{
			if (_fileSystem.DirectoryExists("c:\\temp"))
			{
				_myNumber++;
			}
		}

		public void Clear()
		{
			_myNumber = 0;
		}
	}
}
