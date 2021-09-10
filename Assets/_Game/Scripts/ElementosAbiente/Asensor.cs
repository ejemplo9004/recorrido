using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asensor : MonoBehaviour
{
    public float[] alturas;
    public int indice;
    public float segundos;

    public float a, b, t;
    Vector3 posicionInicial;

    void Start()
    {
        a = alturas[0];
        b = alturas[0];
        t = 1;
        posicionInicial = transform.position;
        ActualizarPosicion();
    }

    
    void Update()
    {
        if (t < 1)
        {
            t += Time.deltaTime / segundos;
            t = Mathf.Clamp01(t);
            if (t==1)
            {
                PuertasAscensor.singleton.Abrir();
            }
            ActualizarPosicion();
        }
    }

    private void ActualizarPosicion()
    {
        posicionInicial.y = Mathf.Lerp(a, b, t);
        transform.position = posicionInicial;
    }

    [ContextMenu("Siguiente posicion")]
    public void SiguientePosicion()
    {
        indice++;
        indice = (int)Mathf.Clamp(indice, 0, alturas.Length - 1);
        a = b;
        b = alturas[indice];
        PuertasAscensor.singleton.Cerrar();
        Invoke("Poner0", 1);
    }

    public void Poner0()
    {
        t = 0;
    }

    [ContextMenu("Anterior posicion")]
    public void AnteriorPosicion()
    {
        indice--;
        indice = (int)Mathf.Clamp(indice, 0, alturas.Length);
        a = b;
        b = alturas[indice];
        PuertasAscensor.singleton.Cerrar();
        Invoke("Poner0", 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
