using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace MicroService.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase{

        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger){
            _logger = logger;
        }

        [HttpPost("image"), DisableRequestSizeLimit]
        public async Task<string> GetPrediction([FromForm] IFormFile image){
            using (var stream = new MemoryStream()){
                await image.CopyToAsync(stream);
                Bitmap bmp = new Bitmap(stream);

                var newB = new Bitmap(150, 150, PixelFormat.Format24bppRgb);
                using (Graphics gr = Graphics.FromImage(newB)){
                    gr.DrawImage(bmp, new Rectangle(0, 0, newB.Width, newB.Height));
                }

                bmp = newB;

                var result = ImagePredictor.PredictImage(bmp);


                return await Task.FromResult(result);
            }
        }
    }
}