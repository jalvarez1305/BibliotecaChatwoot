using System;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace BibliotecaChatwoot.Services.AWS
{
    public class S3Manager
    {
        private readonly AmazonS3Client _s3Client;
        private readonly string _bucketName = "papanicolaous";
        RegionEndpoint region = RegionEndpoint.USEast2;
        Config config;
        public S3Manager()
        {
            config = new Config();
            var awsCredentials = new BasicAWSCredentials(config.AK, config.Sec);
            _s3Client = new AmazonS3Client(awsCredentials, region);
        }
        /// <summary>
        /// Sube un archivo a S3 y devuelve la URL prefirmada y el ARN del objeto.
        /// </summary>
        public async Task<(string PresignedUrl, string ObjectArn)> UploadObject(string objectKey, byte[] fileData)
        {
            try
            {
                using (var stream = new MemoryStream(fileData))
                {
                    var putRequest = new PutObjectRequest
                    {
                        BucketName = _bucketName,
                        Key = objectKey,
                        InputStream = stream,
                        ContentType = "application/octet-stream"
                    };

                    await _s3Client.PutObjectAsync(putRequest);

                    // Obtener URL prefirmada
                    string presignedUrl = GeneratePresignedUrl(objectKey);

                    // Generar ARN del objeto
                    string objectArn = $"arn:aws:s3:::{_bucketName}/{objectKey}";

                    return (presignedUrl, objectArn);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al subir archivo: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Genera una URL prefirmada para acceder al objeto.
        /// </summary>
        private string GeneratePresignedUrl(string objectKey)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _bucketName,
                Key = objectKey,
                Expires = DateTime.UtcNow.AddDays(6), // Expira en 1 hora
                Verb = HttpVerb.GET
            };

            return _s3Client.GetPreSignedURL(request);
        }
    }
}
