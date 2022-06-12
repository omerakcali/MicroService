using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace MicroService{
    public class ImagePredictor{

        public static string PredictImage(Bitmap image){
            Tensor<float> input = new DenseTensor<float> (new [] { 1,150, 150,3 });
            for (int y = 0; y < 150; y++)
            {
                for (int x = 0; x < 150; x++){
                    input[0,y, x, 0] = image.GetPixel(x, y).R;
                    input[0,y, x, 1] = image.GetPixel(x, y).G;
                    input[0,y, x, 2] = image.GetPixel(x, y).B;
                }
            }
            
            
            var inputs = new List<NamedOnnxValue> {
                NamedOnnxValue.CreateFromTensor("input", input)
            };

            using var session = new InferenceSession( Path.Combine(Directory.GetCurrentDirectory(),"Model","model_son.onnx"));
            var run =session.Run(inputs);

            foreach (var i in run.First().AsTensor<float>().ToArray()){
                Console.WriteLine(i);
            }

            var array = run.First().AsTensor<float>().ToArray();
            int index = 0;
            for (int i = 0; i < array.Length; i++){
                if (array[i] > array[index]) index = i;
            }
            var labels = System.IO.File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(),"Model", "labels.txt"));
            return labels.ToList()[index];
        }
        
    }
}