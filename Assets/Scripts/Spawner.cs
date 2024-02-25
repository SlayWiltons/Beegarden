using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn = 3f;
    private float timeSinceSpawn;
    private ObjectPool objectPool;

    private void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
    }

    private void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >= timeToSpawn)
        {
            GameObject newBee = objectPool.GetBee();
            newBee.transform.position = this.transform.position;
            timeSinceSpawn = 0f;
        }
    }
}
