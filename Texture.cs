using System;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;

namespace Axon
{
    public class Texture
    {
        public Bitmap Bitmap;
        public int Id;
        public Texture (string FilePath)
        {
            try 
            {
                Bitmap = new Bitmap(FilePath);
            }
            catch(Exception e)
            {
                Console.WriteLine("Unable to load texture: " + e.Message);
            }
                this.Bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

                this.Id = GL.GenTexture();
                GL.BindTexture(TextureTarget.Texture2D, this.Id); 
                
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)All.Repeat);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)All.Repeat);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Linear);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, this.Bitmap.Width, this.Bitmap.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, IntPtr.Zero);
                BitmapData bitmap_data = this.Bitmap.LockBits(new Rectangle(0, 0, this.Bitmap.Width, this.Bitmap.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.TexImage2D
                (
                    TextureTarget.Texture2D, 
                    0, 
                    PixelInternalFormat.Rgb, 
                    this.Bitmap.Width, 
                    this.Bitmap.Height,
                    0,
                    OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                    PixelType.UnsignedByte,
                    bitmap_data.Scan0
                );
                
                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

                //this.Bitmap.UnlockBits(bitmap_data);
                //this.Bitmap.Dispose();
                GL.BindTexture(TextureTarget.Texture2D, 0);

               //GL.Enable(EnableCap.Texture2D);
        }
    }
}