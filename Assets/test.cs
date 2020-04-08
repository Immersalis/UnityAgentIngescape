using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ingescape;
using System;
using System.IO;

public class test : MonoBehaviour
{
    igs_observeCallback callbackLabelString;
    igs_observeCallback callbackLabelDouble;

    // Start is called before the first frame update
    void Start()
    {
        InitIngescape();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CallbackString(iop_t iopType, string name, iopType_t valueType, IntPtr value, int valueSize, IntPtr myData)
    {
        Igs.writeOutputAsString("string", "patate");
    }

    private void InitIngescape()
    {
        Igs.setAgentName("UnityAgent");
        
        Igs.createOutput("string", iopType_t.IGS_STRING_T, IntPtr.Zero, 0);

        /*
        Igs.addMappingEntry("stringOutput", "WpfAgent", "stringEntry");
        Igs.setMappingDescription("send string from unity to wpf");
        Igs.setMappingName("MappingUnityWpf");
        */
        
        callbackLabelString = CallbackString;

        Igs.observeOutput("string", callbackLabelString, IntPtr.Zero);
        using (StreamReader r = new StreamReader("mapping.json"))
        {
            string json = r.ReadToEnd();
            Debug.Log(json);
            Igs.loadMapping(json);
            Debug.Log(Igs.getMappingName());


        }
       
        

        Igs.startWithDevice("Wi-Fi", 5670);
    }
}
