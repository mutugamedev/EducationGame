using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptsCounter : MonoBehaviour
{
    [SerializeField]
    int maxAttempts, attempts;
    public static AttemptsCounter instance;

    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (attempts >= maxAttempts)
        {
            Debug.Log("Anda kalah, terlalu banyak percobaan");
            attempts = 0;
            ButtonFunction.instance.ResetButton();
        }
    }

    public void IncreaseAttempts()
    {
        attempts++;
        Debug.Log(attempts);
    }
}
