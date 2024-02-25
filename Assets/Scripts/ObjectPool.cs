using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Queue<GameObject> objectPool = new Queue<GameObject>();
    [SerializeField] private int poolSize;

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bee = Instantiate(objectPrefab);
            objectPool.Enqueue(bee);
            bee.SetActive(false);
        }
    }

    public GameObject GetBee()
    {
        if (objectPool.Count > 0)
        {
            GameObject bee = objectPool.Dequeue();
            bee.SetActive(true);
            return bee;
        }
        else
        {
            GameObject bee = Instantiate(objectPrefab);
            return bee;
        }
    }

    public void ReturnBee(GameObject bee)
    {
        objectPool.Enqueue(bee);
        bee.SetActive(false);
    }
}
