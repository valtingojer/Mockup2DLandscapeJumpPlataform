using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] public float speed = 300;
	[Export] public float jumpVelocity = -600;

	private Variant gravity = ProjectSettings.GetSetting("physics/2d/default_gravity");
	
	public Vector2 PlatformVelocity { get; set; }
	
	
	//_PhysicsProcess
	public override void _PhysicsProcess(double delta)
	{
		if (!IsOnFloor())
		{
			Velocity = Velocity with
			{
				Y = Velocity.Y + (float)gravity * (float)delta,
			};
		}
		
		if (Input.IsActionPressed("ui_accept"))
		{
			Velocity = Velocity with
			{
				Y = jumpVelocity,
				X = PlatformVelocity.X
			};
		}
		
		float direction = Input.GetAxis("left", "right");
		if (direction != 0)
		{
			Velocity = Velocity with
			{
				X = direction * speed,
			};
		}
		else if (IsOnFloor())
		{
			Velocity = Velocity.MoveToward(Vector2.Zero, speed * (float)delta);
		}

		MoveAndSlide();
		PlatformVelocity = GetPlatformVelocity();
	}
	
	
}
