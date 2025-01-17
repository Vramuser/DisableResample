using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using ScriptPortal.Vegas;

public class EntryPoint
{
    Vegas myVegas;

    public void FromVegas(Vegas vegas)
    {
        myVegas = vegas;
        bool resampleDisabled = false;

        foreach (Track track in myVegas.Project.Tracks)
        {
            if (track.MediaType == MediaType.Video)
            {
                foreach (TrackEvent evnt in track.Events)
                {
                    VideoEvent videoEvent = evnt as VideoEvent;
                    if (videoEvent != null && videoEvent.ResampleMode != VideoResampleMode.Disable)
                    {
                        videoEvent.ResampleMode = VideoResampleMode.Disable;
                        resampleDisabled = true;
                    }
                }
            }
        }
        
        if (resampleDisabled)
        {
            MessageBox.Show("Disabled resample for all vids on the timeline", "Resample Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("None were disabled", "Resample Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
//By Vramuser
