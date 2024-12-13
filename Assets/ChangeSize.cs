using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeSize : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject hitunganUI;
    private int panjang = 2;
    private int lebar = 2;
    private int tinggi = 2;
    private BlocksBuilder blocksBuilder;
    private HitungVolume hitungVolume;
    public TextMeshProUGUI textPanjang;
    public TextMeshProUGUI textLebar;
    public TextMeshProUGUI textTinggi;
    void Start()
    {
        blocksBuilder = targetObject.GetComponent<BlocksBuilder>();
        hitungVolume = hitunganUI.GetComponent<HitungVolume>();
        panjang = blocksBuilder.Panjang;
        lebar = blocksBuilder.Lebar;
        tinggi = blocksBuilder.Tinggi;
        hitungVolume.Ubah(panjang, lebar, tinggi);
        /*
        textPanjang.text = panjang.ToString();
        textLebar.text = lebar.ToString();
        textTinggi.text = tinggi.ToString();
        */
    }

    // Update is called once per frame
    void Update()
    {
        textPanjang.text = panjang.ToString();
        textLebar.text = lebar.ToString();
        textTinggi.text = tinggi.ToString();
    }
    //1 <= x < 10
    public void incrementpanjang() {
        if(panjang < 10)
        {
            panjang++;
        }
    }
    public void incrementlebar() {
        if(lebar < 10)
        {
            lebar++;
        }
    }
    public void incrementtinggi() {
        if(tinggi < 10)
        {
            tinggi++;
        }
    }
    public void decrementpanjang() { 
        if(panjang > 1)
        {
            panjang--;
        }
    }
    public void decrementlebar() {
        if (lebar > 1)
        {
            lebar--;
        }
    }
    public void decrementtinggi() {
        if (tinggi > 1)
        {
            tinggi--;
        }
    }
    public void changeTargetSize()
    {
        blocksBuilder.Ubah(panjang, lebar, tinggi);
        hitungVolume.Ubah(panjang, lebar, tinggi);
    }
}
