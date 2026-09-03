using Godot;
using System;

public partial class Player : Character
{

	[Signal]
	delegate void BattleStartedEventHandler();
	bool canFight = true;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		if (Input.IsKeyLabelPressed(Key.W))
		{
			Position += Vector2.Up * Speed * (float)delta;
		}
		if (Input.IsKeyLabelPressed(Key.S))
		{
			Position += Vector2.Down * Speed * (float)delta;
		}
		if (Input.IsKeyLabelPressed(Key.D))
		{
			Position += Vector2.Right * Speed * (float)delta;
		}
		if (Input.IsKeyLabelPressed(Key.A))
		{
			Position += Vector2.Left * Speed * (float)delta;
		}
	}



	public void _on_area_2d_area_entered(Area2D area)
	{
		if (canFight)
		{
			canFight = false;
			EmitSignal("BattleStarted");
		}
	}

}
