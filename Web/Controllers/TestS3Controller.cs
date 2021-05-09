using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestS3Controller : Controller
    {
        
        [HttpPost("")]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            IAmazonS3 amazonS3 = new AmazonS3Client(
                new BasicAWSCredentials(
                    accessKey:"AKIAIGN5D76MQZE3GWCA", 
                    secretKey:"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"),
                region: RegionEndpoint.USEast1); 
            
            var putRequest = new PutObjectRequest()
            {
                BucketName = "ctiradotestbk",
                Key = file.FileName,
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType
            };
            
            var result = await amazonS3.PutObjectAsync(putRequest);
            
            return Ok(result);
        }
    }
}