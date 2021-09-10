using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ver360 : Informacion
{
    public int cual;
    // Update is called once per frame
    void OnMouseDown()
    {
        if (!MouseEnUI())
        {
            Rotar360.singleton.CambiarActivo(true, cual);
        }
    }
}
