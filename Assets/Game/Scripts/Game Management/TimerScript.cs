using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private float time = 0;
    public TMP_Text text;

    void Update()
    {
        time = Time.time + Time.deltaTime;
        text.text = time.ToString("00:00");
    }
}
