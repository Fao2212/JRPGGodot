using System;
using Godot;

[GlobalClass,Tool]
public partial class DialogueResource : Resource
{
	[Export]
	public string[] dialogues;

	public string GetDialogue(int index)
	{
		if(index <= dialogues.Length - 1)
		{
			return dialogues[index];
		}
		else
		{
			throw new Exception(String.Format("Not enough dialogues for the entered index {0}",index));
		}
	}
}
