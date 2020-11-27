using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPersonaje2 : MonoBehaviour
{
    public GameObject p2;
    void Awake()
    {
        p2.SetActive(false);
    }
    public void activarP2()
    {
        p2.SetActive(true);
    }
}
