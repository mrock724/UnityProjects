using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorFlashing : MonoBehaviour
{

    public GameObject theLight;
    int inc;

    // Start is called before the first frame update
    void Start()
    {
        inc = 0;
    }

    // Update is called once per frame
    void Update()
    {
        inc++;
        if (inc > 7)
        {
            theLight.SetActive(!theLight.activeSelf);
            inc = 0;
        }
    }
}
