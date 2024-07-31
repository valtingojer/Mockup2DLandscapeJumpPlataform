using Godot;

public partial class Walls : Area2D
{
	public void OnAreaEntered(Area2D area)
	{
		if (area is MovePlatform platform)
		{
			platform.FlipDirection();
		}
	}
}