/*  Detection Mask Tool for OpenALPR 
    Created by Joel Vargas
    CC 2016
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace DetectionMaskTool
{
    public partial class DetectionMaskForm : Form
    {
        private List<List<Point>> Polygons = new List<List<Point>>();
        private List<Point> NewPolygon = null;
        private Point NewPoint;
        Image referenceImage = null;
        Image<Bgr, byte> maskImage;
        public DetectionMaskForm()
        {
            InitializeComponent();            
        }

        private void DetectionMaskForm_Load(object sender, EventArgs e)
        {
                        
        }

        private void pcbMask_MouseClick(object sender, MouseEventArgs e)
        {         
        }

        private void pcbMask_MouseDown(object sender, MouseEventArgs e)
        {
            // See if we are already drawing a polygon.
            if (NewPolygon != null)
            {
                // We are already drawing a polygon.
                // If it's the right mouse button, finish this polygon.
                if (e.Button == MouseButtons.Right)
                {
                    // Finish this polygon.
                    if (NewPolygon.Count > 2) Polygons.Add(NewPolygon);
                    NewPolygon = null;
                }
                else
                {
                    // Add a point to this polygon.
                    if (NewPolygon[NewPolygon.Count - 1] != e.Location)
                    {
                        NewPolygon.Add(e.Location);
                    }
                }
            }
            else
            {
                // Start a new polygon.
                NewPolygon = new List<Point>();
                NewPoint = e.Location;
                NewPolygon.Add(e.Location);
            }

            // Redraw.
            pcbMask.Invalidate();
        }

        private void pcbMask_MouseMove(object sender, MouseEventArgs e)
        {
            if (NewPolygon == null) return;
            NewPoint = e.Location;
            pcbMask.Invalidate();
        }

        private void pcbMask_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //e.Graphics.Clear(pcbMask.BackColor);

            // Draw the old polygons.
            foreach (List<Point> polygon in Polygons)
            {
                SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 255));
                e.Graphics.FillPolygon(semiTransBrush, polygon.ToArray(), FillMode.Alternate);
                e.Graphics.DrawPolygon(new Pen(Color.Magenta, 2), polygon.ToArray());
            }

            // Draw the new polygon.
            if (NewPolygon != null)
            {
                // Draw the new polygon.
                if (NewPolygon.Count > 1)
                {                    
                    e.Graphics.DrawLines(new Pen(Color.Magenta, 2), NewPolygon.ToArray());
                }

                // Draw the newest edge.
                if (NewPolygon.Count > 0)
                {
                    using (Pen dashed_pen = new Pen(Color.Magenta))
                    {
                        dashed_pen.DashPattern = new float[] { 3, 3 };
                        dashed_pen.Width = 2;
                        e.Graphics.DrawLine(dashed_pen, NewPolygon[NewPolygon.Count - 1], NewPoint);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {                                        
            DialogResult dialogResult = MessageBox.Show("Save the mask and exit?", "Save confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Polygons.Count > 0)
                    maskImage = new Image<Bgr, byte>(referenceImage.Width, referenceImage.Height, new Bgr(0, 0, 0));
                else
                    maskImage = new Image<Bgr, byte>(referenceImage.Width, referenceImage.Height, new Bgr(255, 255, 255));
                foreach (var polygon in Polygons)
                {
                    Point[] points = new Point[polygon.Count];
                    for (int i = 0; i < polygon.Count; i++)
                    {
                        points[i] = polygon.ElementAt(i);
                    }
                    maskImage.Draw(points, new Bgr(255, 255, 255), -1, LineType.AntiAlias, default(Point));
                }
                //saveJpeg(Path.Combine(Form1.AssemblyDirectory,"mask_files/detection_mask.jpg"), maskImage.ToBitmap(), 100L);                
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "mask.jpg")
                {                    
                    FileStream fs = (FileStream)saveFileDialog1.OpenFile();
                    maskImage.ToBitmap().Save(fs, ImageFormat.Jpeg);
                    fs.Close();
                }
                Close();
            }          
        }

        private void saveJpeg(string path, Image img, long quality)
        {
            // Encoder parameter for image quality

            EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality);

            // Jpeg image codec
            ImageCodecInfo jpegCodec = getEncoderInfo("image/jpeg");

            if (jpegCodec == null)
                return;

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }

        private ImageCodecInfo getEncoderInfo(string mimeType)
        {            
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                        
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }

        delegate void SetPicBoxMaskCallback(Image img);
        public void SetPicBoxMaskImg(Image img)
        {
            if (pcbMask.InvokeRequired)
            {
                SetPicBoxMaskCallback d = new SetPicBoxMaskCallback(SetPicBoxMaskImg);
                Invoke(d, new object[] { img });
            }
            else
            {
                pcbMask.Image = img;
                pcbMask.Refresh();
            }
        }

        delegate void SetPicBoxMaskSizeCallback(int width, int height);
        private void SetPicBoxMaskSize(int width, int height)
        {
            if (pcbMask.InvokeRequired)
            {
                SetPicBoxMaskSizeCallback d = new SetPicBoxMaskSizeCallback(SetPicBoxMaskSize);
                Invoke(d, new object[] { width, height });
            }
            else
            {
                pcbMask.Size = new Size(width,height);                
            }
        }

        delegate void SetFormSizeCallback(int width, int height);
        private void SetFormSize(int width, int height)
        {
            if (pcbMask.InvokeRequired)
            {
                SetFormSizeCallback d = new SetFormSizeCallback(SetFormSize);
                Invoke(d, new object[] { width, height });
            }
            else
            {
                this.Size = new Size(width, height);
            }
        }

        private void btnClearMask_Click(object sender, EventArgs e)
        {            
            Polygons = new List<List<Point>>();
            pcbMask.Refresh();            
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                referenceImage = new Bitmap(openFileDialog1.OpenFile());
            }
            else
            {
                return;
            }
            SetPicBoxMaskImg(referenceImage);
            pcbMask.Location = new Point(0, 0);
            SetPicBoxMaskSize(referenceImage.Width, referenceImage.Height);            
            btnSave.Location = new Point(referenceImage.Width, referenceImage.Height / 2);
            btnClearMask.Location = new Point(btnSave.Location.X, btnSave.Location.Y - 30);
            btnLoadImage.Location = new Point(btnSave.Location.X, btnSave.Location.Y - 60);
            btnClearMask.Enabled = true;
            btnSave.Enabled = true;
            maskImage = new Image<Bgr, byte>(referenceImage.Width, referenceImage.Height, new Bgr(255, 255, 255));
        }
    }
}
