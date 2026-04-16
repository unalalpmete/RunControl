using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Alp // bu namespace icerisinde farkli seyleri yapacak olan farkli classlari olusturabiliriz
{
    public class Matematiksel_islemler : MonoBehaviour
    {
        // diger scriptlerden kolayca erisebilelim diye static tanimladik
        public static void Carpma(int GelenSayi, List<GameObject> Karakterler, Transform Pozisyon, List<GameObject> OlusturmaEfektleri)
        {
            int DonguSayisi = (GameManager.AnlikKarakterSayisi * GelenSayi) - GameManager.AnlikKarakterSayisi;
            //                               10                       3                    10      = 20
            //                                5                       6                     5      = 25
            int sayi = 0;
            foreach (var item in Karakterler) // foreach listedekileri dolasir
            {
                if (sayi < DonguSayisi)
                {
                    if (!item.activeInHierarchy) // hirerarchide aktif olmayani buldugu an onu olusturur
                    {
                        foreach (var item2 in OlusturmaEfektleri)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                // efektin olusacagi pozisyona karakterin olustugu yerin(x2 tabelasý fln) pozisyonunu verdik(y degerini degistircez sonradan)
                                item2.transform.position = Pozisyon.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                item2.GetComponent<AudioSource>().Play();
                                break; // 1 kere olusunca diger efektleri dolasmasin diye break deriz
                            }
                        }

                        item.transform.position = Pozisyon.position;
                        item.SetActive(true);
                        sayi++;

                    }
                }
                else
                {
                    sayi = 0;
                    break; // 1 kere olusturduktan sonra devam etmesin diye cikariz donguden
                }

            }
            GameManager.AnlikKarakterSayisi *= GelenSayi; // tum islemler bittiginde karakter sayisi 2 katina cikcak
            
        }

        public static void Toplama(int GelenSayi, List<GameObject> Karakterler, Transform Pozisyon, List<GameObject> OlusturmaEfektleri)
        {
            int sayi2 = 0;
            foreach (var item in Karakterler) // foreach listedekileri dolasir
            {
                if (sayi2 < GelenSayi) // anlikkaraktersayisindan bagimsiz her zaman +gelensayi eklencek yani dongu gelensayi kere doner
                {
                    if (!item.activeInHierarchy) // hirerarchide aktif olmayani buldugu an onu olusturur
                    {
                        foreach (var item2 in OlusturmaEfektleri)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                // efektin olusacagi pozisyona karakterin olustugu yerin(x2 tabelasý fln) pozisyonunu verdik(y degerini degistircez sonradan)
                                item2.transform.position = Pozisyon.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                item2.GetComponent<AudioSource>().Play();
                                break; // 1 kere olusunca diger efektleri dolasmasin diye break deriz
                            }
                        } 

                        item.transform.position = Pozisyon.position;
                        item.SetActive(true);
                        sayi2++;

                    }
                }
                else
                {
                    sayi2 = 0;
                    break; // 1 kere olusturduktan sonra devam etmesin diye cikariz donguden
                }

            }
            GameManager.AnlikKarakterSayisi += GelenSayi;
        }

        public static void Cikartma(int GelenSayi, List<GameObject> Karakterler, List<GameObject> YokOlmaEfektleri)
        {
            if (GameManager.AnlikKarakterSayisi < GelenSayi)
            {
                foreach (var item in Karakterler)
                {
                    foreach (var item2 in YokOlmaEfektleri)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 yeniPoz = new Vector3(item.transform.position.x, 0.18f, item.transform.position.z);

                            item2.SetActive(true);
                            // efektin olusacagi pozisyona karakterin pozisyonunu verdik(y degerini degistircez sonradan)
                            item2.transform.position = yeniPoz;
                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().Play();
                            break; // 1 kere olusunca diger efektleri dolasmasin diye break deriz
                        }
                    }

                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.AnlikKarakterSayisi = 1;
            }
            else
            {
                int sayi3 = 0;
                foreach (var item in Karakterler) // foreach listedekileri dolasir
                {
                    if (sayi3 < GelenSayi) // gelensayi kadar cikarilir
                    {
                        if (item.activeInHierarchy) // yok etme islemini hirerarchide aktif olanlardan yapariz
                        {
                            
                            foreach (var item2 in YokOlmaEfektleri)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 yeniPoz = new Vector3(item.transform.position.x, 0.18f, item.transform.position.z);

                                    item2.SetActive(true);
                                    // efektin olusacagi pozisyona karakterin pozisyonunu verdik(y degerini degistircez sonradan)
                                    item2.transform.position = yeniPoz;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    item2.GetComponent<AudioSource>().Play();
                                    break; // 1 kere olusunca diger efektleri dolasmasin diye break deriz
                                }
                            }


                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi3++;

                        }
                    }
                    else
                    {
                        sayi3 = 0;
                        break; // 1 kere olusturduktan sonra devam etmesin diye cikariz donguden
                    }

                }
                GameManager.AnlikKarakterSayisi -= GelenSayi;
            }
        }

        public static void Bolme(int GelenSayi, List<GameObject> Karakterler, List<GameObject> YokOlmaEfektleri)
        {
            if (GameManager.AnlikKarakterSayisi <= GelenSayi)
            {
                foreach (var item in Karakterler)
                {
                    foreach (var item2 in YokOlmaEfektleri)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 yeniPoz = new Vector3(item.transform.position.x, 0.18f, item.transform.position.z);

                            item2.SetActive(true);
                            // efektin olusacagi pozisyona karakterin pozisyonunu verdik(y degerini degistircez sonradan)
                            item2.transform.position = yeniPoz;
                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().Play();
                            break; // 1 kere olusunca diger efektleri dolasmasin diye break deriz
                        }
                    }

                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.AnlikKarakterSayisi = 1;
            }
            else
            {
                int bolen = GameManager.AnlikKarakterSayisi / GelenSayi;
                int sayi3 = 0;
                foreach (var item in Karakterler) // foreach listedekileri dolasir
                {
                    if (sayi3 < bolen) 
                    {
                        if (item.activeInHierarchy) // yok etme islemini hirerarchide aktif olanlardan yapariz
                        {
                            foreach (var item2 in YokOlmaEfektleri)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 yeniPoz = new Vector3(item.transform.position.x, 0.18f, item.transform.position.z);

                                    item2.SetActive(true);
                                    // efektin olusacagi pozisyona karakterin pozisyonunu verdik(y degerini degistircez sonradan)
                                    item2.transform.position = yeniPoz;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    item2.GetComponent<AudioSource>().Play();
                                    break; // 1 kere olusunca diger efektleri dolasmasin diye break deriz
                                }
                            } 

                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi3++;

                        }
                    }
                    else
                    {
                        sayi3 = 0;
                        break; // 1 kere olusturduktan sonra devam etmesin diye cikariz donguden
                    }

                }

                if (GameManager.AnlikKarakterSayisi % GelenSayi == 0)
                {
                    GameManager.AnlikKarakterSayisi /= GelenSayi;
                }
                else if (GameManager.AnlikKarakterSayisi % GelenSayi == 1)
                {
                    // 2ye bolup 1 arttirdik
                    // 9 karakteri 2ye boldugumuzde 4 cýkar ve 4 azaltýrýz 5 karakter elde kalir ama
                    // anlikkaraktersayisi degiskeninde 9/2 = 4 gozükür. 5e tamamlamak icin sonda 1 arttirdik.
                    GameManager.AnlikKarakterSayisi /= GelenSayi;
                    GameManager.AnlikKarakterSayisi++;
                }
                else if(GameManager.AnlikKarakterSayisi % GelenSayi == 2)
                {
                    GameManager.AnlikKarakterSayisi /= GelenSayi;
                    GameManager.AnlikKarakterSayisi +=2;
                }

            }
        }
    }
}
