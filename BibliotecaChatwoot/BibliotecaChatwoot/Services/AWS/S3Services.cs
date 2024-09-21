using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using RestSharp;

namespace BibliotecasCrediMotos.Services.AWS
{
    public enum S3_FileType
    {
        Video,
        Identificacion
    }
    public  class S3Services
    {
        private Config _confg;
        
        public S3Services()
        {
            _confg = new Config();
        }
        public async Task<string> UploadToS3(Stream stream, string key, S3_FileType fileType)
        {
            var awsCredentials = new BasicAWSCredentials(_confg.AWS_KEY, _confg.AWS_SECRET);

            var s3Config = new AmazonS3Config
            {
                RegionEndpoint = RegionEndpoint.USWest1 // Establecer la región en us-west-1
            };
            var s3Client = new AmazonS3Client(awsCredentials, s3Config);
            var transferUtility = new TransferUtility(s3Client);

            string prefix = "";
            string contentType = "";

            switch (fileType)
            {
                case S3_FileType.Video:
                    prefix = _confg.VIDEO_PREFIX;
                    contentType = "video/mp4";
                    break;
                case S3_FileType.Identificacion:
                    prefix = _confg.IDS_PREFIX;
                    contentType = "image/jpeg";
                    break;
                default:
                    break;
            };

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = stream,
                Key = prefix + key, // Asegúrate de que el prefijo se concatene correctamente
                BucketName = _confg.BUCKET_NAME,
                ContentType = contentType,
                CannedACL = S3CannedACL.AuthenticatedRead
            };

            await transferUtility.UploadAsync(uploadRequest);

            string url = $"https://{_confg.BUCKET_NAME}.s3.{s3Config.RegionEndpoint.SystemName}.amazonaws.com/{prefix}{key}";
            return url;
        }
    }
}
