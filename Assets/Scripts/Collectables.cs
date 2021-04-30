using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Movemnetscript player = other.GetComponent<Movemnetscript>();
            if(player!=null)
            {
                player.addCoins();
            }
            Destroy(this.gameObject);
           
        }
    }
}
