using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCDialogue : MonoBehaviour
{

    public TextMeshProUGUI npcDialogueText;
    public string fullText = "i like salmon and evangalion blah blah blah blah blah blah";
    public float displayDuration = 2f; 
    private bool textComplete = false;
    public AudioSource src;
    public GameObject instructions;

    public GameObject NPCDialogueParent;
    public GameObject tutorial;
    private bool playerIsInRange = false;
    public static bool isInDialogue = false;

    // Start is called before the first frame update
    void Start()
    {
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



        if (playerIsInRange && Input.GetKeyDown(KeyCode.E) && !isInDialogue) {
            npcDialogueText.text = "";
            isInDialogue = true;
            //Time.timeScale = 0f;
            NPCDialogueParent.SetActive(true);
            instructions.SetActive(false);
            StartCoroutine(DisplayText());
            src.loop = true;
            src.Play();
        }


        if (Input.GetKeyDown(KeyCode.Return) && textComplete) {
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
            yield return new WaitForSecondsRealtime(delayPerLetter); 
        }
        src.Stop();
        instructions.SetActive(true);
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
