using Godot;
using System.Threading.Tasks;

public partial class VisualUtils: Node{

	public static async Task FadeIn(Godot.CanvasLayer Canva, int Time){
		Vector2 resolution = Canva.GetViewport().GetVisibleRect().Size;
		Vector2I DiscRes = new Vector2I((int)(resolution.X), 
				(int)(resolution.Y));
		Sprite2D FadeCurtain = new Sprite2D();
		var FadeCurtainTexture = new ImageTexture();
		var FadeCurtainImage = Image.CreateEmpty(DiscRes.X,
				DiscRes.Y, false, Image.Format.Rgba8);

		FadeCurtainImage.Fill(Colors.Black);
		FadeCurtainTexture.SetImage(FadeCurtainImage);
		FadeCurtain.Texture = FadeCurtainTexture;
		FadeCurtain.ZAsRelative = true;
		FadeCurtain.ZIndex = 20;
		FadeCurtain.Centered = false;
		Canva.AddChild(FadeCurtain);
		FadeCurtain.Position = new Vector2(0,0);

		double AnimationFramesCount = 0;
		while (AnimationFramesCount <= Time){
			AnimationFramesCount++;
			Color FadeModulate = FadeCurtain.Modulate;
			FadeModulate.A = (float)1.0 - (float)AnimationFramesCount/Time;
			FadeCurtain.Modulate = FadeModulate;	
			await Canva.ToSignal(Canva.GetTree(), SceneTree.SignalName.ProcessFrame);

		}
		FadeCurtain.QueueFree();
		
	}
	public static async Task FadeOut(Godot.CanvasLayer Canva, int Time){
		Vector2 resolution = Canva.GetViewport().GetVisibleRect().Size;
		Vector2I DiscRes = new Vector2I((int)(resolution.X), 
				(int)(resolution.Y));
		Sprite2D FadeCurtain = new Sprite2D();
		var FadeCurtainTexture = new ImageTexture();
		var FadeCurtainImage = Image.CreateEmpty(DiscRes.X,
				DiscRes.Y, false, Image.Format.Rgba8);

		FadeCurtainImage.Fill(Colors.Black);
		FadeCurtainTexture.SetImage(FadeCurtainImage);
		FadeCurtain.Texture = FadeCurtainTexture;
		FadeCurtain.ZAsRelative = true;
		FadeCurtain.ZIndex = 20;
		FadeCurtain.Centered = false;
		Canva.AddChild(FadeCurtain);
		FadeCurtain.Position = new Vector2(0,0);

		double AnimationFramesCount = 0;
		while (AnimationFramesCount <= Time){
			AnimationFramesCount++;
			Color FadeModulate = FadeCurtain.Modulate;
			FadeModulate.A = (float)AnimationFramesCount/Time;
			FadeCurtain.Modulate = FadeModulate;	
			await Canva.ToSignal(Canva.GetTree(), SceneTree.SignalName.ProcessFrame);

		}
		FadeCurtain.QueueFree();
		
	}

}
