using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Abrir()
    {
        anim.SetTrigger("Open");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            Abrir();
        }
    }
}
