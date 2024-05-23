using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_v2 : MonoBehaviour
{
    [SerializeField] int cost = 75;

    public bool CreateTower(Tower_v2 tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(tower, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
    }
}
