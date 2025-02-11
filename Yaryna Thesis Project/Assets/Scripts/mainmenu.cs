using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Image[] menuOptions; 
    public Color defaultColor = Color.white; 
    public Color highlightedColor = Color.yellow; 

    private int selectedIndex = 0; 

    void Start()
    {
        UpdateMenuColors();
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.W))
        {
            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = menuOptions.Length - 1;
            UpdateMenuColors();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            selectedIndex++;
            if (selectedIndex >= menuOptions.Length)
                selectedIndex = 0;
            UpdateMenuColors();
        }

       
        if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Submit"))
        {
            ExecuteOption();
        }
    }

    void UpdateMenuColors()
    {
        for (int i = 0; i < menuOptions.Length; i++)
        {
            if (i == selectedIndex)
            {
                menuOptions[i].color = highlightedColor; 
            }
            else
            {
                menuOptions[i].color = defaultColor; 
            }
        }
    }

    void ExecuteOption()
    {
        switch (selectedIndex)
        {
            case 0:
                Debug.Log("Option 1 Selected");
                SceneManager.LoadScene("SampleScene");
                break;
            case 1:
                Debug.Log("Option 2 Selected");
                //  code for option 2
                break;
            case 2:
                Debug.Log("Option 3 Selected");
                //  code for option 3
                break;
            case 3:
                Debug.Log("Option 4 Selected");
                //  code for option 4
                break;
            default:
                Debug.Log("Invalid Option");
                break;
        }
    }
}
