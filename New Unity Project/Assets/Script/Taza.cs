using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taza : MonoBehaviour
{
    Animator anim;

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("Taza", GM.gm.personajeActual);
    }
}
