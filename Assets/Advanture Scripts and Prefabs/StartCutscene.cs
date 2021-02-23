using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public static bool isCutSceneOn;
    public Animator camAnim;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player_Knight_Advanturer")
    //    {
    //        isCutSceneOn = true;
    //        camAnim.SetBool("IsCutscene", true);
    //        Invoke(nameof(StopCutscene), 7f);
    //    }
    //}
    public void StartScene()
    {
        isCutSceneOn = true;
        camAnim.SetBool("IsCutscene", true);
        Invoke(nameof(StopCutscene), 7f);
    }
    void StopCutscene()
    {
        isCutSceneOn = false;
        camAnim.SetBool("IsCutscene", false);
        Destroy(gameObject);
    }
}
