using Godot;
using System;
using System.Threading.Tasks;

public partial class Main : Node
{
	[Export]
	PackedScene battleScene;
	Node mainScene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode("World/Player").Connect("BattleStarted", Callable.From(OnBattleFound));
		mainScene = GetNode("World");
	}

	public async Task OnBattleFound()
	{
		GD.Print("Battle Started");
		Node scene = battleScene.Instantiate();
		AddChild(scene);
		RemoveChild(mainScene);
		await ToSignal(GetTree().CreateTimer(5f), "timeout");
		GD.Print("DONE");
		AddChild(mainScene);
		RemoveChild(scene);
	}

}
