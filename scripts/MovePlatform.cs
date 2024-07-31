using Godot;
using System;

public partial class MovePlatform : Area2D
{
	[Export] public float Speed = 800;
	[Export] public int Direction = 1;
	
	public override void _PhysicsProcess(double delta)
	{
		float d = (float)delta;
		Vector2 velocity = new Vector2(Speed * Direction * d, 0);
		Position = Position with
		{
			X = Position.X + velocity.X,
			Y = Position.Y
		};
	}
	
	public void FlipDirection()
	{
		Direction *= -1;
	}
}
