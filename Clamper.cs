using Godot;

//the purpouses of this class is to be a reusable clamper you can't put on any object and use out of the box
//you add this to an object putting the clamp data, and when you want to move it keeping the clamp you call 
//its MoveWithClamp metod giving it a vector
public partial class Clamper(){
	public Vector2I ClampTopLeft;
	public Vector2I ClampBottomRight;
	public Node2D Parent;

	public void Clamper(Vector2I clamp_top_left, Vector2I clamp_bottom_right, Node2D parent)
	{
		ClampTopLeft = clamp_top_left;
		ClampBottomRight = clamp_bottom_right;
		Parent = parent;
	}

	public void MoveWithClamp(Vector2I Mov)
	{
		Parent.Position += Mov;

		//CLAMPING
		if (Parent.Position.X < ClampTopLeft.X)
		{
			Parent.Position.X = ClampTopLeft.X;
		}
		if (Parent.Position.X > ClampBottomRight.X)
		{
			Parent.Position.X = ClampBottomRight.X;
		}
		if (Parent.Positon.Y < ClampTopLeft.Y)
		{
			Parent.Position.Y = ClampTopLeft.Y;
		}
		if (Parent.Position.Y > ClampBottomRight.Y)
		{
			Parent.Position.Y = ClampBottomRight.Y;
		}
	}

}
