using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float maximoX;
    [SerializeField]
    private float minimoX;
    [SerializeField]
    private float minimoY;
    [SerializeField]
    private float maximoY;

    public Transform player;

    void Start()
    {
        
    }

    void Update()
    {
        //transform.position = new Vector3(Mathf.Clamp(player.position.x, minimoX, maximoX), Mathf.Clamp(player.position.y, minimoY, maximoY), transform.position.z);
        if (player != null)
        {
            Vector3 vet = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            transform.position = vet;
        }
    }
}
