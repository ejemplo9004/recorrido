using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ver360 : Informacion
{
    public int cual;
    float tiempoClic;
    // Update is called once per frame
    void OnMouseUp()
    {
        if (!MouseEnUI())
        {
            if (Time.time - tiempoClic < 0.3f) Rotar360.singleton.CambiarActivo(true, cual);
            tiempoClic = Time.time;
        }
    }
}
