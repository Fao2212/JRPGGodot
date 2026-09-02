using Godot;
using System;

public partial class Main : Node
{
	[Export]
	PackedScene BattleScene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode("World/Player").Connect("BattleStarted",Callable.From(onBattleFound));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void onBattleFound()
	{
		GD.Print("Battle Started");
		GetTree().Root.AddChild(BattleScene.Instantiate());
	}

}
