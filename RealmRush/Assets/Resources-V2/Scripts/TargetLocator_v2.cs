using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator_v2 : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    [SerializeField] float rotationSpeed = 5.0f;

    Transform target;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy_v2[] enemies = FindObjectsOfType<Enemy_v2>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy_v2 enemy in enemies)
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

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
