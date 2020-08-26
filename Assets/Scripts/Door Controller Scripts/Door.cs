using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door instance;

    private Animator myAnimator;
    private BoxCollider2D myBoxCollider;
    private GameplayController gameplayController;

    private int collectablesCount;

    void Awake() {
        MakeInstance();
        myAnimator = GetComponent<Animator> ();
        myBoxCollider = GetComponent<BoxCollider2D> ();
        gameplayController = GameObject.Find("Gameplay Controller").GetComponent<GameplayController>();
    }

    public void DecrementCollectables() {
        collectablesCount--;

        if(collectablesCount == 0) {
            StartCoroutine(OpenDoor());
        }
    }

    private void MakeInstance() {
        if(instance == null) {
            instance = this;
        }
    }

    private IEnumerator OpenDoor() {
        myAnimator.SetBool("Open", true);
        yield return new WaitForSeconds(0.7f);
        myBoxCollider.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            gameplayController.LevelComplete();
        }
    }

    public void SetCollectablesCount(int count) {
        collectablesCount = count;
    }

    public int GetCollectablesCount(){
        return collectablesCount;
    }
}
