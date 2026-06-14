using System.Text;

public class TestReport
{
	public static string Save(string productId, List<TestResult> results) // saving as CSV by default
	{
		var sb = new StringBuilder();
		sb.AppendLine("Time,TestName,MeasuredValue,Unit,MinLimit,MaxLimit,Status");
		foreach(TestResult result in results) {
			sb.AppendLine($"{result.Time},{result.TestName},{result.MeasuredValue},{result.Unit},{result.MinLimit},{result.MaxLimit},{result.Status}");
		}
		string fileName = $"results_{productId}_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
		File.WriteAllText(fileName, sb.ToString());
		return fileName ;
    }
}

