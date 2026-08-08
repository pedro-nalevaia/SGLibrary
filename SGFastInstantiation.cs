using Godot;

public static class SGFastInstantiation
{
	public static Node SceneInstanceFromDsk(string ScenePath){
		var Packed = GD.Load<PackedScene>(ScenePath);
		var Instance = Packed.Instantiate() as Node;
		return Instance;
	}
	public static Node AddChildFromDisk(string ChildPath, Node Parent){
		var Instance = SceneInstanceFromDsk(ChildPath);
		Parent.AddChild(Instance);
		return Instance;
	}
}
