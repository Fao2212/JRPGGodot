using Godot;

public partial class Main : Node
{
	Node mainScene;
	PackedScene battleScene;
	DialogueManager dialogueManager;
	
	public override void _Ready()
	{
		mainScene = GetNode("World");
		battleScene = GD.Load<PackedScene>("res://Scenes/Battle.tscn");
	}

    public void OnBattleStarted()
	{
		Node scene = battleScene.Instantiate();
		CallDeferred("add_child", scene);
		//FOrced this need to be fiixed
		scene.GetNode("GUI/Menu/ColorRect").Connect("BattleEnded", Callable.From(OnBattleEnded));
		CallDeferred("remove_child", mainScene);
	}

	public void OnBattleEnded()
	{
		Node scene = GetTree().Root.GetNode("Main/BattleMain");
		CallDeferred("add_child", mainScene);
		CallDeferred("remove_child", scene);
	}

}
