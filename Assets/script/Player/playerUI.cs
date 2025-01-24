using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promtText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateText(string promptMassage)
    {
        promtText.text = promptMassage;
    }
}
