using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject road;
    public GameObject roadWithObstacle;

    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField]private GameObject startingRoad;
    void GenerateRandomLevel()
    {
        //3 kalas yan yana olacak
        //kalasların uzunlukları değişecek (7 - 15 birim arası)
        //kalaslar arası mesafe sınırlandırılacak (max 8 birim)
        //yan yana duran kalasların arası her zaman aynı olacak (4 birim)
        //her zaman yan yana 3 kalas olacak
        //en sonuncu kalasta hep bir end işareti olacak
        //ende olan mesafeye göre fonksiyon yeni kalaslar üretecek

        
        
        ArrayList tumKalaslar = new ArrayList(30);
        int birSiradaOlacakKalasSayisi = 3;
        int kalasSatirSayisi = 10;

        
        //2 SATIR OLUŞTURUYOR
        //BUNUN 5 KERE DÖNMESİ LAZIM

        //Bİ TANE BAŞTA YOL OLACAK
        //SONRA ONU KULLANAR DİĞERLERİ
        //SONRA ONU SİL DİĞERLERİ KALSIN
        
        int satirSayisi = 0;
        GameObject lastRoad = new GameObject();
        lastRoad.transform.position = Vector3.zero;
        
        while (satirSayisi < kalasSatirSayisi / 2)
        {

            for (int i = 0; i < birSiradaOlacakKalasSayisi; i++)
            {

                int bosluk = Random.Range(5, 8);
                int randomScale = Random.Range(7, 15);
                int originlerArasıMesafe = Convert.ToInt32((startingRoad.transform.localScale.x)/2 + bosluk + randomScale/2);
                
                GameObject cloneRoad1 = Instantiate(road, new Vector3(lastRoad.transform.position.x + originlerArasıMesafe, lastRoad.transform.position.y,i*4),Quaternion.identity);
            
                //oluşturulan kalasın önüne kalas oluşturma
                GameObject oppositeRoad = Instantiate(road,
                    new Vector3(cloneRoad1.transform.position.x + originlerArasıMesafe, 0, cloneRoad1.transform.position.z),
                    Quaternion.identity);
                oppositeRoad.transform.localScale = new Vector3(randomScale, 1, 2);
                
                tumKalaslar.Add(cloneRoad1);
                tumKalaslar.Add(oppositeRoad);
           
            }

            lastRoad = (GameObject)tumKalaslar[tumKalaslar.Count-1];

            satirSayisi++;
        }
        
        
        
    }
}
