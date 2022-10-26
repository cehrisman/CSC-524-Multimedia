using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    public abstract class AudioNode
    {
        protected double[] frame = new double[2];
        protected double samplePeriod;
        protected int sampleRate;
        protected double secperbeat;
        protected double bpm;

        /// <summary>
        /// Access a generated audio frame
        /// </summary
        /// ><returns>the sound sample</returns>
        public double[] Frame() { return frame; }

        /// <summary>
        /// Access one channel of a generated audio frame
        /// </summary>
        /// <param name="c">the channel</param>
        /// <returns>the value of at the channel in the sound sample</returns>
        public double Frame(int c) { return frame[c]; }

        public int SampleRate { get => sampleRate; set => sampleRate = value; }
        public double Secperbeat { get => secperbeat; set => secperbeat = value; }
        public double Bpm { get => bpm; set => bpm = value; }

        /// <summary>
        /// Cause one sample to be generated
        /// </summary>
        /// <returns>Returns true if there are remainng smaples to generate</returns>
        public abstract bool Generate();

        /// <summary>
        /// Start the node generation
        /// </summary>
        public abstract void Start();

        public AudioNode()
        {
            frame[0] = 0;
            frame[1] = 0;
            sampleRate = 44100;
            samplePeriod = 1.0 / 44100;
        }
    }

    public class SineWave : AudioNode
    {
        private double freq;
        private double amp;
        private double phase;

        public double Frequency { get => freq; set => freq = value; }
        public double Amp{ get => amp; set => amp = value; }
        public SineWave()
        {
            phase = 0;
            amp = 0.1;
            freq = 440;
        }

        public override void Start()
        {
            phase = 0;
        }

        public override bool Generate()
        {
            frame[0] = amp * Math.Sin(phase * 2 * Math.PI);
            frame[1] = frame[0];

            phase += freq * samplePeriod;

            return true;
        }
    }


}
