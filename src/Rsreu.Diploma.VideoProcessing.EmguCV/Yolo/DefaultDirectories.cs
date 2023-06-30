using System.Reflection;

namespace Rsreu.Diploma.VideoProcessing.EmguCV.Yolo;

internal class DefaultDirectories
{
    private static readonly string _assembly = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);

    public static readonly string YoloV3Config = _assembly + "\\Yolo\\yolov3\\yolov3.cfg";
    public static readonly string YoloV3Weights = _assembly + "\\Yolo\\yolov3\\yolov3.weights";
    public static readonly string YoloV3CocoNames = _assembly + "\\Yolo\\yolov3\\coco.names";

    public static readonly string YoloV3TinyConfig = _assembly + "\\Yolo\\yolov3-tiny\\yolov3-tiny.cfg";
    public static readonly string YoloV3TinyWeights = _assembly + "\\Yolo\\yolov3-tiny\\yolov3-tiny.weights";
    public static readonly string YoloV3TinyCocoNames = _assembly + "\\Yolo\\yolov3-tiny\\coco.names";

    public static readonly string YoloV4Config = _assembly + "\\Yolo\\yolov4\\yolov4.cfg";
    public static readonly string YoloV4Weights = _assembly + "\\Yolo\\yolov4\\yolov4.weights";
    public static readonly string YoloV4CocoNames = _assembly + "\\Yolo\\yolov4\\coco.names";

    public static readonly string YoloV4TinyConfig = _assembly + "\\Yolo\\yolov4-tiny\\yolov4-tiny.cfg";
    public static readonly string YoloV4TinyWeights = _assembly + "\\Yolo\\yolov4-tiny\\yolov4-tiny.weights";
    public static readonly string YoloV4TinyCocoNames = _assembly + "\\Yolo\\yolov4-tiny\\coco.names";
}
