using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerxd : MonoBehaviour
{
    private GameObject RocketmanAnimated;
    private Animator animator;

    public static float speed;
    public static float speedRL;

    public static float distanceForward=700;

    // Start is called before the first frame update
    void Start()
    {
        RocketmanAnimated = GameObject.FindGameObjectWithTag("RocketmanAnimated");
        animator = RocketmanAnimated.GetComponent<Animator>();
        speed = 60;
        speedRL = 40;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RotateZ(float angle)
    {

        angle = Mathf.Clamp(angle, -0.5f, 0.5f);

        animator.SetFloat("RightLeft",Mathf.Lerp(animator.GetFloat("RightLeft"), 0.5f + angle,Time.deltaTime*10));

        MoveForwardRightLeft(angle);

    }



    // movement according rotateZ
    public void MoveForwardRightLeft(float angle)
    {
        distanceForward += Time.deltaTime * speed;

        transform.Translate(Time.deltaTime * angle*speedRL,0, Time.deltaTime*speed);

    }

    /*
    private void Constrict2Value(out float angle)
    {
       angle =  Mathf.Clamp(angle, -0.5f, 0.5f);
        
    }
    */

    


}
