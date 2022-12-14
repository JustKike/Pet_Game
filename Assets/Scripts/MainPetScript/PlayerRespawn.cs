using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{

    private float checkPointPositionX, checkPointPositionY;
    public Animator animator;
    public ParticleSystem DamageHit;


    void Start()
    {
        animator = GetComponent<Animator>();

        if (PlayerPrefs.GetFloat("checkPointPositionX")!=0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY"));
        }

    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamaged()
    {
        //animator.Play("Damage", 0, 0.25f);
        animator.SetTrigger("Hit");
        DamageHit.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


}
