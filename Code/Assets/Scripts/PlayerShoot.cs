using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    
    [SerializeField]
    float cooldownTime = 0;

    float cooldown;

    [SerializeField]
    float bulletSpeed;

    [SerializeField]
    Image ammoBar;
    [SerializeField]
    Image healthBar;

    int ammo;
    [SerializeField]
    int ammoCapacity;

    
    float health;
    [SerializeField]
    float healthMax;



    // Start is called before the first frame update
    void Start()
    {
        ammo = ammoCapacity;
        health = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && cooldown >= cooldownTime && ammo>0)
        {
            Vector3 bulletDirection = transform.forward * bulletSpeed * -1;
            GameObject b = Instantiate(bullet,
            new Vector3(transform.position.x,transform.position.y+transform.localScale.y-0.5f,transform.position.z),
            transform.rotation);
            b.GetComponent<Rigidbody>().velocity = bulletDirection;
            cooldown = 0;
            ammo -= 1;
        }
        else
            cooldown += Time.deltaTime;

        UpdateHUD();

    }

    void UpdateHUD()
    {
        ammoBar.fillAmount = (float)ammo / ammoCapacity;
        healthBar.fillAmount = health / healthMax;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<CollectAmmo>()!=null)
        {
            ammo += ammoCapacity/2;
            Destroy(collision.gameObject);

            if (ammo > ammoCapacity)
                ammo = ammoCapacity;
           
        }

        if (collision.gameObject.GetComponent<DamagePlayer>() != null)
        {

            health -= collision.gameObject.GetComponent<DamagePlayer>().GetDamageAmount();
            Destroy(collision.gameObject);

            if (health <= 0)
                SceneManager.LoadScene(2);

        }

    }
}
