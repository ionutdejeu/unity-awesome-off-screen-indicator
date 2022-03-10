using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OffScreenIndicatorPoolableObject : MonoBehaviour,IPoolableObject<OffScreenIndicatorView>
{

    public static OffScreenIndicatorPoolableObject current;

    [Tooltip("Assign the box prefab.")]
    [SerializeField] OffScreenIndicatorView pooledObject;

    [Tooltip("Initial pooled amount.")]
    public int pooledAmount = 1;
    [Tooltip("Should the pooled amount increase.")]
    public bool willGrow = true;

    public int poolledAmmount =1;

    List<OffScreenIndicatorView> pooledObjects;

    void Awake()
    {
        current = this;
    }

    public void DeactivateAllPooledObjects()
    {
        foreach (OffScreenIndicatorView box in pooledObjects)
        {
            box.gameObject.SetActive(false);
        }
    }

    public OffScreenIndicatorView GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].gameObject.active)
            {
                return pooledObjects[i];
            }
        }
        if (willGrow)
        {
            OffScreenIndicatorView box = Instantiate(pooledObject);
            box.transform.SetParent(transform, false);
            box.gameObject.SetActive(false);
            pooledObjects.Add(box);
            return box;
        }
        return null;
    }

    // Use this for initialization
    void Start()
    {
        pooledObjects = new List<OffScreenIndicatorView>();

        for (int i = 0; i < pooledAmount; i++)
        {
            OffScreenIndicatorView view = Instantiate(pooledObject);
            view.transform.SetParent(transform, false);
            view.gameObject.SetActive(false);
            pooledObjects.Add(view);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
