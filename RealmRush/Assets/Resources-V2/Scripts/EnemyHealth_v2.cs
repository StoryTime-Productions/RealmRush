using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy_v2))]
public class EnemyHealth_v2 : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;
    int currentHealthPoints = 0;

    Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    {
        currentHealthPoints = maxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHealthPoints--;

        if (currentHealthPoints <= 0)
        {
            maxHitPoints += difficultyRamp;

            gameObject.SetActive(false);

            enemy.RewardGold();
        }
    }
}
