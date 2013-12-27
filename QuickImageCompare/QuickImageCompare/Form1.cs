using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickImageCompare
{
    public partial class Form1 : Form
    {
        private FolderMetadata folder;
        private Bitmap _previousImage = new Bitmap(1,1);
        private Bitmap _thisImage = new Bitmap(1, 1);
        private Bitmap _nextImage = new Bitmap(1, 1);
        private Bitmap _nextNextImage = new Bitmap(1, 1);
        private readonly Bitmap _keepImg = Properties.Resources.keep;
        private readonly Bitmap _deleteImg = Properties.Resources.delete;
        private readonly Bitmap _retouchImg = Properties.Resources.retouch;
        private int _index = 0;
        private int _zoomX = 0;
        private int _zoomY = 0;
        private int _homeX = 0;
        private int _homeY = 0;
        private int _offsetX = 0;
        private int _offsetY = 0;
        private bool _dontDraw = false;

        public Form1()
        {
            InitializeComponent();
            lblndex.Text = "";
            txtFolder.Text = Environment.CurrentDirectory;
            

            thisPic.Paint += (x, y) => PaintFull(_thisImage, thisPic, y.Graphics,_index);
            nextPic.Paint += (x, y) => PaintFull(_nextImage, nextPic, y.Graphics,_index+1);
            zoomThis.Paint += (x, y) => PaintZoom(_thisImage, zoomThis, y.Graphics,false);
            zoomNext.Paint += (x, y) => PaintZoom(_nextImage, zoomNext, y.Graphics,true);
            Top = 0;
        }

        

        private void NextImage()
        {
            _index++;
            if (_index < 0) _index += folder.Items.Count;
            if (_index >= folder.Items.Count) Math.DivRem(_index, folder.Items.Count, out _index);

            _previousImage.Dispose();
            _previousImage = _thisImage;
            _thisImage = _nextImage;
            _nextImage = _nextNextImage;
            LoadImage(ref _nextNextImage,_index+2);

            _homeX = 0;
            _homeY = 0;
            _offsetX = 0;
            _offsetY = 0;

            ReconfigureDisplay();
        }

        private void PrevImage()
        {
            _index--;

            if (_index < 0) _index += folder.Items.Count;
            if (_index >= folder.Items.Count) Math.DivRem(_index, folder.Items.Count, out _index);

            _nextNextImage.Dispose();
            _nextNextImage = _nextImage;
            _nextImage = _thisImage;
            _thisImage = _previousImage;
            LoadImage(ref _previousImage, _index - 1);
            ReconfigureDisplay();
        }

        private void PaintFull(Bitmap image, PictureBox target, Graphics g, int index)
        {
            if (image == null || _dontDraw) return;

            var ar1 = _thisImage.Height / (double)_thisImage.Width;
            var ar2 = thisPic.Height / (double)thisPic.Width;
            var useHeight = ar1 > ar2;
            var height = (float)target.Height;
            var width = (float)target.Width;
            if (useHeight)
            {
                width = (height / image.Height) * image.Width;
            }
            else
            {
                height = (width / image.Width) * image.Height;
            }
            g.DrawImage(image, 0, 0, width, height);

            if (index < 0) index += folder.Items.Count;
            if (index >= folder.Items.Count) Math.DivRem(index, folder.Items.Count, out index);

            if (index < folder.Items.Count)
            {
                var item = folder.Items[index];
                Bitmap icon;
                switch (item.Action)
                {
                    case ItemAction.Keep:
                        icon = _keepImg;break;
                    case ItemAction.Delete:
                        icon = _deleteImg; break;
                    case ItemAction.Retouch:
                        icon = _retouchImg; break;
                    default:
                        return;
                }

                g.DrawImageUnscaled(icon,10,10);
            }
        }

        private void PaintZoom(Bitmap image, PictureBox target, Graphics g, bool useOffset)
        {
            if (image == null || _dontDraw) return;

            var height = (float)target.Height;
            var width = (float)target.Width;

            var zoomPx = ((_zoomX/width)*image.Width);
            var zoomPy = ((_zoomY / height) * image.Height);

            if (useOffset)
            {
                zoomPx += _offsetX - _homeX;
                zoomPy += _offsetY - _homeY;
            }

            g.DrawImage(image, new Rectangle(0, 0, target.Width, target.Height), zoomPx, zoomPy, target.Width, target.Height, GraphicsUnit.Pixel);
        }

        private void ResizeThumbWindow(Bitmap image, PictureBox target)
        {
            var ar1 = image.Height / (double)image.Width;
            var ar2 = target.Height / (double)target.Width;
            var useHeight = ar1 > ar2;
            var height = (float)target.Height;
            var width = (float)target.Width;
            if (useHeight)
            {
                width = (height / image.Height) * image.Width;
                target.Width = (int)width;
            }
            else
            {
                height = (width / image.Width) * image.Height;
                target.Height = (int)height;
            }
        }

        private void ResizePictureBoxes()
        {
            var targetWidth = (int)((Width - 45) * 0.5);
            var targetHeight = (int)((Height - 123) * 0.5);

            thisPic.Left = zoomThis.Left = 10;
            thisPic.Width = zoomThis.Width = targetWidth;
            thisPic.Height = zoomThis.Height = targetHeight;
            nextPic.Width = zoomNext.Width = targetWidth;
            nextPic.Height = zoomNext.Height = targetHeight;
            nextPic.Left = zoomNext.Left = thisPic.Right + 10;
            zoomThis.Top = zoomNext.Top = thisPic.Bottom + 10;
        }

        private void bGetFolder_Click(object sender, EventArgs e)
        {
            ShowFolderDialog();
        }

        private bool ShowFolderDialog()
        {
            Visible = false;
            var result = folderFind.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFolder.Text = folderFind.SelectedPath;
                LoadFolder();
            }
            Visible = true;
            return (result == DialogResult.OK);
        }

        private void LoadFolder()
        {
            folder = FolderMetadata.GetFromFolder(txtFolder.Text);
            if (folder.Items.Count == 0)
            {
                var result = ShowFolderDialog();
                if(!result) Close();
            }
            else
            {
                _index = 0;
                LoadIndexZero();   
            }
        }

        private void LoadIndexZero()
        {
            if (folder.Items.Count == 0)
            {
                SetBlank(_previousImage);
                SetBlank(_thisImage);
                SetBlank(_nextImage);
                SetBlank(_nextNextImage);
            }
            else
            {
                LoadImage(ref _previousImage, -1);
                LoadImage(ref _thisImage, 0);
                LoadImage(ref _nextImage, 1);
                LoadImage(ref _nextNextImage, 2);
            }

            ReconfigureDisplay();
        }

        private void ReconfigureDisplay()
        {
            if (_thisImage == null || _dontDraw) return;

            ResizePictureBoxes();
            ResizeThumbWindow(_thisImage, thisPic);
            ResizeThumbWindow(_nextImage, nextPic);

            thisPic.Invalidate();
            nextPic.Invalidate();
            ReconfigureZooms();
            lblndex.Text = string.Format("{0} / {1}", _index + 1, folder.Items.Count);

        }
        
        private void ReconfigureZooms()
        {
            zoomThis.Invalidate();
            zoomNext.Invalidate();
        }

        private void LoadImage(ref Bitmap img, int index)
        {
            if (index < 0) index += folder.Items.Count;
            if (index >= folder.Items.Count) Math.DivRem(index, folder.Items.Count, out index);

            var itemAtIndex = folder.Items[index];
            
            img = new Bitmap(itemAtIndex.FileName,false);
        }

        private void SetBlank(Bitmap img)
        {
            using (var g = Graphics.FromImage(img))
            {
                g.Clear(Color.Black);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //Change size / position of preview windows.

           

        }
        
        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            _dontDraw = true;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            _dontDraw = false;

            ResizePictureBoxes();
            ReconfigureDisplay();
        }
        
        private void thisPic_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _zoomX = e.X;
                _zoomY = e.Y;
                ReconfigureZooms();
            }
        }

        private void zoomThis_MouseDown(object sender, MouseEventArgs e)
        {
            _homeX = e.X;
            _homeY = e.Y;
            _offsetX = e.X;
            _offsetY = e.Y;
            ReconfigureZooms();
        }

        private void zoomNext_MouseDown(object sender, MouseEventArgs e)
        {
            _offsetX = e.X;
            _offsetY = e.Y;
            ReconfigureZooms();
        }
        
        private void navBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) NextImage();
            if (e.KeyCode == Keys.Left) PrevImage();
            if (e.KeyCode == Keys.Up)
            {
                folder.Items[_index].Action = ItemAction.Keep;
                thisPic.Invalidate();
            }
            if (e.KeyCode == Keys.Down)
            {
                folder.Items[_index].Action = ItemAction.Delete;
                thisPic.Invalidate();
            }
            if (e.KeyCode == Keys.End)
            {
                folder.Items[_index].Action = ItemAction.Retouch;
                thisPic.Invalidate();
            }
            if (e.KeyCode == Keys.Home) folder.Save();
            if (e.KeyCode == Keys.Enter)
            {
                if (
                    MessageBox.Show("Are you sure you want to process images into their folders now?", "Process images?", MessageBoxButtons.OKCancel) ==
                    DialogResult.OK)
                {

                    _previousImage.Dispose();
                    _nextImage.Dispose();
                    _nextNextImage.Dispose();
                    _thisImage.Dispose();

                    _previousImage = new Bitmap(1, 1);
                    _nextImage = new Bitmap(1, 1);
                    _nextNextImage = new Bitmap(1, 1);
                    _thisImage = new Bitmap(1, 1);

                    folder.Process();
                    LoadFolder();
                }
            }

            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (folder == null) LoadFolder();
            navBox.Focus();
            ResizePictureBoxes();
            ReconfigureDisplay();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _previousImage.Dispose();
            _nextImage.Dispose();
            _nextNextImage.Dispose();
            _thisImage.Dispose();
            _keepImg.Dispose();
            _retouchImg.Dispose();
            _deleteImg.Dispose();
        }

    }
}
