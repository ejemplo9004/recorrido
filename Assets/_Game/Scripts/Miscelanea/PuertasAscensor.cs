using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasAscensor : MonoBehaviour
{
    public static PuertasAscensor singleton;
    public Animator animAscensor;
    public bool abirto;
    public GameObject botonera;


    private void Awake()
    {
        singleton = this;
    }
    
    public void Abrir()
    {
        abirto = true;
        animAscensor.SetBool("abierta", abirto);
        botonera.SetActive(abirto);
    }

    public void Cerrar()
    {
        abirto = false;
        animAscensor.SetBool("abierta", abirto);
        botonera.SetActive(abirto);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Abrir();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cerrar();
        }
    }
}
