using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject NothingBlock;
    public GameObject MoveBlock;
    public GameObject AttackBlock;
    public GameObject ShieldBlock;

    public RaycastHit[] hits;

    Vector3 InstantiatePosition;

    List<GameObject> blocks = new List<GameObject>();

    private void Start() {
        blocks.Add(NothingBlock);
        blocks.Add(MoveBlock);
        blocks.Add(AttackBlock);
        blocks.Add(ShieldBlock);
    }

    void OnMouseDown(){
        Ray ray = new Ray(transform.position, transform.up);
        hits = Physics.RaycastAll(ray, 10f, 1<<6);

        foreach(RaycastHit obj in hits){
            obj.transform.Translate(ray.direction * 1.1f);
        }

        StartCoroutine("Instantiate");
    }

    IEnumerator Instantiate(){
        int random = Random.Range(0,4);

        yield return new WaitForSeconds(1);

        Ray ray2 = new Ray(transform.position, transform.up);
        RaycastHit hitData;
        if(Physics.Raycast(ray2, out hitData)){
            InstantiatePosition = hitData.transform.position;
            Debug.Log(hitData.transform.name);
        }

        Instantiate(blocks[random], InstantiatePosition, Quaternion.identity);
    }

}
