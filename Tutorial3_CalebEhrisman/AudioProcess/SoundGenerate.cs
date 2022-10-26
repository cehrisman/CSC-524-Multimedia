using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioProcess
{
    public struct SineParams
    {
        public float freq1;
        public float freq2;
        public float sampleRate;
        public float amplitude;
    }
    class SoundGenerate
    {


        private SineParams sineParams;

        public SoundGenerate()
        {
            sineParams.freq1 = 440.0f;
            sineParams.freq2 = 440.0f;
            sineParams.amplitude = 1f;
        }

        public void MakeParamSine()
        {
            Generic_Sine dlg = new Generic_Sine(sineParams);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sineParams = dlg.SineParams;
            }
        }


       


        /// <summary>
        ///      Example procedure that generates a sine wave.
        ///      The sine wave frequency is set by freq1
        ///
        /// </summary>
        /// <param name="sound">The Sound to fill</param>
        public void MakeSine(SoundChunk sound)
        {

            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Generation Error");
                return;
            }

            //pull needed sound file encoding parameters
            int sampleRate = sound.SampleRate;
            float duration = sound.Duration - 1.0f / sampleRate;

            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();

            //make the sine wave
            for (double time = 0.0; time < duration; time += 1.0 / sampleRate)
            {
                //make the value at this frame
                float val = (float)(sineParams.amplitude * Math.Sin(time * 2 * Math.PI * sineParams.freq1));

                sound.WriteNextFrame(val);

                progress.UpdateProgress(time / duration);
            }
        }

        public void MakeSineAdditive(SoundChunk sound)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Generation Error");
                return;
            }

            //pull needed sound file encoding parameters
            int sampleRate = sound.SampleRate;
            float duration = sound.Duration - 1.0f / sampleRate;

            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();

            //make the sine wave
            for (double time = 0.0; time < duration; time += 1.0 / sampleRate)
            {
                //make the values at this frame
                float val = (float)(sineParams.amplitude * Math.Sin(time * 2 * Math.PI * sineParams.freq1));
                float val2 = (float)(sineParams.amplitude * Math.Sin(time * 2 * Math.PI * sineParams.freq2));

                //sanity check for stereo
                if (sound.Channels != 2)
                    sound.WriteNextFrame(val);
                else
                {
                    float[] frame = { val, val2 };
                    sound.WriteNextFrame(frame);
                }
            }
        }
        public void MakeSineAdditive246(SoundChunk sound)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Generation Error");
                return;
            }

            //pull needed sound file encoding parameters
            int sampleRate = sound.SampleRate;
            float duration = sound.Duration - 1.0f / sampleRate;

            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();

            //make the sine wave
            for (double time = 0.0; time < duration; time += 1.0 / sampleRate)
            {
                //make the values at this frame
                float val = (float)((sineParams.amplitude * Math.Sin(time * 2 * Math.PI * sineParams.freq1)) +
                                    (sineParams.amplitude/2 * Math.Sin(time * 2 * Math.PI * sineParams.freq1*2)) +
                                    (sineParams.amplitude/3 * Math.Sin(time * 2 * Math.PI * sineParams.freq1*3)) +
                                    (sineParams.amplitude/4 * Math.Sin(time * 2 * Math.PI * sineParams.freq1*4)));

                float val2 = val;

                //sanity check for stereo
                if (sound.Channels != 2)
                    sound.WriteNextFrame(val);
                else
                {
                    float[] frame = { val, val2 };
                    sound.WriteNextFrame(frame);
                }
            }
        }
        public void MakeSineAdditive357(SoundChunk sound)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Generation Error");
                return;
            }

            //pull needed sound file encoding parameters
            int sampleRate = sound.SampleRate;
            float duration = sound.Duration - 1.0f / sampleRate;

            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();

            //make the sine wave
            for (double time = 0.0; time < duration; time += 1.0 / sampleRate)
            {
                //make the values at this frame

                float val = (float)((sineParams.amplitude * Math.Sin(time * 2 * Math.PI * sineParams.freq1)) +
                                    (sineParams.amplitude / 3 * Math.Sin(time * 2 * Math.PI * sineParams.freq1 * 3)) +
                                    (sineParams.amplitude / 5 * Math.Sin(time * 2 * Math.PI * sineParams.freq1 * 5)) +
                                    (sineParams.amplitude / 7 * Math.Sin(time * 2 * Math.PI * sineParams.freq1 * 7)));
                float val2 = val;

                //sanity check for stereo
                if (sound.Channels != 2)
                    sound.WriteNextFrame(val);
                else
                {
                    float[] frame = { val, val2 };
                    sound.WriteNextFrame(frame);
                }
            }
        }
        public void MakeSineAdditiveAll(SoundChunk sound)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Generation Error");
                return;
            }

            //pull needed sound file encoding parameters
            int sampleRate = sound.SampleRate;
            float duration = sound.Duration - 1.0f / sampleRate;
            
            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();
            int num_harm = (int)(sampleRate / sineParams.freq1);
            //make the sine wave
            for (double time = 0.0; time < duration; time += 1.0 / sampleRate)
            {
                //make the values at this frame
                float val = 0.0f;

                for (int i = 1; i < num_harm; i++)
                {
                    //Debug.WriteLine($"{i}");
                    val += (float)((sineParams.amplitude / i * Math.Sin(time * 2 * Math.PI * sineParams.freq1 / i)));
                }
                float val2 = val;
                //sanity check for stereo
                if (sound.Channels != 2)
                    sound.WriteNextFrame(val);
                else
                {
                    float[] frame = { val, val2 };
                    sound.WriteNextFrame(frame);
                }
            }
        }
        public void MakeSineAdditiveAllOdd(SoundChunk sound)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Generation Error");
                return;
            }

            //pull needed sound file encoding parameters
            int sampleRate = sound.SampleRate;
            float duration = sound.Duration - 1.0f / sampleRate;
            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();
            Debug.WriteLine($"{sampleRate}");
            int num_harm = (int)(sampleRate / sineParams.freq1);
            //make the sine wave
            for (double time = 0.0; time < duration; time += 1.0 / sampleRate)
            {
                //make the values at this frame

                float val = 0.0f;
                for (int i = 1; i < num_harm; i+=2)
                {
                    val += (float)((sineParams.amplitude / i * Math.Sin(time * 2 * Math.PI * sineParams.freq1 / i)));
                }
                float val2 = val;
                //sanity check for stereo
                if (sound.Channels != 2)
                    sound.WriteNextFrame(val);
                else
                {
                    float[] frame = { val, val2 };
                    sound.WriteNextFrame(frame);
                }
            }
        }

    }
}
