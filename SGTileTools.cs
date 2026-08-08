using Godot;

public static class SGTileTools {
	public static bool CellHasCollision(TileMapLayer ThisTile, Vector2I ThisCell){
		TileData tileData = ThisTile.GetCellTileData(ThisCell);
		bool HasCollision = false;
		if (tileData == null)
		{
			GD.Print("Tried to get null tile data");
		}
		else {
			HasCollision = tileData.GetCollisionPolygonsCount(0) > 0;
		}
		return HasCollision;
	}
}
