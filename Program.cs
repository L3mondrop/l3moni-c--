var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Urls.Add("http://*:3000");

app.MapGet("/", () => "To run a CMD, try /runcmd!");

app.MapGet("/runcmd", () =>
{
    System.Diagnostics.Process process = new System.Diagnostics.Process();
    process.StartInfo.FileName = "./test";
    process.StartInfo.RedirectStandardOutput = true;
    process.Start();
    process.WaitForExit();
    return "Output: "+process.StandardOutput.ReadToEnd();
    //Console.WriteLine(process.StandardOutput.ReadToEnd());
});
app.Run();
    