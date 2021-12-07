using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllerxd : MonoBehaviour
{

     
    private Playerxd playerxd;// Playerxd component of Player object  in the scene 
    
    

    private float XTotalPos;

    // Start is called before the first frame update
    void Start()
    {
        
        playerxd = GameObject.Find("Player").GetComponent<Playerxd>();



        
    }

    
    
    
    // Update is called once per frame
    void Update()
    {

        InputController();

        
    }


    private void InputController()
    {

        XTotalPos = 0;

        for(int i=0;i<Input.touchCount;i++)
        {
            
            Touch finger = Input.GetTouch(i);
            
            //Debug.Log(Camera.main.ScreenToViewportPoint(finger.position));

            float xPos = Camera.main.ScreenToViewportPoint(finger.position).x-0.5f;

            XTotalPos += xPos;
            

        }

        playerxd.RotateZ(XTotalPos);


    }


    
    


}
