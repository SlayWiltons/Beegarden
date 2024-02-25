using UnityEngine;

public class Spawner_Flowers : MonoBehaviour
{
    [SerializeField] private GameObject flowerPrefab;
    [SerializeField] private int rows;
    [SerializeField] private int lines;
    [SerializeField] private ObjPool_Flowers objectPool_flowers;

    private void Start()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int y = 0; y < lines; y++)
            {
                GameObject flower = Instantiate(flowerPrefab);
                Vector3 position = new Vector3(transform.position.x - (i - rows / 2), 0, transform.position.z - (y - lines / 2));
                flower.transform.position = position;
                flower.transform.parent = gameObject.transform;
                flower.GetComponent<Flower>().SetOP(objectPool_flowers);
                objectPool_flowers.ToFree(flower);
            }
        }
    }
}
