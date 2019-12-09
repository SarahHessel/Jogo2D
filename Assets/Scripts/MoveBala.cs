using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBala : MonoBehaviour
{
    private float vel = 10;


    public float Vel
    {
        get { return vel; }
        set { vel = value; }
    }
    void Move()
    {
        Vector3 aux = transform.position;
        aux.x += vel * Time.deltaTime;
        transform.position = aux;
    }
    public void Inicializar(Vector2 _direcao)
    {
        _direcao = _direcao;
    }
  
    void Start()
    {
        
    }

   
    void Update()
    {
        Move();
    }
    public GameObject Projetil;



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            Destroy(gameObject);


        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Coletaveis"))
        {
            Destroy(gameObject);


        }
    }
}
