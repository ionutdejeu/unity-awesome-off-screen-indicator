using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolableObject<T>
{
    public T GetPooledObject();
    public void DeactivateAllPooledObjects();
}
