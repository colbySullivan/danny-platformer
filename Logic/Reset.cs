using Godot;

public class Reset : Area2D
{
	public void BallCollision(Area2D area)
	{
		if (area is Ball ball)
		{
			// Ball hit player, reset it.
			ball.Reset();
		}
	}
}
