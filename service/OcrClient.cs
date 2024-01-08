using System.Text;
using ImageMagick;
using Tesseract;

namespace Service;

public class OcrClient
{
    public string OcrPdf(Stream pdfStream)
    {
        var stringBuilder = new StringBuilder();

        using (var magickImages = new MagickImageCollection())
        {
            magickImages.Read(pdfStream);
            foreach (var magickImage in magickImages)
            {
                // Set the resolution and format of the image (adjust as needed)
                magickImage.Density = new Density(300, 300);
                magickImage.Format = MagickFormat.Png;

                // Perform OCR on the image
                using (var tesseractEngine = new TesseractEngine("tessdata", "eng", EngineMode.Default))
                {
                    using (var page = tesseractEngine.Process(Pix.LoadFromMemory(magickImage.ToByteArray())))
                    {
                        var extractedText = page.GetText();
                        stringBuilder.Append(extractedText);
                    }
                }
            }
        }

        return stringBuilder.ToString();
    }
}
