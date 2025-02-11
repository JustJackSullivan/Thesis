using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHereParticles : MonoBehaviour
{
    public GameObject[] guides;
    private int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        guides[0].SetActive(true);
        for (int i = 1; i < guides.Length; i++) {
            guides[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
       {

           if (other.gameObject == guides[currentIndex])
           {
        
               guides[currentIndex].SetActive(false);
    
            
               currentIndex++;
               if (currentIndex < guides.Length)
               {
                   guides[currentIndex].SetActive(true);
               }
           }
       }
}
