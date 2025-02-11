using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textElement; 
    public string fullText = "This is the prototype for a cool and epic game which rocks and is awesome and cool"; 
    public float displayDuration = 5f; 
    private bool textComplete = false;
    public AudioSource src;
    public GameObject dialogueBox;
    public GameObject instructions;

    public Image dialogueBoxImage;
    public Sprite sprite1;
    public Sprite sprite2;
    private bool shouldAlternateSprite = true;


    public AudioSource src2;
    //public AudioClip wind;

    private bool hasSkipped = false;
    public static bool isFinished = false;

    void Start()
    {
        isFinished = false;
        Time.timeScale = 0f;
        textElement.text = ""; 
        StartCoroutine(DisplayText());
        StartCoroutine(AlternateSprite());
        dialogueBox.SetActive(true);
        instructions.SetActive(false);
        src.loop = true;
        src.Play();
    }

    IEnumerator DisplayText()
    {
        float delayPerLetter = displayDuration / fullText.Length;

        for (int i = 0; i < fullText.Length; i++)
        {
            textElement.text += fullText[i];
            yield return new WaitForSecondsRealtime(delayPerLetter); 
        }
        
        instructions.SetActive(true);
        textComplete = true; 
        src.Stop();
        shouldAlternateSprite = false; 
        dialogueBoxImage.sprite = sprite1; 
    }

    IEnumerator AlternateSprite()
    {
        int frameCount = 0;

        while (shouldAlternateSprite)
        {
            yield return new WaitForSecondsRealtime(0.02f);

            
            frameCount++;
            if (frameCount % 5 == 0)
            {
                dialogueBoxImage.sprite = dialogueBoxImage.sprite == sprite1 ? sprite2 : sprite1;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            hasSkipped = true;
            dialogueBox.SetActive(false);
            instructions.SetActive(false);
            textElement.gameObject.SetActive(false); 
            Time.timeScale = 1f; 
            Destroy(instructions);
            src.Stop();
            isFinished = true;
            
        }

        if ((textComplete && Input.GetKeyDown(KeyCode.E)) && !hasSkipped)
        {
            dialogueBox.SetActive(false);
            instructions.SetActive(false);
            textElement.gameObject.SetActive(false); 
            Time.timeScale = 1f; 
            isFinished = true;
            
        }
    }
}
