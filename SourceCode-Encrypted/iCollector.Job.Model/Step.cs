using System;

namespace iCollector.Job.Model;

internal class Step
{
	public int Index { get; set; }

	public string Name { get; set; }

	public StepStatus Status { get; set; }

	public StepType Type { get; set; }

	public bool StopWhenSuccess { get; set; }

	public bool StopWhenFailed { get; set; }

	public object Spec { get; set; }

	public Func<string, StepResult> CheckResultFunc { get; set; }

	public StepResult StepResult { get; set; }
}
