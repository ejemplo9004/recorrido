using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OrbitarSF : MonoBehaviour
{
    public Vector3 angulos;
    public float velocidad;
    public float velRotacion;
    public Transform pivote;
    float tiempoInicio;
    public Transform camara;

    public Joystick joystick1;
    public EventSystem eventsys;

    void Start()
    {

        Angular();
    }

    void Update()
    {
        transform.Translate((Vector3.forward*joystick1.Vertical + Vector3.right * joystick1.Horizontal) * Time.deltaTime*velocidad );
        if (Informacion.MouseEnUI() || joystick1.Vertical!=0 || joystick1.Horizontal!=0)
        {
            return;
        }
        if (eventsys.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            tiempoInicio = Time.time;
        }
        if ((Input.touchCount>0 || Input.GetMouseButton(0)) && Time.time > (tiempoInicio+0.12f))
        {
            angulos += (Vector3.up * Input.GetAxis("Mouse X") + Vector3.left*Input.GetAxis("Mouse Y")) * velRotacion * Time.deltaTime;
            angulos.x = Mathf.Clamp(angulos.x, -40f, 20f);
            transform.eulerAngles = Vector3.up * angulos.y;
            pivote.localEulerAngles = Vector3.right * angulos.x;
            Angular();
        }
    }

    void Angular()
    {
        for (int i = 0; i < GlobosControl.singleton.globos.Count; i++)
        {
            GlobosControl.singleton.globos[i].transform.LookAt(camara);
        }

        Vector3 rot = Quaternion.Euler(0, 180, 0)*Vector3.one;
    }
}
