using Godot;

public partial class DialogueManager : Node
{
    public override void _Ready()
    {
        base._Ready();
		foreach(Node node in GetTree().Root.GetNode("Main/World/NPCs").GetChildren())
		{
            node.Connect("CreateDialogue", Callable.From((DialogueResource dialogueResource)=>OnDialogueInteract(dialogueResource)));
		}
    }

    public void OnDialogueInteract(DialogueResource dialogueResource)
	{
		PackedScene packedScene = GD.Load<PackedScene>("res://Scenes/Dialogue.tscn");
		DialogueBox dialogueBox = (DialogueBox)packedScene.Instantiate();
		dialogueBox.Resource = dialogueResource;
		GetTree().Root.GetNode("Main/GUI").AddChild(dialogueBox);
	}
}
