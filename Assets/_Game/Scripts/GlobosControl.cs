using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobosControl : MonoBehaviour
{
    public static GlobosControl singleton;
    public List<Informacion> globos = new List<Informacion>();
    public Transform tGlobos;
    public Vector3 pos0, pos1;


    private void Awake()
    {
        singleton = this;
    }

    public void CambiarModo(int cual)
    {
        
        switch (cual)
        {
            case 0:
                tGlobos.position = pos0;
                Reescalar(Vector3.one);
                break;
            case 1:
                tGlobos.position = pos1;
                Reescalar(Vector3.one * 10);
                break;
            default:
                break;
        }
        
    }

    public void Modo0() => CambiarModo(0);
    public void Modo1() => CambiarModo(1);

    public void Reescalar(Vector3 cuanto)
    {
        for (int i = 0; i < globos.Count; i++)
        {
            globos[i].gameObject.transform.localScale = cuanto;
        }
    }
    void Start()
    {
        ControlModos.singleton.modo0 += Modo0;
        ControlModos.singleton.modo1 += Modo1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
