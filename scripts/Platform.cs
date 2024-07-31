using Godot;
using System;

public partial class Platform : Node2D
{
	// Enum para as direções da animação
	public enum AnimationDirectionEnum
	{
		Left,
		Right,
		Random
	}

	[Export] public float AnimationSpeedPercent { get; set; } = 100f;

	[Export] public AnimationDirectionEnum AnimationDirection { get; set; } = AnimationDirectionEnum.Left;
	
	[Export] public AnimationPlayer animationPlayer { get; set; }
	
	[Export(PropertyHint.Range, "-1,100")] public int StartAt { get; set; } = 0;

	private string animMove;
	private string animMoveBack;

	public override void _Ready()
	{
		this.Visible = false;
		SetAnimationNames();
		SetAnimationSpeed(AnimationSpeedPercent);
		PlaySelectedAnimation();
		this.Visible = true;
	}
	
	private void SetAnimationNames()
	{
		foreach (string animName in animationPlayer.GetAnimationList())
		{
			string lowerCaseAnimName = animName.ToLower();
			
			if (lowerCaseAnimName.Contains("moveback"))
			{
				animMoveBack = animName;
			}
			else if (lowerCaseAnimName.Contains("move"))
			{
				animMove = animName;
			}
		}
	}

	private void SetAnimationSpeed(float speedPercent)
	{
		float speedScale = speedPercent / 100f;
		animationPlayer.SpeedScale = speedScale;
	}

	private void PlaySelectedAnimation()
	{
		string animationToPlay = animMove;

		switch (AnimationDirection)
		{
			case AnimationDirectionEnum.Right:
				animationToPlay = animMoveBack;
				break;
			case AnimationDirectionEnum.Random:
				Random random = new Random();
				animationToPlay = random.Next(2) == 0 ? animMove : animMoveBack;
				break;
			case AnimationDirectionEnum.Left:
			default:
				break;
		}
		
		float startPosition = 0f;

		if (StartAt == -1)
		{
			Random random = new Random();
			startPosition = (float)random.NextDouble(); // Random 0 to 1
		}
		else
		{
			// Converter StartAt para uma posição de 0.0 to 1.0
			startPosition = Math.Clamp(StartAt / 100f, 0f, 1f);
		}

		animationPlayer.Play(animationToPlay);
		animationPlayer.Seek(animationPlayer.CurrentAnimationLength * startPosition);
	}
}
