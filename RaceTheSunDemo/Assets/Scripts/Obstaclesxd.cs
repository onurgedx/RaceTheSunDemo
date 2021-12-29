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
            arrangePlanes();
        }

    }


    public void CreateObstaclesxd()
    {
        GameObject goObstacle = Instantiate(list_obstacles[0], pointThatWillCreate, Quaternion.identity,transform);
        /*
        Bounds goBounds = goObstacle.GetComponent<Collider>().bounds;
       Vector3 sizeBrickCube =  goObstacle.transform.GetChild(0).gameObject.GetComponent<Collider>().bounds.size;
        
        Vector3 extentsofPlane = goBounds.extents;

        int countBrickCube = (int)((extentsofPlane[0] * extentsofPlane[1] * extentsofPlane[2]) / (sizeBrickCube.x * sizeBrickCube.y * sizeBrickCube.z));
          
        
        
        for(int i =1; i<countBrickCube; i++)
        {
            Instantiate(goObstacle.transform.GetChild(0).gameObject, new Vector3(Random.Range(goBounds.min.x,goBounds.max.x), Random.Range(goBounds.min.y, goBounds.max.y), Random.Range(goBounds.min.z, goBounds.max.z)),Quaternion.identity,goObstacle.transform);
        
        }
        */
        
        
    }

    public Vector3 pointThatWillCreate
    {
        get
        {
            Bounds boundsLast = transform.GetChild(transform.childCount - 1).gameObject.GetComponent<Collider>().bounds;

            float newPosZ = boundsLast.center.z + boundsLast.size.z;
            return new Vector3(playerxd.transform.position.x, -4, newPosZ);

            /*
            RaycastHit hit;

            Physics.Raycast(playerxd.transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity);
            return new Vector3(playerxd.transform.position.x, -4, hit.collider.bounds.center.z+hit.collider.bounds.size.z* distanceDivFarClipPlane);
            
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            {
                return new Vector3(playerxd.transform.position.x , -4 , hit.collider.bounds.max.z);
            }
            */

            //return playerxd.transform.position + Vector3.forward * Camera.main.farClipPlane*3/2 - Vector3.up*4;
        }
         
    }

    
    // is Proper distance ensured to create obstacles
    // engeller yaratmak için  uygun meseafe sagandý mý

    public bool shallCreate
    {
        get
        {
            float sizeZ = transform.GetChild(0).gameObject.GetComponent<Collider>().bounds.size.z;
            if (Playerxd.distanceForward >= sizeZ)
            {
                Playerxd.distanceForward -= sizeZ;
                return true;
            }

            else { return false; }
        }
    }


    public int distanceDivFarClipPlane
    {
        get
        { int oran =(int) (Playerxd.distanceForward / Camera.main.farClipPlane);
             
            return oran + 1;
        }
    }


    private void arrangePlanes()
    {
       for(int i=0;i<transform.childCount;i++)
        {
            if(!transform.GetChild(i).gameObject.GetComponent<Renderer>().isVisible)
            { transform.GetChild(i).position = new Vector3(playerxd.transform.position.x , transform.GetChild(i).position.y,transform.GetChild(i).position.z );  }

            
        }

    }
}
