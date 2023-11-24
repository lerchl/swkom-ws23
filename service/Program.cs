namespace service;

public class Program {

	public static void Main(String[] args) {
		var client = new OcrClient();
		Console.WriteLine(client.OcrPdf(File.OpenRead("sample.pdf")));
	}
}
