/*Mark off what items are complete (e.g. x, done, checkmark, etc), and put a P if partially complete. If 'P' include how to test what is working for partial credit below the checklist line.

Total available points:  100(105 for grdaute level)

___X___  20  Tutorial completed(if not, what was the last section completed)
___X___ 5       CSC\CENG 524 ONLY What happened: < When the sampling rate cannot keep up with the actual sound frequency it will then tend to record a different 
                                                  frequency that the 0 and peak match that is within the range of the sampling frequency. For example, a tone
                                                  100hz above the Nyquist Frequency is going to be sampled as a tone 100hz below the Nyquist Frequency. So in
                                                  the case of these sample tones the 8500 sounds the same as the 7500. >
___X___  5   234 Menu Option
___X___	5	357 Menu Option
___X___	10	All Harmonics Option 
___X___	5	Odd Harmonics Option
___X___	10	Ramp In/Out
___X___	10	Tremolo
___X___	10	Half Speed
___X___	10	Backwards
___X___	10	Double speed
___X___  5   Did you hear it? (Completion points)
			NASA Statement about Roswell: __3__
            Joran van der Sloot: __9__
            Nancy Pelosi: __6__
___105___	Total (please add the points and include the total here)


The grade you compute is the starting point for course staff, who reserve the right to change the grade if they disagree with your assessment and to deduct points for other issues they may encounter, such as errors in the submission process, naming issues, etc.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace AudioProcess
{
 

    public partial class MainForm : Form
    {

        private SoundChunk sound = null;
        private String lastFile = null;
        private SoundView soundRendering = new SoundView();
        private SoundGenerate gen = new SoundGenerate();
        private SoundProcess process = new SoundProcess();

        public MainForm()
        {
            InitializeComponent();
           
            //define the area to display the sound waves
            Rectangle drawArea = ClientRectangle;
            drawArea.Y = menuStrip1.Height;
            soundRendering.DrawArea = drawArea;
            soundRendering.SamplesPerPeak = vScrollBar.Value;
            saveItem.Enabled = false;

            DoubleBuffered = true;
        }

        #region Callbacks
        protected override void OnPaint(PaintEventArgs e)
        {
            if (sound == null)
                return;

            soundRendering.OnPaint(e.Graphics);
        }

        protected override void OnResize(EventArgs e)
        {
            
            base.OnResize(e);

            Rectangle drawArea = ClientRectangle;
            drawArea.Y = menuStrip1.Height;
            soundRendering.DrawArea = drawArea;

            Invalidate();
        }
        #endregion

        #region Menu Handlers
        private void closeItem_Click(object sender, EventArgs e)
        {
            sound = null;
            Invalidate();

        }

        private void darkModeItem_Click(object sender, EventArgs e)
        {
            soundRendering.MakeDarkFormat();
            Invalidate();
        }

        private void exitItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            soundRendering.SetOffsetFromPercent((double)e.NewValue / (hScrollBar.Maximum - hScrollBar.Minimum));

            Invalidate();
        }

        private void lightModeItem_Click(object sender, EventArgs e)
        {
            soundRendering.MakeLightFormat();
            Invalidate();
        }

        private void newMenu_Click(object sender, EventArgs e)
        {
            NewSound dlg = new NewSound();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sound = new SoundChunk(dlg.SampleRate, dlg.Channels);
                soundRendering.Sound = sound;
            }
           dlg.Dispose();

            Invalidate();
        }

        private void openDefaultItem_Click(object sender, EventArgs e)
        {
            sound = new SoundChunk("res//nasa.wav");

            soundRendering.Sound = sound;
            Invalidate();
        }

        private void openItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sound = new SoundChunk(openFileDialog.FileName);
                sound.Open(openFileDialog.FileName);
                soundRendering.Sound = sound;
                Invalidate();
            }
            openFileDialog.Dispose();
        }

        private void pauseItem_Click(object sender, EventArgs e)
        {
            if (sound != null)
                sound.Pause();
        }

        private void playItem_Click(object sender, EventArgs e)
        {
            if (sound != null)
                sound.Play();
        }

        private void saveAsItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                sound.Save(saveFileDialog.FileName, (SoundFileTypes)saveFileDialog.FilterIndex);
                if (lastFile != null)
                {
                    saveItem.Enabled = true;
                    lastFile = saveFileDialog.FileName;
                }
            }
            saveFileDialog.Dispose();
        }

        private void saveItem_Click(object sender, EventArgs e)
        {
            if (lastFile != null)
                sound.Save();
            else
                MessageBox.Show("No prior file saved", "Error");
        }

        private void sineItem_Click(object sender, EventArgs e)
        {
            sound = new SoundChunk(44100, 2, 2);
            soundRendering.Sound = sound;

            gen.MakeSine(sound);
            Invalidate();
        }

        private void stopItem_Click(object sender, EventArgs e)
        {
            if (sound != null)
                sound.Stop();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            soundRendering.SamplesPerPeak = e.NewValue;
            Invalidate();
        }

        private void sineParamsItem_Click(object sender, EventArgs e)
        {
            gen.MakeParamSine();
        }


        #endregion

        private void volumeAdjustItem_Click(object sender, EventArgs e)
        {
            Volume_Adjust dlg = new Volume_Adjust();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                process.OnProcessVolume(sound, dlg.Adjust);
                Invalidate();
            }
            
        }

        private void sineWavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //make a fresh new sound
            sound = new SoundChunk(44100, 2, 2);

            //tell the view to use this sound
            soundRendering.Sound = sound;

            gen.MakeSineAdditive(sound);
            Invalidate();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //make a fresh new sound
            sound = new SoundChunk(44100, 2, 2);

            //tell the view to use this sound
            soundRendering.Sound = sound;
            gen.MakeSineAdditive246(sound);
            Invalidate();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //make a fresh new sound
            sound = new SoundChunk(44100, 2, 2);

            //tell the view to use this sound
            
            soundRendering.Sound = sound;
            gen.MakeSineAdditive357(sound);
            Invalidate();
        }

        private void allHarmonicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //make a fresh new sound
            sound = new SoundChunk(22000, 2, 2);

            //tell the view to use this sound

            soundRendering.Sound = sound;
            gen.MakeSineAdditiveAll(sound);
            Invalidate();
        }

        private void allOddHarmonicsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //make a fresh new sound
            sound = new SoundChunk(22000, 2, 2);

            //tell the view to use this sound

            soundRendering.Sound = sound;
            gen.MakeSineAdditiveAllOdd(sound);
            Invalidate();
        }

        private void rampToolStripMenuItem_Click(object sender, EventArgs e)
        {
            process.Ramp(sound);
            Invalidate();
        }

        private void rampInOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            process.RampInOut(sound);
            Invalidate();

        }

        private void tremeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            process.Tremolo(sound, .2f, 4f);
            Invalidate();
        }

        private void slowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundChunk sound_slow = new SoundChunk(sound.SampleRate, 2, sound.Duration * 2); 
            process.slow(sound, sound_slow);
            sound = sound_slow;
            Invalidate();
        }

        private void fastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundChunk sound_fast = new SoundChunk(sound.SampleRate, 2, sound.Duration / 2);
            process.fast(sound, sound_fast);
            sound = sound_fast;
            Invalidate();
        }

        private void backwardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundChunk sound_backwards = new SoundChunk(sound.SampleRate, 2, sound.Duration);
            process.backwards(sound, sound_backwards);
            sound = sound_backwards;
            Invalidate();
        }
    }
}
