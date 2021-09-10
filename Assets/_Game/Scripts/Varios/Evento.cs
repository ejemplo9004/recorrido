using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Evento : MonoBehaviour
{
    public UnityEvent eventoInmediato;
    public UnityEvent eventoInmediato2;
    public UnityEvent eventoInmediato3;
    public float tiempoDelay;
    public UnityEvent eventoRetardado;

    public void InvocarEvento()
    {
        eventoInmediato.Invoke();
    }
    public void InvocarEvento2()
    {
        print("Entro al evento 2");
        eventoInmediato2.Invoke();
    }
    public void InvocarEvento3()
    {
        print("Entro al evento 3");
        eventoInmediato3.Invoke();
    }


    public void InvocarEventoRetardado()
    {
        Invoke("Evento2", tiempoDelay);
    }

    void Evento2()
    {
        eventoRetardado.Invoke();
    }
}
