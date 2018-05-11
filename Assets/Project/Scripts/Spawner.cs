﻿using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject[] Prefabs;    // létrehozható prefabek
    public float Delay;             // idő másodpercekben a következő létrehozásig
    public bool Active = true;      // aktív-e az objektum
    public Vector2 DelayRange;      // minimum és maximum időintervallum a következő lehetséges létrehozásig

    private void Start() {
        ResetDelay();
        StartCoroutine(ObjectGenerator());    // coroutine indítása
    }

    private IEnumerator ObjectGenerator() {
        yield return new WaitForSeconds(Delay);    // várakozás Delay másodpercig

        if (Active) {    // ha aktív, létrehozzuk az új objektumot és új várakozási időt állítunk be
            GameObjectUtil.Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], transform.position);
            ResetDelay();
        }

        StartCoroutine(ObjectGenerator());    // meghívjuk újra a coroutinet
    }

    // beállítja a Delayt egy DelayRange közti random értékre
    private void ResetDelay() {
        Delay = Random.Range(DelayRange.x, DelayRange.y);
    }
}