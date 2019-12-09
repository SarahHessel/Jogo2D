using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance = null;

    public GameObject starParticles;
    public GameObject dieParticles;


    void Awake(){
    if(instance == null) {
        instance = this;
    }
}

    public void ShowStarParticles(GameObject obj) {
        GameObject particles = Instantiate(starParticles, obj.transform.position, Quaternion.identity);
        GameObject tape = GameObject.Find("Tape");
        particles.transform.SetParent(tape.transform);
    }

    public void ShowDieParticles(GameObject obj) {
        GameObject particles = Instantiate(dieParticles, obj.transform.position, Quaternion.identity);
        GameObject tape = GameObject.Find("Tape");
        particles.transform.SetParent(tape.transform);
    }
}
