﻿using System;

namespace classwork
{

    public class Input
    {
        public string InputText;

        public Input(string inputText)
        {
            InputText = inputText;
        }

        public string[] SplitLines()
        {
            var lines = InputText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return lines;
        }

        public string[] Parse(string[] lines)
        {
            string[] temp = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                temp = lines[i].Split(':', '(', ';');
            }

            return temp;
        }
    }



    public class OFile
    {
        public string[] Obj;

        public OFile(string[] obj)
        {
            this.Obj = obj;
        }
    }

    public class File : OFile
    {
        public string fileName;
        public string size;

        public File(string[] obj) : base(obj)
        {
            fileName = obj[1];
            size = obj[2];
        }


    }

    public class TextFile : File
    {
        public string content;

        public TextFile(string[] obj) : base(obj)
        {
            content = obj[3];
        }

        public void Print()
        {
            Console.WriteLine("Text files:");
            Console.WriteLine("  " + fileName);
            Console.WriteLine("      Extension: txt");
            Console.WriteLine("      Size: " + size.Trim(new char[] { ' ', ')' }));
            Console.WriteLine("      Content: " + content);
        }

    }

    public class ImageFile : File
    {
        public string resolution;

        public ImageFile(string[] obj) : base(obj)
        {
            resolution = obj[3];
        }

        public void Print()
        {
            Console.WriteLine("Images:");
            Console.WriteLine("  " + fileName);
            Console.WriteLine("      Extension: mkv");
            Console.WriteLine("      Size: " + size.Trim(new char[] { ' ', ')' }));
            Console.WriteLine("      Resolution: " + resolution);
        }
    }


    public class VideoFile : ImageFile
    {
        public string length;

        public VideoFile(string[] obj) : base(obj)
        {
            length = obj[4] = length;
        }

        public void Print()
        {
            Console.WriteLine("Movies:");
            Console.WriteLine("  " + fileName);
            Console.WriteLine("      Extension: mkv");
            Console.WriteLine("      Size: " + size.Trim(new char[] { ' ', ')' }));
            Console.WriteLine("      Resolution: " + resolution);
            Console.WriteLine("      Length: " + length);
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


            var newinput = new Input(allinput);

            var lines = newinput.SplitLines();

            for (int i = 0; i < lines.Length; i++)
            {
                var temp = newinput.Parse(lines);

                if (temp[0] == "Text")
                {
                    var textscope = new TextFile(temp);
                    textscope.Print();

                }
                else if (temp[0] == "Movie")
                {
                    var moviescope = new VideoFile(temp);
                    moviescope.Print();

                }
                else
                {
                    var imagescope = new ImageFile(temp);
                    imagescope.Print();

                }
            }


        }

    }
}

