using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI tiempotext, puntuaciontext;
    public int puntuacion = 0;
    public int tiempo = 0;
    public static GameManager reference;
    public void Awake()
    {
        if (reference == null)
            reference = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        puntuacion = 0;
        tiempo = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //tiempo += (int)Time.time;
        //float tiempoDecimales = tiempo * 0.100f;
        float tiempoDecimales = Time.realtimeSinceStartup;
        tiempotext.text = tiempoDecimales.ToString("0.00");
    }
}
