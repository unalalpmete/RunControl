using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Alp;

public class GameManager : MonoBehaviour
{
    //public GameObject DogmaNoktasi; // sayisal bloklara degdigi anda olusturacagimiz icin artýk dogmanoktasina gerek yok
    
    public static int AnlikKarakterSayisi = 1; 

    public List<GameObject> Karakterler; // object pooling sistemi icinde tuttugumuz karakterleri liste icinde sakliyoruz.
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfektleri;
    public List<GameObject> AdamLekesiEfektleri;

    [Header("LEVEL VERÝLERÝ")]
    public List<GameObject> Dusmanlar;
    public int KacDusmanOlsun;
    public GameObject _AnaKarakter;
    public bool OyunBittimi;
    bool SonaGeldikmi;

    void Start()
    {
        DusmanlariOlustur();
    }

    public void DusmanlariOlustur()
    {
        for (int i = 0; i < KacDusmanOlsun; i++)
        {
            Dusmanlar[i].SetActive(true); 
        }
    }

    public void DusmanlariTetikle()
    {
        foreach (var item in Dusmanlar)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<Dusman>().AnimasyonTetikle();
            }
        }
        SonaGeldikmi = true;
        SavasDurumu();
    }


    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (var item in Karakterler) // foreach listedekileri dolasir
            {
                if (!item.activeInHierarchy) // hirerarchide aktif olmayani buldugu an onu olusturur
                {
                    item.transform.position = DogmaNoktasi.transform.position;
                    item.SetActive(true);
                    AnlikKarakterSayisi++;
                    break; // 1 kere olusturduktan sonra devam etmesin diye cikariz donguden
                }
            }
        }*/
    }

    void SavasDurumu()
    {
        if (SonaGeldikmi == true)
        {
            if (AnlikKarakterSayisi == 1 || KacDusmanOlsun == 0)
            {
                OyunBittimi = true;
                foreach (var item in Dusmanlar)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldir", false);
                    }
                }
                foreach (var item in Karakterler)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldir", false);
                    }
                }

                _AnaKarakter.GetComponent<Animator>().SetBool("Saldir", false);

                if (AnlikKarakterSayisi < KacDusmanOlsun || AnlikKarakterSayisi == KacDusmanOlsun)
                {
                    Debug.Log("Kaybettin");
                }
                else
                {
                    Debug.Log("Kazandýn");
                }
            }
        }

        
    }

    public void AdamYonetimi(string islemturu, int GelenSayi, Transform Pozisyon)
    {
        switch (islemturu)
        {
            case "Carpma":
                Matematiksel_islemler.Carpma(GelenSayi,Karakterler,Pozisyon, OlusmaEfektleri);
                break;
            case "Toplama":
                Matematiksel_islemler.Toplama(GelenSayi, Karakterler, Pozisyon, OlusmaEfektleri);
                break;
            case "Cikartma":
                Matematiksel_islemler.Cikartma(GelenSayi, Karakterler, YokOlmaEfektleri); // cikarma ve bolmede yeni bir pozisyona ihtiyac yok
                break;
            case "Bolme":
                Matematiksel_islemler.Bolme(GelenSayi, Karakterler, YokOlmaEfektleri);
                break;
        }
    }

    public void YokOlmaEfektiOlustur(Vector3 Pozisyon, bool Balyoz = false, bool Durum = false)
    {
        foreach (var item in YokOlmaEfektleri)
        {
            if (!item.activeInHierarchy) // hirerarchide aktif olmayani buldugu an onu olusturur
            {
                item.SetActive(true);
                item.transform.position = Pozisyon;
                item.GetComponent<ParticleSystem>().Play(); // efekt calisacak
                item.GetComponent<AudioSource>().Play();
                if (Durum == false)
                    AnlikKarakterSayisi--;
                else
                    KacDusmanOlsun--;
                break;
            }
        }
        

        if (Balyoz == true)
        {
            Vector3 yeniPoz = new Vector3(Pozisyon.x, 0.005f, Pozisyon.z);
            foreach (var item in AdamLekesiEfektleri)
            {
                if (!item.activeInHierarchy) // hirerarchide aktif olmayani buldugu an onu olusturur
                {
                    item.SetActive(true);
                    item.transform.position = yeniPoz;
                    break;
                }
            }
        }

        if(OyunBittimi == false)
            SavasDurumu();

    }

   

}
