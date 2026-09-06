using System.Threading.Tasks;
using Godot;

//THis whole file is forcing behaviour
public partial class Battle : Node
{

	[Export]
	private Character Player,Enemy;
	// I could use signals to update or make this part of the Character so it updates. I dont want to mix UI and LOgic I'll think on an MVC approach
	[Export]
	private ProgressBar PlayerProgressBar,EnemyProgressBar;
	// Turns IMprove as for  number of participants in the Battle
	public bool PlayerTurn = true;
	// Link Attack from signal
	[Export]
	private Menu menu;
	// End Battle
	Timer timer = new Timer();

	public override void _Ready()
	{
		EnemyProgressBar.MaxValue = Enemy.CurrentHP;
		PlayerProgressBar.MaxValue = Player.CurrentHP;
		menu.Connect("PlayerAttacked",Callable.From(OnPlayerAttacked));
		timer.WaitTime = 2f;
		timer.Timeout += NextTurn;
		timer.OneShot = true;
		AddChild(timer);
	}

	public void NextTurn()
	{
		Enemy.Attack(Player);
		PlayerProgressBar.Value = Player.CurrentHP;
		PlayerTurn = true;
		menu.CanAttack = true;
	}

	public void OnPlayerAttacked()
	{
		if (PlayerTurn)
		{
			PlayerTurn = false;
			Player.Attack(Enemy);
			EnemyProgressBar.Value = Enemy.CurrentHP;
		}
		else
		{
			GD.PrintErr("Not player turn");
		}
		timer.Start();
	}

}
