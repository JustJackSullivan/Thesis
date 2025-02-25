using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwingToggle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void swingStart() {
        PlayerHealth.canSwing = false;
    }
    void swingEnd() {
        PlayerHealth.canSwing = true;
    }
}
