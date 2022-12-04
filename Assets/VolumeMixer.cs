using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeMixer : MonoBehaviour
{
     void Start()
    {
     
    }
 
   public void ChangeVol(float newValue) {
        float newVol = AudioListener.volume;
        newVol = newValue;
        AudioListener.volume = newVol;
    }

}
