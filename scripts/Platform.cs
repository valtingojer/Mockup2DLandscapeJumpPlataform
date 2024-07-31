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

	// Propriedade para definir a velocidade da animação em porcentagem
	[Export] public float AnimationSpeedPercent { get; set; } = 100f;

	// Propriedade para escolher a direção da animação usando o enum
	[Export] public AnimationDirectionEnum AnimationDirection { get; set; } = AnimationDirectionEnum.Left;
	
	[Export] public AnimationPlayer animationPlayer { get; set; }

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
		// Converte a porcentagem para o multiplicador de velocidade
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

		// Toca a animação selecionada
		animationPlayer.Play(animationToPlay);
	}
}
