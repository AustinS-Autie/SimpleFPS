using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    
    [SerializeField]
    float cooldownTime = 0;

    float cooldown;

    [SerializeField]
    float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && cooldown >= cooldownTime)
        {
            Vector3 bulletDirection = transform.forward * bulletSpeed;
            GameObject b = Instantiate(bullet, transform.position, transform.rotation);
            b.GetComponent<Rigidbody>().velocity = bulletDirection;
            cooldown = 0;
        }
        else
            cooldown += Time.deltaTime;

    }
}
