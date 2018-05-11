using System.IO;
using ImageResizer;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace IntelliTect.Functions.Thumbnailer
{
    public static class ThumbnailerFunction
    {
        private const int Size = 200;
        private const int Quality = 75;

        [FunctionName(nameof(Run))]
        public static void Run(
            [QueueTrigger("thumbnailer-items")] string queueItem,
            [Blob("large-image-queue/{queueTrigger}", FileAccess.Read)]
            Stream largeImageStream,

            [Blob("thumbnail-result/{queueTrigger}", FileAccess.Write)]
            Stream imageSmall,

            TraceWriter log)
        {
            log.Info($"Thumbnailer function received blob\n Name:{queueItem} \n Size: {largeImageStream.Length} Bytes");

            var settings = new ResizeSettings
            {
                MaxWidth = Size,
                MaxHeight = Size,
                Quality = Quality,
                Format = "jpg"
            };

            ImageBuilder.Current.Build(largeImageStream, imageSmall, settings);
            log.Info($"Hello from the SUG meeting item: {queueItem}");

            log.Info($"Thumbnail encoded to thumbnail-result/{queueItem} with quality: {Quality}");
        }
    }
}