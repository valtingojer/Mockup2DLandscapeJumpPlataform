using Godot;
using System;
using System.Threading.Tasks;

public partial class Loading : ColorRect
{
	[Export] public bool IsLoading { get; set; } = true;	
	
	public override void _Ready()
	{ 
        ToggleLoadingByTime();
	} 

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		if (IsLoading)
		{
			ShowMe();
		}
		else
		{
			HideMe();
		}
	}
	
	private void ShowMe()
	{
		this.Visible = true;
	}
	
	private void HideMe()
	{
		this.Visible = false;
	}
	
	private async void ToggleLoadingByTime()
	{
		await Task.Delay(TimeSpan.FromSeconds(2f));
		IsLoading = false;
	}
	
	
	
	
}
