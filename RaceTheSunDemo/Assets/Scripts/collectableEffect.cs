using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Vanishingxd()
    {
        StartCoroutine(Vanishing());
        
    }

    private IEnumerator Vanishing()
    {
        while (transform.localScale.magnitude >= 0.2f)
        {
            transform.localScale  = Vector3.Lerp(transform.localScale,Vector3.zero,Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            // vanish pls 
            Vanishingxd();
        }
    }
}
