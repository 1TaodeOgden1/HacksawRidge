using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static int PlayerHP = 100;
    public TextMeshProUGUI playerHPText;
    public GameObject bloodOverlay;

    public static bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerHPText.text = "+" + PlayerHP;

        if (isGameOver)
        {
            SceneManager.LoadScene("Enemies");
        }
    }
     public IEnumerator TakeDamage(int damageAmount)
    {
        bloodOverlay.SetActive(true);
        PlayerHP -= damageAmount;
        if(PlayerHP <= 0 )
        isGameOver = true;

        yield return new WaitForSeconds(1.5f);
        bloodOverlay.SetActive(false);
    }

}
