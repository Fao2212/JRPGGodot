using Godot;

public partial class DialogueBox: Control
{
	public DialogueResource Resource {get;set;}
	RichTextLabel box;	
	int currentDialogue;
	Player player;
	Main main;
	[Signal]
	delegate void BattleStartedEventHandler();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		main = GetTree().Root.GetNode<Main>("Main");
		box = (RichTextLabel)GetNode("Background").GetNode("RichTextLabel");
		player = GetTree().Root.GetNode<Player>("Main/World/Player");
		player.Connect("Interacted",Callable.From(NextDialogue));
		NextDialogue();
	}


    public void NextDialogue()
	{
		if (currentDialogue <= Resource.dialogues.Length-1)
		{
			box.Text = Resource.GetDialogue(currentDialogue);
			currentDialogue++;
		}
		else
		{
			main.OnBattleStarted();
		}
	}
}
