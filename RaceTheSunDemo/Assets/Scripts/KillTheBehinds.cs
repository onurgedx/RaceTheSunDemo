using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTheBehinds : MonoBehaviour
{
    private GameObject playerxdd;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        killBehind();
    }


    private void killBehind()
    {
        if(Camera.main.transform.position.z > transform.GetChild(0).gameObject.GetComponent<Collider>().bounds.max.z)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        

    }
    
}
