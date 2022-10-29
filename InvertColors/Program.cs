using System;
using System.Drawing;
namespace InvertColors
{
    class Program
    {
        static void Main(string[] args)
        {
            cwl("Wellcome to Invert Colors App");
            cwl("Black Pixel to White Pixel");
            cwl("Commands");
            cwl("-ic path1 path2");
            cwl("   -path1 : source image path");
            cwl("         -path2 : destination path");
            if (args.Length > 0)
            {
                if (args[0] == "-ic")
                {
                    cwl("Inverse color selected");
                    if (args.Length < 3)
                    {
                        cwl("[ ERROR ]>Inverse color requires source and destination file path");
                    }
                    else
                    {
                        InvertColor(args[1], args[2]);
                    }
                }
            }
            else
            {

                try
                {
                    cw("Source Path : ");
                    string? src = Console.ReadLine();
                    cw("Destination Path : ");
                    string? dest = Console.ReadLine();
                    if (string.IsNullOrEmpty(src) == false && string.IsNullOrEmpty(dest) == false)
                    {
                        InvertColor(src, dest);
                    }
                    else
                    {
                        eCwl(new Exception("Source Or Destination cant be null"));
                    }
                }
                catch (System.Exception excp)
                {
                    eCwl(excp);
                }
                finally
                {
                    cwl("press any key to exit");
                    Console.ReadKey();
                }
            }
        }
        static void eCwl(Exception excp)
        {
            ConsoleColor x = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            cwl(excp.Message);
            cwl("\n" + excp.StackTrace);
            Console.ForegroundColor = x;
        }
        static void cwl(Object msg)
        {
            System.Console.WriteLine(msg);
        }
        static void cw(Object msg)
        {
            System.Console.Write(msg);
        }
        static void InvertColor(string src, string dest)
        {
            cwl("==Invert Color==\nSource : " + src + "\n" + "Destination : " + dest);
            //System Drawing Common / .Net CLI command : dotnet add package System.Drawing.Common --version 6.0.0
            try
            {
                if (File.Exists(src) == false)
                {
                    eCwl(new Exception("File not exists in Source Path"));
                    return;
                }
                Bitmap bimp = new Bitmap(Image.FromFile(src));
                for (int i = 0; i < bimp.Height; i++)
                {
                    for (int j = 0; j < bimp.Width; j++)
                    {
                        if (bimp.GetPixel(i, j).A != 0)
                        {
                            bimp.SetPixel(i, j, Color.White);
                        }
                    }
                }
                bimp.Save(dest);
                cwl("Image might be saved to " + dest);
            }
            catch (System.Exception excp)
            {
                eCwl(excp);
            }
        }
    }
}
