using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text speedText, distanceText, spawnTimeText, warningSpeedText, warningDistanceText, warningSpawnTimeText;
    [SerializeField] private GameObject cubePrefab, spawnPoint;

    private float speed, distance, spawnTime, spawnTmr;
    private bool spawning;
    private GameObject cube;

    void Start()
    {
        spawning = true;

        spawnTmr = 1f;
    }

    private void UpdateParameters()
    {
        if (!float.TryParse(speedText.text, out speed))
            warningSpeedText.text = "Некорректно указана скорость";
        else
            warningSpeedText.text = "";

        if (!float.TryParse(distanceText.text, out distance))
            warningDistanceText.text = "Некорректно указана дистанция";
        else
            warningDistanceText.text = "";

        if (!float.TryParse(spawnTimeText.text, out spawnTime))
            warningSpawnTimeText.text = "Некорректно указано время спавна";
        else
            warningSpawnTimeText.text = "";

        if (warningSpeedText.text == "" & warningDistanceText.text == "" & warningSpawnTimeText.text == "")
            spawning = true;
        else
            spawning = false;
    }

    private void CreateCube()
    {
        ObjectMovement objMovement;
        
        cube = Instantiate(cubePrefab) as GameObject;
        cube.transform.SetParent(spawnPoint.transform, false);
        cube.transform.localPosition = Vector3.zero;

        objMovement = cube.GetComponent<ObjectMovement>();
        objMovement.speed = speed;
        objMovement.targetPoint = distance;

        spawnTmr = spawnTime;
    }

    void Update()
    {
        UpdateParameters();

        if (spawning)
        {
            spawnTmr -= Time.deltaTime;

            if (spawnTmr <= 0)
                CreateCube();
        }
    }
}
