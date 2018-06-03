using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace cam
{
    public partial class CamReader : Form
    {
        private CameraList _cameraList;
        private List<Thread> threads;
        private List<PictureBox> pic;

        public CamReader()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _cameraList = new CameraList();
            threads = new List<Thread>();
            if (!_cameraList.Init())
            {
                MessageBox.Show("Невозможно получить список камер. Проверьте интернет соединение.");
                Application.Exit();
            }
            pic = new List<PictureBox>() { LTBox, RTBox, LBBox, RBBox };
            for (int i = 0; i < _cameraList.GetCameraNumbers(); i++)
            {
                //ServerTread.Add(new Thread(() => work(pic[i-1], _cameraList.GetCamera(i-1))));
                _cameraList.GetCamera(i).Init();
                pic[i].Image = _cameraList.GetCamera(i).GetFrame();
                _cameraList.GetCamera(i).Close();
            }
            /*for (int i = 0; i < threads.Count; i++)
                threads[i].Start();*/
        }

        private void work(PictureBox pb, Camera cam)
        {
            if (cam != null)
            {
                cam.Init();
                while (true)
                {
                    pb.Image = cam.GetFrame();
                    Thread.Sleep(0);
                }
            }
        }

        private void Run(object sender, EventArgs e)
        {
            foreach (Thread thread in threads)
                thread.Abort();
            threads.Clear();
            threads.Add(new Thread(() => work((PictureBox)sender,
                _cameraList.GetCamera(Convert.ToInt32(((PictureBox)sender).Tag)))));
            threads[0].Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Thread thread in threads)
                {
                    thread.Abort();
                }
        }

    }

    /// <summary>
    /// Класс для работы с камерой
    /// </summary>

    public class Camera
    {
        private string _id;
        private string _name;
        private string _videoUrl = "http://demo.macroscop.com:8080/mobile?login=root&channelid={0}&resolutionX=640&resolutionY=480&fps=25";
        private Stream _videoStream;

        /// <summary>
        /// Инициализирует экземпляр класса Camera идентификатором и названием камеры
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>

        public Camera(string id, string name)
        {
            _id = id;
            _name = name;
            _videoUrl = string.Format(_videoUrl, _id);
        }

        /// <summary>
        /// Инициализирует видеопоток с камеры
        /// </summary>

        public void Init()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(_videoUrl);
            WebResponse webResponse = webRequest.GetResponse();
            _videoStream = webResponse.GetResponseStream();
        }

        /// <summary>
        /// Возвращает Url камеры
        /// </summary>
        /// <returns></returns>

        public string GetUrl()
        {
            return _videoUrl;
        }

        /// <summary>
        /// Возвращает название камеры
        /// </summary>
        /// <returns></returns>

        public string GetName()
        {
            return _name;
        }

        /// <summary>
        /// Возвращает очередной кадр с камеры
        /// </summary>
        /// <returns></returns>

        public Bitmap GetFrame()
        {
            Bitmap bmp = _getstream();          
            Graphics g = Graphics.FromImage(bmp);
            if (bmp == null)
                g.Clear(Color.White);
            g.DrawString(_name, new Font("Arial", 12), Brushes.Red, new Point(5, 5));
            g.Flush();
            return bmp;
        }

        /// <summary>
        /// Закрытие видеопотока
        /// </summary>

        public void Close()
        {
            _videoStream.Close();
        }

        /// <summary>
        /// Возвращает кадр с камеры
        /// </summary>
        /// <returns></returns>

        private Bitmap _getstream()
        {
            byte[] buffer = new byte[100000];
            int read, total = 0;
            int n, l = 0;
            string str = "";
            read = _videoStream.Read(buffer, total, 10000);
            total += read;
            str = System.Text.Encoding.Default.GetString(buffer).TrimEnd('\0');
            n = str.IndexOf("Content-Length: ") + 16;
            l = str.IndexOf("\r\n\r\n") + 4;
            if (n < l)
            {
                int datalength = Convert.ToInt32(str.Substring(n, l - n - 4));
                total = read - l;
                Array.Copy(buffer, l, buffer, 0, read - l);
                while (total < datalength)
                {
                    read = _videoStream.Read(buffer, total, 1000);
                    total += read;
                }
                Bitmap bmp = (Bitmap)Bitmap.FromStream(new MemoryStream(buffer, 0, total));
                return bmp;
            }
            else return null;
        }

    }

    /// <summary>
    /// Класс для работы со списком камер
    /// </summary>

    public class CameraList
    {
        private List<Camera> _cameras;
        private string _cameraListUrl = "http://demo.macroscop.com:8080/configex?login=root";

        /// <summary>
        /// Инициализирует экземпляр класса CameraList
        /// </summary>

        public CameraList()
        {
            _cameras = new List<Camera>();

        }

        /// <summary>
        /// Получает список доступных камер с сервера
        /// </summary>

        public bool Init()
        {
            try
            {
                _updatelist();
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Возвращает объект класса Camera по его номеру
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>

        public Camera GetCamera(int i)
        {
            if ((i > -1) && (i < _cameras.Count))
                return _cameras[i];
            else
                return null;
        }

        /// <summary>
        /// Возвращает число доступных камер
        /// </summary>
        /// <returns></returns>

        public int GetCameraNumbers()
        {
            return _cameras.Count;
        }

        /// <summary>
        /// Получает список доступных камер с сервера
        /// </summary>

        private void _updatelist()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(_cameraListUrl);
            WebResponse webResponse = webRequest.GetResponse();
            Stream stream = webResponse.GetResponseStream();
            byte[] buffer = new byte[10000];
            int read, total = 0;
            while ((read = stream.Read(buffer, total, 1000)) > 0)
            {
                total += read;
            }
            stream.Close();
            string text = System.Text.Encoding.Default.GetString(buffer).TrimEnd('\0');
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(text);
            foreach (XmlNode node in doc.SelectNodes("//Configuration/Channels/ChannelInfo"))
            {
                string id = node.Attributes["Id"].Value;
                string name = node.Attributes["Name"].Value;
                _cameras.Add(new Camera(id, name));
            }
        }

    }

}