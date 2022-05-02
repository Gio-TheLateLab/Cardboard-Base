using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceActivate : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Activate()
    {
        animator.SetTrigger("Activate");
    }
}
