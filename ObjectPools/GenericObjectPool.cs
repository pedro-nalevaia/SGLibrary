
using System.Collections.Generic;
using Godot;

public struct ObjAndIndexInPool<T>
{
	public int PoolIndex;
	public T Obj;

	public ObjAndIndexInPool(int pos, T obj)
	{
		Obj = obj;
		PoolIndex = pos;
	}
}

public class ObjPool<T>where T : new()
{
	public T[] Pool;
	public List<int> IndexOfAvaliableObjects;

	public ObjPool(int Size)
	{
		Pool = new T[Size];
		IndexOfAvaliableObjects = new List<int>();

		for (int i = 0; i<Size; i++)
		{
			Pool[i] = new T();
			IndexOfAvaliableObjects.Add(i);
		}
	}
	public ObjAndIndexInPool<T>? GetObjFromPool()
	{
		if (IndexOfAvaliableObjects.Count == 0)
		{
			GD.PushError("sprite object pool was requested more objects than it has acess to");
			return null;
		}

		int last = IndexOfAvaliableObjects.Count-1;
		int poolIndex = IndexOfAvaliableObjects[last];
	

		IndexOfAvaliableObjects.RemoveAt(last);

		return new ObjAndIndexInPool<T>(
				poolIndex,
				Pool[IndexOfAvaliableObjects[poolIndex]]
				);

	}
	public void ReturnObjToThePool(int indx)
	{
		IndexOfAvaliableObjects.Add(indx);
	}
}
