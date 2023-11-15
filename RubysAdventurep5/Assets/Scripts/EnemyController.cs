using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;

    public ParticleSystem smokEffect;
    
    Rigidbody2D rigidbody2d;

    bool broken = true;

    Animator animator;

    float timer;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!broken)
        {
            return;
        }
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
     void FixedUpdate()
    {
        if (!broken)
        {
            return;
        }
        Vector2   position = rigidbody2d.position;
        if (vertical)
        {
            animator.SetFloat("Move x", 0);
            animator.SetFloat("Move y", direction);
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            animator.SetFloat("Move x", direction);
            animator.SetFloat("Move y", 0);
            position.x = position.x + Time.deltaTime *speed  *  direction;
        }
       

        rigidbody2d.MovePosition(position);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();
        if (player != null) 
        {
            player.ChangeHealth(-1);
        }
       
    }
    public void Fix()
    {
        broken = false;
            rigidbody2d.simulated = false;
        animator.SetTrigger("Fixed");
        smokEffect.Stop();
    }

}

