using Godot;

public class Ball : Area2D
{
	private const int DefaultSpeed = 200;

	public Vector2 direction = Vector2.Right;

	private Vector2 _initialPos;
	private float _speed = DefaultSpeed;

	public override void _Ready()
	{
		_initialPos = Position;
	}

	public override void _Process(float delta)
	{
		_speed += delta * 2;
		Position += _speed * delta * direction;
	}

	public void Reset()
	{
		direction = Vector2.Right;
		Position = _initialPos;
		_speed = DefaultSpeed;
	}
}
