using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesPersonaje1 : MonoBehaviour
{
    public GameObject p2;
    public Transform personaje2;
    private float speed = 400f;
    float dist1;
    public Animator anim1;
    public Animator anim2;
    void Start()
    {
        personaje2 = GameObject.FindGameObjectWithTag("Personaje2").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(p2.activeSelf == true)
        {
            dist1 = Vector3.Distance(personaje2.transform.position, transform.position);

            StartCoroutine(animacionesPelea());
        }
    }
    IEnumerator animacionesPelea()
    {
        //QUE LO PERSIGA Y HAGA LA ANIMACION DE CORRER
        if (dist1 > 200f)
        {
            transform.position = Vector3.MoveTowards(transform.position, personaje2.position, speed * Time.deltaTime);
            transform.LookAt(personaje2);
            anim1.SetBool("isIdle", false);
            anim1.SetBool("isRunning", true);
        }

        //COMIENZA LA PELEA
        if (dist1 <= 200f)
        {
            //ANIMACIÓN BOXING A
            anim1.SetBool("isBoxingA", true);
            anim1.SetBool("isRunning", false);
            yield return new WaitForSeconds(2.133f);

            //TIRAR PATADA
            anim1.SetBool("isKickingA", true);
            anim1.SetBool("isBoxingA", false);
            yield return new WaitForSeconds(1.333f);

            //BLOQUEAR PATADA
            anim1.SetBool("bloquearPatada", true);
            anim1.SetBool("isKickingA", false);
            yield return new WaitForSeconds(2.000f);

            //IDLE RAPIDO
            anim1.SetBool("bloquearPatada", false);
            anim1.SetBool("isIdle", true);
            yield return new WaitForSeconds(0.467f);

            //ANIMACION FIST FIGHT B
            anim1.SetBool("isIdle", false);
            anim1.SetBool("FistFightB", true);
            yield return new WaitForSeconds(3.900f);

            anim1.enabled = false;
            yield return new WaitForSeconds(1f);
        }
      
    }
}
