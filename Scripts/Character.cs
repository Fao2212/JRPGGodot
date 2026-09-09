using Godot;

public partial class Character : Node2D
{
	[Export]
	protected float Speed {get;set;} = 200;
	[Export]
	public int MaxHP {get;set;}
	public int CurrentHP {get;set;}
	[Export]
	public int Damage {get;set;}
    public bool IsAlive { get {return CurrentHP > 0;}}

	public override void _Ready()
	{
		CurrentHP = MaxHP;
	}

    public void TakeDamage(int damage)
	{
		CurrentHP -= damage;
	}

	public void Attack(Character attacked)
	{
		attacked.TakeDamage(Damage);
	}

}
