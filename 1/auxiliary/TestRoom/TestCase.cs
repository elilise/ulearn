using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace TestingRoom
{
	public abstract class TestCase
	{
		public static Pen actualAnswerPen = new Pen(Color.Red, 2);
		public static Pen expectedAnswerPen = new Pen(Color.Green, 1){DashStyle = DashStyle.Dash};
		public static Pen neutralPen = new Pen(Color.Black, 2);
		public static Pen neutralThinPen = new Pen(Color.Black, 1);

		protected TestCase(string name)
		{
			Name = name;
			LastResult = TestResult.Unknown;
		}

		public string Name { get; private set; }
		public TestResult LastResult { get; private set; }
		public Exception LastException{ get; private set; }
		
		public Task Run()
		{
			return Task.Run(() =>
				{
					try
					{
						LastResult = InternalRun() ? TestResult.OK : TestResult.Failed;
					}
					catch (Exception e)
					{
						LastException = e;
						LastResult = TestResult.Failed;
					}
				});
		}

		public void Visualize(TestCaseUI ui)
		{
			if (LastResult == TestResult.OK) ui.Log("Success!");
			if (LastResult == TestResult.Failed) ui.Log("Failed...");
			InternalVisualize(ui);
			if (LastException != null)
			{
				ui.Log("");
				ui.Log(LastException.ToString());
			}
		}

		protected abstract void InternalVisualize(TestCaseUI ui);

		protected abstract bool InternalRun();
	}
}