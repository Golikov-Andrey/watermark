using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace watermark
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Поток снятия водиного знака
        /// </summary>
        public Thread Work_Process;


        /// <summary>
        /// Иня файла для коррекции
        /// </summary>
        public string _FileForCorrection = "";

        /// <summary>
        /// Иня файла шаблона для коррекции
        /// </summary>
        public string _FilePatternForCorrection = "";

        /// <summary>
        /// Каталог с файлами для коррекции
        /// </summary>
        public string _DirNameForCorrection = "";

        /// <summary>
        /// Выходной каталог с корректированными файлами
        /// </summary>
        public string _DirNameOutputAfterCorrection = "";


        /// <summary>
        /// Индексы строк с шаблоном в файле PNG. Массив индексов строк для коррекции
        /// </summary>
        public List<int> _IndexJ = new List<int>();

        //public List<int> _IndexiStart = new List<int>();

        //public List<int> _IndexiStop = new List<int>();

        /// <summary>
        /// Сохраняем файл для коррекции в память
        /// </summary>
        private void buttonLoadImageForCorrection_Click(object sender, EventArgs e)
        {
            //Создаем диалоговое окно выбора файла для корректировки
            DialogResult result = openFileDialog1.ShowDialog();
            //Если нажат ОК
            if (result == DialogResult.OK)
            {
                //Отображаем имя корректируемого файла
                label1.Text = openFileDialog1.FileName;
                //Сохраняем путь к корректируемому файлу
                _FileForCorrection = openFileDialog1.FileName;
                //Отображаем корректируемый файл
                pictureBox1.BackgroundImage = new Bitmap(_FileForCorrection);
            }
        }

        /// <summary>
        /// Сохраняем файл после коррекции на жесткий диск
        /// </summary>
        private void buttonSaveImageAfterCorrection_Click(object sender, EventArgs e)
        {
            //Создаем диалоговое окно сохранения файла
            DialogResult result = saveFileDialog1.ShowDialog();
            //Если нажат ОК
            if (result == DialogResult.OK)
            {
                //Отображаем сохраненный файл на форме
                label2.Text = saveFileDialog1.FileName;
                //Сохраняем файл на жесткий диск
                pictureBox2.BackgroundImage.Save(saveFileDialog1.FileName);
            }
        }

        /// <summary>
        /// Алгоритм корректировки построчный. Довольно медленный. Но нет необходимости предобработки шаблона
        /// </summary>
        public void Correction_Code()
        {

            Bitmap bitmap = new Bitmap(_FileForCorrection);
            Bitmap pattern = new Bitmap(_FilePatternForCorrection);
            Bitmap bitmapClone = (Bitmap)bitmap.Clone();

            int width = bitmap.Size.Width;
            int height = bitmap.Size.Height;

            int Adder = 20;

            for (int j = 0; j < height; j++)
            {

                for (int i = 0; i < width; i++)
                {
                    Color col;
                    Color colPat;

                    col = bitmap.GetPixel(i, j);
                    colPat = pattern.GetPixel(i, j);


                    int correct = Adder;
                    bool go = false;


                    if ((colPat.A > 0))
                    {
                        go = true;
                    }

                    if (i > 3 && i < (width - 3))
                    {
                        Color c1 = pattern.GetPixel(i + 1, j);
                        Color c2 = pattern.GetPixel(i + 2, j);
                        Color c3 = pattern.GetPixel(i + 3, j);

                        if ((c1.A > 0) && (c2.A > 0) && (c3.A > 0)&& (colPat.A == 0))
                        {
                            go = true;
                            correct = 10;
                        }


                        if ((c1.A == 0) && (c2.A == 0) && (c3.A == 0)&& (colPat.A > 0))
                        {
                            go = true;
                            correct = 10;
                        }

                    }



                    //if ((colPat.R != 0) && (colPat.R != 255))
                    if (go)
                        {
                            try
                        {
                            bitmapClone.SetPixel(i, j, Color.FromArgb(col.R - correct, col.G - correct, col.B - correct));
                        }
                        catch
                        {

                        }
                    }
                }

            }

            pictureBox2.BackgroundImage = bitmapClone;

        }

        /// <summary>
        /// Быстрый алгоритм корректировки с предобработанным шаблоном
        /// </summary>
        public void Correction_Code_Fast()
        {
            try
            {
                //Картинка для коррекции
                Bitmap bitmap = new Bitmap(_FileForCorrection);
                //Создаем копию картинки, которую будем корректировать 
                Bitmap bitmapClone = (Bitmap)bitmap.Clone();
                //Загрузка шаблона для коррекции
                Bitmap pattern = new Bitmap(_FilePatternForCorrection);
                //Ширина изображения
                int width = bitmap.Size.Width;
                //Дельта коррекции цвета
                int Adder = (int)numericUpDown1.Value;

                //Проходим по всем строчкам в которых есть корректируемые пиксели
                foreach (int j in _IndexJ)
                {
                    //Проходим по всем пикселям слева на право
                    for (int i = 0; i < width; i++)
                    {
                        //Получаем цвет пикселей
                        Color col;
                        Color colPat;

                        //Цвет пикселя корректируемого изображения
                        col = bitmap.GetPixel(i, j);
                        //Цвет пикселя шаблона
                        colPat = pattern.GetPixel(i, j);

                        //Копируем дельту коррекции цвета
                        int correct = Adder;
                        //Флаг коррекции пикселя
                        bool go = false;

                        //Если альфа канал в шаблоне есть, то пиксель корректируем
                        if ((colPat.A > 0))
                        {
                            //Поднимаем флаг
                            go = true;
                        }
                        //Определяем пиксель границу
                        if (i > 3 && i < (width - 3))
                        {
                            //Получаем цвета трех пикселей подряд для определения границы
                            Color c1 = pattern.GetPixel(i + 1, j);
                            Color c2 = pattern.GetPixel(i + 2, j);
                            Color c3 = pattern.GetPixel(i + 3, j);

                            //Определение границы начала шаблона
                            if ((c1.A > 0) && (c2.A > 0) && (c3.A > 0) && (colPat.A == 0))
                            {
                                //Пиксель границы будет скорректирован, но в половину дельты
                                go = true;
                                //Уменьшаем дельту
                                correct = (int)(correct / 2);
                            }

                            //Определение границы конца шаблона
                            if ((c1.A == 0) && (c2.A == 0) && (c3.A == 0) && (colPat.A > 0))
                            {
                                //Пиксель границы будет скорректирован, но в половину дельты
                                go = true;
                                //Уменьшаем дельту
                                correct = (int)(correct / 2);
                            }
                        }

                        //Корректируем пиксель
                        if (go)
                        {
                            try
                            {
                                //Корректируем пиксель на дельту. По краям дельта уменьшается
                                bitmapClone.SetPixel(i, j, Color.FromArgb(col.R - correct, col.G - correct, col.B - correct));
                            }
                            catch
                            {

                            }
                        }
                    }
                }
                //Показываем скорректируемый файл
                pictureBox2.BackgroundImage = bitmapClone;
            }
            catch
            {
                MessageBox.Show("Возникла ошибка. Возможно не указан шаблон снятия водяного знака.");
            }

        }

        /// <summary>
        /// Загружаем шаблон для коррекции
        /// </summary>
        private void buttonLoadPattern_Click(object sender, EventArgs e)
        {
            //Создаем диалоговое окно выбора файла шаблона
            DialogResult result = openFileDialog1.ShowDialog();
            //Если нажат ОК
            if (result == DialogResult.OK)
            {
                //Получаем ссылку на шаблон
                _FilePatternForCorrection = openFileDialog1.FileName;

                //Загружаем файл шаблона
                Bitmap pattern = new Bitmap(_FilePatternForCorrection);
                //Ширина шаблона
                int width = pattern.Size.Width;
                //Высота шаблона
                int height = pattern.Size.Height;
                //Отображаем шаблон
                pictureBox3.BackgroundImage = pattern;

                //Отчищаем массив индексов строк для коррекции
                _IndexJ.Clear();
                //_IndexiStart.Clear();
                //_IndexiStop.Clear();

                //Проходим по всем строкам
                for (int j = 0; j < height; j++)
                {
                    //Флаг наличия пикселей для коррекции в строке
                    bool RegJ = true;
                    //Проходим по всем пикселям в строке слева на право
                    for (int i = 0; i < width; i++)
                    {
                        //Получаем цвет пикселей шаблона
                        Color colPat = pattern.GetPixel(i, j);
                        //Если альфаканал есть, то в строке есть пиксели для коррекции
                        if (colPat.A>0)
                        {
                            //if(RegJ)
                            //{
                                //_IndexiStop.Add(i);
                                //_IndexiStart.Add(i);

                                //Добавляем номер строки в массив
                                _IndexJ.Add(j);
                                //Опускаем флаг
                                RegJ = false;
                                //Прекращаем цыкл так как строка для корректировки найдена
                                break;
                            //}
                            //if (_IndexiStop.Count > 0)
                            //{
                            //    _IndexiStop[_IndexiStop.Count - 1] = i;
                            //}
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Код пакетной коррекции файлов
        /// </summary>
        public void Correction_Code_Fast_Dir_Processing()
        {
            //Сообщаем о начале обработки файла
            MessageBox.Show("Обработка начата!");


            try
            {

                //Получаем ссылку на входную директорию
                DirectoryInfo d = new DirectoryInfo(_DirNameForCorrection);
                //Получаем ссылку на выходную директорию
                DirectoryInfo dout = new DirectoryInfo(_DirNameOutputAfterCorrection);
                if (!dout.Exists) dout.Create();

                //Загружаем файл шаблона
                Bitmap pattern = new Bitmap(_FilePatternForCorrection);
                //Ширина шаблона
                int width = pattern.Size.Width;
                //Высота шаблона
                int height = pattern.Size.Height;

                //Отчищаем массив индексов строк для коррекции
                _IndexJ.Clear();
                //Проходим по всем строкам
                for (int j = 0; j < height; j++)
                {
                    //Флаг наличия пикселей для коррекции в строке
                    bool RegJ = true;
                    //Проходим по всем пикселям в строке слева на право
                    for (int i = 0; i < width; i++)
                    {
                        //Получаем цвет пикселей шаблона
                        Color colPat = pattern.GetPixel(i, j);
                        //Если альфаканал есть, то в строке есть пиксели для коррекции
                        if (colPat.A > 0)
                        {
                            //Добавляем номер строки в массив
                            _IndexJ.Add(j);
                            //Опускаем флаг
                            RegJ = false;
                            //Прекращаем цыкл так как строка для корректировки найдена
                            break;
                        }
                    }
                }

                //Получаем количество файлов во входной директории
                int CountInputFile = d.GetFiles().Length;
                //Количество обработанных файлов
                int CountOutputFile = 0;
                //Проходим по всем файлам в входной директории
                foreach (FileInfo f in d.GetFiles())
                {

                    //Картинка для коррекции
                    Bitmap bitmap = new Bitmap(f.FullName);
                    //Создаем копию картинки, которую будем корректировать 
                    Bitmap bitmapClone = (Bitmap)bitmap.Clone();
                    //Загрузка шаблона для коррекции
                    pattern = new Bitmap(_FilePatternForCorrection);

                    //Ширина изображения
                    width = bitmap.Size.Width;
                    //Дельта коррекции цвета
                    int Adder = (int)numericUpDown1.Value;
                    //Проходим по всем строчкам в которых есть корректируемые пиксели
                    foreach (int j in _IndexJ)
                    {
                        //Проходим по всем пикселям слева на право
                        for (int i = 0; i < width; i++)
                        {
                            //Получаем цвет пикселей
                            Color col;
                            Color colPat;

                            //Цвет пикселя корректируемого изображения
                            col = bitmap.GetPixel(i, j);
                            //Цвет пикселя шаблона
                            colPat = pattern.GetPixel(i, j);

                            //Копируем дельту коррекции цвета
                            int correct = Adder;
                            //Флаг коррекции пикселя
                            bool go = false;


                            //Если альфа канал в шаблоне есть, то пиксель корректируем
                            if ((colPat.A > 0))
                            {
                                //Поднимаем флаг
                                go = true;
                            }
                            //Определяем пиксель границу
                            if (i > 3 && i < (width - 3))
                            {
                                //Получаем цвета трех пикселей подряд для определения границы
                                Color c1 = pattern.GetPixel(i + 1, j);
                                Color c2 = pattern.GetPixel(i + 2, j);
                                Color c3 = pattern.GetPixel(i + 3, j);

                                //Определение границы начала шаблона
                                if ((c1.A > 0) && (c2.A > 0) && (c3.A > 0) && (colPat.A == 0))
                                {
                                    //Пиксель границы будет скорректирован, но в половину дельты
                                    go = true;
                                    //Уменьшаем дельту
                                    correct = (int)(correct / 2);
                                }

                                //Определение границы конца шаблона
                                if ((c1.A == 0) && (c2.A == 0) && (c3.A == 0) && (colPat.A > 0))
                                {
                                    //Пиксель границы будет скорректирован, но в половину дельты
                                    go = true;
                                    //Уменьшаем дельту
                                    correct = (int)(correct / 2);
                                }
                            }

                            //Корректируем пиксель
                            if (go)
                            {
                                try
                                {
                                    //Если суммарный уровень цвета слабый(темные цвета) то корректируем по максимуму
                                    if (col.R + col.G + col.B < 300) correct = correct;
                                    //Если суммарный уровень цвета средний(обычные цвета) то корректируем в половину дельты цвета
                                    if ((col.R + col.G + col.B < 600) && ((col.R + col.G + col.B > 300))) correct = correct / 2;
                                    //Если суммарный уровень цвета высокий(яркие цвета) то корректируем по минимуму в четверть дельты
                                    if (col.R + col.G + col.B > 600) correct = correct / 4;
                                    //Корректируем пиксель на адоптивную дельту
                                    bitmapClone.SetPixel(i, j, Color.FromArgb(col.R - correct, col.G - correct, col.B - correct));
                                }
                                catch
                                {
                                }
                            }
                        }
                        //Сохраняем скорректированный файл
                        bitmapClone.Save(_DirNameOutputAfterCorrection + f.Name);
                    }

                    //Увеличиваем количество обработанных файлов
                    CountOutputFile++;
                    //Отображаем ход обработки файлов
                    label7.Text = "Всего обработано " + CountInputFile.ToString() + " из " + CountOutputFile.ToString();

                }
            }
            catch(Exception eee)
            {
                MessageBox.Show("В момент выполнения произошла ошибка: "+eee.ToString());
            }

            //Сообщаем об конце обработки
            MessageBox.Show("Обработка завершена!");
        }

        /// <summary>
        /// Корректировка изображения
        /// </summary>
        private void CorrectionAction_Click(object sender, EventArgs e)
        {
            //Запускаем процесс корректировки
            Work_Process = new Thread(Correction_Code_Fast);
            Work_Process.Priority = ThreadPriority.Normal;
            Work_Process.Start();

        }

        /// <summary>
        /// Корректировка изображения
        /// </summary>
        private void buttonPocketCorrection_Click(object sender, EventArgs e)
        {
            //Запускаем процесс пакетной корректировки
            Work_Process = new Thread(Correction_Code_Fast_Dir_Processing);
            Work_Process.Priority = ThreadPriority.Normal;
            Work_Process.Start();
        }        

        /// <summary>
        /// Получение пути к входной директории
        /// </summary>
        private void buttonInputDirLoad_Click(object sender, EventArgs e)
        {
            //Создаем диалоговое окно выбора директории
            DialogResult result = folderBrowserDialog1.ShowDialog();
            //Если нажат ОК
            if (result == DialogResult.OK)
            {
                //Передаем путь к входной директории
                _DirNameForCorrection = folderBrowserDialog1.SelectedPath + "\\";

                //Отображаем путь к входной директории в текстовое окошко
                textBox1.Text = _DirNameForCorrection;
            }
        }

        /// <summary>
        /// Получение пути к выходной директории
        /// </summary>
        private void buttonOutputDirLoad_Click(object sender, EventArgs e)
        {
            //Создаем диалоговое окно выбора директории
            DialogResult result = folderBrowserDialog1.ShowDialog();
            //Если нажат ОК
            if (result == DialogResult.OK)
            {
                //Передаем путь к выходной директории
                _DirNameOutputAfterCorrection = folderBrowserDialog1.SelectedPath + "\\";

                //Отображаем путь к выходной директории в текстовое окошко
                textBox2.Text = _DirNameOutputAfterCorrection;
            }

        }

        /// <summary>
        /// Загружаем шаблон для коррекции
        /// </summary>
        private void buttonPatternLoad_Click(object sender, EventArgs e)
        {
            //Создаем диалоговое окно выбора файла шаблона
            DialogResult result = openFileDialog1.ShowDialog();
            //Если нажат ОК
            if (result == DialogResult.OK)
            {
                //Получаем ссылку на шаблон
                _FilePatternForCorrection = openFileDialog1.FileName;

                //Загружаем файл шаблона
                Bitmap pattern = new Bitmap(_FilePatternForCorrection);
                //Ширина шаблона
                int width = pattern.Size.Width;
                //Высота шаблона
                int height = pattern.Size.Height;
                //Отображаем шаблон
                pictureBox3.BackgroundImage = pattern;

                //Отображаем путь к файлу шаблона
                textBox3.Text = _FilePatternForCorrection;

                //Отчищаем массив индексов строк для коррекции
                _IndexJ.Clear();
                //_IndexiStart.Clear();
                //_IndexiStop.Clear();

                //Проходим по всем строкам
                for (int j = 0; j < height; j++)
                {
                    //Флаг наличия пикселей для коррекции в строке
                    bool RegJ = true;
                    //Проходим по всем пикселям в строке слева на право
                    for (int i = 0; i < width; i++)
                    {
                        //Получаем цвет пикселей шаблона
                        Color colPat = pattern.GetPixel(i, j);
                        //Если альфаканал есть, то в строке есть пиксели для коррекции
                        if (colPat.A > 0)
                        {
                            //if(RegJ)
                            //{
                            //_IndexiStop.Add(i);
                            //_IndexiStart.Add(i);

                            //Добавляем номер строки в массив
                            _IndexJ.Add(j);
                            //Опускаем флаг
                            RegJ = false;
                            //Прекращаем цыкл так как строка для корректировки найдена
                            break;
                            //}
                            //if (_IndexiStop.Count > 0)
                            //{
                            //    _IndexiStop[_IndexiStop.Count - 1] = i;
                            //}
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Бонус добавление водяного знака
        /// </summary>
        private void buttonAddMasck_Click(object sender, EventArgs e)
        {
            //Запускаем процесс корректировки
            Work_Process = new Thread(Add_WaterMask_Code_Fast);
            Work_Process.Priority = ThreadPriority.Normal;
            Work_Process.Start();

        }

        /// <summary>
        /// Быстрое добавление водяной маски
        /// </summary>
        public void Add_WaterMask_Code_Fast()
        {
            try
            {
                //Картинка для коррекции
                Bitmap bitmap = new Bitmap(_FileForCorrection);
                //Создаем копию картинки, которую будем корректировать 
                Bitmap bitmapClone = (Bitmap)bitmap.Clone();
                //Загрузка шаблона для коррекции
                Bitmap pattern = new Bitmap(_FilePatternForCorrection);
                //Ширина изображения
                int width = bitmap.Size.Width;
                //Дельта коррекции цвета
                int Adder = (int)numericUpDown1.Value;

                //Проходим по всем строчкам в которых есть корректируемые пиксели
                foreach (int j in _IndexJ)
                {
                    //Проходим по всем пикселям слева на право
                    for (int i = 0; i < width; i++)
                    {
                        //Получаем цвет пикселей
                        Color col;
                        Color colPat;

                        //Цвет пикселя корректируемого изображения
                        col = bitmap.GetPixel(i, j);
                        //Цвет пикселя шаблона
                        colPat = pattern.GetPixel(i, j);

                        //Копируем дельту коррекции цвета
                        int correct = Adder;
                        //Флаг коррекции пикселя
                        bool go = false;

                        //Если альфа канал в шаблоне есть, то пиксель корректируем
                        if ((colPat.A > 0))
                        {
                            //Поднимаем флаг
                            go = true;
                        }
                        //Определяем пиксель границу
                        if (i > 3 && i < (width - 3))
                        {
                            //Получаем цвета трех пикселей подряд для определения границы
                            Color c1 = pattern.GetPixel(i + 1, j);
                            Color c2 = pattern.GetPixel(i + 2, j);
                            Color c3 = pattern.GetPixel(i + 3, j);

                            //Определение границы начала шаблона
                            if ((c1.A > 0) && (c2.A > 0) && (c3.A > 0) && (colPat.A == 0))
                            {
                                //Пиксель границы будет скорректирован, но в половину дельты
                                go = true;
                                //Уменьшаем дельту
                                correct = (int)(correct / 2);
                            }

                            //Определение границы конца шаблона
                            if ((c1.A == 0) && (c2.A == 0) && (c3.A == 0) && (colPat.A > 0))
                            {
                                //Пиксель границы будет скорректирован, но в половину дельты
                                go = true;
                                //Уменьшаем дельту
                                correct = (int)(correct / 2);
                            }
                        }

                        //Корректируем пиксель
                        if (go)
                        {
                            try
                            {
                                if (col.R + col.G + col.B > 300) correct = (int)(Adder / 2);
                                if (col.R + col.G + col.B > 600) correct = (int)(Adder / 4);

                                //Корректируем пиксель на дельту. По краям дельта уменьшается
                                bitmapClone.SetPixel(i, j, Color.FromArgb(col.R + correct, col.G + correct, col.B + correct));
                            }
                            catch
                            {

                            }
                        }
                    }
                }
                //Показываем скорректируемый файл
                pictureBox2.BackgroundImage = bitmapClone;
            }
            catch
            {
                MessageBox.Show("Возникла ошибка. Возможно не указан шаблон снятия водяного знака.");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




        //public static Bitmap MakeGrayscale2(Bitmap original)
        //{
        //    unsafe
        //    {
        //        //create an empty bitmap the same size as original
        //        Bitmap newBitmap =
        //           new Bitmap(original.Width, original.Height);

        //        //lock the original bitmap in memory
        //        BitmapData originalData = original.LockBits(
        //           new Rectangle(0, 0, original.Width, original.Height),
        //           ImageLockMode.ReadOnly,
        //           PixelFormat.Format24bppRgb);

        //        //lock the new bitmap in memory
        //        BitmapData newData = newBitmap.LockBits(
        //           new Rectangle(0, 0, original.Width, original.Height),
        //           ImageLockMode.WriteOnly,
        //           PixelFormat.Format24bppRgb);

        //        //set the number of bytes per pixel
        //        int pixelSize = 3;

        //        for (int y = 0; y < original.Height; y++)
        //        {
        //            //get the data from the original image
        //            byte* oRow = (byte*)originalData.Scan0 +
        //               (y * originalData.Stride);

        //            //get the data from the new image
        //            byte* nRow = (byte*)newData.Scan0 +
        //               (y * newData.Stride);

        //            for (int x = 0; x < original.Width; x++)
        //            {
        //                //create the grayscale version
        //                byte grayScale =
        //                   (byte)((oRow[x * pixelSize] * .11) + //B
        //                   (oRow[x * pixelSize + 1] * .59) +  //G
        //                   (oRow[x * pixelSize + 2] * .3)); //R

        //                //set the new image's pixel to the grayscale version
        //                nRow[x * pixelSize] = grayScale; //B
        //                nRow[x * pixelSize + 1] = grayScale; //G
        //                nRow[x * pixelSize + 2] = grayScale; //R
        //            }
        //        }

        //        //unlock the bitmaps
        //        newBitmap.UnlockBits(newData);
        //        original.UnlockBits(originalData);

        //        return newBitmap;
        //    }
        //}

    }
}
