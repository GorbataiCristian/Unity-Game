using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{

    public GameObject target;
    public float speed = .001f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > .5)
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        transform.forward = transform.position - target.transform.position;
    }
}
