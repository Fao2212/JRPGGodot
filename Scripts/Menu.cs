using Godot;
using Godot.Collections;

public partial class Menu : Node
{

	[Signal]
	delegate void BattleEndedEventHandler();
	//TODO IMPROVE THIS IM SLEEPY
	bool canEnd = true;

	int currentSelection = 0;

	Array<Node> options;

	public override void _Ready()
	{
		currentSelection = 0;
		options = GetChildren();
		ShowSelected();
	}

	public void ShowSelected()
	{
		Control selector = (Control)options[currentSelection].GetNode("Selector");
		selector.Visible = true;
	}

	public void SelectOption()
	{
		for (int i = 0; i < options.Count; i++)
		{
			Control selector = (Control)options[i].GetNode("Selector");
			selector.Visible = false;
		}
		ShowSelected();
	}

	// Control de repetition. Inso? Idempotency?
	public override void _Process(double delta)
	{
		if (Input.IsKeyPressed(Key.A))
		{
			currentSelection = Mathf.Max(0, currentSelection - 1);
			SelectOption();
		}
		if (Input.IsKeyPressed(Key.D))
		{
			currentSelection = Mathf.Min(1, currentSelection + 1);
			SelectOption();
		}
		if (Input.IsKeyPressed(Key.Space))
		{
			//IMprove this to avoiod if hell
			if (currentSelection == 1)
			{
				if (canEnd)
				{
					canEnd = false;
					EmitSignal("BattleEnded");
				}
			}
		}
	}
}
