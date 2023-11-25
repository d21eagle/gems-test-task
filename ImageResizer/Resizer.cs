using System.Drawing;

namespace imageResizer;

public class Resizer
{
    public Size ResizeImage(int windowWidth, int windowHeight, int imageWidth, int imageHeight)
    {
        ValidateSizes(windowWidth, windowHeight, imageWidth, imageHeight);
        
        var imageRatio = (double)imageWidth / imageHeight;
        int newWidth, newHeight;
        
        if (windowWidth / imageRatio <= windowHeight)
        {
            newWidth = windowWidth;
            newHeight = (int)Math.Round(newWidth / imageRatio);
        }
        else
        {
            newHeight = windowHeight;
            newWidth = (int)Math.Round(newHeight * imageRatio);
        }
        
        return new Size(newWidth, newHeight);
    }

    private void ValidateSizes(int windowWidth, int windowHeight, int imageWidth, int imageHeight)
    {
        if (windowWidth <= 0 || windowHeight <= 0 || imageWidth <= 0 || imageHeight <= 0)
            throw new ArgumentException("Sizes are negative or zero");
    }
}