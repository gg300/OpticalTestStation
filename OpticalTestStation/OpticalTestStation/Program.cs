using System.Text.Json;

string configJson = File.ReadAllText("config.json");
var config = JsonSerializer.Deserialize<TestConfig>(configJson, new JsonSerializerOptions { IncludeFields = true});
if (config == null)
{
    throw new InvalidOperationException("Config is null");
}

Console.WriteLine($"Starting test sequence for {config.ProductId}\n\n");

//initialising the testing tools
var powerMeter = new MockPowerMeter();
var osa = new MockOSA();
var tls = new MockTLS();

// build the list of testing steps
var limits = config.Limits;
var steps = new List<ITestStep>
{
    new PowerTest(powerMeter,limits),
    new WavelengthTest(osa,limits),
    new OsnrTest(osa,limits),
    new BiasCurrentTest(tls,limits)
};

var sequencer = new TestSequencer(steps);
var results = sequencer.TestAll();

int pass_count = results.Count(result => result.Status == "Passed");
string sequenceStatus = results.Any(result => result.Status == "Failed")?"Failed":"Passed";
Console.WriteLine($"Result: {sequenceStatus} | {pass_count}/{results.Count} passed\n");

string fileName = TestReport.Save(config.ProductId,results);
Console.WriteLine($"Report saved: {fileName}");