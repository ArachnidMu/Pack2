using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : MonoBehaviour
{
    private GameObject target;
    private Vector3 initialposition;
    private Vector3 recordposition;
    GameObject[] blocks;
    GameObject[] enemies;

    GameObject[] AAA;
    Vector3[] AA;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        AAA = GameObject.FindGameObjectsWithTag("Enemy");
        AA = new Vector3 [AAA.Length];
        RecordPosition();
    }

    // Update is called once per frame
    void Update()
    {
        blocks = GameObject.FindGameObjectsWithTag("Block");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
       
        Move();
        Movement();
    
        
    }

    private void LateUpdate() 
    {
        IsHit();
        IsReach();
    }

    public void Move()
    {
        recordposition = transform.position;

        if (Input.GetKeyDown(KeyCode.W) && transform.position.z != 1)
        {
            transform.Translate(Vector3.forward);
            recordposition.z = transform.position.z-1;
        }
        if (Input.GetKeyDown(KeyCode.S) && transform.position.z != -1)
        {
            transform.Translate(Vector3.back);
            recordposition.z = transform.position.z+1;
        }
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x != -1)
        {
            transform.Translate(Vector3.left);
            recordposition.x = transform.position.x+1;
        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x != 1)
        {
            transform.Translate(Vector3.right);
            recordposition.x = transform.position.x-1;
        }
    }

    private void IsReach()
    {
        if (transform.position == target.transform.position)
        {
            print("Game Over");
        }
    }

    private void Movement()
    {
        for (int i = 0; i < blocks.Length; i++)
            if (transform.position != blocks[i].transform.position)
            {

            }
            else
            {
                transform.position = recordposition;
            }
    }

    private void IsHit()
    {
        for (int i = 0; i < enemies.Length; i++)
            if(transform.position == enemies[i].transform.position)
            {
                transform.position = initialposition;
                ObjectsManager.isShake = true;
                Timer.isStartTimer = true;
                print(enemies[i].transform.position);
                enemies[i].transform.position = AA[i];
            }
        if(Timer.isStartTimer == false)
        {
            ObjectsManager.isShake = false;
        }
    }

    private void RecordPosition()
    {
        initialposition = transform.position;
        for (int i = 0; i < AAA.Length; i++)
        {
            AA[i] = AAA[i].transform.position;
        }
    }
}