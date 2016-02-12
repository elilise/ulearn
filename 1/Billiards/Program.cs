using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using TestingRoom;

namespace Billiards
{
	public static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new TestRoom(CreateTestCases()));
		}

		private static IEnumerable<TestCase> CreateTestCases()
		{
			yield return BilliardTestCase.VerticalWall(45, 135);
			yield return BilliardTestCase.VerticalWall(10, 170);
			yield return BilliardTestCase.VerticalWall(171, 9);
			yield return BilliardTestCase.VerticalWall(90, 90);
			yield return BilliardTestCase.VerticalWall(91, 89);
			yield return BilliardTestCase.HorizontalWall(90, 270);
			yield return BilliardTestCase.HorizontalWall(270, 90);
			yield return BilliardTestCase.HorizontalWall(-95, 95);
			yield return BilliardTestCase.HorizontalWall(10, 350);
			yield return BilliardTestCase.HorizontalWall(40, 320);
			yield return BilliardTestCase.ArbitraryWall(0, 45, 90);
			yield return BilliardTestCase.ArbitraryWall(45, 45, 45);
			yield return BilliardTestCase.ArbitraryWall(44, 45, 46);
			yield return BilliardTestCase.ArbitraryWall(-44, -45, -46);
			yield return BilliardTestCase.ArbitraryWall(44, -45, -134);
			yield return BilliardTestCase.ArbitraryWall(0, 10, 20);
			yield return BilliardTestCase.ArbitraryWall(0, -10, -20);
		}
	}

	public enum BillartTaskType
	{
		HorizontallWall,
		VerticalWall,
		ArbitraryWall
	}

	public class BilliardTestCase : TestCase
	{
		private readonly double expectedFinalDirection;
		private readonly double initialDirection;
		private readonly BillartTaskType taskType;
		private readonly double wallInclanation;
		private double angle;

		private BilliardTestCase(double initialDirection, double wallInclanation, double expectedFinalDirection, BillartTaskType taskType)
			: base(taskType.ToString())
		{
			this.taskType = taskType;
			this.wallInclanation = wallInclanation*Math.PI/180;
			this.initialDirection = initialDirection*Math.PI/180;
			this.expectedFinalDirection = expectedFinalDirection*Math.PI/180;
		}

		public static BilliardTestCase HorizontalWall(double initialDirection, double expectedFinalDirection)
		{
			return new BilliardTestCase(initialDirection, 0, expectedFinalDirection, BillartTaskType.HorizontallWall);
		}

		public static BilliardTestCase VerticalWall(double initialDirection, double expectedFinalDirection)
		{
			return new BilliardTestCase(initialDirection, 90, expectedFinalDirection, BillartTaskType.VerticalWall);
		}

		public static BilliardTestCase ArbitraryWall(double initialDirection, double wallInclanationDirection, double expectedFinalDirection)
		{
			return new BilliardTestCase(initialDirection, wallInclanationDirection, expectedFinalDirection, BillartTaskType.ArbitraryWall);
		}

		protected override void InternalVisualize(TestCaseUI ui)
		{
			ui.Log("Wall inclanation: " + ToGradus(wallInclanation));
			ui.Log("Direction: " + ToGradus(initialDirection));
			ui.Line(-100 * Math.Cos(wallInclanation), 100 * Math.Sin(wallInclanation), 100 * Math.Cos(wallInclanation), -100 * Math.Sin(wallInclanation), new Pen(Color.Black, 1));
			ui.Line(-50 * Math.Cos(initialDirection), 50 * Math.Sin(initialDirection), 0, 0, new Pen(Color.Red, 3));
			ui.Line(50 * Math.Cos(angle), -50 * Math.Sin(angle), 0, 0, new Pen(Color.Red, 3) { DashStyle = DashStyle.Dash });
			ui.Line(50 * Math.Cos(expectedFinalDirection), -50 * Math.Sin(expectedFinalDirection), 0, 0, new Pen(Color.Green, 1) { DashStyle = DashStyle.Dash });
		}

		protected override bool InternalRun()
		{
			angle = FindBounceAngle();
			double diff = angle - expectedFinalDirection;
			while (diff < -Math.PI) diff += 2 * Math.PI;
			while (diff > Math.PI) diff -= 2 * Math.PI;
			return Math.Abs(diff) < 0.001;
		}

		private double FindBounceAngle()
		{
			var tasks = new BilliardTasks();
			if (taskType == BillartTaskType.ArbitraryWall)
				return tasks.BounceWall(initialDirection, wallInclanation);
			else if (taskType == BillartTaskType.HorizontallWall)
				return tasks.BounceHorizontalWall(initialDirection);
			else
				return tasks.BounceVerticalWall(initialDirection);
		}

		private string ToGradus(double radians)
		{
			return radians*180/Math.PI + "°";
		}

	}
}