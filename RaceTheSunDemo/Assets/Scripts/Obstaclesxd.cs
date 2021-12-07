using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaclesxd : MonoBehaviour
{


    private GameObject playerxd;

    [SerializeField]
    private List<GameObject> list_obstacles;

    // Start is called before the first frame update
    void Start()
    {
        playerxd = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shallCreate)
        {
            CreateObstaclesxd();
        }

    }


    public void CreateObstaclesxd()
    {
        GameObject goObstacle = Instantiate(list_obstacles[0], pointThatWillCreate, Quaternion.identity,transform);
        

    }

    public Vector3 pointThatWillCreate
    {
        get
        {
            return playerxd.transform.position + Vector3.forward * Camera.main.farClipPlane*3/2 - Vector3.up*4;
        }
         
    }

    
    // is Proper distance ensured to create obstacles
    // engeller yaratmak için  uygun meseafe sagandý mý
    public bool shallCreate
    {
        get
        {
            if (Playerxd.distanceForward >= Camera.main.farClipPlane)
            {
                Playerxd.distanceForward = 0;
                return true;
            }
            else { return false; }
        }
    }




}
