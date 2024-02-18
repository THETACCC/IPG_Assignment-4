using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Gun gun;
    public MountingPoint[] mountPoints;
    public Transform target;
    public float maxRange = 100f;


    void Update()
    {
        // Always search for the closest enemy to update the target
        UpdateTarget();


        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget <= maxRange)
            {
                // Aim and fire 
                AimAndFire();
            }
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyAim");
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }


        target = closestEnemy != null ? closestEnemy.transform : null;
    }

    void AimAndFire()
    {
        var aimed = true;
        foreach (var mountPoint in mountPoints)
        {
            if (!mountPoint.Aim(target.position))
            {
                aimed = false;
                break; 
            }
        }

        if (aimed)
        {
            gun.Fire();
        }
    }
}
