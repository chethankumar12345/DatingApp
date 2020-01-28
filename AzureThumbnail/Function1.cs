using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace AzureThumbnail
{
    public static class Function1
    {

        [FunctionName("Function1")]
        public static void Run(
            [BlobTrigger("datinguploads/{name}", Connection = "StorageConnection")]Stream image,
            [Blob("datingthumbnail/{name}", FileAccess.Write, Connection = "StorageConnection")]Stream imageSmall,
            ILogger log)
        {
            using (Image<Rgba32> thumbNail = Image.Load(image))
            {
                thumbNail.Mutate(x => x
                    .Resize(new ResizeOptions
                    {
                        Mode = ResizeMode.BoxPad,
                        Size = new SixLabors.Primitives.Size(100, 100)
                    }).BackgroundColor(new Rgba32(0, 0, 0)));

                thumbNail.Save(imageSmall, new PngEncoder());

                log.LogInformation("Thumbnail uploaded successfully.");
            }
        }

    }
}
