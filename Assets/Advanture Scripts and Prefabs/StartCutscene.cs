using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public static bool isCutSceneOn;
    public Animator camAnim;
    //public GameObject activateButtonForCamera;
    public GameObject createPlatform;
    public GameObject effectCreatingPlatform;
    public Transform posCreatePlatform;
    public PlayerMovementAdvanturerKnight moveSpeed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player_Knight_Advanturer")
        {
            moveSpeed.normalMovementSpeed = 0;
            Invoke(nameof(CreatePlatform), 2f);
            isCutSceneOn = true;
            camAnim.SetBool("IsCutscene", true);
            //activateButtonForCamera.SetActive(false);
            Invoke(nameof(StopCutscene), 5f);
        }
    }
    //public void StartScene()
    //{
    //    Invoke(nameof(CreatePlatform), 2f);
    //    isCutSceneOn = true;
    //    camAnim.SetBool("IsCutscene", true);
    //    //activateButtonForCamera.SetActive(false);
    //    Invoke(nameof(StopCutscene), 5f);
    //}
    void StopCutscene()
    {
        isCutSceneOn = false;
        camAnim.SetBool("IsCutscene", false);
        moveSpeed.normalMovementSpeed = 400;
        //Destroy(gameObject);   
    }
    void CreatePlatform()
    {
        Instantiate(effectCreatingPlatform, posCreatePlatform.transform.position, Quaternion.identity);
        createPlatform.SetActive(true);  
    }
}
