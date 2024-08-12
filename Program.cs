using System.Drawing;
using System.Text;

char[] asciiChars = { '@', '#', 'S', '%', '?', '*', '+', ';', ':', ',', '.' };

string imagePath = @"your_image_path.jpg";
var image = new Bitmap(imagePath);
var newWidth = 256; //you can change it :)
image = ResizeImage(image, newWidth);
var asciiArt = ConvertToAscii(image);

Console.WriteLine(asciiArt);

string ConvertToAscii(Bitmap image)
{
    if (image is null)
    {
        Console.WriteLine("Image is null.");
    }

    var asciiArt = new StringBuilder();

    for (int h = 0; h < image.Height; h++)
    {
        for (int w = 0; w < image.Width; w++)
        {
            Color pixelColor = image.GetPixel(w, h);
            int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
            int asciiIndex = grayValue * (asciiChars.Length - 1) / 255;
            asciiArt.Append(asciiChars[asciiIndex]);
        }
        asciiArt.Append(Environment.NewLine);
    }

    return asciiArt.ToString();
}

Bitmap ResizeImage(Bitmap image, int newWidth)
{
    int originalWidth = image.Width;
    int originalHeight = image.Height;

    double aspectRatio = (double)originalHeight / originalWidth;
    var newHeight = (int)(newWidth * aspectRatio);

    return new Bitmap(image, new Size(newWidth, newHeight));
}