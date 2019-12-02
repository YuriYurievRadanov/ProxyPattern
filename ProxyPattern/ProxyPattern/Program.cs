using System;
using System.Threading;

namespace ProxyPattern
{
    /// <summary>
    /// Subject Interface
    /// </summary>
    public interface IImageGenerator
    {
        void ShowImage();

    }

    /// <summary>
    /// RealSubject Class
    /// </summary>
    public class ImageGenerator : IImageGenerator
    {
        public void ShowImage()
        {
            Console.WriteLine("Resim Gösteriliyor..");
        }

    }

    /// <summary>
    /// Proxy Class
    /// </summary>
    public class ImageGeneratorProxy : IImageGenerator
    {
        private ImageGenerator _imageGenerator;
        private Timer t;
        private bool LoadRealObject = false;

        private void ShowRealImage(object o)
        {
            _imageGenerator = new ImageGenerator();
            _imageGenerator.ShowImage();
            LoadRealObject = true;
        }

        public void ShowImage()
        {
            if (_imageGenerator == null)
            {
                t = new System.Threading.Timer(new TimerCallback(ShowRealImage), this, 2000, 0);
            }
            if (!LoadRealObject)
                Console.WriteLine("Önizleme resmi gösteriliyor..");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
