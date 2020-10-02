using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed;

    GameObject target;

    Transform targetTransform;

    [SerializeField]
    float bulletLifetime;

    float elapsed = 0;

    Vector3 bulletPath;


    // Start is called before the first frame update
    void Start()
    {
        targetTransform = target.GetComponent<Transform>();
        bulletPath = new Vector3(targetTransform.position.x,targetTransform.position.y-(0.3f),
        targetTransform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(
        transform.position, bulletPath, bulletSpeed*Time.deltaTime);


        elapsed += Time.deltaTime;
        Debug.Log(target.name);

        if (elapsed >= bulletLifetime)
        {
            Destroy(gameObject);
        }
    }

    public void SetBulletSpeed(float val)
    {
        bulletSpeed = val;
    }

    public void SetTarget(GameObject val)
    {
        target = val;
    }

}
