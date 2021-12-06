using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerxd : MonoBehaviour
{
    private GameObject RocketmanAnimated;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        RocketmanAnimated = transform.GetChild(0).gameObject;
        animator = RocketmanAnimated.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RotateZ(float angle)
    {
        
        animator.SetFloat("RightLeft",Mathf.Lerp(animator.GetFloat("RightLeft"), 0.5f + angle,Time.deltaTime*10));
        
        //transform.Rotate(0, 0, angle);     
        

    }
}
