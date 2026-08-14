using Godot;

//the purpouses of this class is to be a reusable clamper you can't put on any object and use out of the box
//you add this to an object putting the clamp data, and when you want to move it keeping the clamp you call 
//its MoveWithClamp metod giving it a vector
public partial class Clamper{
	public Vector2 ClampTopLeft;
	public Vector2 ClampBottomRight;
	public Node2D Parent;

	public Clamper(Vector2 clamp_top_left, Vector2 clamp_bottom_right, Node2D parent)
	{
		ClampTopLeft = clamp_top_left;
		ClampBottomRight = clamp_bottom_right;
		Parent = parent;
	}

	public void MoveWithClamp(Vector2 Mov)
	{
		//get position as a struct
		//this needs to be done since modifying parts of the 
		//Parent.position only modify a sturct copy inside this function
		Vector2 pos = Parent.Position;
		pos += Mov;

		//CLAMPING
		if (pos.X < ClampTopLeft.X)
		{
			pos.X = ClampTopLeft.X;
		}
		if (pos.X > ClampBottomRight.X)
		{
			pos.X = ClampBottomRight.X;
		}
		if (pos.Y < ClampTopLeft.Y)
		{
			pos.Y = ClampTopLeft.Y;
		}
		if (pos.Y > ClampBottomRight.Y)
		{
			pos.Y = ClampBottomRight.Y;
		}
		//assign back
		Parent.Position = pos;
	}

}

