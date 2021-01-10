using System.Collections.Generic;
using UnityEngine;

public class BoxPool : Singleton<BoxPool>
{
    public  GameObject prefabObject;
    private readonly List<GameObject> pool = new List<GameObject>();
    private readonly int poolDepth = 15;


    void Start()
    {
        for (int i = 0; i < poolDepth; i++)
        {
            GameObject poolObject = Instantiate(prefabObject);
            poolObject.SetActive(false);
            pool.Add(poolObject);
        }
    }

    public GameObject GetAvailableObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                return pool[i];
            }
        }
        return null;
    }
}
