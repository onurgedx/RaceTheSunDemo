using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Canvasxd : MonoBehaviour
{

    public GameObject ResumeExit,StopButton,Score,Resume,Exit,Menu,restartxd,Toggle,jumpButton,playerxd,jumpingoText;

    public Animator animatorCanvas;
    public static bool soundOn=true;
    
    // Start is called before the first frame update
    void Start()
    {
        if(Toggle != null)
        {
            Toggle.GetComponent<Toggle>().isOn = !isSoundOn;
            
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        deadControl();
        Debug.Log(isSoundOn);
        

    }


    public void jumpPlayer()
    {   playerxd.GetComponent<Playerxd>().FlyxdPublicvoid();
        animatorCanvas.SetTrigger("jump");
        jumpButton.SetActive(false);
        

    }

    public void jumpOnline()
    {
        // jump tusuna basildigi zaman




        jumpButton.SetActive(true);
    }
    public bool isSoundOn
    {
        get
        {
            
            return soundOn;
        }
        set
        {
            Debug.Log(!value);
            if(!value)
            {
                AudioListener.volume = 1;

            }
            else { AudioListener.volume = 0; }
            soundOn = !value; 
        }
    }

    public void PauseButton()
    {

        Controllerxd.modePlay = false;
        animatorCanvas.SetTrigger("Pause");
        StopButton.SetActive(false);
        
        
    }
    public void ResumeButton()
    {

        Controllerxd.modePlay = true;
        
        animatorCanvas.SetTrigger("Resume");

       
        StopButton.SetActive(true);
    }

    public void RestartScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    private void deadControl()
    {
        if(SceneManager.GetActiveScene().name!="Menu")
        { 
            if(Playerxd.isDead)
            {
                StopButton.SetActive(false);
                animatorCanvas.SetTrigger("Dead");
            
            }


            else
            {

                Score.GetComponent<Text>().text = ((int)Playerxd.score).ToString();
            }
        }

    }

    public void goMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void goPlay()
    {
        SceneManager.LoadScene(1);
    }
    
   


}
