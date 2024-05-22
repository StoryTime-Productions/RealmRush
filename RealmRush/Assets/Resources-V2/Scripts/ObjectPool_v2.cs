using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_v2 : MonoBehaviour
{
    [SerializeField] GameObject enemyGameObject;
    [SerializeField][Range(0, 50)] int poolSize = 5;
    [SerializeField][Range(0.1f, 30f)] float spawnTimer = 1f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void EnableObjectInPool()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy) { obj.SetActive(true); return; }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();

            yield return new WaitForSeconds(spawnTimer);
        }
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyGameObject, transform);

            pool[i].SetActive(false);
        }
    }
}
