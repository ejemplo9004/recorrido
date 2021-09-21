using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicMoverPersonaje : MonoBehaviour
{
    public Transform jugador;
    public GameObject prefabJugador;
    public float tiempoClic;
    public Camera camara;
    public static ClicMoverPersonaje singleton;


    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time-tiempoClic < 0.5f)
            {
                MoverAlClic();

            }
            else
            {
                tiempoClic = Time.time;
            }
        }
    }

    public void MoverAlClic()
    {
        Ray ray = camara.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitdist;

        if (Physics.Raycast(ray, out hitdist))
        {
            if (hitdist.transform.CompareTag("Piso"))
            {
                Vector3 targetPoint = hitdist.point + Vector3.up;
                //jugador.position = targetPoint;
                ReinstanciarPersonaje(targetPoint);
            }

        }
        ControlModos.singleton.CambiarModo(0);
    }

    public void ReinstanciarPersonaje(Vector3 targetPoint)
	{
        Destroy(jugador.gameObject);
        GameObject go = Instantiate(prefabJugador, targetPoint, Quaternion.identity);
        jugador = go.transform;
        ControlModos.singleton.elementosM0[0] = jugador.gameObject;
    }
}
