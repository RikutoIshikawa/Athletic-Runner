using UnityEngine;

//棒を回転させ続けるスクリプト
public class RodManager : MonoBehaviour
{
    ////////////////////
    //アップデート関数//
    ////////////////////
    void Update()
    {
        //Z軸を0.2度づつ回転させ続ける
        transform.Rotate(new Vector3(0, 0, 0.2f));
    }
}
