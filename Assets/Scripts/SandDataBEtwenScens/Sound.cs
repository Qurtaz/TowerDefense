using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Sound", menuName = "TransferData/Sound")]
public class Sound : ScriptableObject {
    [Range(0,100)]
    public int sound;
    public bool mute;
}
