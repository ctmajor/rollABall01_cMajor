using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PickupTrigger : MonoBehaviour
{
    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject instructionsObject;
    public GameObject countTextObject;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        instructionsObject.SetActive(true);
        countTextObject.SetActive(true);
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 1)
        {
            instructionsObject.SetActive(false);
        }

        if (count >= 12)
        {
            winTextObject.SetActive(true);
            countTextObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
}
