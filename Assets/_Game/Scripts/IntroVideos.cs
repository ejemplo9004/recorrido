using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroVideos : MonoBehaviour
{
    public GameObject[] objetos;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(12);
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
