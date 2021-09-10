using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausador : MonoBehaviour
{
    public GameObject objetoActivaPause;
    public float tiempoPause;

    void Update()
    {
        if (objetoActivaPause.activeSelf && Time.timeScale>0.5f)
        {
            Time.timeScale = tiempoPause;
        }
        else if (!objetoActivaPause.activeSelf && Time.timeScale < 0.5f)
        {
            Time.timeScale = 1;
        }
    }
}
