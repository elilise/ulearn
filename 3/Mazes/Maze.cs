using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Mazes
{
	public class Maze
	{
		private readonly bool[][] walls;

		public Maze(string filename)
		{
			string[] lines = File.ReadAllLines(filename);
			Robot = ParsePoint(lines[0]);
			Exit = ParsePoint(lines[1]);
			walls = ParseWalls(lines.Skip(2));
			Size = new Size(walls.Max(row => row.Length), walls.Length);
		}

		public Point Robot { get; private set; }
		public Point Exit { get; private set; }
		public Size Size { get; private set; }

		private Point ParsePoint(string s)
		{
			int[] coords = s.Split(' ').Select(int.Parse).ToArray();
			return new Point(coords[0], coords[1]);
		}

		public bool IsWall(Point pos)
		{
			return walls[pos.Y][pos.X];
		}

		private bool[][] ParseWalls(IEnumerable<string> lines)
		{
			return lines.Select(line => line.Select(c => c == '#').ToArray()).ToArray();
		}
	}
}