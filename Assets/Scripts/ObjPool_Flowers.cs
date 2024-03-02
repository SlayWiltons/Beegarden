using System.Collections.Generic;
using UnityEngine;

public class ObjPool_Flowers : MonoBehaviour
{
    [SerializeField] private List<GameObject> freeFlowers;
    [SerializeField] private List<GameObject> occupiedFlowers;
    [SerializeField] private List<GameObject> rechargeFlowers;

    public void ToFree(GameObject flower)
    {
        freeFlowers.Add(flower);
    }

    public void FromFree(GameObject flower)
    {
        freeFlowers.Remove(flower);
    }

    public void ToOccupied(GameObject flower)
    {
        occupiedFlowers.Add(flower);
    }

    public void FromOccupied(GameObject flower)
    {
        occupiedFlowers.Remove(flower);
    }

    public void ToRecharge(GameObject flower)
    {
        rechargeFlowers.Add(flower);
    }

    public void FromRecharge(GameObject flower)
    {
        rechargeFlowers.Remove(flower);
    }

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var id = Random.Range(0, freeFlowers.Count);
            freeFlowers[id].GetComponent<Flower>().ChangeValue(20);
        }
    }*/
}
