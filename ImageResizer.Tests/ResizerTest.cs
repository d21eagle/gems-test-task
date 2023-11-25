using System.Drawing;

namespace imageResizer.Tests;

public class ResizerTest
{
    private readonly Resizer _imageResizer = new Resizer();
    
    [Theory]
    [InlineData(1920,1080, 1280, 720)]
    public void ResizeImage_LargeWindowAndEqualRatio(int windowWidth, int windowHeight, int imageWidth, int imageHeight)
    {
        //Arrange.
        var expectedSize = new Size(1920, 1080);
        
        //Act.
        var newSize = _imageResizer.ResizeImage(windowWidth, windowHeight, imageWidth, imageHeight);

        //Assert.
        Assert.Equal(expectedSize.Width, newSize.Width);
        Assert.Equal(expectedSize.Height, newSize.Height);
    }
    
    [Theory]
    [InlineData(1280,720, 1920, 1080)]
    public void ResizeImage_LargeImageAndEqualRatio(int windowWidth, int windowHeight, int imageWidth, int imageHeight)
    {
        //Arrange.
        var expectedSize = new Size(1280, 720);
        
        //Act.
        var newSize = _imageResizer.ResizeImage(windowWidth, windowHeight, imageWidth, imageHeight);

        //Assert.
        Assert.Equal(expectedSize.Width, newSize.Width);
        Assert.Equal(expectedSize.Height, newSize.Height);
    }
    
    [Theory]
    [InlineData(1920,1080, 800, 600)]
    public void ResizeImage_LargeWindowAndUnequalRatio(int windowWidth, int windowHeight, int imageWidth, int imageHeight)
    {
        //Arrange.
        var expectedSize = new Size(1440, 1080);
        
        //Act.
        var newSize = _imageResizer.ResizeImage(windowWidth, windowHeight, imageWidth, imageHeight);

        //Assert.
        Assert.Equal(expectedSize.Width, newSize.Width);
        Assert.Equal(expectedSize.Height, newSize.Height);
    }
    
    [Theory]
    [InlineData(800,600, 1920, 1080)]
    public void ResizeImage_LargeImageAndUnequalRatio(int windowWidth, int windowHeight, int imageWidth, int imageHeight)
    {
        //Arrange.
        var expectedSize = new Size(800, 450);
        
        //Act.
        var newSize = _imageResizer.ResizeImage(windowWidth, windowHeight, imageWidth, imageHeight);

        //Assert.
        Assert.Equal(expectedSize.Width, newSize.Width);
        Assert.Equal(expectedSize.Height, newSize.Height);
    }
    
    [Theory]
    [InlineData(1280,720, 1280, 720)]
    public void ResizeImage_EqualSizes(int windowWidth, int windowHeight, int imageWidth, int imageHeight)
    {
        //Arrange.
        var expectedSize = new Size(1280, 720);
        
        //Act.
        var newSize = _imageResizer.ResizeImage(windowWidth, windowHeight, imageWidth, imageHeight);

        //Assert.
        Assert.Equal(expectedSize.Width, newSize.Width);
        Assert.Equal(expectedSize.Height, newSize.Height);
    }
    
    [Theory]
    [InlineData(-1920,-1080, 0, 0)]
    public void ResizeImage_NegativeOrZeroSizes(int windowWidth, int windowHeight, int imageWidth, int imageHeight)
    {
        //Act + Assert.
        Assert.Throws<ArgumentException>(() => _imageResizer.ResizeImage(windowWidth, windowHeight, imageWidth, imageHeight));
    }
}