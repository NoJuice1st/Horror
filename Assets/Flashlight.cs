using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public bool isOn;
    public Light light;
    public AudioClip click;
    private AudioSource source;

    public float flashlightPower = 75;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOn = !isOn;
            source.PlayOneShot(click);
        }

        light.enabled = isOn;

        if (isOn && flashlightPower > 0)
        {
            flashlightPower -= Time.deltaTime * 2;
            print(flashlightPower);



            if (flashlightPower < 75 && flashlightPower > 50)
            {
                light.intensity = Random.Range(1.75f, 2f);
            }
            else if (flashlightPower < 50 && flashlightPower > 25)
            {
                light.intensity = Random.Range(1f, 1.25f);
            }
            else if(flashlightPower < 25 && flashlightPower > 5)
            {
                light.intensity = Random.Range(0.1f, 1f);
            }
            else if(flashlightPower < 5 && flashlightPower > 0)
            {
                light.intensity = Random.Range(0.05f, 0.5f);
            }
            else if(flashlightPower <= 0)
            {
                light.intensity = 0;
            }
        }

    }
}
