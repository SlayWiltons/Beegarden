using UnityEngine;

public class BeeReturn : MonoBehaviour
{
    private ObjectPool objectPool;

    private void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
    }

    private void OnDisable()
    {
        if (objectPool != null)
        {
            objectPool.ReturnBee(this.gameObject);
        }
    }
}
