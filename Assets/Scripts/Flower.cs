using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour, IChangeValue, IDie
{
    [SerializeField] private GameObject flowerVisual;
    [SerializeField] private int maxHealth;
    [SerializeField] private int rechargingPoints;
    [SerializeField] private int currentHealth;
    private ObjPool_Flowers objectPool;
    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        flowerVisual.SetActive(true);
        StartCoroutine(Recharging());
    }

    public void SetOP(ObjPool_Flowers OP)
    {
        objectPool = OP;
    }

    public void ChangeValue(int value)
    {
        currentHealth -= value;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        objectPool.ToRecharge(gameObject);
        objectPool.FromFree(gameObject);
        flowerVisual.SetActive(false);
    }

    private IEnumerator Recharging()
    {
        yield return new WaitForSeconds(3);
        if (currentHealth < maxHealth)
        {
            currentHealth += rechargingPoints;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            if (isDead && currentHealth == maxHealth)
            {
                isDead = false;
                objectPool.FromRecharge(gameObject);
                objectPool.ToFree(gameObject);
                flowerVisual.SetActive(true);
            }
        }
        StartCoroutine(Recharging());
    }
}
