using Godot;
using System;

public partial class Player : Character
{

	[Signal]
	delegate void BattleStartedEventHandler();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		if (Input.IsKeyLabelPressed(Key.W))
		{
			Position += Vector2.Up * _speed * (float)delta;
		}
		if (Input.IsKeyLabelPressed(Key.S))
		{
			Position += Vector2.Down * _speed * (float)delta;
		}
		if (Input.IsKeyLabelPressed(Key.D))
		{
			Position += Vector2.Right * _speed * (float)delta;
		}
		if (Input.IsKeyLabelPressed(Key.A)) 
		{
			Position += Vector2.Left * _speed * (float)delta;
		}
	}



		public void _on_area_2d_area_entered(Area2D area)
	{
		GD.Print(area);
		EmitSignal("BattleStarted");
	}

}
