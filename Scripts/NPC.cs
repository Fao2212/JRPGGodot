using Godot;

public partial class NPC : Character
{
	Sprite2D interactIcon;	
	[Export]
	DialogueResource[] dialogues;
	[Export]
	DialogueManager DialogueManager;
	[Signal]
	delegate void CreateDialogueEventHandler();
	//MAybe a global?\
	[Export]
	Player player;

	public override void _Ready()
	{
		Area2D area = (Area2D)GetNode("Area2D");
		area.AreaEntered += ShowIcon;
		area.AreaExited += HideIcon;
		interactIcon = (Sprite2D)GetNode("InteractIcon");
		player.Connect("Interacted",Callable.From(PlayerInteraction));
	}

	public override void _Process(double delta)
	{
	}
	    private void HideIcon(Area2D area)
    {
        interactIcon.Visible = false;
    }

    private void ShowIcon(Area2D area)
    {

        interactIcon.Visible = true;
    }

	public void PlayerInteraction()
	{
		if (interactIcon.Visible)
		{
			interactIcon.Visible = false;
			EmitSignal("CreateDialogue",dialogues[0]);
		}
	}

}
