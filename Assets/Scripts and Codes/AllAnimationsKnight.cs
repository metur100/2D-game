using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllAnimationsKnight : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        while (true)
        animator.SetBool("AllAnimations", true);
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetBool("AllAnimations", true);
    }
}
