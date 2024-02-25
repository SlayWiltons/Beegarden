using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private ObjPool_Flowers objectPool;

    public void SetOP(ObjPool_Flowers OP)
    {
        objectPool = OP;
    }
}
