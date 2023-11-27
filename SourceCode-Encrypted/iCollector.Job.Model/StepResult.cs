namespace iCollector.Job.Model;

internal class StepResult
{
	public bool Success { get; set; }

	public object Data { get; set; }

	public static StepResult Of(bool success, object data)
	{
		StepResult obj = new StepResult
		{
			Success = success
		};
		if (0 == 0 && 8u != 0)
		{
			obj.Data = data;
		}
		return obj;
	}

	public static StepResult Of(bool success)
	{
		StepResult stepResult = new StepResult();
		if (2u != 0 && 0 == 0)
		{
			stepResult.Success = success;
		}
		return stepResult;
	}
}
