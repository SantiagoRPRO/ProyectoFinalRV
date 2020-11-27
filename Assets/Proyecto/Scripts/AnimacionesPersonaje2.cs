using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesPersonaje2 : MonoBehaviour
{
    public GameObject p1;
    public Transform personaje1;
    private float speed = 400f;
    public Animator anim2;
    public Animator anim1;
    void Start()
    {
        personaje1 = GameObject.FindGameObjectWithTag("Personaje1").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(p1.activeSelf == true)
        {
            StartCoroutine(animacionesPelea());
        }
    }
    IEnumerator animacionesPelea()
    {
        //QUE LO PERSIGA Y HAGA LA ANIMACION DE CORRER
        if (anim1.GetBool("isIdle") == false && anim1.GetBool("isRunning") == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, personaje1.position, speed * Time.deltaTime);
            transform.LookAt(personaje1);
            anim2.SetBool("Idle", false);
            anim2.SetBool("Run", true);
        }

        //QUE HAGA LA ANIMACION DE ESQUIVAR DERECHA
        if (anim1.GetBool("isRunning") == false && anim1.GetBool("isBoxingA") == true)
        {
            anim2.SetBool("EsquivarDerecha", true);
            anim2.SetBool("Run", false);
            yield return new WaitForSeconds(1.433f);

            //IDLE RAPIDO
            anim2.SetBool("Idle", true);
            anim2.SetBool("EsquivarDerecha", false);
            yield return new WaitForSeconds(0.5f);

            //BLOQUEAR PATADA
            anim2.SetBool("Idle", false);
            anim2.SetBool("bloquearPatada", true);
            yield return new WaitForSeconds(2.000f);

            //TIRAR PATADA VOLADORA
            anim2.SetBool("bloquearPatada", false);
            anim2.SetBool("patadaVoladora", true);
            yield return new WaitForSeconds(2.100f);

            //FIST FIGHT A
            anim2.SetBool("patadaVoladora", false);
            anim2.SetBool("FistFightA", true);
            yield return new WaitForSeconds(3.900f);

            anim2.enabled = false;
            yield return new WaitForSeconds(1f);
        }
    }
}
