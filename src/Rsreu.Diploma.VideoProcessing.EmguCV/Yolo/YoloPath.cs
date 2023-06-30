namespace Rsreu.Diploma.VideoProcessing.EmguCV.Yolo;

internal record YoloPath
{
    public string Configuration { get; set; }

    public string Weights { get; set; }

    public string CocoNames { get; set; }
}
