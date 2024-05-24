using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_v2 : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] float buildDelay = 1f;

    void Start()
    {
        StartCoroutine(Build());
    }

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

    IEnumerator Build()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);

            foreach (Transform granchild in child)
            {
                granchild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);

            yield return new WaitForSeconds(buildDelay);

            foreach (Transform granchild in child)
            {
                granchild.gameObject.SetActive(true);
            }
        }
    }
}
