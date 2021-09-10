using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    public Transform camara;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Ray rayo = new Ray(camara.position, camara.forward);
        RaycastHit hit;
        if (Physics.Raycast(rayo, out hit, 4))
        {
            if (hit.transform.CompareTag("Arbol"))
            {
                Arbol a = hit.transform.gameObject.GetComponent<Arbol>();
                UIArboles.singleton.MostrarNombre(a.nombreComun, a.nombreCientifico);
            }else
            {
                if (UIArboles.singleton.Mostrando)
                {
                    UIArboles.singleton.OcultarNombre();
                }
            }
        }
        else
        {
            if (UIArboles.singleton.Mostrando)
            {
                UIArboles.singleton.OcultarNombre();
            }
        }

    }
}
