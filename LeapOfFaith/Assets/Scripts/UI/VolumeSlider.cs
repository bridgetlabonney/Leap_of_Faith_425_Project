using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] Slider slider;

    public void volume()
    {
        float t = slider.value;
        PlayerPrefs.SetFloat("volume", t);
    }
  

}
