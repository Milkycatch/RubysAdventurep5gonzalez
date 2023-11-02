using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtColectable : MonoBehaviour
{
    void  OnTriggerEnter2D(Collider2D other)
    { 
        RubyController controller = other.GetComponent<RubyController>();
        if (controller != null)
        {
            controller.ChangeHealth(1);
            Destroy(gameObject);
        }
        Debug.Log("Object that entered  the tiggerr  is:" + other);
    }
}
