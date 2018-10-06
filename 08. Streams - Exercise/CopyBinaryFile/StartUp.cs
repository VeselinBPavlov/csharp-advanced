namespace CopyBinaryFile
{
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            var path = "../_Resources/";
            var file = "copyMe.png";
            var resultFile = "result.png";

            path = Path.Combine(path, file);

            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                var bytes = new byte[4096];

                using (var destination = new FileStream(resultFile, FileMode.Create))
                {
                    var read = stream.Read(bytes, 0, bytes.Length);

                    while (read != 0)
                    {                        
                        destination.Write(bytes, 0, read);
                        read = stream.Read(bytes, 0, bytes.Length);
                    }
                }
            }
        }
    }
}
