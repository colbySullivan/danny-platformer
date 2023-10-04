using Godot;

public class LeftWall : Area2D
{
	[Export]
	private int _bounceDirection = 1;

	public void OnAreaEntered(Area2D area)
	{
		if (area is Ball ball)
		{
			ball.direction = -(ball.direction + new Vector2(0,_bounceDirection)).Normalized();
		}
	}


private void OnWallAreaEntered(object area)
{
	if (area is Ball ball)
		{
			// Ball went off the side of the screen, reset it.
			ball.Reset();
		}
}
}
