using System;
using Godot;

public partial class Dialogue : Control
{
	[Export]
	DialogueResource dialogueResource;
	RichTextLabel dialogueBox;	
	int currentDialogue;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		if (Input.IsKeyPressed(Key.Space))
		{
			NextDialogue();
		}
	}

	public void NextDialogue()
	{
		dialogueBox.Text = dialogueResource.GetDialogue(currentDialogue);
		currentDialogue++;
	}

	//Load Dialogues. Use some kind of data asset.
	public void LoadDialogue()
	{
		// Use @GlobalScope.var_to_bytes() or FileAccess.store_var() instead. To enable data compression, use PackedByteArray.compress() or FileAccess.open_compressed().

	}
}
