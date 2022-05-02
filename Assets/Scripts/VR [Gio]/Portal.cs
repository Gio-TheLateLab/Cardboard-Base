using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int lvl;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(lvl);   
    }
}
