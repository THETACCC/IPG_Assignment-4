using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ZombieWalk : MonoBehaviour
{
    [SerializeField]
    Transform MovePosTransform;
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    public Animator anim;

    private bool isDead = false;
    public int Health = 100;

    void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }


    private void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Goal");
        if (player != null)
        {
            MovePosTransform = player.transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = MovePosTransform.position;
        if (Health <= 0)
        {
            if (!isDead)
            {
                anim.SetTrigger("isDead");
                isDead= true;
            }

        }
    }

    public void AnimationWalk()
    {
        anim.SetBool("isHit", false);
    }

    public void DestorySelf()
    {
        Destroy(gameObject);
    }




}
