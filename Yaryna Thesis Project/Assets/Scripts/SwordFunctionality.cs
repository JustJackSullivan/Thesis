using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwordFunctionality : MonoBehaviour
{

    public TextMeshProUGUI npcDialogueText;
    public string fullText = "Will you take the sword?";
    public float displayDuration = 3f; 
    private bool textComplete = false;
    public AudioSource src;


    public GameObject NPCDialogueParent;
    public GameObject tutorial;
    private bool playerIsInRange = false;
    public static bool isInDialogue = false;

    public GameObject swordViewmodel;
    public GameObject normalViewmodel;

    public GameObject yesOption;
    public GameObject noOption;

    public GameObject yesArrow;
    public GameObject noArrow;

    private int selectedIndex = 0;

    public GameObject physicalSword;

    public BoxCollider swordCollectHitbox;

    public AudioClip optionSound;

    private bool hasSword;

    // Start is called before the first frame update
    void Start()
    {
        swordViewmodel.SetActive(false);
        isInDialogue = false;
        NPCDialogueParent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {



        if (playerIsInRange && !isInDialogue) {
            tutorial.SetActive(true);
        }
        else {
            tutorial.SetActive(false);
        }

        if (!textComplete) {
            yesArrow.SetActive(false);
            noArrow.SetActive(false);
        }

        if (selectedIndex == 0 && textComplete) {
            yesArrow.SetActive(true);
            noArrow.SetActive(false);
        }
        if (selectedIndex == 1 && textComplete) {
            noArrow.SetActive(true);
            yesArrow.SetActive(false);
        }



        if (playerIsInRange && Input.GetKeyDown(KeyCode.E) && !isInDialogue) {
            npcDialogueText.text = "";
            isInDialogue = true;
            //Time.timeScale = 0f;
            NPCDialogueParent.SetActive(true);
            yesOption.SetActive(false);
            noOption.SetActive(false);
            //instructions.SetActive(false);
            StartCoroutine(DisplayText());
            src.loop = true;
            src.Play();
        }

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && textComplete)
        {
            src.PlayOneShot(optionSound);
            selectedIndex = (selectedIndex == 0) ? 1 : 0; // toggle between 0 and 1
        }

        if (Input.GetKeyDown(KeyCode.E) && textComplete && selectedIndex == 0 && !hasSword) { //YES OPTION
            NPCDialogueParent.SetActive(false);
            isInDialogue = false;
            //Time.timeScale = 1f;
            textComplete = false;
            normalViewmodel.SetActive(false);
            swordViewmodel.SetActive(true);
            physicalSword.SetActive(false);
            swordCollectHitbox.enabled = false;
            PlayerHealth.hasSword = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && textComplete && selectedIndex == 1) { //NO OPTION
            NPCDialogueParent.SetActive(false);
            isInDialogue = false;
            //Time.timeScale = 1f;
            textComplete = false;
        }

    }


    IEnumerator DisplayText()
    {
        float delayPerLetter = displayDuration / fullText.Length;

        for (int i = 0; i < fullText.Length; i++)
        {
            npcDialogueText.text += fullText[i];
            yield return new WaitForSecondsRealtime(delayPerLetter); // use WaitForSecondsRealtime to ignore Time.timeScale
        }
        src.Stop();
        //instructions.SetActive(true);
        yesOption.SetActive(true);
        noOption.SetActive(true);
        yesArrow.SetActive(true);
        noArrow.SetActive(false);
        textComplete = true; 
    }


     void OnCollisionEnter(Collision collision)
    {
      
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsInRange = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsInRange = false;
        }
    }
}
