using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerxd : MonoBehaviour
{
    private GameObject RocketmanAnimated;
    private Animator animator;

    private Animator cameraDeadAnimator;
    private Rigidbody rg;
    private Collider playerColl;

    public Canvasxd canvassal;

    [Tooltip("sagdan yada soldan carptiktan sonra sarsilma suresi")]
    public float propelDuration = 0.55f;




    private static bool canPlayerJump = true;


    public static bool isDead = false;
    public static float speed;
    public static float speedRL;

    public static float distanceForward;
    public static float score = 0;

    private Vector3 lastMoveDistance;

    [Tooltip("carpilabilir tag listesi")]
    public List<string> CollidingTags =new List<string> {"Brick","Ball" };

    public List<AudioClip> audioClips;
    public AudioSource auSource;


    // Start is called before the first frame update
    void Start()
    {

        distanceForward = Camera.main.farClipPlane*3;

        isDead = false;
        score = 0;

        RocketmanAnimated = GameObject.FindGameObjectWithTag("RocketmanAnimated");
        animator = RocketmanAnimated.GetComponent<Animator>();

        cameraDeadAnimator = GameObject.Find("cameraDeadAni").GetComponent<Animator>();

        rg = GetComponent<Rigidbody>();
        playerColl = GetComponent<Collider>();

        setDefaultbothSpeed();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    
    private void setDefaultspeedRL()
    {
        speedRL = 120;

    }
    private  void setDefaultspeed()
    { speed = 140; }

    private void setDefaultbothSpeed()
    {

        setDefaultspeed();
        setDefaultspeedRL();
    }

    public void RotateZ(float angle)
    {
        
        angle = Mathf.Clamp(angle, -0.5f, 0.5f);

        animator.SetFloat("RightLeft",Mathf.Lerp(animator.GetFloat("RightLeft"), 0.5f + angle,Time.deltaTime*10));

        MoveForwardRightLeftUp(angle);

    }

   

    // movement according rotateZ
    public void MoveForwardRightLeftUp(float angle)
    {
        distanceForward += Time.deltaTime * speed;

        score += Time.deltaTime * speed; ;


       

        


        lastMoveDistance =new Vector3(Time.deltaTime * angle * speedRL, 0, Time.deltaTime * speed);
        if(speed != 0) { 

        
        transform.Translate(lastMoveDistance);


        }

        
    }


    private void AfterCollide(Collision coll)
    {
        
        Vector3 closestPointofCollide = coll.collider.ClosestPoint(RocketmanAnimated.transform.position - lastMoveDistance);
        
        Debug.Log(closestPointofCollide);
        bool maxXEqual = closestPointofCollide.x >= coll.collider.bounds.center.x; 
        bool minXEqual = closestPointofCollide.x <= coll.collider.bounds.center.x; 
        bool minZnotEqual = closestPointofCollide.z != coll.collider.bounds.min.z;
        bool yandanMý = (maxXEqual || minXEqual) && minZnotEqual;

        if (yandanMý)
        {
            StartCoroutine(Propelxd(maxXEqual ? 1 :-1));
            
           
        }
        else
        {
            Deadxd(closestPointofCollide);
            
        }
       
        



    }
    private void Deadxd(Vector3 closestPointofCollide)
    {
        deadSoundEffect();
        speed = 0;
        speedRL = 0;

        //rg.isKinematic = true;
        cameraDeadAnimator.SetTrigger("dead");
        transform.position = closestPointofCollide- Vector3.forward * playerColl.bounds.extents.z;
        isDead = true;

    }

    private IEnumerator Propelxd(float direct)
    {
        propelSoundEffect();
        
        
        cameraDeadAnimator.SetTrigger("shake");
        speedRL = 0;
       
        while (Mathf.Abs(direct)>propelDuration)
        {
           
            transform.Translate(direct*Time.fixedDeltaTime*30,0,0);
            direct = Mathf.Lerp(direct, 0, Time.fixedDeltaTime);
              yield return new WaitForSeconds(Time.fixedDeltaTime);
            
                
        }
        setDefaultspeedRL();
    }


    private IEnumerator Flyxd(float upAmount2=100f)
    {
       
       
        float upAmount = upAmount2;
        
        while (transform.position.y>=0)
        {
            
            transform.position += Vector3.up * upAmount * Time.deltaTime;
            upAmount-=20*Time.deltaTime;
             
            yield return null;
        
        }
        transform.position = Vector3.Scale(transform.position , new Vector3(1, 0, 1));

       

           

    }
    public void FlyxdPublicvoid()
    {
        if(canPlayerJump)
        { 
        StartCoroutine(Flyxd());
        }
    }

    

    private void OnCollisionEnter(Collision coll)
    {
        if(CollidingTags.Contains(coll.gameObject.tag))
        {
            Debug.Log(coll.gameObject.name);
            // carpýlacak bir seye carptýgýnda carpiminin sonucu olacak þeyler
            AfterCollide(coll);
            
            
        }

        if(coll.gameObject.tag =="RampSmall")
        {

            StartCoroutine(Flyxd(coll.GetContact(0).normal.normalized.y*speed/2));

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="collectablePTK")
        {
            canvassal.jumpOnline();
        }
    }

    private void propelSoundEffect()
    {
        auSource.PlayOneShot(audioClips[1]);

    }
    private void deadSoundEffect()
    {
        auSource.PlayOneShot(audioClips[0]);
    }


    




}
