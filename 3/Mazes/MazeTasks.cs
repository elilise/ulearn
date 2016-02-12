namespace Mazes
{
	public static class MazeTasks
	{
		public static void MoveToIndicatedDirection(Robot robot, int steps, Direction direction)
		{
			int doneSteps = 0;
			while (doneSteps < steps)
			{
				robot.MoveTo(direction);
				doneSteps += 1;
			}
		}

		public static void MoveOutFromEmptyMaze(Robot robot, int width, int height)
		{
			int stepsRight = width - 3;
			int stepsDown = height - 3;
			MoveToIndicatedDirection(robot, stepsRight, Direction.Right);
			MoveToIndicatedDirection(robot, stepsDown, Direction.Down);	
			
		}

		public static void MoveOutFromSnakeMaze(Robot robot, int width, int height)
		{
			int horizontalSteps = width - 3;
			int countofIterations = (int) height/4;
			int stepsDown = 2;
			for (int i = 1; i <= countofIterations; i++)
			{
				MoveToIndicatedDirection(robot, horizontalSteps, Direction.Right);
				MoveToIndicatedDirection(robot, stepsDown, Direction.Down);
				MoveToIndicatedDirection(robot, horizontalSteps, Direction.Left);
				if (i != countofIterations)
					MoveToIndicatedDirection(robot, stepsDown, Direction.Down);
			}
		}

		public static void MoveOutFromPyramidMaze(Robot robot, int width, int height)
		{
			int horizontalSteps = width - 3;
			int countofIterations = (int)height / 4;
			int stepsUp = 2;
			for (int i = 1; i <= countofIterations; i++)
			{
				MoveToIndicatedDirection(robot, horizontalSteps, Direction.Right);
				MoveToIndicatedDirection(robot, stepsUp, Direction.Up);
				horizontalSteps -= 2;
				MoveToIndicatedDirection(robot, horizontalSteps, Direction.Left);
				horizontalSteps -= 2;
				if (i != countofIterations)
					MoveToIndicatedDirection(robot, stepsUp, Direction.Up);
			}
		}
	}
}