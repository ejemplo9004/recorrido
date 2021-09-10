using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clic : MonoBehaviour
{
    public bool sobreSiMismo;
    public UnityEvent evento;

    void Update()
    {
        if (!sobreSiMismo && Input.GetMouseButtonDown(0))
        {
            evento.Invoke();
        }
    }

    private void OnMouseDown()
    {
        if (sobreSiMismo )
        {
            evento.Invoke();
        }
    }
}
