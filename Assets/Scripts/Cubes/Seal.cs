using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : MonoBehaviour
{
    GameObject[] colorCubes;
    public int blueNumber;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UnSeal();
        print(colorCubes.Length);
    }

    public void UnSeal()
    {
        colorCubes = GameObject.FindGameObjectsWithTag("Blue");
        blueNumber = colorCubes.Length;

        if(blueNumber == 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
