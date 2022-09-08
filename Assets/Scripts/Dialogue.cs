using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public Sprite[] images;
    public Image insertImage;
    public GameObject CanvasPlayer;
    // public Image imageOne;
    // public Image imageTwo;
    // public Image imageThree;

    private int index;

    [Header("gameMaster to take away controls")]
    public GameObject gameMaster;


    PlayerStats playerStats;
    GameObject playerObjectInteract;
    MouseLook mouseLook;
    InputManager inputManager;
    Interactable interactablePC;


    // Start is called before the first frame update
    void Start()
    {
        CanvasPlayer.SetActive(false);

        // this.transform.parent.gameObject.GetComponent<Image>().sprite = images[0];
        // set image
        // insertImage.GetComponent<Image>().sprite = images[0].CrossFadeAlpha(1, 2.0f, false);

        textComponent.text = string.Empty;
        //standart no fade in
        insertImage.GetComponent<Image>().sprite = images[0];
        StartDialogue();

        //take away players control
        // function change camera maybe
        TakeControls();
        
    }

    void TakeControls()
    {
        playerStats = gameMaster.GetComponent<PlayerStats>();

        playerObjectInteract = playerStats.playerObject;
        mouseLook = playerObjectInteract.GetComponent<MouseLook>();
        inputManager = playerObjectInteract.GetComponent<InputManager>();
        
        mouseLook.enabled = false;
        inputManager.enabled = false;

    }

    void GiveControls()
    {
        playerStats = gameMaster.GetComponent<PlayerStats>();
       
        playerObjectInteract = playerStats.playerObject;  
        mouseLook = playerObjectInteract.GetComponent<MouseLook>();
        inputManager = playerObjectInteract.GetComponent<InputManager>();

        mouseLook.enabled = true;
        inputManager.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                // skip text animation(disable it in final version)
                // StopAllCoroutines();
                // textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text +=c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    IEnumerator FadeToNextImage(float startTime, int index)
    {

        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());

        // fade out old image
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                insertImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, i);
                yield return null;
            }

            insertImage.GetComponent<Image>().sprite = images[index];


            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                insertImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, i);
                yield return null;
            }

        
        
    }
// it should not be courutine (give control ONLY when image fade out completely)
    IEnumerator FadeToFinale(float startTime)
    {

        //fade out dialog box
        // for (float i = 1; i >= 0; i -= Time.deltaTime)
        // {
        //     // set color with i as alpha
        //     this.GetComponent<Image>().color = new Color(1f, 1f, 1f, i);
        //     yield return null;
        // }


        //this.transform.parent.gameObject

        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            insertImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, i);
            yield return null;
        }


        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            this.transform.parent.gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, i);
            yield return null;
        }

        gameObject.SetActive(false);
        this.transform.parent.gameObject.SetActive(false);

        CanvasPlayer.SetActive(true);
        GiveControls();


        yield return null;

        // while(true)
        // {
        //     float t = (Time.time - startTime) / duration;
        // UnityEngine.Debug.Log("time = " + t);


        // }
        
        // Sprite mySprite = insertImage.GetComponent<Image>().sprite;
        // mySprite.color = new color( 1f,1f,1f,Mathf.SmoothStep(minimum, maximum, t) );


        // insertImage.GetComponent<Image>().color = new Color( 1f,1f,1f,Mathf.SmoothStep(minimum, maximum, t) );

        // for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        
    }

    void NextLine()
    {
        //childObject.transform.parent.gameObject
        UnityEngine.Debug.Log("TEST = " + this.transform.parent.gameObject.transform);
        //this.transform.parent.gameObject.GetComponent<Image> ().sprite = images[0]
        if(index < lines.Length -1)
        {
            
            index++;
            // change image
            // insertImage.GetComponent<Image>().sprite = images[index];
            // coroutine to change image


      //  this function is now inside FadeIntoNextImage
            // textComponent.text = string.Empty;
            // StartCoroutine(TypeLine());



            float endTime = Time.time;
            StartCoroutine(FadeToNextImage(endTime, index));

            // float endTime = Time.time;
            // StartCoroutine(FadeToFinale(endTime));
        }else
        {
        // unfinished fade images function
            float endTime = Time.time;
            StartCoroutine(FadeToFinale(endTime));
            

            // gameObject.SetActive(false);
            // this.transform.parent.gameObject.SetActive(false);
            // GiveControls();
        }
    }
}
