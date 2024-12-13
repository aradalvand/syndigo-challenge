FindTheIslands.PrintAnswer();

public static class FindTheIslands
{
	private static readonly int[][] Map =
	[[0, 0, 1, 1, 0, 1, 0, 1],
	 [0, 0, 1, 0, 0, 1, 1, 0],
	 [1, 0, 0, 0, 0, 0, 0, 0],
	 [1, 1, 0, 1, 0, 1, 0, 1],
	 [0, 1, 0, 0, 0, 1, 0, 0],
	 [0, 0, 0, 1, 0, 1, 0, 0]];

	public static void PrintAnswer()
	{
		Console.WriteLine($"{CountIslands(Map)} Islands Found!");
	}

	public static int CountIslands(int[][] map)
	{
		List<Island> islands = [];

		for (int y = 0; y < map.Length; y++)
		{
			for (int x = 0; x < map[y].Length; x++)
			{
				if (map[y][x] == 0)
				{
					continue;
				}

				if (map[y][x] == 1)
				{
					Coordinates coordinates = new(y, x);
					var continuousWith = islands.FirstOrDefault(i =>
						i.Pieces.Any(c => c.IsAdjacentTo(coordinates))
					);
					if (continuousWith is null)
						islands.Add(new(
							Pieces: [coordinates]
						));
					else
						continuousWith.Pieces.Add(coordinates);
				}
			}
		}

		return islands.Count;
	}
}

public record Island(
	List<Coordinates> Pieces
);

public record Coordinates(
	int Y,
	int X
);

public static class CoordinatesExtensions
{
	public static bool IsAdjacentTo(this Coordinates coordinates, Coordinates other)
	{
		return (coordinates.X == other.X || coordinates.X == other.X - 1 || coordinates.X == other.X + 1) &&
			(coordinates.Y == other.Y || coordinates.Y == other.Y - 1 || coordinates.Y == other.Y + 1);
	}
}
