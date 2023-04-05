using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_HUD : MonoBehaviour
{
  public int maxLives;

  public TMP_Text nameText;
  public TMP_Text healthText;
  public Transform playerLives;
  public GameObject lifeSprite;
  public Image characterIcon;
  public Sprite momoIcon;
  public Sprite boxerIcon;
  public Sprite stickIcon;

  public GameObject player;
  public Animator anim;

  void Awake()
  {
    maxLives = 3;

    nameText = gameObject.transform.Find("Player_Name").GetComponent<TMP_Text>();
    healthText = gameObject.transform.Find("Player_Health").GetComponent<TMP_Text>();
    playerLives = gameObject.transform.Find("Player_Lives");
  }

  void Start()
  {
    if (gameObject.name == "Player_One_HUD")
    {
      nameText.text = PlayerPrefs.GetString("Player_One_Character");
      if (PlayerPrefs.GetString("Player_One_Character") == "Momo") {
        characterIcon.sprite = momoIcon;
      } else if (PlayerPrefs.GetString("Player_One_Character") == "Boxer") {
        characterIcon.sprite = boxerIcon;
      } else if (PlayerPrefs.GetString("Player_One_Character") == "Stick") {
        characterIcon.sprite = stickIcon;
      }
      player = GameObject.Find("Player_One");
    }
    else if (gameObject.name == "Player_Two_HUD")
    {
      nameText.text = PlayerPrefs.GetString("Player_Two_Character");
      if (PlayerPrefs.GetString("Player_Two_Character") == "Momo") {
        characterIcon.sprite = momoIcon;
      } else if (PlayerPrefs.GetString("Player_Two_Character") == "Boxer") {
        characterIcon.sprite = boxerIcon;
      } else if (PlayerPrefs.GetString("Player_Two_Character") == "Stick") {
        characterIcon.sprite = stickIcon;
      }
      player = GameObject.Find("Player_Two");
    }
    anim = player.GetComponent<Animator>();
    healthText.text = anim.GetFloat("Health").ToString("0.00") + "%";
  }

  void FixedUpdate()
  {
    if (healthText.text != anim.GetFloat("Health").ToString("0.00") + "%")
    {
      healthText.text = anim.GetFloat("Health").ToString("0.00") + "%";
    }
  }
}
