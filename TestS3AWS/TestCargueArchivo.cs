using System;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using NUnit.Framework;

namespace TestS3AWS  
{
    public class TestCargueArchivo
    {
        private const string bucketName = "arn:aws:s3:sa-east-1:847513621693:accesspoint/ctiradotestap";
        private const string keyName = "AKIA4KU57SS656GJJRU3";  
        private const string filePath = @"C:\IMG-20201207-WA0041.jpeg"; 
        
        // Specify your bucket region (an example region is shown).
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.SAEast1;
        private static IAmazonS3 s3Client;

        [Test]
        public void Main()
        {
            s3Client = new AmazonS3Client(bucketRegion);
            UploadFileAsync().Wait();
        }

        private static async Task UploadFileAsync()
        {
            try
            {
                var fileTransferUtility =
                    new TransferUtility(s3Client);

                // Option 2. Specify object key name explicitly.
                await fileTransferUtility.UploadAsync(filePath, bucketName,keyName);
                Console.WriteLine("Upload 2 completed");


                

            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }

        }
    }
}