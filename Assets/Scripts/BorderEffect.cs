using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject border1;
    public GameObject border2;
    
    bool On;
    float count = 0;
    void Start()
    {
        On = false;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;       
        if (count > 1f)
        {
            if (On)
            {
                border1.SetActive(true);
                border2.SetActive(false);
                On = false;
            }
            else if (!On)
            {
                border1.SetActive(false);
                border2.SetActive(true);
                On = true;
            }
            count = 0;
        }

    }
}
