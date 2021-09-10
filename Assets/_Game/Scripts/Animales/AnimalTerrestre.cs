using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalTerrestre : MonoBehaviour
{
    [Header("Checkpoints")]
    public bool         visualizarChecPoints;
    public Transform[]  checkpoints;
    public float        rangoCreacionCheckPoints;
    public float        rangoAceptarCheckpoint;
    [Header("Comportamiento")]
    public bool         visualizarComportamiento;
    public float        tiempoIdle;
    public float        rangoAlerta;
    public float        tiempoAlerta;
    public float        rangoEscapar;
    public float        velocidadNormal;
    public float        velocidadEscapar;
    [Header("Configuracion")]
    public Animator     animaciones;
    public NavMeshAgent agente;
    public int          estado;


    private int chpActual = 0;
    private float cuadradoRangoAceptarChp;

    private void Start()
    {
        cuadradoRangoAceptarChp = rangoAceptarCheckpoint * rangoAceptarCheckpoint;
        StartCoroutine(SerOEstar());
    }
    public IEnumerator SerOEstar()
    {
        while (true)
        {
            switch (estado)
            {
                case 0: // Idle
                    animaciones.SetInteger("estado", estado);
                    float f = Random.Range(0f, tiempoIdle);
                    yield return new WaitForSeconds(f);
                    if (VerificarAlerta())
                    {
                        CambiarEstado(2);
                    }
                    else
                    {
                        SiguienteCheckpoint();
                        CambiarEstado(1);
                    }
                    break;
                case 1: // Caminando
                    animaciones.SetInteger("estado", estado);
                    do
                    {
                        if (VerificarCercaniaChechPoint(chpActual))
                        {
                            CambiarEstado(0);
                        }
                        if (VerificarAlerta())
                        {
                            CambiarEstado(2);
                        }
                        yield return new WaitForSeconds(0.5f);
                    } while (estado == 1);
                    break;
                case 2: // Alerta
                    animaciones.SetInteger("estado", estado);
                    agente.SetDestination(transform.position);
                    yield return new WaitForSeconds(tiempoAlerta);
                    do
                    {
                        if (VerificarEscape())
                        {
                            CambiarEstado(3);
                        }
                        if (!VerificarAlerta())
                        {
                            CambiarEstado(0);
                        }
                        yield return new WaitForSeconds(0.5f);
                    } while (estado == 2);
                    break;
                case 3: // Escapando
                    animaciones.SetInteger("estado", estado);
                    float d = 0;
                    Collider[] cols = Physics.OverlapSphere(transform.position, rangoAlerta);
                    Transform jugador = null;
                    for (int i = 0; i < cols.Length; i++)
                    {
                        if (cols[i].CompareTag("Player"))
                        {
                            jugador = cols[i].transform;
                        }
                    }
                    if (jugador == null)
                    {
                        jugador = transform;
                    }
                    int chElegido = 0;
                    for (int i = 0; i < checkpoints.Length; i++)
                    {
                        float dista = (checkpoints[i].position - jugador.position).sqrMagnitude;
                        if (dista > d)
                        {
                            d = dista;
                            chElegido = i;
                        }
                    }
                    agente.SetDestination(checkpoints[chElegido].position);
                    yield return new WaitUntil(()=>VerificarCercaniaChechPoint(chElegido));
                    CambiarEstado(0);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void CambiarEstado(int nEstado)
    {
        estado = nEstado;
        if (estado == 1)
        {
            agente.speed = velocidadNormal;
        }
        else if(estado == 3)
        {
            agente.speed = velocidadEscapar;
        }
    }

    public bool VerificarCercaniaChechPoint(int cual)
    {
        return (transform.position - checkpoints[cual].position).sqrMagnitude < cuadradoRangoAceptarChp;
    }

    public bool VerificarAlerta()
    {
        bool r = false;
        Collider[] cols = Physics.OverlapSphere(transform.position, rangoAlerta);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].CompareTag("Player"))
            {
                r = true;
            }
        }
        return r;
    }
    public bool VerificarEscape()
    {
        bool r = false;
        Collider[] cols = Physics.OverlapSphere(transform.position, rangoEscapar);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].CompareTag("Player"))
            {
                r = true;
            }
        }
        return r;
    }


    void SiguienteCheckpoint()
    {
        chpActual = (chpActual + 1) % checkpoints.Length;
        agente.SetDestination(checkpoints[chpActual].position);
    }

    public void CrearChecPoints()
    {
        GameObject pChecks = GameObject.Find("chp - " + gameObject.name);
        if (pChecks == null)
        {
            pChecks = new GameObject("chp - " + gameObject.name);
            pChecks.transform.parent = transform.parent;
        }
        for (int i = 0; i < checkpoints.Length; i++)
        {
            if (checkpoints[i]!=null)
            {
                DestroyImmediate(checkpoints[i].gameObject);
            }
            GameObject go = new GameObject("Checkpoint " + gameObject.name + " " + i);
            go.transform.parent = pChecks.transform;
            Vector3 npos = transform.position + new Vector3(Random.Range(-rangoCreacionCheckPoints, rangoCreacionCheckPoints), 1, Random.Range(-rangoCreacionCheckPoints, rangoCreacionCheckPoints));
            go.transform.position = npos;
            checkpoints[i] = go.transform;
        }
        AplanarCheckpoints();
    }

    public void AplanarCheckpoints()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            RaycastHit hit = new RaycastHit();
            Vector3 npos = checkpoints[i].position + Vector3.up * 4;
            if (Physics.Raycast(npos, Vector3.down, out hit))
            {
                checkpoints[i].position = hit.point;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (visualizarChecPoints)
        {
            Gizmos.color = Color.red;
            for (int i = 0; i < checkpoints.Length; i++)
            {
                Gizmos.DrawSphere(checkpoints[i].position, 0.3f);
            }
            Gizmos.DrawWireSphere(transform.position, rangoAceptarCheckpoint);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, rangoCreacionCheckPoints);
        }
        if (visualizarComportamiento)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, rangoAlerta);
            Gizmos.color = new Color(1f, 0.5f, 0.1f);
            Gizmos.DrawWireSphere(transform.position, rangoEscapar);
        }
    }

}
