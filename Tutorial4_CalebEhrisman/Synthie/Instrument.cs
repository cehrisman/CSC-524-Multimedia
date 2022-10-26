using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Synthie
{
    public abstract class Instrument : AudioNode
    {
        public abstract void SetNote(Note note);
    }

    public class ToneInstrument : Instrument
    {
        private double duration;
        private SineWave sinewave = new SineWave();
        private double time;
        public double Frequency { get => sinewave.Frequency; set => sinewave.Frequency = value; }

        public ToneInstrument()
        {
            duration = 0.1;
        }


        public override bool Generate()
        {
            if (duration - time < 0.05)
                sinewave.Amp = duration - time;
            if (time < 0.05)
                sinewave.Amp = time;
            // Tell the component to generate an audio sample
            sinewave.Generate();

            // Read the component's sample and make it our resulting frame.
            frame[0] = sinewave.Frame(0);
            frame[1] = sinewave.Frame(1);
            // Update time
            time += samplePeriod;
            // We return true until the time reaches the duration.
            return time < duration;
        }

        public override void Start()
        {
            sinewave.SampleRate = SampleRate;
            //duration = 1.0 / (this.Bpm / 60.0);
            sinewave.Start();
            time = 0;

            //ar.Source = this;
            //ar.SampleRate = SampleRate;
            //ar.Start();
        }
        public override void SetNote(Note note)
        {
            duration = note.Count * (1 / (this.bpm / 60));
            Frequency = Notes.NoteToFrequency(note.Pitch);
        }
    }
}
