using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimalInfo : MonoBehaviour
{
    [HideInInspector]
    public string codigo;
    public string titulo;
    public string texto;
    public Sprite imagen;
    float tiempoClic;

    //Saber si hay un elemento UI en el puntero
    public static bool MouseEnUI()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return (results.Count > 0);
    }
    private void OnMouseUp()
    {
        if (!MouseEnUI())
        {
            if (Time.time - tiempoClic < 0.3f)
            {
                InfoControl.singleton.Activar(texto, codigo, titulo, imagen);
            }
            tiempoClic = Time.time;
        }
    }
}
