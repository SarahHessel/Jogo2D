using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    Animator anim;
    Collider2D col;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        col = gameObject.GetComponent<Collider2D>();
    }

    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
            anim.SetTrigger("Coletando");
            Destroy(gameObject, 0.667f);
        }
    }
}
