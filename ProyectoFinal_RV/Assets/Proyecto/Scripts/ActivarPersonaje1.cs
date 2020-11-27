using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPersonaje1 : MonoBehaviour
{
    public GameObject p1;
    void Awake()
    {
        p1.SetActive(false);
    }
    public void activarP1()
    {
        p1.SetActive(true);
    }
}
