using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    [SerializeField]
    Transform[] targets;
    Transform currentTarget;
    
    [SerializeField]
    float speed;
    [SerializeField]
    int dist;
    int targetIndex;




    
    // Start is called before the first frame update
    void Start()
    {
        UpdateTarget();  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentTarget.position, speed * Time.deltaTime);  
    
        if(Vector3.Distance(transform.position,currentTarget.position) < dist)
        {
            targetIndex += 1;
            if (targetIndex >= targets.Length)
                targetIndex = 0;
            
                UpdateTarget();
        }
    }

    void UpdateTarget()
    {
        currentTarget = targets[targetIndex];
    }
}
