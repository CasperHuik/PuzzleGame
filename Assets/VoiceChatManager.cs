using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror; 
using Steamworks; 

public class VoiceChatManager : NetworkBehaviour
{

    public AudioSource[] audioSources;  
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    [TargetRpc (channel = 2)]
    public void Target_PlaySound(NetworkConnection conn, byte[] destBuffer, uint bytesWritten, float voiceVolume, int fromWho)
    {
        //if(fromWho == gamePlayer.ConnectionId){return;}
        Debug.Log("Target");
        byte[] destBuffer2 = new byte[22050 * 2];
        uint bytesWritten2;
        EVoiceResult ret = SteamUser.DecompressVoice(destBuffer, bytesWritten, destBuffer2, (uint)destBuffer2.Length, out bytesWritten2, 22050);
        if(ret == EVoiceResult.k_EVoiceResultOK && bytesWritten2 > 0)
        {
            audioSource.clip = AudioClip.Create(UnityEngine.Random.Range(100, 1000000).ToString(), 22050, 1, 22050, false);
 
            float[] test = new float[22050];
            for (int i = 0; i < test.Length; i++)
            {
                test[i] = (short)(destBuffer2[i * 2] | destBuffer2[i * 2 + 1] << 8) / 32768.0f;
            }
            audioSource.clip.SetData(test, 0);
            audioSource.volume = voiceVolume;
            
            audioSource.Play();
        }
    }
}
