using Godot;
using System;

public class KBExample : KinematicBody2D
{
	[Signal]
	public delegate void playerHit();
	
	public int Speed = 250;
	private Vector2 _velocity = new Vector2();

	public void GetInput()
	{
		// Detect up/down/left/right keystate and only move when pressed
		_velocity = new Vector2();

		if (Input.IsActionPressed("ui_right"))
			_velocity.x += Speed;
			//set_frame(1); // Doesn't work

		if (Input.IsActionPressed("ui_left"))
			_velocity.x -= Speed;

		if (Input.IsActionPressed("ui_down"))
			_velocity.y += Speed;

		if (Input.IsActionPressed("ui_up"))
			_velocity.y -= Speed;
	}

	public override void _PhysicsProcess(float delta)
	{
		GetInput();
		//MoveAndCollide(_velocity * delta);
		var collision = MoveAndCollide(_velocity * (float)delta);
		if (collision != null)
		{
			GD.Print("I collided with ", ((Node)collision.GetCollider()).Name);
		}
	}
	private void _on_Ball_body_entered(object body)
	{
		// Ball resets when player is hit
		EmitSignal("playerHit");
	}
}
