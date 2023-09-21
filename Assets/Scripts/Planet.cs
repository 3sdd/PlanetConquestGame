using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    [SerializeField]
    int maxNumShips = 10;

    [SerializeField]
    int currentNumShips = 0;

    [SerializeField]
    TextMeshProUGUI numShipsText;

    [SerializeField]
    Owner owner;

    [SerializeField]
    Image ringImage;

    private void Start()
    {
        UpdateCurrentNumShips(0);

        // 
        ringImage.color = owner.GetColor();
        print(ringImage.color);

        StartCoroutine(GenerateNewShipsCoroutine());
    }



    IEnumerator GenerateNewShipsCoroutine()
    {
        while (true)
        {

            yield return new WaitForSeconds(1);


            UpdateCurrentNumShips(currentNumShips + 1);

        }
    }

    void UpdateCurrentNumShips(int numShips)
    {
        currentNumShips = numShips;
        numShipsText.text = numShips.ToString();
    }



}
