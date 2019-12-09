using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaSpaw : MonoBehaviour
{
    GameObject parent;
    public GameObject Projetil;

    public GameObject posicaoProjetil;

    public float waitTime = 3f;

    public float projectileSpeed = 3f;

    public Vector3[] directions;

    void Start()

    {
        parent = GameObject.Find("Tape");

        StartCoroutine(Spawn());

    }

    IEnumerator Spawn()
    {

        while (true)
        {

            yield return new WaitForSeconds(waitTime);

            for (int i = 0; i < directions.Length; i++)
            {
                GameObject projectile = Instantiate(Projetil, posicaoProjetil.transform.position, Quaternion.identity);
                projectile.transform.SetParent(parent.transform);



                projectile.GetComponent<Rigidbody2D>().velocity = projectileSpeed * directions[i];

            }

        }

    }

}
