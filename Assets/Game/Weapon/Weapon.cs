using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Weapon : MonoBehaviour
{
    private StarterAssetsInputs _input;
    public GameObject bulletPreFab;//bullet object
    public GameObject bulletPoint;//location of bullet 
    public float bulletSpeed = 600;//speed of bullet

    // Start is called before the first frame update
    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_input.shoot){
            Shoot();
            _input.shoot = false;
        }
    }

    void Shoot(){
        Debug.Log("Pew Pew ~~~");
        GameObject bullet = Instantiate(bulletPreFab,bulletPoint.transform.position,transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        Destroy(bullet,1);//erase bullet after its use is finished
    }   
}
