using Godot;

public partial class Player : Character
{
	[Signal]
	delegate void InteractedEventHandler();
	Timer interactTimer = new();
	bool freeInteract = true;

    public override void _Ready()
    {
        base._Ready();
		interactTimer.WaitTime = 1f;
		interactTimer.Autostart = false;
		interactTimer.Timeout += ()=>{freeInteract = true;};
		AddChild(interactTimer);
    }

	public override void _Process(double delta)
	{
		if (Input.IsKeyLabelPressed(Key.W))
		{
			Position += Vector2.Up * Speed * (float)delta;
		}
		if (Input.IsKeyLabelPressed(Key.S))
		{
			Position += Vector2.Down * Speed * (float)delta;
		}
		if (Input.IsKeyLabelPressed(Key.D))
		{
			Position += Vector2.Right * Speed * (float)delta;
		}
		if (Input.IsKeyLabelPressed(Key.A))
		{
			Position += Vector2.Left * Speed * (float)delta;
		}
		if(Input.IsKeyPressed(Key.Space))
		{
			if(freeInteract)
			{
				freeInteract = false;
				interactTimer.Start();
				EmitSignal("Interacted");
			}
		}
	}


}
