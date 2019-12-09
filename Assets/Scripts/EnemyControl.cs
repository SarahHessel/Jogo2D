using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private float velMove = 2f;
    private Rigidbody2D rb;
    private bool moveE;

    [SerializeField]
    private Transform limite;
    public LayerMask layer;


    void Start()
    {
        // Ignorar colisão com o outro objecto; 10,10 são as layers dos objetos Enemy.
        Physics2D.IgnoreLayerCollision(10, 10);
        rb = GetComponent<Rigidbody2D>();
        moveE = true;
    }
    void Update()
    {
        if (moveE)
        {
            rb.velocity = new Vector2(-velMove, rb.velocity.y);
        }
        else 
        {
            rb.velocity = new Vector2(velMove, rb.velocity.y);
        }
        VerificaCol();
    }
    void VerificaCol()
    {
		
		/*
        if(!Physics2D.Raycast(limite.position, Vector2.down, 0.1f))
        {
            Flip();
        }*/
    }

    void Flip()
    {
        moveE = !moveE;
        Vector3 temp = transform.localScale;

        if (moveE)
        {
            temp.x = Mathf.Abs(temp.x);
        }
        else
        {
            temp.x = -Mathf.Abs(temp.x);
        }

        transform.localScale = temp;
    }
	
	
	void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Obstaculo")) {
			Flip();
        }
        else if (other.gameObject.CompareTag("Bala"))
        {
            Destroy(gameObject);
        }
    }

}
