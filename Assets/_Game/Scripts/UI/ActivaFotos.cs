using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaFotos : MonoBehaviour
{
    public GameObject mostrar;
    public float tiempoMostrar;
    void Start()
    {
        Invoke("Manifiestese", tiempoMostrar);
    }

    // Update is called once per frame
    void Manifiestese()
    {
        mostrar.SetActive(true);
    }
}
