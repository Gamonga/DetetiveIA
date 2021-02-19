using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    private int target = 60;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != Application.targetFrameRate){
            Application.targetFrameRate = target;
        }
        
    }
}
