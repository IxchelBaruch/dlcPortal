using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public float velocidadGiro;
    public int dano;
    public float cadencia;
    public Transform rayPos;
    public Transform laserPos;
    public Transform aimPos;

    bool disparar;
    bool puedeComezar;

    float contador;

    Animator anim;

    Transform originalT;

    void Start()
    {
        anim = GetComponent<Animator>();
        puedeComezar = true;
        contador = cadencia;
        originalT = GetComponent<Transform>();
    }

    void Update()
    {
        print(transform.localEulerAngles);
        if((transform.localEulerAngles.x < 300f && transform.localEulerAngles.x > 60f) || (transform.localEulerAngles.z < 300f && transform.localEulerAngles.z > 60f))
        {
            Salir();
            SoundManager.instance.Play("Morir");
            this.enabled = false;
            laserPos.gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.Play("Activada");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            RaycastHit hit;
            rayPos.transform.LookAt(other.transform);
            //var targetRotationRay = Quaternion.LookRotation(other.transform.position - rayPos.position);

            //rayPos.localRotation = Quaternion.Slerp(rayPos.localRotation, targetRotationRay, velocidadGiro * Time.deltaTime);
            rayPos.transform.localRotation = Quaternion.Euler(0.0f, rayPos.transform.localEulerAngles.y, 0.0f);
            Debug.DrawRay(rayPos.position, rayPos.transform.forward * 1000, Color.green);
            

            if (Physics.Raycast(rayPos.position, rayPos.transform.forward, out hit))
            {
                if(hit.transform.CompareTag("Player"))
                {
                    if (puedeComezar)
                    {
                        anim.SetTrigger("ComenzarAtaque");
                        anim.SetBool("ModoAtaque", true);
                        puedeComezar = false;
                    }

                    if (disparar)
                    {
                        if (contador >= cadencia)
                        {
                            hit.transform.gameObject.GetComponent<PlayerHealth>().RecibirDano(dano);
                            contador = 0.0f;
                        }

                        /*var targetRotationLaser = Quaternion.LookRotation(hit.transform.position - laserPos.position);
                        var targetRotationAim = Quaternion.LookRotation(hit.transform.position - aimPos.position);

                        laserPos.rotation = Quaternion.Slerp(laserPos.rotation, targetRotationLaser, velocidadGiro * Time.deltaTime);
                        aimPos.rotation = Quaternion.Slerp(aimPos.rotation, targetRotationAim, velocidadGiro * Time.deltaTime);*/

                        laserPos.transform.LookAt(hit.transform);
                        laserPos.localRotation = Quaternion.Euler(0.0f, laserPos.localEulerAngles.y, laserPos.localEulerAngles.z); //Bloquear rotación X
                        aimPos.transform.LookAt(hit.transform);
                        aimPos.localRotation = Quaternion.Euler(0.0f, aimPos.localEulerAngles.y, aimPos.localEulerAngles.z); //Bloquear rotación X

                        contador += Time.deltaTime;
                    }
                }
                else if(!hit.transform.CompareTag("Player") && !puedeComezar)
                {
                    Salir();
                }
            }
                
        }
    }

    public void ActivarDisparo()
    {
        disparar = true;
    }

    public void DesactivarDisparo()
    {
        disparar = false;
    }

    public void PuedeComenzar()
    {
        puedeComezar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.Play("Cerrar");

            //Devolver las cosas a su posicion original (0, 0, 0)
            DesactivarDisparo();
            LeanTween.rotate(rayPos.gameObject, originalT.rotation.eulerAngles, 1.0f);
            LeanTween.rotate(laserPos.gameObject, originalT.rotation.eulerAngles, 1.0f);
            LeanTween.rotate(aimPos.gameObject, originalT.rotation.eulerAngles, 1.0f).setOnComplete(Descanso);
        }
    }

    void Salir()
    {
        //Devolver las cosas a su posicion original (0, 0, 0)
        DesactivarDisparo();
        LeanTween.rotate(rayPos.gameObject, originalT.rotation.eulerAngles, 1.0f);
        LeanTween.rotate(laserPos.gameObject, originalT.rotation.eulerAngles, 1.0f);
        LeanTween.rotate(aimPos.gameObject, originalT.rotation.eulerAngles, 1.0f).setOnComplete(Descanso);
    }

    void Descanso()
    {
        anim.SetTrigger("Descanso");
        anim.SetBool("ModoAtaque", false);
    }
}
