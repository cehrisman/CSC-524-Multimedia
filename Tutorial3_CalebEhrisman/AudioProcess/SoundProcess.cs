using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioProcess
{
    class SoundProcess
    {
        public SoundProcess()
        {
        }

        /// <summary>
        /// Increases or descrease the volume of a sound
        /// </summary>
        /// <param name="sound">the sound to change</param>
        /// <param name="volume">the new amplitude multiplier</param>
        public void OnProcessVolume(SoundChunk sound, float volume)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Process Error");
                return;
            }


            //pull needed sound file encoding parameters
            int n = sound.FrameCount;

            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();

            for (int i = 0; i < n; i++)
            {
                float[] temp = sound.GetFrame(i);
                for(int c = 0; c < temp.Length; c++)
                    sound.SetFrame(temp[c] * volume, i, c);

                progress.UpdateProgress( (double)i / n);
            }
        }

        public void Ramp(SoundChunk sound)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Process Error");
                return;
            }


            //pull needed sound file encoding parameters
            int n = sound.FrameCount;

            // Keep track of time
            float time = 0;

            //store channels for easy lookup
            int channels = sound.Channels;

            //number of frames to process
            int count = sound.FrameCount;

            //time duration of one frame
            float frameDuration = 1.0f / sound.SampleRate;

            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();

            for (int i = 0; i < count; i++, time += frameDuration)
            {
                float[] temp = sound.GetFrame(i);

                float ramp;
                if (time < 0.5)
                {
                    ramp = time / 0.5f;
                }
                else
                {
                    ramp = 1;
                }

                for (int c = 0; c < temp.Length; c++)
                    sound.SetFrame(temp[c] * ramp, i, c);

                progress.UpdateProgress((double)i / n);
            }
        }

        public void RampInOut(SoundChunk sound)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Process Error");
                return;
            }


            //pull needed sound file encoding parameters
            int n = sound.FrameCount;

            // Keep track of time
            float time = 0;

            //store channels for easy lookup
            int channels = sound.Channels;

            //number of frames to process
            int count = sound.FrameCount;

            //time duration of one frame
            float frameDuration = 1.0f / sound.SampleRate;
            int total_time = (int)sound.Duration;
            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();
            Debug.WriteLine($"{total_time}");
            for (int i = 0; i < count; i++, time += frameDuration)
            {
                float[] temp = sound.GetFrame(i);

                float ramp;
                if (time < 1.5)
                {
                    ramp = time * 2.0f;
                }
                else if (time < 3.0)
                {
                    //Debug.WriteLine($"{time}");
                    ramp = (3.0f - time) * 2.0f;
                }
                else
                    ramp = 0f;

                for (int c = 0; c < temp.Length; c++)
                    sound.SetFrame(temp[c] * ramp, i, c);

                progress.UpdateProgress((double)i / n);
            }
        }

        public void Tremolo(SoundChunk sound, float depth, float freq)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Process Error");
                return;
            }


            //pull needed sound file encoding parameters
            int n = sound.FrameCount;

            // Keep track of time
            float time = 0;

            //store channels for easy lookup
            int channels = sound.Channels;

            //number of frames to process
            int count = sound.FrameCount;

            //time duration of one frame
            float frameDuration = 1.0f / sound.SampleRate;
            int total_time = (int)sound.Duration;
            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();
            Debug.WriteLine($"{total_time}");
            for (int i = 0; i < count; i++, time += frameDuration)
            {
                float[] temp = sound.GetFrame(i);

                float a = (float)(1 + depth * Math.Sin(freq * 2 * Math.PI * time));

                for (int c = 0; c < temp.Length; c++)
                    sound.SetFrame(temp[c] * a, i, c);

                progress.UpdateProgress((double)i / n);
            }
        }
        public void slow(SoundChunk sound, SoundChunk sound_slow)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Process Error");
                return;
            }


            //pull needed sound file encoding parameters
            int n = sound.FrameCount;

            // Keep track of time
            float time = 0;

            //store channels for easy lookup
            int channels = sound.Channels;

            //number of frames to process
            int count = sound.FrameCount;

            //time duration of one frame
            float frameDuration = 1.0f / sound.SampleRate;
            int total_time = (int)sound.Duration;
            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();
            int slow_count = 0;
            Debug.WriteLine($"{total_time}");
            for (int i = 0; i < count-1; i++, time += frameDuration)
            {
                float[] temp = sound.GetFrame(i);
                float[] temp2 = sound.GetFrame(i+1);
                
                for (int c = 0; c < temp.Length; c++)
                {
                    sound_slow.SetFrame(temp[c], slow_count, c);

                    sound_slow.SetFrame((temp2[c] + temp[c]) / 2, slow_count+1, c);
                }
                slow_count += 2;

                progress.UpdateProgress((double)i / n);
            }
        }
        public void fast(SoundChunk sound, SoundChunk sound_fast)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Process Error");
                return;
            }


            //pull needed sound file encoding parameters
            int n = sound.FrameCount;

            // Keep track of time
            float time = 0;

            //store channels for easy lookup
            int channels = sound.Channels;

            //number of frames to process
            int count = sound.FrameCount;

            //time duration of one frame
            float frameDuration = 1.0f / sound.SampleRate;

            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();
            
            for (int i = 0; i < count - 1; i+=2, time += frameDuration)
            {
                float[] temp = sound.GetFrame(i);
                float[] temp2 = sound.GetFrame(i + 1);

                for (int c = 0; c < temp.Length; c++)
                {
                    sound_fast.SetFrame((temp[c] + temp2[c])/2, i/2, c);
                }


                progress.UpdateProgress((double)i / n);
            }
        }

        public void backwards(SoundChunk sound, SoundChunk backward)
        {
            if (sound == null)
            {
                MessageBox.Show("Need a sound loaded first", "Process Error");
                return;
            }


            //pull needed sound file encoding parameters
            int n = sound.FrameCount;

            // Keep track of time
            float time = 0;

            //store channels for easy lookup
            int channels = sound.Channels;

            //number of frames to process
            int count = sound.FrameCount;

            //time duration of one frame
            float frameDuration = 1.0f / sound.SampleRate;

            //setup progress bar
            ProgressBar progress = new ProgressBar();
            progress.Runworker();

            for (int i = 0; i < count - 1; i += 2, time += frameDuration)
            {
                float[] temp = sound.GetFrame(i);

                for (int c = 0; c < temp.Length; c++)
                {
                    backward.SetFrame(temp[c], count - i - 1 , c);
                }


                progress.UpdateProgress((double)i / n);
            }
        }
    }
}
