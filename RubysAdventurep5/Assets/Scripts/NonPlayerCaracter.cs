using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCaracter : MonoBehaviour
{
    public float display = 4.0f;
    public GameObject dialogeBox;
    float timerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        dialogeBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if(timerDisplay < 0)
            {
                dialogeBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        
        dialogeBox.SetActive(true);
    }
}
