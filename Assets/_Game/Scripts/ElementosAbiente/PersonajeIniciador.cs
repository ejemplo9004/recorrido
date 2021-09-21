using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeIniciador : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ControlModos.singleton.personaje = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
