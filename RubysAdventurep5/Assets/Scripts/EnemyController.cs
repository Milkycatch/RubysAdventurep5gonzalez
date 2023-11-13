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
    
    Rigidbody2D rigidbody2;

    Animator animator;

    float timer;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        timer = changeTime;
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
     void FixedUpdate()
    {
        Vector2   position = rigidbody2.position;
        if (vertical)
        {
            animator.SetFloat("Move x", 0);
            animator.SetFloat("Move y", direction);
            position.y = position.y + Time.deltaTime * speed *direction;
        }
        else
        {
            animator.SetFloat("Move x", direction);
            animator.SetFloat("Move y", 0);
            position.x = position.x + Time.deltaTime *speed  *  direction;
        }
       

        rigidbody2.MovePosition(position);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();
        if (player != null) 
        {
            player.ChangeHealth(-1);
        }
       
    }

}
