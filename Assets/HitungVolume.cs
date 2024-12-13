using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitungVolume : MonoBehaviour
{

    public TextMeshProUGUI textRumus;
    public TextMeshProUGUI textHasilHitung;
    private int Volume;

    public void Ubah(int panjang, int lebar, int tinggi)
    {
        textRumus.text = "Volume = " + panjang.ToString() + " x " + lebar.ToString() + " x " + tinggi.ToString();
        Volume = panjang * lebar * tinggi;
        textHasilHitung.text = " Volume = " + Volume.ToString();
    }
}
