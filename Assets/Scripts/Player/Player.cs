using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator anim;
    private bool eLadoDireito;
    private bool facingRight = true;
    float horizontal;
    private bool acao;
    public float speed = 2.4f;
    public LayerMask Platform;
    public Vector3 pontoColisaoPiso = Vector2.zero;
    public bool estaNoChao;
    public float raio;
    public Color debugcorColisao = Color.red;
    public float forcaPulo = 200f;
     
    [SerializeField]
    private float velocidade = 0;

    public GameObject Projetil;

    public float velocity = 100f;

    bool wait = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        eLadoDireito = transform.localScale.x > 0;
    }

    void FixedUpdate()
    {
        Movimentar();
        EstaNoChao();
        ControlarEntradas();
    }
    void Update()
    {
    }
    private void EstaNoChao()
    {
        var pontoPosicao = pontoColisaoPiso;
        pontoPosicao.x += transform.position.x;
        pontoPosicao.y += transform.position.y;
        estaNoChao = Physics2D.OverlapCircle(pontoPosicao, raio, Platform);
    }
    private void Pular()
    {
        if(estaNoChao && rb2D.velocity.y <= 0)
        {
            rb2D.AddForce(new Vector2(0, forcaPulo));
        }
    }
    private void ControlarEntradas()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Pular();
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            anim.SetTrigger("Atirar2");
            rb2D.velocity = Vector2.zero;
            Quaternion rotacao = (facingRight) ? Quaternion.identity : Quaternion.Euler(Vector3.up * 180);
            GameObject projectile = Instantiate(Projetil, transform.position, rotacao);
            Vector2 vet = (facingRight) ? Vector2.right : Vector2.left;
            projectile.GetComponent<Rigidbody2D>().velocity = vet * velocity;
        }

        else if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            anim.SetTrigger("Atirar2");
            rb2D.velocity = Vector2.zero;
            Quaternion rotacao = (facingRight) ? Quaternion.identity : Quaternion.Euler(Vector3.up * 180);
            GameObject projectile = Instantiate(Projetil, transform.position, rotacao);
            Vector2 vet = (facingRight) ? Vector2.right : Vector2.left;
            projectile.GetComponent<Rigidbody2D>().velocity = vet * velocity;
        }

    }
    public void Atirar() 
    {
        GameObject projectile = Instantiate(Projetil, transform.position, Quaternion.identity);
        Debug.Log(facingRight);
        if (facingRight)
        {
            projectile.GetComponent<Rigidbody2D>().velocity = Vector2.right * velocity;
        }
        else
        {
            projectile.GetComponent<Rigidbody2D>().velocity = Vector2.left * velocity;
        }
    }

    private void Movimentar()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Atirar"))
        {
            rb2D.velocity = new Vector2(horizontal * velocidade, rb2D.velocity.y);
        }
        float horizontalForceButton = Input.GetAxis("Horizontal");
        anim.SetFloat("Correr", Mathf.Abs(horizontalForceButton));
        rb2D.velocity = new Vector2(horizontalForceButton * speed, rb2D.velocity.y);
       

        if (horizontalForceButton < 0 && facingRight) Flip();
        if (horizontalForceButton > 0 && !facingRight) Flip();

        void Flip()
           {
                facingRight = !facingRight;
                transform.Rotate(Vector3.up * 180);
           }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = debugcorColisao;
        var pontoPosicao = pontoColisaoPiso;
        pontoPosicao.x += transform.position.x;
        pontoPosicao.y += transform.position.y;
        Gizmos.DrawWireSphere(pontoPosicao, raio);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Forb"))
        {
            KillPlayer();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            if (!wait) { 
                SFXManager.instance.ShowDieParticles(other.gameObject);
                Destroy(other.gameObject);
                HurtPlayer();
            }
        }
    }

    void KillPlayer()
    {
        SFXManager.instance.ShowDieParticles(gameObject);
        Destroy(gameObject);
    }



    void HurtPlayer()
    {
        LevelManager.instance.DecrementLifeCount();
        ChangeAlpha(0.5f);
        if (LevelManager.instance.GetLifeCount() == 0)
        {
            KillPlayer();
        }
        else
        {
            //AudioManager.instance.PlaySoundHurt(gameObject); // OPCIONAL: TOCAR UM SOM DE MACHUCADO       
            wait = true;
            StartCoroutine(DisableWait(2.0f));
        }
    }

    private IEnumerator DisableWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ChangeAlpha(1f);
        wait = false;
    }

    private void ChangeAlpha(float alpha)
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = alpha;
        GetComponent<SpriteRenderer>().color = tmp;
    }
}
