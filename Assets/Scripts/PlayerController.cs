using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    float Imput_x = 0;
    float Imput_y = 0;
    public float speed = 2.5f;
    bool isWalking = false;


    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Imput_x = Input.GetAxisRaw("Horizontal");
        Imput_y = Input.GetAxisRaw("Vertical");
        isWalking = (Imput_x != 0 | Imput_y != 0);

        if(isWalking){
            var move = new Vector3(Imput_x, Imput_y, 0).normalized;
            transform.position += move * speed * Time.deltaTime;
            playerAnimator.SetFloat("Imput_x", Imput_x);
            playerAnimator.SetFloat("Imput_y", Imput_y);
        }

        playerAnimator.SetBool("isWalking", isWalking);

        if(Input.GetButtonDown("Fire1"))
            playerAnimator.SetTrigger("Atack");
        
    }
}
