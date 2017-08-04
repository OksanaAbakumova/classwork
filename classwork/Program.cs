using System;

namespace classwork
{

    public class File
    {
        public string FileName;
        public string Size;

        public File(string size, string fileName)
        {
            Size = size;
            FileName = fileName;
        }


    }

    public class TextFile : File
    {
        public string Content;

        public TextFile(string size, string fileName, string content) : base(size, fileName)
        {
            Content = content;
        }

        public void Print()
        {
            Console.WriteLine("Text files:");
            Console.WriteLine("  " + FileName);
            Console.WriteLine("      Extension: txt");
            Console.WriteLine("      Size: " + Size.Trim(new char[] { ' ', ')' }));
            Console.WriteLine("      Content: " + Content);
        }

    }

    public class ImageFile : File
    {
        public string Resolution;

        public ImageFile(string size, string fileName, string resolution) : base(size, fileName)
        {
            Resolution = resolution;
        }

        public void Print()
        {
            Console.WriteLine("Images:");
            Console.WriteLine("  " + FileName);
            Console.WriteLine("      Extension: mkv");
            Console.WriteLine("      Size: " + Size.Trim(new char[] { ' ', ')' }));
            Console.WriteLine("      Resolution: " + Resolution);
        }
    }


    public class VideoFile : ImageFile
    {
        public string Length;

        public VideoFile(string size, string fileName, string resolution, string length) : base(size, fileName, resolution)
        {
            Length = length;
        }

        public void Print()
        {
            Console.WriteLine("Movies:");
            Console.WriteLine("  " + FileName);
            Console.WriteLine("      Extension: mkv");
            Console.WriteLine("      Size: " + Size.Trim(new char[] { ' ', ')' }));
            Console.WriteLine("      Resolution: " + Resolution);
            Console.WriteLine("      Length: " + Length);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String allinput = @"Text: file.txt(6B); Some string content
Image: img.bmp(19MB); 1920х1080
Text:data.txt(12B); Another string
Text:data1.txt(7B); Yet another string
Movie:logan.2017.mkv(19GB); 1920х1080; 2h12m";

            var lines = allinput.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < lines.Length; i++)
            {
                var temp = lines[i].Split(':', '(', ';');


                if (temp[0] == "Text")
                {
                    TextFile textscope = new TextFile(temp[2], temp[1], temp[3]);
                    textscope.Print();

                }
                else if (temp[0] == "Movie")
                {
                    var moviescope = new VideoFile(temp[2], temp[1], temp[3], temp[4]);
                    moviescope.Print();

                }
                else
                {
                    var imagescope = new ImageFile(temp[2], temp[1], temp[3]);
                    imagescope.Print();

                }
            }

        }

    }
}

