using Godot;
using System;

public partial class MovePlataform : AnimatableBody2D
{
	[Export] public float Speed = 400;
	[Export] public int Direction = 1;

	public override void _Process(double delta)
	{
		Move(delta);
	}

	private void Move(double delta)
	{
		float d = (float)delta;
		Vector2 velocity = new Vector2(Speed * Direction * d, 0);
		MoveAndCollide(velocity);
	}
	
	public int FlipDirection()
	{
		Direction *= -1;
		return Direction;
	}
}
