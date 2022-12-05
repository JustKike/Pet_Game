using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerSelect : MonoBehaviour
{
    
    public enum Player {Dog, Cat};
    public Player playerSelected;
    public bool enableSelectCharacter;

    private CinemachineVirtualCamera vcam;

    public GameObject[] playersObj;
    public GameObject[] playersVcam;

    void Start()
    {

        if (!enableSelectCharacter)
        {
            ChangePlayerInMenu();
        }
        else
        {
            switch (playerSelected)
            {
                case Player.Dog:
                    playersObj[0].SetActive(true);
                    playersVcam[0].SetActive(true);
                    break;
                case Player.Cat:
                    playersObj[1].SetActive(true);
                    playersVcam[1].SetActive(true);
                    break;
            }
        }
    }

    public void ChangePlayerInMenu()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "Dog":
                playersObj[0].SetActive(true);
                playersVcam[0].SetActive(true);
                playersObj[1].SetActive(false);
                playersVcam[1].SetActive(false);
                break;
            case "Cat":
                playersObj[1].SetActive(true);
                playersVcam[1].SetActive(true);
                playersObj[0].SetActive(false);
                playersVcam[0].SetActive(false);
                break;
        }
    }

}
