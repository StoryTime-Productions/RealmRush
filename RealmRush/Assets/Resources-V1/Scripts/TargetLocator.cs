using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    [SerializeField] ParticleSystem projectileParticles;

    [SerializeField] float rotationSpeed = 5.0f;
    [SerializeField] float range = 15f;


    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        if (targetDistance < range)
        {
            Attack(true);
        }

        else
        {
            Attack(false);
        }

        Vector3 direction = target.position - weapon.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        weapon.rotation = Quaternion.Lerp(weapon.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        Transform closestTarget = null;

        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;

                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;

        emissionModule.enabled = isActive;
    }
}
