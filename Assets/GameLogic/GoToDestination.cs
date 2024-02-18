using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class GoToDestination : MonoBehaviour
{
    [SerializeField]
    Transform MovePosTransform;
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {

            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = MovePosTransform.position;


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
        float distanceToTarget = Vector3.Distance(transform.position, closestEnemy.transform.position);
        if (distanceToTarget <= 1.5)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }



}
