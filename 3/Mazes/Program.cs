using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TestingRoom;

namespace Mazes
{
	internal static class Program
	{
		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new TestRoom(CreateMazes()));
		}

		private static IEnumerable<MazeTestCase> CreateMazes()
		{
			yield return new MazeTestCase("empty1", MazeTasks.MoveOutFromEmptyMaze);
			yield return new MazeTestCase("empty2", MazeTasks.MoveOutFromEmptyMaze);
			yield return new MazeTestCase("empty3", MazeTasks.MoveOutFromEmptyMaze);
			yield return new MazeTestCase("empty4", MazeTasks.MoveOutFromEmptyMaze);
			yield return new MazeTestCase("empty5", MazeTasks.MoveOutFromEmptyMaze);
			yield return new MazeTestCase("snake1", MazeTasks.MoveOutFromSnakeMaze);
			yield return new MazeTestCase("snake2", MazeTasks.MoveOutFromSnakeMaze);
			yield return new MazeTestCase("snake3", MazeTasks.MoveOutFromSnakeMaze);
			yield return new MazeTestCase("pyramid1", MazeTasks.MoveOutFromPyramidMaze);
			yield return new MazeTestCase("pyramid2", MazeTasks.MoveOutFromPyramidMaze);
			yield return new MazeTestCase("pyramid3", MazeTasks.MoveOutFromPyramidMaze);
			yield return new MazeTestCase("pyramid4", MazeTasks.MoveOutFromPyramidMaze);
//			Hey! You've just found the secret levels! You can earn one more point.
//			yield return new MazeTestCase("diagonal1", MazeTasks.MoveOutFromDiagonalMaze);
//			yield return new MazeTestCase("diagonal2", MazeTasks.MoveOutFromDiagonalMaze);
//			yield return new MazeTestCase("diagonal3", MazeTasks.MoveOutFromDiagonalMaze);
		}
	}

	internal class MazeTestCase : TestCase
	{
		private readonly Maze maze;
		private readonly Action<Robot, int, int> solve;
		private Robot robot;
		private readonly int cellSize;

		public MazeTestCase(string name, Action<Robot, int, int> solve)
			: base(name)
		{
			maze = new Maze("mazes\\" + name + ".txt");
			cellSize = 200 / Math.Max(maze.Size.Width, maze.Size.Height);
			this.solve = solve;
		}

		protected override void InternalVisualize(TestCaseUI ui)
		{
			for (int x = 0; x < maze.Size.Width; x++)
				for (int y = 0; y < maze.Size.Height; y++)
					if (maze.IsWall(new Point(x, y))) DrawWall(ui, x, y);
			Point last = maze.Robot;
			foreach (var cur in robot.Path)
			{
				ui.Line(Conv(last.X), Conv(last.Y), Conv(cur.X), Conv(cur.Y), actualAnswerPen);
				last = cur;
			}
			ui.Circle(Conv(robot.X), Conv(robot.Y), cellSize / 3.0, actualAnswerPen);
			ui.Circle(Conv(maze.Exit.X), Conv(maze.Exit.Y), cellSize / 2.5, expectedAnswerPen);
		}

		private double Conv(int coord)
		{
			return coord*cellSize - 100 + cellSize/2.0;
		}

		private void DrawWall(TestCaseUI ui, int x, int y)
		{
			var x1 = x*cellSize - 100;
			var y1 = y*cellSize - 100;
			var x2 = (x + 1) * cellSize - 101;
			var y2 = (y + 1) * cellSize - 101;
			ui.Rect(new Rectangle(x1, y1, cellSize, cellSize), neutralPen);
			ui.Line(x1, y1, x2, y2, neutralPen);
			ui.Line(x1, y2, x2, y1, neutralPen);
		}

		protected override bool InternalRun()
		{
			robot = new Robot(maze);
			solve(robot, maze.Size.Width, maze.Size.Height);
			return robot.Finished;
		}
	}
}