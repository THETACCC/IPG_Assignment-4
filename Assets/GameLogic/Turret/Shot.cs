using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float speed;

    Rigidbody rb;
    Vector3 velocity;

    void Awake()
    {
        TryGetComponent(out rb);
    }

    void Start()
    {

        velocity = transform.up * speed;
        Destroy(gameObject, 15f);
    }

    void FixedUpdate()
    {
        var displacement = velocity * Time.deltaTime;
        rb.MovePosition(rb.position + displacement);



    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            ZombieWalk zombie = other.gameObject.GetComponent<ZombieWalk>();    
            if (zombie != null )
            {
                zombie.anim.SetTrigger("isHit");

                zombie.Health -= 20;


                Destroy(gameObject);
            }
        }
        Destroy(gameObject);
    }
}
