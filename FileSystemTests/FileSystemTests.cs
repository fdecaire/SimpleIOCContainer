using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyClasses;
using SimpleIOC;

namespace UnitTests
{
	[TestClass]
	public class MyTests
	{
		[TestMethod]
		public void test_temp_directory_exists()
		{
			var mockFileSystem = new Mock<IFileSystem>();
			mockFileSystem.Setup(x => x.DirectoryExists("c:\\temp")).Returns(true);

			IOCContainer.Instance.Clear();
			IOCContainer.Instance.AddObject("IFileSystem", mockFileSystem.Object);

			var myObject = new ChildClass();
			myObject.IncrementIfTempDirectoryExists();
			Assert.AreEqual(1, myObject.TotalNumbers());
		}

		[TestMethod]
		public void test_temp_directory_missing()
		{
			var mockFileSystem = new Mock<IFileSystem>();
			mockFileSystem.Setup(x => x.DirectoryExists("c:\\temp")).Returns(false);

			IOCContainer.Instance.Clear();
			IOCContainer.Instance.AddObject("IFileSystem", mockFileSystem.Object);

			var myObject = new ChildClass();
			myObject.IncrementIfTempDirectoryExists();
			Assert.AreEqual(0, myObject.TotalNumbers());
		}

		[TestMethod]
		public void test_root_count_exceeded_true()
		{
			var mockChildClass = new Mock<IChildClass>();
			mockChildClass.Setup(x => x.TotalNumbers()).Returns(12);

			IOCContainer.Instance.Clear();
			IOCContainer.Instance.AddObject("IChildClass", mockChildClass.Object);

			var myObject = new MyRootClass();
			myObject.Increment();
			Assert.AreEqual(true,myObject.CountExceeded());
		}

		[TestMethod]
		public void test_root_count_exceeded_false()
		{
			var mockChildClass = new Mock<IChildClass>();
			mockChildClass.Setup(x => x.TotalNumbers()).Returns(1);

			IOCContainer.Instance.Clear();
			IOCContainer.Instance.AddObject("IChildClass", mockChildClass.Object);

			var myObject = new MyRootClass();
			myObject.Increment();
			Assert.AreEqual(false, myObject.CountExceeded());
		}
	}
}
