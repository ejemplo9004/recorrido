using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguidor : MonoBehaviour
{
    public Transform objetivo;

    void Update()
    {
        transform.position = objetivo.position;
    }
}
