using UnityEngine;
using System.Collections;

public class MusicStarter : MonoBehaviour
{

    [SerializeField] private MusicController controller;
    [SerializeField] private int levelMusic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))

            switch (levelMusic)
            {
                case 1:
                    controller.PlayLevel1Music();
                    break;
                case 2:
                    controller.PlayLevel2Music();
                    break;
                case 3:
                default:
                    controller.PlayLevel3Music();
                    break;
            }
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
