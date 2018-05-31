[HttpPost]
[Route("UploadImagem")]
public async Task<HttpResponseMessage> PostUserImage()
{
    Dictionary<string, object> dict = new Dictionary<string, object>();
    var httpRequest = HttpContext.Current.Request;
    string nomeArquivo;
    foreach (string file in httpRequest.Files)
    {
        var postedFile = httpRequest.Files[file];
        //postedFile.InputStream.Read()

        var strReader = new System.IO.StreamReader(postedFile.InputStream);

        //var strWriter = new System.IO.StreamWriter(postedFile.InputStream);
        using (StreamReader readStream = new StreamReader(postedFile.InputStream, Encoding.UTF8))
        {
            var documentContents = readStream.ReadToEnd();
            File.WriteAllText(@"C:\data\teste.pdf", documentContents);
        }

        nomeArquivo = postedFile.FileName;
    }
    return Request.CreateResponse(HttpStatusCode.NotFound);
}