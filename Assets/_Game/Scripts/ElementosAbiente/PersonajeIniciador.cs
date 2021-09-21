using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeIniciador : MonoBehaviour
{
    public GameObject camara;
    // Start is called before the first frame update
    void Start()
    {
        ControlModos.singleton.personaje = gameObject;
        GlobosControl.singleton.camaraActiva = camara.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
