using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyM : MonoBehaviour
{
    public static Vector3 initialposition;
    private Vector3 recordposition;
    public bool isYellow;
    GameObject[] blocks;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        initialposition = transform.position;
        // for (int i = 0; i < blocks.Length; i++)
        // {
        //     print(blocks[i].name);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        blocks = GameObject.FindGameObjectsWithTag("Block");
        player = GameObject.FindGameObjectWithTag("Player");
        if(isYellow)
        {
            Move();
            Movement();
        }

    }

    private void LateUpdate()
    {

    }

    public void Move()
    {
        recordposition = transform.position;

        if (Input.GetKeyDown(KeyCode.W) && transform.position.z != 1)
        {
            transform.Translate(Vector3.forward);
            recordposition.z = transform.position.z - 1;
        }
        if (Input.GetKeyDown(KeyCode.S) && transform.position.z != -1)
        {
            transform.Translate(Vector3.back);
            recordposition.z = transform.position.z + 1;
        }
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x != -1)
        {
            transform.Translate(Vector3.left);
            recordposition.x = transform.position.x + 1;
        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x != 1)
        {
            transform.Translate(Vector3.right);
            recordposition.x = transform.position.x - 1;
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
}