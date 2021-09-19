using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tapabocas : MonoBehaviour
{
    public static bool tieneTapabocas = true;
    public GameObject tapa;
    void FixedUpdate()
    {
		if (tapa!=null)
		{
            tapa.SetActive(tieneTapabocas);
		}
    }

    public void CambiarEstado(bool nEstado)
	{
        tieneTapabocas = nEstado;
	}
}
