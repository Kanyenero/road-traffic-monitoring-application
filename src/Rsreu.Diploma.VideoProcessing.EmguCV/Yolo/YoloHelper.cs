using Emgu.CV.Dnn;
using Emgu.CV.Util;
using Rsreu.Diploma.Extensions;
using Rsreu.Diploma.VideoProcessing.Models;
using System.Drawing;

namespace Rsreu.Diploma.VideoProcessing.EmguCV.Yolo;

internal static class YoloHelper
{
    public static YoloResult GetYoloResult(VectorOfMat source, float scoreThreshold, float nmsThreshold, Size frameSize)
    {
        var bboxes = new List<Rectangle>();
        var scores = new List<float>();
        var indices = new List<int>();

        for (int matIndex = 0; matIndex < source.Size; matIndex++)
        {
            var blob = source[matIndex];
            var data = blob.GetData() as float[,];
            var rows = data.GetLength(0);

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                var row = data.GetRow(rowIndex);
                var rowScores = row.Skip(5).ToList();
                var classIndex = rowScores.IndexOf(rowScores.Max());
                var score = rowScores[classIndex];

                if (score > scoreThreshold)
                {
                    var center_x = (int)(row[0] * frameSize.Width);
                    var center_y = (int)(row[1] * frameSize.Height);

                    var width = (int)(row[2] * frameSize.Width);
                    var height = (int)(row[3] * frameSize.Height);

                    var x = center_x - width / 2;
                    var y = center_y - height / 2;

                    bboxes.Add(new Rectangle(x, y, width, height));
                    scores.Add(score);
                    indices.Add(classIndex);
                }
            }
        }

        var bboxArray = bboxes.ToArray();
        var scoreArray = scores.ToArray();
        var indexArray = indices.ToArray();

        var thresholdedIndicesArray = DnnInvoke.NMSBoxes(bboxArray, scoreArray, scoreThreshold, nmsThreshold);

        return new YoloResult
        {
            BoundingBoxes = bboxArray,
            Scores = scoreArray,
            ClassIndicies = indexArray,
            ThresholdedBoundingBoxIndices = thresholdedIndicesArray
        };
    }

    public static IEnumerable<Detection> GetDetections(YoloResult yoloResult, string[] classNames, int[] allowedClassIndexes)
    {
        foreach (var bboxIndex in yoloResult.ThresholdedBoundingBoxIndices)
        {
            var classId = yoloResult.ClassIndicies[bboxIndex];
            var classIdAllowed = allowedClassIndexes.Contains(classId);
            if (classIdAllowed)
            {
                var boundingBox = yoloResult.BoundingBoxes[bboxIndex];
                var className = classNames[classId];
                var score = yoloResult.Scores[bboxIndex];

                yield return new Detection()
                {
                    BoundingBox = boundingBox,
                    ClassName = className,
                    Score = score
                };
            }
        }
    }
}

