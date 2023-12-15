using Unity.VisualScripting;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour
{
    private AudioClip microphoneClip;
    private int sampleWindow = 64;

    void Start()
    {
        MicrophoneToAudioClip();
    }
    void Update()
    {
        Debug.Log(GetLoudnessFromMicroPhone()*100);
        ParticleController.OnVoiceBeingSpoken?.Invoke(0,GetLoudnessFromMicroPhone()*100);
    }

    private void MicrophoneToAudioClip(){
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }

    private float GetLoudnessFromMicroPhone(){
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }

    private float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip){
        int startPosition = clipPosition - sampleWindow;

        if(startPosition < 0){
            return 0;
        }

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0f;

        for(int i = 0; i < sampleWindow; i++){
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        return totalLoudness / sampleWindow;
    }


        
}
